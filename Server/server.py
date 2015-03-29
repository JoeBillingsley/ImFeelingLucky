	#!/usr/bin/python
from BaseHTTPServer import BaseHTTPRequestHandler,HTTPServer
from majesticRequest import request
from urlparse import urlparse
import cgi

PORT_NUMBER = 8080

#This class will handles any incoming request from
#the browser 
class myHandler(BaseHTTPRequestHandler):

	site = ""

	#Handler for the GET requests
	def do_GET(self):

		# Parse the form data posted
	   	form = cgi.FieldStorage(
           	fp=self.rfile, 
         	headers=self.headers,
          	environ={'REQUEST_METHOD':'GET',
                  	'CONTENT_TYPE':self.headers['Content-Type'],
                   	})

		self.send_response(200)

	  	self.send_header('Content-type','text/html')

		self.end_headers()

		self.wfile.write('Form data:\n')

	   	# Echo back information about what was posted in the form
	 	for field in form.keys():
	   		field_item = form[field]
	    	if field_item.filename:
	        	# The field contains an uploaded file
	            file_data = field_item.file.read()
	            file_len = len(file_data)
	            del file_data
	            self.wfile.write('\tUploaded %s as "%s" (%d bytes)\n' % \
                        (field, field_item.filename, file_len))
	      	else:
				# Regular form value
				self.wfile.write('\t%s=%s\n' % (field, form[field].value))
	 	return
			
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

