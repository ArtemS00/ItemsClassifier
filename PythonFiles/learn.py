# %%
import pandas as pd

from string import punctuation

from sklearn.feature_extraction.text import CountVectorizer
from sklearn.linear_model import LogisticRegression

import pickle
import spacy
nlp = spacy.load('ru_core_news_md')

import sys

# %%
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
        
    def train_name(self, fileName, separator):
        df_train= pd.read_csv(fileName, sep=separator, encoding='utf-8')
        df_train['clean_text'] = df_train['ItemName'].apply(lambda x: self.preprocess_text(x))

        self.nameVectorizer = CountVectorizer(min_df=5, ngram_range=(1, 3))
        self.nameVectorizer.fit(df_train["clean_text"])
        X_train = self.nameVectorizer.transform(df_train["clean_text"])

        self.nameClassifier = LogisticRegression(max_iter=1000)
        self.nameClassifier.fit(X_train.toarray(), df_train["CategoryID"])
        
    def train_description(self, fileName, separator):
        df_train= pd.read_csv(fileName, sep=separator, encoding='utf-8')
        df_train = df_train[df_train['Description'].str.len() > 0]
        df_train['clean_text'] = df_train['Description'].apply(lambda x: self.preprocess_text(x))
        if df_train.shape[0] == 0:
            return

        self.descriptionVectorizer = CountVectorizer(min_df=5)
        self.descriptionVectorizer.fit(df_train["clean_text"])
        X_train = self.descriptionVectorizer.transform(df_train["clean_text"])

        self.descriptionClassifier = LogisticRegression(max_iter=1000)
        self.descriptionClassifier.fit(X_train.toarray(), df_train["CategoryID"])

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


# %%
def train_and_save(filePath, separator, modelPath, useDescription):
    classifier = Classifier()
    if (useDescription):
        classifier.train_description(filePath, separator)
    classifier.train_name(filePath, separator)
    df = pd.read_csv(filePath, sep=separator)
    df = df.drop_duplicates(subset = ["CategoryID"])[['CategoryID', 'CategoryName']]
    categories = dict(df.values)
    model = Model(classifier, categories)
    with open(modelPath, 'wb') as pickle_file:
        pickle.dump(model, pickle_file)

if __name__ == "__main__":
    if len(sys.argv) == 5:
        train_and_save(sys.argv[1], sys.argv[2], sys.argv[3], sys.argv[4])
    else:
        raise ValueError('Аргументы не корректны. Формат: <script.py> <Путь к csv файлу> <Разделитель в csv файле> <Путь для сохранения модели> <Используется ли описание (True/False)>')


