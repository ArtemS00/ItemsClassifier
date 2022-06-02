using System;

namespace ItemsClassifier
{
    public class PredictModel
    {
        public PredictModel(string csvFilePath, string modelPath, string outputPath, string separator)
        {
            CsvFilePath = csvFilePath ?? throw new ArgumentNullException(nameof(csvFilePath));
            ModelPath = modelPath ?? throw new ArgumentNullException(nameof(modelPath));
            OutputPath = outputPath ?? throw new ArgumentNullException(nameof(outputPath));
            Separator = separator ?? throw new ArgumentNullException(nameof(separator));
        }

        public string CsvFilePath { get; set; }
        public string ModelPath { get; set; }
        public string OutputPath { get; set; }
        public string Separator { get; set; }
    }
}
