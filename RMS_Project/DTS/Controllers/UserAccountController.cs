using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DTS.Controllers
{
    public class UserAccountController : Controller
    {
        // GET: UserAccount
        public ActionResult UserDashBoard()
        {
            return View();
        }
    }
}