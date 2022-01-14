using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DTS.Models
{
    public class MakerModel
    {

        public int MakerId { get; set; }

        [Display(Name = "Maker Name")]
        [Required(ErrorMessage = "Required")]
        public string MakerName { get; set; }
        public string Error { get; set; }
        public List<MakerModel> LIST_MAKER
        {
            get; set;
        }
    }
}