using System;

namespace ItemsClassifier
{
    public class LearnModel
    {
        public LearnModel(string csvFilePath, string modelPath, string separator, bool useDescription)
        {
            CsvFilePath = csvFilePath ?? throw new ArgumentNullException(nameof(csvFilePath));
            ModelPath = modelPath ?? throw new ArgumentNullException(nameof(modelPath));
            Separator = separator ?? throw new ArgumentNullException(nameof(separator));
            UseDescription = useDescription;
        }

        public string CsvFilePath { get; set; }
        public string ModelPath { get; set; }
        public string Separator { get; set; }
        public bool UseDescription { get; set; }
    }
}
