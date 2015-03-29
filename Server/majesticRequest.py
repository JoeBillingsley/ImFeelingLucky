import urllib3, json, traceback, requests, re
from bs4 import BeautifulSoup
from selenium import webdriver
import tinycss

apiKey = '20DE5AE7C82056A29670B0458D3871DB'
majurl = 'http://developer.majestic.com/api/json?app_api_key='+str(apiKey)+'&cmd='
def backlinkRequest(siteRequest):
	limit = 100
	try:
		url = str(majurl)+'GetBackLinkData&item='+str(siteRequest)+'&Count='+str(limit)+'&datasource=fresh&MaxSourceURLsPerRefDomain=1'
		r = requests.get(url, stream=True)
		return getSourceURL(r)
	except Exception:
		print (traceback.format_exc())

def trustRequest(siteRequest):
	http = urllib3.PoolManager()
	try:
		url = str(majurl)+'GetLinkProfile&item0='+str(siteRequest)
		r = requests.get(url,stream=True)
		parsed = r.json()["DataTables"]["RankingMatrix_0"]["Headers"]["TotalValues"]
		return parsed
	except Exception:
		print (traceback.format_exc())

def getSourceURL(r):
	parsed = r.json()["DataTables"]["BackLinks"]["Data"]
	l = []
	for row in parsed:
		targetURL = row["SourceURL"]

		if targetURL not in l:
			l.append(targetURL)
	
	return l

def refDomains(siteRequest):
	limit = 100
	try:
		url = str(majurl)+'GetBackLinkData&item='+str(siteRequest)+'&Count='+str(limit)+'&datasource=fresh&MaxSourceURLsPerRefDomain=1'
		r = requests.get(url,stream=True)
		return getSourceURL(r)
	except Exception:
		print(traceback.format_exc())

def imgScrape(site):
	http = urllib3.PoolManager()
	filehandle = http.urlopen('GET',site)
	soup = BeautifulSoup(filehandle.data)
	imageArr = []
	for image in soup.find_all('img'):
		imageArr.append(image["src"])
	return imageArr

def cssScrape(site):
	"""
	driver = webdriver.Firefox()
	driver.get('http://'+site)

	element = driver.find_element_by_id('html')
	print(element.value_of_css_property('background-color'))
	"""

	http = urllib3.PoolManager()
	filehandle = http.urlopen('GET',site)
	soup = BeautifulSoup(filehandle.data)

	inlineCSS = soup.find_all('style',attrs={'type':'text/css'})

	cssCode = ''

	if inlineCSS != None:
		for css in inlineCSS:
			#print(css.text)

			c = css.text.split('\n')

			for x in c:
				if 'background' in x:
					#print(x)

					y = x.split(';')

					for z in y:
						if 'background' in z:
							a = z.split(':')
							for b in a:
								if '#' in b:
									if cssCode == '':
										cssCode = b									

			#print(css.text)
			#parser = tinycss.make_parser('page3')
			#stylesheet = parser.parse_stylesheet(css.text)

			#print(stylesheet.rules)
	else:
		for css in soup.find_all('link',attrs = {'type':'text/css'}):
			#print (css)

			filehandleCSS = http.urlopen('GET',css["href"])
			#print(filehandleCSS.data)

			#soupCSS = BeautifulSoup(filehandleCSS.data)

			parser = tinycss.make_parser('page3')
			stylesheet = parser.parse_stylesheet_bytes(filehandleCSS.data)
			print(stylesheet.rules)

			for x in stylesheet.rules:
				if 'background' in x:
					a = x.split(':')
					for b in a:
						if '#' in b:
							if cssCode == '':
								cssCode = b

	if cssCode == '':
		cssCode = '#000'

	return cssCode	

print(cssScrape('http://outlinenone.com/'))
#print(trustRequest('http://www.reddit.com'))