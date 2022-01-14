using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DTS.App_Start;
using DTS.Models;
using System.Data;
using System.Web.Security;

namespace DTS.Controllers
{
    public class ComponentController : Controller
    {
        // GET: Desktop
        DataBaseAccess db = new DataBaseAccess();
        DropDownData dropdowndata = new DropDownData();


        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["CircleId"] != null)
            {
                base.OnActionExecuting(filterContext);
            }
            else
            {
                Session.Abandon();
                FormsAuthentication.SignOut();
                filterContext.Result = new RedirectResult("~/UserLogin/Login");
            }
        }


        //public ComponentController()
        //{
        //    var x = int.Parse(Session["CircleId"].ToString());


        // if (int.Parse(Session["CircleId"].ToString())>0)
        //    {
        //        Session.Abandon();
        //        FormsAuthentication.SignOut();
        //        Response.Redirect("~/Login.cshtml");
        //    }
        //}



        public ActionResult AddComponent()
        {
            return View(db.FillDropDown());
        }

        [HttpPost]
        public ActionResult AddComponent(ComponentViewModel component, string submit, string reset)
        {
            if (submit == "Add Component")
            {

                if (component.EquipmentId > 0)//CPU All in One Laptop
                {
                    ModelState.Clear();
                    return View(db.AddComponent(component));
                }
                else
                {
                    return View(db.FillDropDown());
                }

            }
            else if (reset == "Reset")
            {
                ModelState.Clear();
                return View(db.FillDropDown());
            }
            return View(db.FillDropDown());
        }

        public ActionResult InboxCPUComponents()
        {
            CPUModel cpu = new CPUModel();
            List<CPUModel> inboxCPU = new List<CPUModel>();

            DataTable dt = db.get_DataTable("spComponent", "InboxCPU", int.Parse(Session["CircleId"].ToString()));
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    cpu.CPUId = int.Parse(dr["CPUId"].ToString());
                    cpu.EquipmentName = dr["EquipmentName"].ToString();
                    cpu.SerialNo = dr["CPUSerialNo"].ToString();
                    cpu.DeviceModel = dr["DeviceModel"].ToString();
                    cpu.MakerName = dr["MakerName"].ToString();
                    cpu.ProcessorType = dr["ProcessorType"].ToString();
                    cpu.RAMSize = dr["RAMSize"].ToString();
                    cpu.Storage = dr["Storage"].ToString();
                    cpu.Warranty = int.Parse(dr["Warranty"].ToString());
                    //cpu.IsCircleAssigned = dr["IsCircleAssigned"].ToString();
                    //cpu.Circle = dr["CircleName"].ToString();
                    //cpu.VCode = dr["VerificationCode"].ToString();
                    inboxCPU.Add(cpu);
                }

            }
            //DataTable dtable = db.get_DataTable("spComponent", "CircleDropDownList");
            //ViewBag.CircleList = dropdowndata.RenderDropDownList(dtable);
            return PartialView("~/Views/Shared/_InboxCPUList.cshtml", dt);
        }

        public ActionResult AssigntoDistOfficeCPUComponents()
        {
            CPUModel cpu = new CPUModel();
            List<CPUModel> inboxCPU = new List<CPUModel>();
            DataSet ds = db.get_DataSet("spComponent", "AssigntoOfficeCPU", int.Parse(Session["CircleId"].ToString()));
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    cpu.CPUId = int.Parse(dr["CPUId"].ToString());
                    cpu.EquipmentName = dr["EquipmentName"].ToString();
                    cpu.SerialNo = dr["CPUSerialNo"].ToString();
                    cpu.DeviceModel = dr["DeviceModel"].ToString();
                    cpu.MakerName = dr["MakerName"].ToString();
                    cpu.ProcessorType = dr["ProcessorType"].ToString();
                    cpu.RAMSize = dr["RAMSize"].ToString();
                    cpu.Storage = dr["Storage"].ToString();
                    cpu.Warranty = int.Parse(dr["Warranty"].ToString());
                    inboxCPU.Add(cpu);
                }

            }

            DataTable dtableDist = db.get_DataTable("spComponent", "DistrictDropDownList", int.Parse(Session["CircleId"].ToString()));
            ViewBag.DistrictList = dropdowndata.RenderDropDownList(dtableDist);
            return PartialView("~/Views/Shared/_AssigntoDistOfficeCPUList.cshtml", ds);
        }




        public ActionResult AssigntoDistStaffCPUComponents()
        {
            CPUModel cpu = new CPUModel();
            List<CPUModel> inboxCPU = new List<CPUModel>();
            DataSet ds = db.get_DataSet("spComponent", "AssigntoStaffCPU", int.Parse(Session["CircleId"].ToString()));
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    cpu.AssignedId= int.Parse(dr["AssignedId"].ToString());
                    cpu.IsStaffAssigned = dr["IsStaffAssigned"].ToString();
                    cpu.CPUId = int.Parse(dr["CPUId"].ToString());
                    cpu.EquipmentName = dr["EquipmentName"].ToString();
                    cpu.SerialNo = dr["CPUSerialNo"].ToString();
                    cpu.DeviceModel = dr["DeviceModel"].ToString();
                    cpu.MakerName = dr["MakerName"].ToString();
                    cpu.ProcessorType = dr["ProcessorType"].ToString();
                    cpu.RAMSize = dr["RAMSize"].ToString();
                    cpu.Storage = dr["Storage"].ToString();
                    cpu.Warranty = int.Parse(dr["Warranty"].ToString());
                    cpu.District = dr["DistrictName"].ToString();
                    inboxCPU.Add(cpu);
                }

            }

            //DataTable dtableDist = db.get_DataTable("spComponent", "DistrictDropDownList", int.Parse(Session["CircleId"].ToString()));
            //ViewBag.DistrictList = dropdowndata.RenderDropDownList(dtableDist);
            return PartialView("~/Views/Shared/_AssigntoDistStaffCPUList.cshtml", ds);
        }
        public ActionResult CPUComponents()
        {

            CircleModel circle = new CircleModel();
            List<CircleModel> listcircle = new List<CircleModel>();

            CPUModel cpu = new CPUModel();
            List<CPUModel> listCPUNotAssigned = new List<CPUModel>();
            List<CPUModel> listCPUAssigned = new List<CPUModel>();

            DataSet ds = db.CPUList();
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    cpu.CPUId = int.Parse(dr["CPUId"].ToString());
                    cpu.EquipmentName = dr["EquipmentName"].ToString();
                    cpu.SerialNo = dr["CPUSerialNo"].ToString();
                    cpu.DeviceModel = dr["DeviceModel"].ToString();
                    cpu.MakerName = dr["MakerName"].ToString();
                    cpu.ProcessorType = dr["ProcessorType"].ToString();
                    cpu.RAMSize = dr["RAMSize"].ToString();
                    cpu.Storage = dr["Storage"].ToString();
                    cpu.Warranty = int.Parse(dr["Warranty"].ToString());                   
                    //cpu.IsCircleAssigned = dr["IsCircleAssigned"].ToString();
                    cpu.IsCircleAssigned = dr["IsCircleAssigned"].ToString();
                    listCPUNotAssigned.Add(cpu);
                }
                foreach (DataRow dr in ds.Tables[1].Rows)
                {
                    cpu.CPUId = int.Parse(dr["CPUId"].ToString());
                    cpu.EquipmentName = dr["EquipmentName"].ToString();
                    cpu.SerialNo = dr["CPUSerialNo"].ToString();
                    cpu.DeviceModel = dr["DeviceModel"].ToString();
                    cpu.MakerName = dr["MakerName"].ToString();
                    cpu.ProcessorType = dr["ProcessorType"].ToString();
                    cpu.RAMSize = dr["RAMSize"].ToString();
                    cpu.Storage = dr["Storage"].ToString();
                    cpu.Warranty = int.Parse(dr["Warranty"].ToString());
                    cpu.IsCircleAssigned = dr["IsCircleAssigned"].ToString();
                    cpu.District = dr["DistrictName"].ToString();
                    //cpu.IsCircleAssigned = dr["IsCircleAssigned"].ToString();
                    cpu.Circle = dr["CircleName"].ToString();
                    cpu.VCode = dr["VerificationCode"].ToString();
                    listCPUAssigned.Add(cpu);
                }

            }


            //DataTable dt=db.CPUList();           
            //if (dt.Rows.Count > 0)
            //{
            //    foreach (DataRow dr in dt.Rows)
            //    {
            //        cpu.CPUId = int.Parse(dr["CPUId"].ToString()); 
            //        cpu.EquipmentName = dr["EquipmentName"].ToString();
            //        cpu.SerialNo = dr["CPUSerialNo"].ToString();
            //        cpu.DeviceModel = dr["DeviceModel"].ToString();
            //        cpu.MakerName = dr["MakerName"].ToString();
            //        cpu.ProcessorType = dr["ProcessorType"].ToString();
            //        cpu.RAMSize = dr["RAMSize"].ToString();
            //        cpu.Storage = dr["Storage"].ToString();
            //        cpu.Warranty = int.Parse(dr["Warranty"].ToString());
            //        cpu.IsCircleAssigned = dr["IsCircleAssigned"].ToString();
            //        listCPU.Add(cpu);
            //    }               
            //}

            DataTable dtable = db.get_DataTable("spComponent", "CircleDropDownList");
            ViewBag.CircleList = dropdowndata.RenderDropDownList(dtable);
            return PartialView("~/Views/Shared/_CPUMasterList.cshtml", ds);
        }

        //public ActionResult PrintersComponents()
        //{
        //    return View(db.PrintersList());
        //}

        public ActionResult GetAssignedEmployeeName(int AssignId, int CPUId)
        {
            EmployeeModel emp = new EmployeeModel();
            List<EmployeeModel> listEmp = new List<EmployeeModel>();
            DataSet ds = db.get_DataSetStaffName("spAllocation", "GetAssignedEmployeeData", int.Parse(Session["CircleId"].ToString()), AssignId, CPUId);
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    emp.EmployeeName = dr["EmployeeName"].ToString();
                    emp.PayeeCode = dr["PayeeCode"].ToString();
                    emp.Designation = dr["Designation"].ToString();
                    emp.MobileNo = dr["MobileNo"].ToString();
                    emp.AllocationDate = dr["AllocationDate"].ToString();
                    emp.AllocationStatus = dr["AllocationStatus"].ToString();
                    listEmp.Add(emp);
                }

            }
            return PartialView("~/Views/Shared/_ComponentAssignedListtoEmployee.cshtml", ds);
        }
       
        public ActionResult CreatePdf()
        {
           
            return View();
        }

        public ActionResult GetEmployeeLog(int CPUId)
        {
            EmployeeModel emp = new EmployeeModel();
            List<EmployeeModel> listEmp = new List<EmployeeModel>();
            DataSet ds = db.get_DataSetStaffNameLog("spAllocation", "GetStaffLog", CPUId);
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    emp.EmployeeName = dr["EmployeeName"].ToString();
                    emp.PayeeCode = dr["PayeeCode"].ToString();
                    emp.Designation = dr["Designation"].ToString();
                    emp.MobileNo = dr["MobileNo"].ToString();
                    emp.AllocationDate = dr["AllocationDate"].ToString();
                    emp.AllocationStatus = dr["AllocationStatus"].ToString();
                    listEmp.Add(emp);
                }

            }
            return PartialView("~/Views/Shared/_ComponentAssignedListtoEmployee.cshtml", ds);
        }

        public JsonResult GetModel(int ID_Eqp)
        {
            return Json(db.GetModelFromEquipmentId(ID_Eqp), JsonRequestBehavior.AllowGet);
        }

        public JsonResult AssignCPUtoCircle(int CircleId, string CPUIds)
        {
            Random code = new Random();
            int verificationcode = code.Next(10000, 99999);
            return Json(db.AssignCPUtoCircle(CircleId, CPUIds, verificationcode), JsonRequestBehavior.AllowGet);
        }


        public JsonResult AssignCPUtoDistOffice(int DistrictId, string CPUIds)
        {
            return Json(db.AssignCPUtoDistOffice(DistrictId, CPUIds), JsonRequestBehavior.AllowGet);
        }

        public JsonResult AssignCPUtoDistStaff(int StaffPersonId, string CPUIds)
        {
            return Json(db.AssignCPUtoDistStaff(StaffPersonId, CPUIds), JsonRequestBehavior.AllowGet);
        }

        public JsonResult VerifyPayeeCode(string EmployeePayeeCode,int CPU_ID)
        {
            return Json(db.VerifyPayeeCode(EmployeePayeeCode, CPU_ID), JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeallocateDevice(int Assign_Id, int CPU_Id)
        {
            return Json(db.DeallocateDevice(Assign_Id, CPU_Id), JsonRequestBehavior.AllowGet);
        }
        public JsonResult InboxVerifyCPU(int CPUId, string VCode)
        {
            return Json(db.InboxVerifyCPU(CPUId, VCode), JsonRequestBehavior.AllowGet);
        }

        public JsonResult AssignCPUtoStaff(int AssignedId, int CPUId,string PayeeCode,string Designation,string EmpName,string EmpMobile)
        {
            return Json(db.AssignCPUtoStaff(AssignedId, CPUId, PayeeCode, Designation, EmpName, EmpMobile), JsonRequestBehavior.AllowGet);
        }
    }
}