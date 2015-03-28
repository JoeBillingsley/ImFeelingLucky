import urllib3, json, traceback, requests, re
apiKey = '20DE5AE7C82056A29670B0458D3871DB'
majurl = 'http://developer.majestic.com/api/json?app_api_key='+str(apiKey)+'&cmd='
def backlinkRequest(siteRequest):
	http = urllib3.PoolManager()
	limit = 100
	try:
		url = str(majurl)+'GetBackLinkData&item='+str(siteRequest)+'&Count='+str(limit)+'&datasource=fresh'
		r = requests.get(url, stream=True)
		parsed = r.json()["DataTables"]["BackLinks"]["Data"]
		l = []
		for row in parsed:
			targetURL = row["SourceURL"]

			if targetURL not in l:
				l.append(row["SourceURL"])
		return l
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

trustRequest('www.bbc.co.uk')