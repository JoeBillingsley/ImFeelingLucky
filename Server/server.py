	#!/usr/bin/python
from BaseHTTPServer import BaseHTTPRequestHandler,HTTPServer
import majesticRequest
from urlparse import urlparse, parse_qs
 


PORT_NUMBER = 8080

#This class will handles any incoming request from
#the browser 
class myHandler(BaseHTTPRequestHandler):

	site = ""

	#Handler for the GET requests
	def do_GET(self):

		self.send_response(200)

	  	self.send_header('Content-type','text/html')

		self.end_headers()

		parsed = urlparse(self.path)
		command =  parse_qs(parsed.query)['command'][0]
		url = parse_qs(parsed.query)['url'][0]

		 majesticReturnString = ""

		 majesticReturnList = []

		if command == 'GetBackLinks':

			majesticReturnList = majesticRequest.backlinkRequest(url)

		elif command == 'GetTrustRequest':
		
			majesticReturnString = majesticRequest.trustRequest(url)

		elif command == 'GetRefDomains':

			majesticReturnList = majesticRequest.refDomains(url)

		elif command == 'GetImages':

			majesticReturnList = majesticRequest.imgScrape(url)

		elif command == 'GetBackgroundColour':

			majesticReturnString = majesticRequest.cssScrape(url) 
			
try:
	#Create a web server and define the handler to manage the
	#incoming request
	server = HTTPServer(('', PORT_NUMBER), myHandler)
	print 'Started httpserver on port ' , PORT_NUMBER
		
	#Wait forever for incoming htto requests
	server.serve_forever()

except KeyboardInterrupt:
	print '^C received, shutting down the web server'
	server.socket.close()

