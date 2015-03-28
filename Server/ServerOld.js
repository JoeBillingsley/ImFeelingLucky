var apiKey = '20DE5AE7C82056A29670B0458D3871DB';
var majesticSite = 'developer.majestic.com';
//var majesticSite = 'vitalityrpg.com/Brumhack/doREQUEST.php'
var limit = 10;
//var siteRequest = 'www.bbc.co.uk';

var http = require('http');

function getSiteFromName(siteRequest){
    var options = {
        hostname: majesticSite,
        path: '/api/json?app_api_key='+apiKey+'&cmd=GetBackLinkData&item='+siteRequest+'&Count='+limit+'&datasource=fresh'
    };

    var req = http.request(options,function(res) {
        var data = '';

     // console.log('STATUS: ' + res.statusCode);
     // console.log('HEADERS: ' + JSON.stringify(res.headers));
     //   res.setEncoding('utf8');
        res.on('data', function (chunk) {
            data += chunk;
        });

        res.on('end',function(){
            console.log("END");

//            var dataStr = JSON.stringify(data);
//            var jChunk = JSON.parse(dataStr);
            //data += '}'

            console.log(data);

            if(data == null){
                console.log("ahhh");
                return;
            }
            //console.log('rekt');
            //console.log('is', typeof jChunk);
            //console.log(dataStr);
            //console.log(Object.keys(jChunk));

            //var l = [];

            console.log(data);

/*            if(data.DataTables.BackLinks != null)
                console.log("Woo");
            else
                console.log("Boo");
*/
            /*for(var i in jChunk.DataTables.Headers.BackLinks.Data){            
                //var l = _.keys(jChunk.DataTables.BackLinks.Data);
                if(!_.contains(l,i.sourceURL)){
                    l.push(i.sourceURL);
                }
                console.log(l.length());
            }*/
        });
    });

    req.end();  
}

var main = function(){
//    http.createServer(function(req,res){
//        var site = req.getHeader('site');
//        getSiteFromName(site);

//    }).listen(8080);

    getSiteFromName('www.bbc.co.uk');
}

if (require.main === module) {
    main();
}