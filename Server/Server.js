var apiKey = '20DE5AE7C82056A29670B0458D3871DB';
var majesticSite = 'developer.majestic.com';
//var majesticSite = 'vitalityrpg.com/Brumhack/doREQUEST.php'
var limit = 10;
var siteRequest = 'www.bbc.co.uk';

var http = require('http');

var siteRequest = 'www.bbc.co.uk';

var options = {
    hostname: majesticSite,
    path: '/api/json?app_api_key='+apiKey+'&cmd=GetBackLinkData&item='+siteRequest+'&Count='+limit+'&datasource=fresh'
};

var req = http.request(options,function(res) {
  console.log('STATUS: ' + res.statusCode);
  console.log('HEADERS: ' + JSON.stringify(res.headers));
  res.setEncoding('utf8');
  res.on('data', function (chunk) {
    console.log('BODY: ' + chunk);
  })});

req.end();