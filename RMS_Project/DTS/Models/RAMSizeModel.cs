using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DTS.Models
{
    public class RAMSizeModel
    {
        public int RAMId { get; set; }

        [Display(Name = "RAM Size")]
        [Required(ErrorMessage = "Required")]
        public string RAMCapacity { get; set; }
        public string Error { get; set; }
        public List<RAMSizeModel> LIST_RAMSIZE
        {
            get; set;
        }
    }
}