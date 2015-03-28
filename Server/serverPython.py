import urllib3, json, traceback, requests, re
def request(siteRequest):
	http = urllib3.PoolManager()
	limit = 10000
	apiKey = '20DE5AE7C82056A29670B0458D3871DB'
	try:
		url = 'http://developer.majestic.com/api/json?app_api_key='+str(apiKey)+'&cmd=GetBackLinkData&item='+str(siteRequest)+'&Count='+str(limit)+'&datasource=fresh'
		r = requests.get(url, stream=True)
		parsed = r.json()["DataTables"]["BackLinks"]["Data"]
		l = []
		for row in parsed:
			url = row["SourceURL"]

			if url not in l:
				l.append(row["SourceURL"])
		return l
	except Exception:
		print (traceback.format_exc())

l = request('www.bbc.co.uk')

for i in l:
	print (i)