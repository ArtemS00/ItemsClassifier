using System;
using System.Windows.Forms;

namespace ItemsClassifier
{
    public partial class ModelLearnModal : Form
    {
        EventHandler<LearnModel> onSave { get; }
        string csvFilePath { get; set; }
        string modelPath { get; set; }

        public ModelLearnModal(EventHandler<LearnModel> onSave)
        {
            InitializeComponent();
            this.onSave = onSave;
        }

        private void learnButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(csvFilePath))
            {
                MessageBox.Show("Выберете файл формата csv", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(modelPath))
            {
                MessageBox.Show("Установите путь для сохранения модели", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(separatorTextBox.Text))
            {
                MessageBox.Show("Введите разделитель csv файла", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                onSave.Invoke(this, new LearnModel(csvFilePath, modelPath, separatorTextBox.Text, useDescriptionCheckBox.Checked));
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

        private void selectModelPath_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "Pickle file|*.pkl";
                DialogResult result = sfd.ShowDialog();
                if (result != DialogResult.OK)
                    return;
                if (string.IsNullOrEmpty(sfd.FileName))
                    return;

                modelPath = sfd.FileName;
                saveModelPathLabel.Text = sfd.FileName;
            }
        }
    }
}
