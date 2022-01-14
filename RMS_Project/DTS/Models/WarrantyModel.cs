using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DTS.Models
{
    public class WarrantyModel 
    {
        public int WarrantyId { get; set; }

        [Display(Name = "Warranty (In Years)")]
        [Required(ErrorMessage = "Required")]
        public int Warranty { get; set; }

        public string Message { get; set; }
        
        public List<WarrantyModel> LIST_WARRANTY
        {
            get; set;
        }
    }
}