#!/usr/bin/python

import requests

#payload = {'key1': 'GetBaseLinks'}
url = "http://localhost:8080"

data = {'command': 'GetBaseLinks', 'url': 'www.example.com'}

#r = requests.get("localhost:8080", params=payload)

print requests.get(url, data=data)