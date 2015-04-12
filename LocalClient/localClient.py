#!/usr/bin/python

import requests
import urllib
import urllib3

params = {'command': 'GetImages', 'url': 'www.google.co.uk'}

myPort = "8080"

myURL = "http://52.17.60.90:%s/?%s" % (myPort, urllib.urlencode(params)) 

r = urllib.urlopen(myURL)

print r.read()