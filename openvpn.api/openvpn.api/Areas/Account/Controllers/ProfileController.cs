using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace openvpn.api.Areas.Account.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Account/Profile
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Logout()
        {
            Session.Abandon();

            var ctx = Request.GetOwinContext();
            var authenticationManager = ctx.Authentication;
            authenticationManager.SignOut();


            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}