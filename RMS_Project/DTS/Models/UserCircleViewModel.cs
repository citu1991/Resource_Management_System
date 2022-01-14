using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DTS.Models
{
    public class UserCircleViewModel
    {
        public int UserId { get; set; }
        public int CircleId { get; set; }
        public string CircleName { get; set; }
        public string UserandCircle { get; set; }

        public List<CircleModel> LIST_CIRCLE { get; set; }
        public List<UserRegistration> LIST_USER { get; set; }        
        public List<UserCircleViewModel> LIST_USERCIRCLEVM {get;set;}
      
    }
}