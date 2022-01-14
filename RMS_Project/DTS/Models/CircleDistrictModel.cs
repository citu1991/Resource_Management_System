using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DTS.Models
{
    public class CircleDistrictModel
    {
        public int CircleId { get; set; }
        public int DistrictId { get; set; }
        public string CircleName { get; set; }
        [Required(ErrorMessage ="Required")]
        [Display(Name ="District Name")]
        public string DistrictName { get; set; }

        public List<CircleDistrictModel> LIST_DISTRICT { get; set; }
        public List<CircleModel> LIST_CIRCLE { get; set; }
    }
}