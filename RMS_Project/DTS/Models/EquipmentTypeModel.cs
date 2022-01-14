using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DTS.Models
{
    public class EquipmentTypeModel
    {
         [Required(ErrorMessage = "Required")]
        public int EquipmentId { get; set; }

        [Display(Name = "Equipment Name")]
        [Required(ErrorMessage = "Required")]
        public string EquipmentName { get; set; }
        public string Error { get; set; }
        public List<EquipmentTypeModel> LIST_EQUIPMENTTYPE
        {
            get; set;
        }
    }
}