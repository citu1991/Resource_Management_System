using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DTS.App_Start;
using DTS.Models;

namespace Device_Tracking_System.Controllers
{
    public class UserRegistrationController : Controller
    {
        // GET: UserRegistration
        

        DataBaseAccess db = new DataBaseAccess();
        public ActionResult Registration()
        {
             return View();
        }
        
        [HttpPost]
        public ActionResult Registration([Bind(Include = "UserEmailId,UserPwd,UserFname,UserLname,UserMobNo")]UserRegistration user)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Message=db.Registration(user);
                ModelState.Clear();
                return View();
            }
            return View(user);
        }

        public ActionResult ActiveUsers()
        {
            return View(db.GetActiveUsers());
        }
       
        public ActionResult In_ActiveUsers()
        {
            return View(db.GetInActiveUsers());
        }
       
        public JsonResult  ConfirmUserAction(int UserId,string ActionOnUser)
        {
            bool result = db.ConfirmUserAction(UserId, ActionOnUser);
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        public ActionResult AssignCircletoUser()
        {
            return View(db.ListAssignCircletoUser());
        }

        [HttpPost]
        public ActionResult AssignCircletoUser([Bind(Include = "UserId,CircleId")]UserCircleViewModel ucview,string submit,string reset)
        {
            
                if (submit== "Assign Circle to User")
                {
                if (ModelState.IsValid)
                {
                    ModelState.Clear();
                    return View(db.AssignCircleToUser(ucview.CircleId, ucview.UserId));
                }
                }
            else if (reset == "Reset")
            {
                ModelState.Clear();
                return View(db.ListAssignCircletoUser());
            }
            return View(db.ListAssignCircletoUser());
        }

        // GET: UserRegistration/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserRegistration/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserRegistration/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserRegistration/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserRegistration/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserRegistration/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserRegistration/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
