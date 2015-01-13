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

using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.Owin.Security;
using openvpn.api.core.auth;

namespace openvpn.api.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var currentUser = System.Web.HttpContext.Current.Session["ExternalLoginModel"] as openvpn.api.core.auth.ExternalLoginModel;
            if (User.Identity.IsAuthenticated && currentUser != null)
            {
                return RedirectToAction("Index", "Dashboard", new { area = "Account" });
            }
            return View();
        }

        public ActionResult Login(string returnUrl)
        {
            // Request a redirect to the external login provider
            return new AuthenticationChallengeResult("Google", Url.Action("ExternalLoginCallback", "Home", new { ReturnUrl = returnUrl }));
        }

        public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            //var ctx = Request.GetOwinContext();
            //var result = await ctx.Authentication.AuthenticateAsync("External");


            var ctx = Request.GetOwinContext();
            var result = await ctx.Authentication.AuthenticateAsync("ExternalCookie");
            ctx.Authentication.SignOut("ExternalCookie");

           
            
            var externalLogin = ExternalLoginModel.FromIdentity(result.Identity);

            if (externalLogin == null)
            {
                return new HttpStatusCodeResult(500);
            }

            var claims = result.Identity.Claims.ToList();
            claims.Add(new Claim(ClaimTypes.AuthenticationMethod, "Google"));

            var ci = new ClaimsIdentity(claims, "Cookie");
            ctx.Authentication.SignIn(ci);
          
            //ctx.Authentication.SignOut("External");

            //var claims = result.Identity.Claims.ToList();
            //claims.Add(new Claim(ClaimTypes.AuthenticationMethod, "Google"));

            //var ci = new ClaimsIdentity(claims, "External");
            //ctx.Authentication.SignIn(ci);

            //authentication.AuthenticationResponseGrant = new AuthenticationResponseGrant(result.Identity, new AuthenticationProperties()
            //{
            //    IsPersistent = false
            //});

            
            Session["ExternalLoginModel"] = externalLogin;

            if (!String.IsNullOrEmpty(returnUrl))
                return new RedirectResult(returnUrl);
            else
                return RedirectToAction("Index", "Dashboard", new {area = "Account"});
        }
    }
}