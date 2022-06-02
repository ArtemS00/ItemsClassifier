using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ItemsClassifier
{
    public partial class ItemsClassificationModal : Form
    {
        private PostClassificationSettings _settings { get; set; } 
        private List<ListItem> _categories { get; set; }
        private List<ListItem> _supplierCategories { get; set; }
        private readonly MainService _mainService = new MainService();

        public ItemsClassificationModal()
        {
            InitializeComponent();
            dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            selectFileButton.Click += selectFileButton_Click;
            distributeItemsButton.Click += distributeButton_Click;
            classificationTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            classificationTypeComboBox.Items.Insert((int)ClassificationType.Individual, "Индивидаульно");
            classificationTypeComboBox.Items.Insert((int)ClassificationType.Group, "По категориям");
            classificationTypeComboBox.Items.Insert((int)ClassificationType.GroupWithDescription, "По категориям учитывая описание");
            classificationTypeComboBox.SelectedIndexChanged += classificationTypeComboBox_SelectedIndexChanged;

            behaviorTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            behaviorTypeComboBox.Items.Insert((int)CategoriesConflictBehaviorType.ChooseMax, "Выбрать с наибольшим числом совпадений");
            behaviorTypeComboBox.Items.Insert((int)CategoriesConflictBehaviorType.DistributeIndividually, "Распределить индивидаульно");
            behaviorTypeComboBox.SelectedIndexChanged += behaviorTypeComboBox_SelectedIndexChanged;

            criticalValueTextBox.KeyPress += criticalValueTextBox_KeyPress;

            this.InitProperties();
            this.SetPanelsVisibility(true);
            this.cancelButton.Click += CancelButton_Click;
            this.addCategoryButton.Click += AddCategoryButton_Click;
            this.setCategoryButton.Click += SetCategoryButton_Click;
            this.saveButton.Click += SaveButton_Click;
            this.textBox1.TextChanged += Search_TextChanged;
        }

        private void Search_TextChanged(object sender, EventArgs e)
        {
            CurrencyManager currencyManager = (CurrencyManager)BindingContext[dataGrid.DataSource];
            currencyManager.SuspendBinding();
            for (int i = 0; i < dataGrid.Rows.Count; i++)
            {
                dataGrid.Rows[i].Visible = string.IsNullOrEmpty(textBox1.Text) || dataGrid.Rows[i].Cells["Название Товара"].Value.ToString().ToLower().Contains(textBox1.Text.ToLower());
            }
            currencyManager.ResumeBinding();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV Files|*.csv;*.txt";
                DialogResult result = sfd.ShowDialog();
                if (result != DialogResult.OK)
                    return;
                if (string.IsNullOrEmpty(sfd.FileName))
                    return;

                var fileContent = GetDataGridCsv();
                File.WriteAllText(sfd.FileName, fileContent);
            }
            Close();
        }

        private string GetDataGridCsv()
        {
            StringBuilder csv = new StringBuilder();
            csv.AppendLine("ItemID|ItemName|CategoryID|CategoryName|PredictCategoryID|PredictCategoryName");
            for (int i = 0; i < dataGrid.Rows.Count; i++)
            {
                csv.AppendLine($"{dataGrid.Rows[i].Cells["ID Товара"].Value}|" +
                    $"{dataGrid.Rows[i].Cells["Название Товара"].Value}|" +
                    $"{dataGrid.Rows[i].Cells["CategoryID"].Value}|" +
                    $"{dataGrid.Rows[i].Cells["Категория Магазина"].Value}|" +
                    $"{dataGrid.Rows[i].Cells["Предсказанная Категория"].Value}|" +
                    $"{_categories.Find(c => c.ID == (int)dataGrid.Rows[i].Cells["Предсказанная Категория"].Value).Name}");
            }
            return csv.ToString();
        }

        private void SetCategoryButton_Click(object sender, EventArgs e)
        {
            _mainService.OpenSetCategoryModal(
                new Action<(ListItem, ListItem)>((categories) => SetShopCategoryForSupplierCategory(categories.Item1, categories.Item2)),
                _supplierCategories,
                _categories);
        }

        private void SetShopCategoryForSupplierCategory(ListItem shopCategory, ListItem supplierCategory)
        {
            for (int i = 0; i < dataGrid.Rows.Count; i++)
            {
                if (dataGrid.Rows[i].Cells["CategoryID"].Value.ToString() == supplierCategory.ID.ToString())
                    dataGrid.Rows[i].Cells["Предсказанная Категория"].Value = shopCategory.ID;
            }
        }

        private void AddCategoryButton_Click(object sender, EventArgs e)
        {
            _mainService.OpenAddCategoryModal(new Action<ListItem>((category) => AddCategory(category)), this._categories);
        }

        private void AddCategory(ListItem category)
        {
            _categories.Add(category);
            ((DataGridViewComboBoxColumn)dataGrid.Columns["Предсказанная Категория"]).Items.Add(category);
        }

        private void InitProperties()
        {
            _categories = null;
            _settings = new PostClassificationSettings();
            classificationTypeComboBox.SelectedIndex = (int)_settings.ClassificationType;
            behaviorTypeComboBox.SelectedIndex = (int)_settings.ConflictBehavior;
            criticalValueTextBox.Text = _settings.CriticalValue.ToString();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.InitProperties();
            this.SetPanelsVisibility(true);
            this.dataGrid.DataSource = null;
            this.dataGrid.Rows.Clear();
            this.dataGrid.Columns.Clear();
        }

        private void ParseSettingsControls()
        {
            _settings.ClassificationType = (ClassificationType)classificationTypeComboBox.SelectedIndex;
            _settings.ConflictBehavior  = (CategoriesConflictBehaviorType)behaviorTypeComboBox.SelectedIndex;
            _settings.CriticalValue = double.Parse(criticalValueTextBox.Text);

        }

        private void SetPanelsVisibility(bool isMainPanelVisible)
        {
            this.panel1.Visible = isMainPanelVisible;
            this.panel2.Visible = !isMainPanelVisible;
        }

        private void distributeButton_Click(object sender, EventArgs e)
        {
            ParseSettingsControls();
            var table = ConvertCSVtoDataTable(csvFilePathLabel.Text, separatorTextBox.Text);
            var hasDescription = table.Columns.Contains("PredictByDescriptionCategoryID");
            var items = table.Select()
                .Select(row =>
                    new ItemModel()
                    {
                        ItemID = int.Parse(row.Field<string>("ItemID")),
                        ItemName = row.Field<string>("ItemName"),
                        CategoryID = int.Parse(row.Field<string>("CategoryID")),
                        CategoryName = row.Field<string>("CategoryName"),
                        PredictCategory = new ListItem(int.Parse(row.Field<string>("PredictCategoryID")),  row.Field<string>("PredictCategoryName")),
                        PredictCategoryByDescription = !hasDescription || int.Parse(row.Field<string>("PredictByDescriptionCategoryID")) == -1 ? null :
                            new ListItem(int.Parse(row.Field<string>("PredictByDescriptionCategoryID")), row.Field<string>("PredictByDescriptionCategoryName"))
                    }).ToList();

            var predictCategories = items.GroupBy(i => i.PredictCategory.ID).ToDictionary(g => g.Key, g => g.First().PredictCategory.Name);
            if (_settings.ClassificationType == ClassificationType.Group || _settings.ClassificationType == ClassificationType.GroupWithDescription)
            {
                items.GroupBy(i => i.CategoryID).ToList().ForEach(g =>
                {
                    var groupItems = g.ToList();
                    var predictions = new Dictionary<int, double>();
                    groupItems.ForEach(i =>
                    {
                        if (!predictions.ContainsKey(i.PredictCategory.ID))
                            predictions.Add(i.PredictCategory.ID, 0);
                        predictions[i.PredictCategory.ID] += 1;

                        if (_settings.ClassificationType == ClassificationType.GroupWithDescription && i.PredictCategoryByDescription != null)
                        {
                            if (!predictions.ContainsKey(i.PredictCategoryByDescription.ID))
                                predictions.Add(i.PredictCategoryByDescription.ID, 0);
                            predictions[i.PredictCategoryByDescription.ID] += 0.3;
                        }
                    });
                    var totalScore = predictions.Sum(p => p.Value);
                    var groupPredictions = predictions
                        .Select(p => (p.Key, Value: p.Value / totalScore))
                        .OrderByDescending(p => p.Item2)
                        .ToList();

                    if (predictions.Count >= 2)
                    {
                        var firstCategory = groupPredictions.First().Value;
                        if (_settings.ConflictBehavior == CategoriesConflictBehaviorType.ChooseMax || firstCategory > _settings.CriticalValue)
                        {
                            groupItems.ForEach(j => {
                                if (_settings.ClassificationType == ClassificationType.Group || j.PredictCategory.ID != j.PredictCategoryByDescription?.ID)
                                    j.PredictCategory.ID = groupPredictions.First().Key;
                            });
                        }
                    }
                });
                items.ForEach(i => i.PredictCategory.Name = predictCategories[i.PredictCategory.ID]);
            }
            _categories = items
                .GroupBy(s => s.PredictCategory.ID)
                .Select(g => g.First().PredictCategory)
                .ToList();
            _supplierCategories = items
                .GroupBy(s => s.CategoryID)
                .Select(g => g.ToList())
                .Select(g => new ListItem(g.First().CategoryID, g.First().CategoryName))
                .ToList();
            SetDataGridSource(items);
            SetPanelsVisibility(false);
        }

        private void SetDataGridSource(List<ItemModel> source)
        {
            dataGrid.DataSource = source;
            dataGrid.Columns.Remove("PredictCategory");
            dataGrid.Columns.Remove("PredictCategoryByDescription");
            dataGrid.Columns["CategoryID"].Visible = false;
            dataGrid.Columns["CategoryName"].ReadOnly = true;
            dataGrid.Columns["CategoryName"].Name = "Категория Магазина";
            //dataGrid.Columns["Description"].ReadOnly = true;
            //dataGrid.Columns["Description"].Name = "Описание";
            dataGrid.Columns["ItemID"].ReadOnly = true;
            dataGrid.Columns["ItemID"].Name = "ID Товара";
            dataGrid.Columns["ItemName"].ReadOnly = true;
            dataGrid.Columns["ItemName"].Name = "Название Товара";
            var predictedCategory = new DataGridViewComboBoxColumn()
            {
                DisplayMember = "Name",
                Name = "Предсказанная Категория",
                ValueType = typeof(int),
                ValueMember = "ID"
            };
            predictedCategory.Items.AddRange(_categories.ToArray());
            dataGrid.Columns.Add(predictedCategory);
            for (int i = 0; i < dataGrid.Rows.Count; i++)
            {
                dataGrid.Rows[i].Cells["Предсказанная Категория"].Value = source[i].PredictCategory.ID;
            }
        }

        private void criticalValueTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void behaviorTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (behaviorTypeComboBox.SelectedIndex == (int)CategoriesConflictBehaviorType.ChooseMax)
            {
                settingsGroupBox.Height = 70;
                criticalValueLabel.Visible = false;
                criticalValueTextBox.Visible = false;
            }
            if (behaviorTypeComboBox.SelectedIndex == (int)CategoriesConflictBehaviorType.DistributeIndividually)
            {
                settingsGroupBox.Height = 140;
                criticalValueLabel.Visible = true;
                criticalValueTextBox.Visible = true;
            }
        }

        private void classificationTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (classificationTypeComboBox.SelectedIndex == (int)ClassificationType.Individual)
                settingsGroupBox.Visible = false;
            if (classificationTypeComboBox.SelectedIndex == (int)ClassificationType.Group || classificationTypeComboBox.SelectedIndex == (int)ClassificationType.GroupWithDescription)
                settingsGroupBox.Visible = true;
        }

        private void selectFileButton_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "CSV Files|*.csv;*.txt";
                DialogResult result = ofd.ShowDialog();
                if (result != DialogResult.OK)
                    return;
                if (string.IsNullOrEmpty(ofd.FileName))
                    return;

                csvFilePathLabel.Text = ofd.FileName;
            }
        }

        private DataTable ConvertCSVtoDataTable(string strFilePath, string sep)
        {
            DataTable dt = new DataTable();
            using (StreamReader sr = new StreamReader(strFilePath))
            {
                string[] headers = sr.ReadLine().Split(sep);
                foreach (string header in headers)
                {
                    dt.Columns.Add(header);
                }
                while (!sr.EndOfStream)
                {
                    string[] rows = sr.ReadLine().Split(sep);
                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < headers.Length; i++)
                    {
                        dr[i] = rows[i];
                    }
                    dt.Rows.Add(dr);
                }
            }

            return dt;
        }
    }
}
