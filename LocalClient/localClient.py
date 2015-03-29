#!/usr/bin/python

import requests
import urllib
import urllib3

#payload = {'key1': 'GetBaseLinks'}
url = "http://localhost:8080"

params = {'command': 'GetRefDomains', 'url': 'www.google.co.uk'}

myPort = "8080"

myURL = "http://localhost:%s/?%s" % (myPort, urllib.urlencode(params)) 

print myURL

r = urllib.urlopen(myURL)

#print r.read()