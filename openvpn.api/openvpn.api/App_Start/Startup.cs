﻿/*
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
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using openvpn.api.core.auth;
using Owin;

namespace openvpn.api
{
    public partial class Startup
    {

        private void ConfigureAuth(IAppBuilder app)
        {

            // this is the normal cookie middleware
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "Cookie",
                AuthenticationMode = Microsoft.Owin.Security.AuthenticationMode.Active,
            });

            // these two lines of code are needed if you are using any of the external authentication middleware
            app.Properties["Microsoft.Owin.Security.Constants.DefaultSignInAsAuthenticationType"] = "ExternalCookie";
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "ExternalCookie",
                AuthenticationMode = Microsoft.Owin.Security.AuthenticationMode.Passive,
            });


            //var cookieOptions = new CookieAuthenticationOptions
            //{
            //    LoginPath = new PathString("/Home/Login"),
            //    AuthenticationType = "External",
            //    AuthenticationMode = AuthenticationMode.Passive,
            //    LogoutPath = new PathString("/Account/Profile/Logout"),
            //    CookieName = CookieAuthenticationDefaults.CookiePrefix + "External",
            //    ExpireTimeSpan = TimeSpan.FromMinutes(30)
            //};

            //app.UseCookieAuthentication(cookieOptions);

            //app.SetDefaultSignInAsAuthenticationType(cookieOptions.AuthenticationType);

            var googleOptions = new GoogleOAuth2AuthenticationOptions
            {
                ClientId = ConfigurationManager.AppSettings["GoogleClientId"],
                ClientSecret = ConfigurationManager.AppSettings["GoogleClientSecret"],
                Provider = new GoogleAuthProvider()
            };

            googleOptions.Scope.Add("email");

            app.UseGoogleAuthentication(googleOptions);
            
        }
    }
}