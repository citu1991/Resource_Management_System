using DTS.App_Start;
using DTS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DTS.Controllers
{
    public class DeviceController : Controller
    {
        DataBaseAccess db = new DataBaseAccess();
        // GET: Device
        public ActionResult AddEquipmentType()
        {
            return View(db.ListEquipmentType());
        }

        [HttpPost]
        public ActionResult AddEquipmentType([Bind(Include = "EquipmentName")]EquipmentTypeModel equipment, string submit, string reset)
        {
            if (submit == "Add Equipment")
            {
                if (equipment.EquipmentName != null)
                {
                    ModelState.Clear();
                    return View(db.AddEquipmentType(equipment));
                }
                else
                {
                    return View(db.ListEquipmentType());
                }

            }
            else if (reset == "Reset")
            {
                ModelState.Clear();
                return View(db.ListEquipmentType());
            }
            return View(db.ListEquipmentType());
        }
        


        public ActionResult AddMaker()
        {
            return View(db.ListMaker());
        }
        [HttpPost]
        public ActionResult AddMaker([Bind(Include = "MakerName")]MakerModel maker, string submit, string reset)
        {
           if (submit == "Add Maker")
            {
                if (maker.MakerName != null)
                {
                    ModelState.Clear();
                    return View(db.AddMaker(maker));
                }
                else
                {
                    return View(db.ListMaker());
                }

            }
            else if (reset == "Reset")
            {
                ModelState.Clear();
                return View(db.ListMaker());
            }
            return View(db.ListMaker());
        }
        


        public ActionResult AddDeviceModel()
        {
            return View(db.ListDeviceModel());
        }
               
        [HttpPost]
        public ActionResult AddDeviceModel([Bind(Include = "Device_Model,EquipmentId")]DeviceModelModel devicemodel, string submit, string reset)
        {
            if (submit == "Add Model")
            {
                if (devicemodel.Device_Model != null)
                {
                    ModelState.Clear();
                    return View(db.AddDeviceModel(devicemodel));
                }
                else
                {
                    return View(db.ListDeviceModel());
                }

            }
            else if (reset == "Reset")
            {
                ModelState.Clear();
                return View(db.ListDeviceModel());
            }
            return View(db.ListDeviceModel());
        }



        public ActionResult AddProcessor()
        {
            return View(db.ListProcessorModel());
        }
        [HttpPost]
        public ActionResult AddProcessor([Bind(Include = "ProcessorType")]ProcessorModel processor, string submit, string reset)
        {
            if (submit == "Add Processor")
            {
                if (processor.ProcessorType != null)
                {
                    ModelState.Clear();
                    return View(db.AddProcessorModel(processor));
                }
                else
                {
                    return View(db.ListProcessorModel());
                }

            }
            else if (reset == "Reset")
            {
                ModelState.Clear();
                return View(db.ListProcessorModel());
            }
            return View(db.ListProcessorModel());
        }


        public ActionResult AddRAMSize()
        {
            return View(db.ListRAMSizeModel());
        }
        [HttpPost]
        public ActionResult AddRAMSize([Bind(Include = "RAMCapacity")]RAMSizeModel ramsize, string submit, string reset)
        {
            if (submit == "Add Memory")
            {
                if (ramsize.RAMCapacity != null)
                {
                    ModelState.Clear();
                    return View(db.AddRAMSizeModel(ramsize));
                }
                else
                {
                    return View(db.ListRAMSizeModel());
                }

            }
            else if (reset == "Reset")
            {
                ModelState.Clear();
                return View(db.ListRAMSizeModel());
            }
            return View(db.ListRAMSizeModel());
        }


        public ActionResult AddStorage()
        {
            return View(db.ListStorage());
        }
        [HttpPost]
        public ActionResult AddStorage([Bind(Include = "StorageSize")]StorageModel storage, string submit, string reset)
        {
            if (submit == "Add Storage")
            {
                if (storage.StorageSize != null)
                {
                    ModelState.Clear();
                    return View(db.AddStorage(storage));
                }
                else
                {
                    return View(db.ListStorage());
                }

            }
            else if (reset == "Reset")
            {
                ModelState.Clear();
                return View(db.ListStorage());
            }
            return View(db.ListStorage());
        }
          

        public ActionResult AddWarranty()
        {
            return View(db.ListWarranty());
        }


        [HttpPost]
        public ActionResult AddWarranty(WarrantyModel wrty, string submit, string reset)
        {
            if (submit == "Add Warranty")
            {
                if (wrty.Warranty >= 0)
                {
                    ModelState.Clear();
                    return View(db.AddWarranty(wrty));
                }
                else
                {
                    return View(db.ListWarranty());
                }

            }
            else if (reset == "Reset")
            {
                ModelState.Clear();
                return View(db.ListWarranty());
            }
            return View(db.ListWarranty());
        }



        public ActionResult AddPort()
        {
            return View(db.ListPort());
        }
        [HttpPost]
        public ActionResult AddPort(PortModel portno, string submit, string reset)
        {
            if (submit == "Add Port")
            {
                if (portno.Port>0)
                {
                    ModelState.Clear();
                    return View(db.AddPort(portno));
                }
                else
                {
                    return View(db.ListPort());
                }

            }
            else if (reset == "Reset")
            {
                ModelState.Clear();
                return View(db.ListPort());
            }
            return View(db.ListPort());
        }

        public ActionResult AddDisplaySize()
        {
            return View(db.ListDisplaySize());
        }

        [HttpPost]
        public ActionResult AddDisplaySize(DisplaySizeModel dspsize, string submit, string reset)
        {
            if (submit == "Add DisplaySize")
            {
                if (dspsize.DisplaySize != null)
                {
                    ModelState.Clear();
                    return View(db.AddDisplaySize(dspsize));
                }
                else
                {
                    return View(db.ListDisplaySize());
                }

            }
            else if (reset == "Reset")
            {
                ModelState.Clear();
                return View(db.ListDisplaySize());
            }
            return View(db.ListDisplaySize());
        }

        public ActionResult AddBatteryType()
        {
            return View(db.ListBatteryType());
        }

        [HttpPost]
        public ActionResult AddBatteryType(BatteryTypeModel btrytype, FormCollection fm,string submit, string reset)
        {
            if (submit == "Add BatteryType")
            {
                
                var value1 = fm[1];
                if (btrytype.BatteryType != null)
                {
                    ModelState.Clear();
                    return View(db.AddBatteryType(btrytype));
                }
                else
                {
                    return View(db.ListBatteryType());
                }

            }
            else if (reset == "Reset")
            {
                ModelState.Clear();
                return View(db.ListBatteryType());
            }
            return View(db.ListBatteryType());
        }

        public ActionResult AddPrinterType()
        {
            return View(db.ListPrinterType());
        }

        [HttpPost]
        public ActionResult AddPrinterType(PrinterTypeModel prnttype, string submit, string reset)
        {
            if (submit == "Add PrinterType")
            {
                if (prnttype.PrinterType != null)
                {
                    ModelState.Clear();
                    return View(db.AddPrinterType(prnttype));
                }
                else
                {
                    return View(db.ListPrinterType());
                }

            }
            else if (reset == "Reset")
            {
                ModelState.Clear();
                return View(db.ListPrinterType());
            }
            return View(db.ListPrinterType());
        }

        public ActionResult AddPrinterColor()
        {
            return View(db.ListPrinterColor());
        }

        [HttpPost]
        public ActionResult AddPrinterColor(PrinterColorModel prtcolor, string submit, string reset)
        {
            if (submit == "Add PrinterColor")
            {
                if (prtcolor.PrinterColor != null)
                {
                    ModelState.Clear();
                    return View(db.AddPrinterColor(prtcolor));
                }
                else
                {
                    return View(db.ListPrinterColor());
                }

            }
            else if (reset == "Reset")
            {
                ModelState.Clear();
                return View(db.ListPrinterColor());
            }
            return View(db.ListPrinterColor());
        }

        public ActionResult AddPrinterTech()
        {
            return View(db.ListPrinterTech());
        }

        [HttpPost]
        public ActionResult AddPrinterTech(PrinterTechModel prttech, string submit, string reset)
        {
            if (submit == "Add PrinterTech")
            {
                if (prttech.PrinterTech != null)
                {
                    ModelState.Clear();
                    return View(db.AddPrinterTech(prttech));
                }
                else
                {
                    return View(db.ListPrinterTech());
                }

            }
            else if (reset == "Reset")
            {
                ModelState.Clear();
                return View(db.ListPrinterTech());
            }
            return View(db.ListPrinterTech());
        }

    }
}