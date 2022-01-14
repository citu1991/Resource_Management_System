using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DTS.Models;

namespace DTS.Models
{
    public class CPUModel : ComponentBaseModel
    {

        public int CPUId { get; set; }

        [Required(ErrorMessage = "Required")]
        public int ProcessorId { get; set; }      
        public string ProcessorType { get; set; }



        [Required(ErrorMessage = "Required")]
        public int RAMId { get; set; }       
        public string RAMSize { get; set; }


        [Required(ErrorMessage = "Required")]
        public int StorageId { get; set; }       
        public string Storage { get; set; }
       

        public string IsStaffAssigned { get; set; }
        public string IsCircleAssigned { get; set; }
        public string Circle { get; set; }
        public string District { get; set; }
        public string VCode { get; set; }
        public CPUModel CPU { get; set; }
        public List<CPUModel> LIST_CPU { get; set; }


    }
}