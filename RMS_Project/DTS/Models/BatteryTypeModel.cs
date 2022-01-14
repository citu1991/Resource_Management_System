using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DTS.Models
{
    public class BatteryTypeModel :ComponentBaseModel
    {
        public int BatteryTypeId { get; set; }

        [Display(Name = "Battery Type")]
        [Required(ErrorMessage = "Required")]
        public string BatteryType { get; set; }
        public List<BatteryTypeModel> LIST_BATTERYTYPE
        {
            get; set;
        }
    }
}