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
using Raven.Client;

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
        // TODO: Add pagination

        public async Task<IHttpActionResult> Get()
        {
            IEnumerable<Event> logs = await Session.Query<Event>().ToListAsync();

            return Ok(logs);

        }
        public async Task<IHttpActionResult> GetLog(string id)
        {
            Event log = await Session.LoadAsync<Event>(String.Format("{0}/{1}", "events", id));

            return Ok(log);
        }
    }
}
