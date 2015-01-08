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

using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace openvpn.api.core.auth
{
    public class Guardian : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);

            var isAuthorized = base.AuthorizeCore(filterContext.HttpContext);
            var currentUser = HttpContext.Current.Session["ExternalLoginModel"] as openvpn.api.core.auth.ExternalLoginModel;
            if (!isAuthorized || currentUser == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                     new RouteValueDictionary 
                        {
                            { "action", "Index" },
                            { "controller", "Home" },
                            { "area", ""}
                        });
            }
        }
    }
}
