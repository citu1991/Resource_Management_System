using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DTS.Models
{
    public class DeviceModelModel
    {
        public int DeviceModelId { get; set; }
        public int EquipmentId { get; set; }

        [Display(Name = "Device Model")]
        [Required(ErrorMessage = "Required")]
        public string Device_Model { get; set; }
        

        [Display(Name = "Equipment Name")]
        [Required(ErrorMessage = "Required")]
        public string EquipmentName { get; set; }
        public string Error { get; set; }
        public List<EquipmentTypeModel> LIST_EQUIPMENTTYPE { get; set; }
        
        public List<DeviceModelModel> LIST_DEVICEMODEL
        {
            get; set;
        }
    }
}