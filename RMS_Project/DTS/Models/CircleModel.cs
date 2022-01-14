using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DTS.Models
{
    public class CircleModel
    {
        public int CircleId { get; set; }

        [Display(Name ="Circle Name")]
        [Required(ErrorMessage ="Required")]
        public string CircleName { get; set; }
        public string Error { get; set; }
        public List<CircleModel> LIST_CIRCLE { get; set; }
    }
}