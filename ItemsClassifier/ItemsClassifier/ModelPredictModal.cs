using System;
using System.Windows.Forms;

namespace ItemsClassifier
{
    public partial class ModelPredictModal : Form
    {
        EventHandler<PredictModel> onSave { get; }
        string csvFilePath { get; set; }
        string modelPath { get; set; }
        string outputPath { get; set; }

        public ModelPredictModal(EventHandler<PredictModel> onSave, string modelPath = null)
        {
            InitializeComponent();
            this.onSave = onSave;
            if (modelPath != null)
            {
                this.modelPath = modelPath;
                this.modelPathLabel.Text = modelPath;
            }
        }

        private void predictButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(csvFilePath))
            {
                MessageBox.Show("Выберете файл формата csv", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(modelPath))
            {
                MessageBox.Show("Установите путь к модели", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(outputPath))
            {
                MessageBox.Show("Установите путь к для сохранения результата", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(separatorTextBox.Text))
            {
                MessageBox.Show("Введите разделитель csv файла", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                onSave.Invoke(this, new PredictModel(csvFilePath, modelPath, outputPath, separatorTextBox.Text));
                Close();
            }
            catch
            {
                MessageBox.Show("Возникла непредвиденная ошибка, попробуйте еще раз.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void selectCsvFile_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "CSV Files|*.csv;*.txt";
                DialogResult result = ofd.ShowDialog();
                if (result != DialogResult.OK)
                    return;
                if (string.IsNullOrEmpty(ofd.FileName))
                    return;

                csvFilePath = ofd.FileName;
                csvFilePathLabel.Text = csvFilePath;
            }
        }

        private void selectOutputPath_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV File|*.csv";
                DialogResult result = sfd.ShowDialog();
                if (result != DialogResult.OK)
                    return;
                if (string.IsNullOrEmpty(sfd.FileName))
                    return;

                outputPath = sfd.FileName;
                outputPathLabel.Text = sfd.FileName;
            }
        }

        private void selectModelPath_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Pickle file|*.pkl";
                DialogResult result = ofd.ShowDialog();
                if (result != DialogResult.OK)
                    return;
                if (string.IsNullOrEmpty(ofd.FileName))
                    return;

                modelPath = ofd.FileName;
                modelPathLabel.Text = ofd.FileName;
            }
        }
    }
}
