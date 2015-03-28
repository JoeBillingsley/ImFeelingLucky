import urllib3, json, traceback, requests, re

def request(siteRequest):
	http = urllib3.PoolManager()

	limit = 10
	apiKey = '20DE5AE7C82056A29670B0458D3871DB'

	try:
		url = 'http://developer.majestic.com/api/json?app_api_key='+str(apiKey)+'&cmd=GetBackLinkData&item='+str(siteRequest)+'&Count='+str(limit)+'&datasource=fresh'

		#req = http.urlopen('GET',url)

		#print(req.headers)

		#encoding = req.headers.get_content_charset()
		#jRes = json.loads(req.readall().decode(encoding))

		r = requests.get(url, stream=True)
		r.json()

		print(r.json())

		"""
		relevant = []

		lines = r.iter_lines()
		# Save the first line for later or just skip it
		first_line = next(lines)
		for line in lines:
			if 'SourceURL' in str(line):
				relevant.append(line)
				#print(line)
				splitLine = str(line).split
		"""
		#jRes = json.loads(req)

		#print(jRes.DataTables)
	except Exception:
		print (traceback.format_exc())

request('www.bbc.co.uk')