using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DTS.Models
{
    public class ProcessorModel 
    {
        public int ProcessorId { get; set; }

        [Display(Name = "Processor Type")]
        [Required(ErrorMessage = "Required")]
        public string ProcessorType { get; set; }
        public string Error { get; set; }
        public List<ProcessorModel> LIST_PROCESSOR
        {
            get; set;
        }
    }
}