using DTS.App_Start;
using DTS.Models;
using System.Web.Mvc;

namespace Device_Tracking_System.Controllers
{
    public class UserLoginController : Controller
    {
        DataBaseAccess dbLogin = new DataBaseAccess();
        // GET: UserLogin
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserLogin user)
        {
            if (ModelState.IsValid)
            {
                string resultLogin = dbLogin.Login(user);
                if (resultLogin == "Admin")
                {
                    return RedirectToAction("AdminDashBoard", "AdminAccount");
                }
                else if (resultLogin == "User")
                {
                    return RedirectToAction("UserDashBoard", "UserAccount");
                }
                else
                {
                    ViewBag.MessageLogin = resultLogin;
                    ModelState.Clear();
                    return View();
                }
            }
            return View(user);
        }
    }
}