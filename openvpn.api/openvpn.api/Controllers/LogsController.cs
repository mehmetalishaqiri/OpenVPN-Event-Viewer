using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using openvpn.api.common;
using openvpn.api.core.controllers;


namespace OpenVPN.Api.Controllers
{
    public class LogsController : RavenDbController
    {

        /// <summary>
        /// Log an open vpn event -> Connect / Disconnect
        /// </summary>
        /// <param name="eventModel"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> Post(Event eventModel)
        {
            await Session.StoreAsync(eventModel);

            return new HttpResponseMessage(HttpStatusCode.Created);
        }
    }
}
