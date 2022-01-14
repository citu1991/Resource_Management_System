using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DTS.Models
{
    public class PrinterTypeModel :ComponentBaseModel
    {
        public int PrinterTypeId { get; set; }

        [Display(Name = "Printer Type")]
        [Required(ErrorMessage = "Required")]
        public string PrinterType { get; set; }
        
        public List<PrinterTypeModel> LIST_PRINTERTYPE
        {
            get; set;
        }
    }
}