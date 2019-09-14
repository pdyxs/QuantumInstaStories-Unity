import requests
import json


# set to your own subscription key value
subscription_key = "<insert_key_here>"
assert subscription_key

# replace <My Endpoint String> with the string from your endpoint URL
face_api_url = 'https://westcentralus.api.cognitive.microsoft.com/face/v1.0/detect'


image_url = 'https://www.rehabmagazine.ca/wp-content/uploads/rccm_anger1.jpg'


headers = {'Ocp-Apim-Subscription-Key': subscription_key}

params = {
    'returnFaceId': 'true',
    'returnFaceLandmarks': 'false',
    'returnFaceAttributes': 'emotion',
}

response = requests.post(face_api_url, params=params,
                         headers=headers, json={"url": image_url})
print(json.dumps(response.json()))
