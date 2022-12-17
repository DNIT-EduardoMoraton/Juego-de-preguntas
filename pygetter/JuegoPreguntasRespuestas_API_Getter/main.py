import requests
import requests as rq
import json
from azure.storage.blob import BlobServiceClient

API_BASE = "https://the-trivia-api.com/api/questions?categories=arts_and_literature,history,sport_and_leisure,science,society_and_culture,food_and_drink&limit=10&region=ES"
API_DIFF = ["&difficulty=easy", "&difficulty=medium", "&difficulty=hard"]

translate_cat = {
    "Society & Culture": 'Ocio y Entretenimiento',
    "Science": "Ciencia",
    "Arts & Literature": 'Arte y literatura',
    "Food & Drink": 'Comida',
    "History": "Historia",
    "Sport & Leisure": "Deportes"
}

sp_difs = ["Facil", "Medio", "Dificil"]

storage_account_key = "ZLNCSVkZB/C4pBLnbUODrNZwNQOfYMq6Jo7MGAgQm2eSunYX/3eFWLAkzMCPtZwvjIZFTyduzis0+AStiwWiQw=="
storage_account_name = "trivialedu"
connection_string = "DefaultEndpointsProtocol=https;AccountName=trivialedu;AccountKey=ZLNCSVkZB/C4pBLnbUODrNZwNQOfYMq6Jo7MGAgQm2eSunYX/3eFWLAkzMCPtZwvjIZFTyduzis0+AStiwWiQw==;EndpointSuffix=core.windows.net"
container_name = "trivial"


def uploadToBlobStorage(file_path, file_name):
    file_name = "img/" + file_name + '.png'
    blob_service_client = BlobServiceClient.from_connection_string(connection_string)
    blob_client = blob_service_client.get_blob_client(container=container_name, blob=file_name)

    img_data = requests.get(file_path).content
    with open(file_name, 'wb') as handler:
        handler.write(img_data)

    with open(file_name, "rb") as data:
        a = blob_client.upload_blob(data)
        print(a)
        print(f"Uploaded {file_name}.")
        return "https://trivialedu.blob.core.windows.net/trivial/" + file_name


def translate(sp_text):
    API = 'https://api.mymemory.translated.net/get?q='
    lan_setting = "&langpair=en|es"
    req = rq.get(API + sp_text + lan_setting)
    return req.json()["responseData"]['translatedText']


def getImage(srt):
    url = "https://pexelsdimasv1.p.rapidapi.com/v1/search"

    querystring = {"query": srt, "locale": "en-US", "per_page": "15", "page": "1"}

    headers = {
        "Authorization": "563492ad6f917000010000015d62995a97bd492e897f693affd63d4e",
        "X-RapidAPI-Key": "9ea51c2790msh678dea6e0ef0f02p15fa3djsn21fc31b3dc76",
        "X-RapidAPI-Host": "PexelsdimasV1.p.rapidapi.com"
    }

    response = rq.request('GET', url=url, params=querystring, headers=headers)
    print(response.status_code)
    return response.json()["photos"][0]["src"]['original']


questionsforjson = []
for apidiff, spdiff in zip(API_DIFF, sp_difs):

    quiz = rq.get(API_BASE + apidiff).json()

    for question in quiz:
        cat = question["category"]
        sp_cat = translate_cat[cat]

        corrans = question["correctAnswer"]
        corrans_sp = str(translate(corrans)).lower()

        qtext = question["question"]
        qtext_sp = translate(qtext)
        print(qtext_sp)

        img_url = getImage(str(corrans))
        bloburl = uploadToBlobStorage(img_url, str(corrans))
        q = {
            "QuestionText": qtext_sp,
            "CorrectAns": corrans_sp,
            "Category": sp_cat,
            "Image": bloburl,
            "Dificulty": spdiff
        }
        questionsforjson.append(q)

    jsonstr = json.dumps(questionsforjson)
    print(jsonstr)


with open("resultJson.json", 'w') as f:
    f.write(jsonstr)
