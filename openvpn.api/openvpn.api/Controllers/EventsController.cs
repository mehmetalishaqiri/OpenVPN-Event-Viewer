/*
    The MIT License (MIT)

    Copyright (c) 2014 Mehmetali Shaqiri (mehmetalishaqiri@gmail.com)

    Permission is hereby granted, free of charge, to any person obtaining a copy
    of this software and associated documentation files (the "Software"), to deal
    in the Software without restriction, including without limitation the rights
    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    copies of the Software, and to permit persons to whom the Software is
    furnished to do so, subject to the following conditions:

    The above copyright notice and this permission notice shall be included in all
    copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
    SOFTWARE. 
 */

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using openvpn.api.common.domain;
using openvpn.api.core.controllers;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Raven.Client;
using Raven.Client.Linq;

namespace openvpn.api.Controllers
{
    public class EventsController : RavenDbApiController
    {
        /// <summary>
        /// Store open vpn event in RavenDb document store.
        /// </summary>
        /// <param name="eventModel">The event model passed by open vpn client connect/disconnect</param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> Post([FromBody]Event eventModel)
        {
            await Session.StoreAsync(eventModel);

            return new HttpResponseMessage(HttpStatusCode.Created);
        }


        /// <summary>
        /// Get open vpn events for user certificates
        /// </summary>
        /// <param name="email">User's email address</param>
        /// <returns>A collection of Event model</returns>
        [HttpGet]
        
        public async Task<IEnumerable<Event>> GetUserEvents(string email)
        {
            var user = await Session.Query<User>().SingleOrDefaultAsync(u => u.Email == email);


            if (user == null)
                return null;

            var userCertificates = user.Certificates.Select(c => c.CommonName.ToLower()).ToArray();

            var query = Session.Query<Event>()
                    .Where(r => r.CommonName.In<string>(userCertificates))
                    .ToListAsync();


            return await query;
        }

    }
}
