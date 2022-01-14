using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DTS.Models
{
    public class PrinterTechModel :ComponentBaseModel
    {
        public int PrinterTechId { get; set; }

        [Display(Name = "Printer Technology")]
        [Required(ErrorMessage = "Required")]
        public string PrinterTech { get; set; }
        public List<PrinterTechModel> LIST_PRINTERTECH
        {
            get; set;
        }
    }
}