using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace ItemsClassifier
{
    public class MainService
    {
        public void OpenLearnModal(EventHandler<LearnModel> eventHandler)
        {
            var modal = new ModelLearnModal(eventHandler);
            modal.Text = "Обучение модели";
            modal.StartPosition = FormStartPosition.CenterScreen;
            modal.Show();
        }

        public void OpenPredictModal(EventHandler<PredictModel> eventHandler)
        {
            var modal = new ModelPredictModal(eventHandler);
            modal.Text = "Автоматическое распределение элементов";
            modal.StartPosition = FormStartPosition.CenterScreen;
            modal.Show();
        }

        public void OpenClassifierModal()
        {
            var modal = new ItemsClassificationModal();
            modal.Text = "Распределение элементов";
            modal.StartPosition = FormStartPosition.CenterScreen;
            modal.Show();
        }

        public void OpenAddCategoryModal(Action<ListItem> onSave, List<ListItem> categories)
        {
            var modal = new AddCategoryModal(onSave, categories);
            modal.Text = "Новая категория";
            modal.StartPosition = FormStartPosition.CenterScreen;
            modal.Show();
        }

        public void OpenSetCategoryModal(Action<(ListItem, ListItem)> onSave, List<ListItem> supplierCategories, List<ListItem> shopCategories)
        {
            var modal = new SetCategoryModal(onSave, supplierCategories, shopCategories);
            modal.Text = "Установить категорию";
            modal.StartPosition = FormStartPosition.CenterScreen;
            modal.Show();
        }

        public void RunPythonScript(string scriptName, string args)
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = "C:\\Users\\Artem\\AppData\\Local\\Programs\\Python\\Python39\\python.exe";
            start.Arguments = string.Format("{0} {1}", scriptName, args);
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            start.CreateNoWindow = true;
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    Console.Write(result);
                }
            }
        }
    }
}
