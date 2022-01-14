using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DTS.Models
{
    public class Active_InActiveUsers
    {
        public int UserId { get; set; }
        public int CircleId { get; set; }

        public string DistrictOfficeString { get; set; }

        public List<string> DistrictOffice => DistrictOfficeString.Split(',').ToList();
        public string FullName { get; set; }

        public string UserMobNo { get; set; }
        
        public string CircleName { get; set; }
        public string UserEmailId { get; set; }
        public string Exception { get; set; }
        public List<Active_InActiveUsers> LISTACT_INACT { get; set; }
        
    }
}