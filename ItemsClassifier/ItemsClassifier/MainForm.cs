using System;
using System.IO;
using System.Windows.Forms;

namespace ItemsClassifier
{
    public partial class MainForm : Form
    {
        private const string _learnScriptPath = "..\\..\\..\\..\\..\\PythonFiles\\learn.py";
        private const string _predictScriptPath = "..\\..\\..\\..\\..\\PythonFiles\\PythonFiles\\predict.py";

        private MainService _service = new MainService();

        public MainForm()
        {
            InitializeComponent();
            this.Text = "ВКР - Автоматическое распредление товаров по категориям";
            button1.Click += learnModelButton_Click;
            button2.Click += predictButton_Click;
        }

        private void learnModelButton_Click(object sender, EventArgs e)
        {
            var eventHandler = new EventHandler<LearnModel>(OnModelLearnStart);
            _service.OpenLearnModal(eventHandler);
        }

        private void OnModelLearnStart(object sender, LearnModel args)
        {
            _service.RunPythonScript(Path.GetFullPath(_learnScriptPath), string.Join(' ', args.CsvFilePath, args.Separator, args.ModelPath, args.UseDescription ? "True" : "False"));
            MessageBox.Show("Модель успешно обучена", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void predictButton_Click(object sender, EventArgs e)
        {
            var eventHandler = new EventHandler<PredictModel>(OnModelPredictStart);
            _service.OpenPredictModal(eventHandler);
        }

        private void OnModelPredictStart(object sender, PredictModel args)
        {
            _service.RunPythonScript(Path.GetFullPath(_predictScriptPath), string.Join(' ', args.ModelPath, args.CsvFilePath, args.Separator, args.OutputPath));
            MessageBox.Show("Элементы успешно распределены", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void classifierButton_Click(object sender, EventArgs e)
        {
            _service.OpenClassifierModal();
        }
    }
}
