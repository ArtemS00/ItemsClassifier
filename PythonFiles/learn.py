# %%
import pandas as pd
import nltk

from pymystem3 import Mystem
from string import punctuation

from nltk.corpus import stopwords

nltk.download('punkt')
nltk.download('averaged_perceptron_tagger')
nltk.download('wordnet')
nltk.download('stopwords')
mystem = Mystem()
russian_stopwords = stopwords.words("russian")


from sklearn.model_selection import train_test_split
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

    def preprocess_text(self, text, withStopwords = False):
        doc = nlp(text)
        tokens = [token.lemma_ for token in doc]
        tokens = [token for token in tokens if (withStopwords or token not in russian_stopwords)\
            and token != " " \
            and token.strip() not in punctuation]
        return " ".join(tokens)
        
    def train_name(self, fileName, separator):
        df_train= pd.read_csv(fileName, sep=separator, encoding='utf-8')
        df_train['clean_text'] = df_train['ItemName'].apply(lambda x: self.preprocess_text(x, True))

        min = (len(df_train) - 1000) / 20000
        if (min < 0): min = 0
        min = int(min)
        self.nameVectorizer = CountVectorizer(min_df=min)
        self.nameVectorizer.fit(df_train["clean_text"])
        X_train = self.nameVectorizer.transform(df_train["clean_text"])

        self.nameClassifier = LogisticRegression(max_iter=1000)
        self.nameClassifier.fit(X_train, df_train["CategoryID"])
        
    def train_description(self, fileName, separator):
        df_train= pd.read_csv(fileName, sep=separator, encoding='utf-8')
        df_train = df_train[df_train['Description'].str.len() > 0]
        df_train['clean_text'] = df_train['Description'].apply(lambda x: self.preprocess_text(x, False))
        if df_train.shape[0] == 0:
            return
        min = (len(df_train) - 1000) / 20000
        if (min < 0): min = 0
        min = int(min)
        self.descriptionVectorizer = CountVectorizer(min_df=min)
        self.descriptionVectorizer.fit(df_train["clean_text"])
        X_train = self.descriptionVectorizer.transform(df_train["clean_text"])

        self.descriptionClassifier = LogisticRegression(max_iter=1000)
        self.descriptionClassifier.fit(X_train, df_train["CategoryID"])

    def predict_name(self, text):
        text = self.preprocess_text(text, True).split(' ')
        vector = self.nameVectorizer.transform(text)
        return self.nameClassifier.predict(vector)[0]

    def predict_description(self, text):
        if text.str.len() <= 0:
            return -1
        text = self.preprocess_text(text, False).split(' ')
        vector = self.descriptionVectorizer.transform(text)
        return self.descriptionClassifier.predict(vector)[0]
    

class Model:
    def __init__(self, classifier, categories):
        self.classifier = classifier
        self.categories = categories


# %%
def train_and_save(filePath, separator, modelPath, useDescription):
    classifier = Classifier()
    classifier.train_name(filePath, separator)
    if (useDescription):
        classifier.train_description(filePath, separator)
    df = pd.read_csv(filePath, sep=separator)
    df = df.drop_duplicates(subset = ["CategoryID"])[['CategoryID', 'CategoryName']]
    categories = dict(df.values)
    model = Model(classifier, categories)
    with open(modelPath, 'wb') as pickle_file:
        pickle.dump(model, pickle_file)

train_and_save('C:/Users/Artem/Desktop/ВКР_Товары_Магазина.csv', '|', 'C:/Users/Artem/Desktop/model331.pkl', True)

if __name__ == "__main__":
    if len(sys.argv) == 5:
        train_and_save(sys.argv[1], sys.argv[2], sys.argv[3], sys.argv[4])
    else:
        raise ValueError('Аргументы не корректны. Формат: <script.py> <Путь к csv файлу> <Разделитель в csv файле> <Путь для сохранения модели> <Используется ли описание (True/False)>')


