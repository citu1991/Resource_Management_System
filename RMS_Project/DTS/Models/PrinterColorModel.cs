using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DTS.Models
{
    public class PrinterColorModel :ComponentBaseModel
    {
        public int PrinterColorId { get; set; }

        [Display(Name = "Printer Color")]
        [Required(ErrorMessage = "Required")]
        public string PrinterColor { get; set; }
        public List<PrinterColorModel> LIST_PRINTERCOLOR
        {
            get; set;
        }
    }
}