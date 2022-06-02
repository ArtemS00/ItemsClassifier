using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ItemsClassifier
{
    public partial class SetCategoryModal : Form
    {
        private Action<(ListItem, ListItem)> _onSave;

        public SetCategoryModal(Action<(ListItem, ListItem)> onSave, List<ListItem> supplierCategories, List<ListItem> shopCategories)
        {
            _onSave = onSave;
            InitializeComponent();
            supplierCategoryComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            supplierCategoryComboBox.DisplayMember = "Name";
            supplierCategoryComboBox.Items.AddRange(supplierCategories.ToArray());
            shopCategoryComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            shopCategoryComboBox.DisplayMember = "Name";
            shopCategoryComboBox.Items.AddRange(shopCategories.ToArray());
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (shopCategoryComboBox.SelectedItem == null || supplierCategoryComboBox.SelectedItem == null)
            {
                MessageBox.Show("Поля не заполнены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _onSave.Invoke(((ListItem)shopCategoryComboBox.SelectedItem, (ListItem)supplierCategoryComboBox.SelectedItem));
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
