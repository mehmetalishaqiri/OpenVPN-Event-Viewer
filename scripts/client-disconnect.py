import os
import socket
import httplib2
import time
import datetime
import json


# Get the HTTP object
http = httplib2.Http(".cache")

# Set the request headers
headers = {  'Content-Type': 'application/json' }


commonName = os.environ['common_name']
localip = os.environ['ifconfig_pool_remote_ip']
remoteip = os.environ['untrusted_ip']
hostname = socket.getfqdn(remoteip)
bytesrec = os.environ['bytes_received']
bytessent = os.environ['bytes_sent']
duration = os.environ['time_duration']


  
# Send the GET request
url = 'http://192.168.88.3:8082/api/logs'       

http = httplib2.Http()

time = datetime.datetime.now()
params = json.dumps({        
        'Type' : 'Disconnect',
        'VpnServer' : 'CRSRV2',
        'CommonName' : commonName,
        'LocalIp' : localip,
        'RemoteIp' : remoteip,
        'HostName' : hostname,
        'BytesSent' : bytessent,
        'BytesReceived' : bytesrec,
        'Duration' : duration, 
        'EnteredOn' : time.strftime("%Y-%m-%d %H:%M:%S")
    })

response, content = http.request(url, 'POST', body = params ,headers = headers)

print(content)



