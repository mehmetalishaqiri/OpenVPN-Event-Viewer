# The MIT License (MIT)
#
# Copyright (c) 2014 Mehmetali Shaqiri (mehmetalishaqiri@gmail.com)
#
# Permission is hereby granted, free of charge, to any person obtaining a copy
# of this software and associated documentation files (the "Software"), to deal
# in the Software without restriction, including without limitation the rights
# to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
# copies of the Software, and to permit persons to whom the Software is
# furnished to do so, subject to the following conditions:
#
# The above copyright notice and this permission notice shall be included in all
# copies or substantial portions of the Software.
#
# THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
# IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
# FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
# AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
# LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
# OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
# SOFTWARE.


__version__ = "1.0"
__author__ = "Mehmetali Shaqiri <mehmetalishaqiri@gmail.com>"

import json
import time
import os
import socket
import OpenVpnApi

api = OpenVpnApi.RestAPI('http://localhost:65444/api/events')

event_type = 'Disconnect'
server = 'OpenVpnServer'
common_name = os.environ['common_name']
local_ip = os.environ['ifconfig_pool_remote_ip']
remote_ip = os.environ['untrusted_ip']
host_name = socket.getfqdn(remote_ip)
bytes_received = os.environ['bytes_received']
bytes_sent = os.environ['bytes_sent']
duration = os.environ['time_duration']

params = json.dumps(
    dict(Type=event_type, VpnServer=server, CommonName=common_name, LocalIp=local_ip, RemoteIp=remote_ip,
         HostName=host_name, BytesSent=bytes_sent, BytesReceived=bytes_received, Duration=duration,
         EnteredOn=time.strftime("%Y-%m-%d %H:%M:%S")))

api.post(params)
