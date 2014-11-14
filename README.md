### What is OpenVPN?###

OpenVPN  is  a robust and highly flexible VPN daemon.  OpenVPN supports  SSL/TLS security,  ethernet  bridging,  TCP  or  UDP  tunnel  transport through  proxies  or  NAT,  support  for dynamic IP addresses and DHCP, scalability to hundreds or thousands of users, and portability to  most major OS platforms.

OpenVPN  is  tightly  bound to the OpenSSL library, and derives much of its crypto capabilities from it.

### What is OpenVPN Event Viewer?###

OpenVPN Event Viewer offers a human readable format of the open vpn connection logs.


### How does it work?###

 OpenVPN allows any option to be placed either on the command line or in a configuration file. To intercept the client's connection and disconnections we have to use the following options:

###--client-connect script ### - Run script on client connection
###--client-disconnect ###– Run script on client instance shutdown.

For this to work, you have to add the following lines in you openvpn server config file:

script-security 2

--client-connect "client-connect.bat"

--client-disconnect "client-disconnect.bat"



### Tech Stack ###

* Asp.NET Web API
* RavenDB
* Python