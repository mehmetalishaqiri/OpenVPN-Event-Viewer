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

import http.client

try:
    from urlparse import urlparse
except ImportError:
    from urllib.parse import urlparse


class RestAPI(object):
    def __init__(self, base_url):
        self.base_url = base_url + '/' if not base_url.endswith('/') else base_url
        self.api_path = urlparse(base_url).path
        self.scheme, self.host, self.url, z1, z2 = http.client.urlsplit(self.base_url)
        self.mime = 'application/json',
        self.headers = {'Content-Type': 'application/json'}
        self.conn = None

    def post(self, event):
        if self.conn is not None:
            self.conn.close()

        self.conn = http.client.HTTPConnection(self.host)

        self.conn.request("POST", self.url, body=event, headers=self.headers)

        response = self.conn.getresponse()

        result = response.read()

        if not result.StatusCode == 201:
            print('OpenVPN event was logged successfully in RavenDB Document Store.')
        else:
            raise Exception("Unable to log OpenVPN event!")