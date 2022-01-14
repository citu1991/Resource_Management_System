using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DTS.Models
{
    public class PortModel
    {
        public int PortId { get; set; }

        [Display(Name = "No of Port")]
        [Required(ErrorMessage = "Required")]
        public int Port { get; set; }

        public string Message { get; set; }
        public List<PortModel> LIST_PORT
        {
            get; set;
        }
    }
}