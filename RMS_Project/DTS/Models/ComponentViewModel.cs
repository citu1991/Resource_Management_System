using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DTS.Models
{
    public class ComponentViewModel : ComponentBaseModel
    {
        [Required(ErrorMessage = "Required")]
        public int ProcessorId { get; set; }
        public string ProcessorType { get; set; }
        

        [Required(ErrorMessage = "Required")]
        public int RAMId { get; set; }
        public string RAMSize { get; set; }


        [Required(ErrorMessage = "Required")]
        public int StorageId { get; set; }
        public string Storage { get; set; }


        [Required(ErrorMessage = "Required")]
        public int DisplaySizeId { get; set; }
        public string DisplaySize { get; set; }


        [Required(ErrorMessage = "Required")]
        public int BatteryTypeId { get; set; }
        public string BatteryType { get; set; }


        [Required(ErrorMessage = "Required")]
        public int PortId { get; set; }
        public int Port { get; set; }



        [Required(ErrorMessage = "Required")]
        public int PrinterColorId { get; set; }
        public string PrinterColor { get; set; }


        [Required(ErrorMessage = "Required")]
        public int PrinterTechId { get; set; }
        public string PrinterTech { get; set; }


        [Required(ErrorMessage = "Required")]
        public int PrinterTypeId { get; set; }
        public string PrinterType { get; set; }

    }
}