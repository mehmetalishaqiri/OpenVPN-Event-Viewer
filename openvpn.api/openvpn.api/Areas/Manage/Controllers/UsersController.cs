using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace openvpn.api.Areas.Manage.Controllers
{
    public class UsersController : Controller
    {
        // GET: Manage/Users
        public ActionResult Index()
        {
            return View();
        }
    }
}