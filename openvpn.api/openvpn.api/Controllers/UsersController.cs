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

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using openvpn.api.common.domain;
using openvpn.api.core.controllers;
using Raven.Client;
using openvpn.api.core.auth;

namespace openvpn.api.Controllers
{
    public class UsersController : RavenDbApiController
    {
        /// <summary>
        /// Store open vpn event in RavenDb document store.
        /// </summary>
        public async Task<IEnumerable<User>> Get()
        {
            var query = Session.Query<User>().OrderBy(u => u.Firstname).ToListAsync();

            return await query;
        }


        public async Task<HttpResponseMessage> Post([FromBody]User userModel)
        {
            await Session.StoreAsync(userModel);

            return new HttpResponseMessage(HttpStatusCode.Created);
        }
    }
}