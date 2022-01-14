using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DTS.Models
{
    public class DisplaySizeModel
    {
        public int DisplaySizeId { get; set; }

        [Display(Name = "Display Size")]
        [Required(ErrorMessage = "Required")]
        public string DisplaySize { get; set; }
        public string Message { get; set; }
        public List<DisplaySizeModel> LIST_DISPLAYSIZE
        {
            get; set;
        }
    }
}