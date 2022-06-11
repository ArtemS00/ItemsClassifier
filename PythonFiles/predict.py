# %%
import pandas as pd
import pickle
import sys

from string import punctuation

import spacy
nlp = spacy.load('ru_core_news_md')

class Classifier:
    def __init__(self):
        self.nameVectorizer = None
        self.nameClassifier = None
        self.descriptionVectorizer = None
        self.descriptionClassifier = None

    def preprocess_text(self, text):
        doc = nlp(text)
        tokens = [token.lemma_ for token in doc]
        tokens = [token for token in tokens if token != " " \
            and token.strip() not in punctuation]
        return " ".join(tokens)

    def predict_name(self, text):
        text = self.preprocess_text(text)
        vector = self.nameVectorizer.transform([text])
        return self.nameClassifier.predict(vector[0].toarray())[0]

    def predict_description(self, text):
        if not text or text != text:
            return -1
        text = self.preprocess_text(text)
        vector = self.descriptionVectorizer.transform([text])
        return self.descriptionClassifier.predict(vector[0].toarray())[0]

class Model:
    def __init__(self, classifier, categories):
        self.classifier = classifier
        self.categories = categories

def predict_and_save(modelPath, filePath, separator, outputPath):
    with open(modelPath, 'rb') as pickle_file:
        model = pickle.load(pickle_file)
    classifier = model.classifier
    categories = model.categories

    df = pd.read_csv(filePath, sep=separator, index_col=False)
    df['PredictCategoryID'] = df['ItemName'].apply(lambda x: classifier.predict_name(x))
    df['PredictCategoryName'] = df['PredictCategoryID'].apply(lambda x: categories[x])
    if (classifier.descriptionClassifier != None):
        df['PredictByDescriptionCategoryID'] = df['Description'].apply(lambda x: classifier.predict_description(x))
        df['PredictByDescriptionCategoryName'] = df['PredictByDescriptionCategoryID'].apply(lambda x: categories[x] if x > -1 else '')
    df.to_csv(outputPath, sep=separator, index=False)

if __name__ == "__main__":
    if len(sys.argv) == 5:
        predict_and_save(sys.argv[1], sys.argv[2], sys.argv[3], sys.argv[4])
    else:
        raise ValueError('Аргументы не корректны. Формат: <script.py> <Путь к модели> <Путь к csv файлу> <Разделитель в csv файле> <Путь для сохранения результата>')
