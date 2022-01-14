using DTS.App_Start;
using DTS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Device_Tracking_System.Controllers
{
    public class DistrictController : Controller
    {
        DataBaseAccess db = new DataBaseAccess();
        public ActionResult AddDistrict()
        {
            return View(db.ListDistrict());
        }

        [HttpPost]
        public ActionResult AddDistrict([Bind(Include = "DistrictName,CircleId")]CircleDistrictModel circledistrict, string submit, string reset)
        {
            if (submit == "Add District")
            {
                if (circledistrict.CircleId>0 && circledistrict.DistrictName != null)
                {
                    ModelState.Clear();
                    return View(db.AddDistrict(circledistrict));
                }
                else
                {
                    return View(db.ListDistrict());
                }

            }
            else if (reset == "Reset")
            {
                ModelState.Clear();
                return View(db.ListDistrict());
            }
            return View(db.ListDistrict());
        }





    }
}