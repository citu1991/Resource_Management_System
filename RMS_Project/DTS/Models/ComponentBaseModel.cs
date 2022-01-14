using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DTS.Models
{
    public class ComponentBaseModel
    {
        public int AssignedId { get; set; }
        [Required(ErrorMessage = "Required")]
        public int EquipmentId { get; set; }
        public string EquipmentName { get; set; }



        [Required(ErrorMessage = "Required")]
        public int DeviceModelId { get; set; }
        public string DeviceModel { get; set; }



        [Required(ErrorMessage = "Required")]
        public int MakerId { get; set; }
        public string MakerName { get; set; }


        [Display(Name = "Serial No")]
        [Required(ErrorMessage = "Required")]
        public string SerialNo { get; set; }


        [Required(ErrorMessage = "Required")]
        public int WarrantyId { get; set; }
        public int Warranty { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateofPurchase { get; set; }

        public string Remarks { get; set; }
        public string Message { get; set; }

        public List<EquipmentTypeModel> LIST_EQUIPMENT { get; set; }
        public List<MakerModel> LIST_MAKER { get; set; }
        public List<WarrantyModel> LIST_WARRANTY { get; set; }

        public List<PortModel> LIST_PORT { get; set; }
        public List<DisplaySizeModel> LIST_DISPLAYSIZE { get; set; }
        public List<BatteryTypeModel> LIST_BATTERYTYPE { get; set; }
        public List<PrinterTypeModel> LIST_PRINTERTYPE { get; set; }
        public List<PrinterTechModel> LIST_PRINTERTECH { get; set; }

        public List<PrinterColorModel> LIST_PRINTERCOLOR { get; set; }
        public List<ProcessorModel> LIST_PROCESSOR { get; set; }
        public List<RAMSizeModel> LIST_RAM { get; set; }
        public List<StorageModel> LIST_STORAGE { get; set; }
        public List<DeviceModelModel> LIST_DEVICEMODEL { get; set; }
    }
}