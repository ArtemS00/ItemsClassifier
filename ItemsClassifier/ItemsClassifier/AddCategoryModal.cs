using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ItemsClassifier
{
    public partial class AddCategoryModal : Form
    {
        private Action<ListItem> _onSave;
        private List<ListItem> _categories;

        public AddCategoryModal(Action<ListItem> onSave, List<ListItem> categories)
        {
            _onSave = onSave;
            _categories = categories;
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(categoryIDTextBox.Text, out var result))
            {
                MessageBox.Show("ID категории невалиден", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_categories.Any(c => c.ID == int.Parse(categoryIDTextBox.Text)))
            {
                MessageBox.Show($"Категория с таким ID уже существует ({_categories.Find(c => c.ID == int.Parse(categoryIDTextBox.Text)).Name})", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _onSave.Invoke(new ListItem(int.Parse(categoryIDTextBox.Text), categoryNameTextBox.Text));
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
