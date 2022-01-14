using DTS.App_Start;
using DTS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Device_Tracking_System.Controllers
{
    public class CircleController : Controller
    {
        DataBaseAccess db = new DataBaseAccess();
        public ActionResult AddCircle()
        {
            return View(db.ListCircle());
        }

        [HttpPost]
        public ActionResult AddCircle([Bind(Include ="CircleName")]CircleModel circle,string submit,string reset)
        {
            if (submit=="Add Circle")
            {
                if (circle.CircleName != null)
                {
                    ModelState.Clear();
                    return View(db.AddCircle(circle));
                }
                else
                {                    
                    return View(db.ListCircle());
                }
                
            }
            else if(reset=="Reset")
            {
                ModelState.Clear();
                return View(db.ListCircle());
            }
            return View(db.ListCircle());
        }


    }
}