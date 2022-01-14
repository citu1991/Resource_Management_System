using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DTS.Models
{
    public class EmployeeModel
    {
        public string EmployeeName { get; set; }        
        public string PayeeCode { get; set; }
        public string Designation { get; set; }
        public string MobileNo { get; set; }
        public string AllocationDate { get; set; }
        public string AllocationStatus { get; set; }
    }
}