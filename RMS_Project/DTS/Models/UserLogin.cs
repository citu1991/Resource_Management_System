using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DTS.Models
{
    public class UserLogin
    {
       
        [Required(ErrorMessage = "Required")]
        [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$",
        ErrorMessage = "Please Enter Correct Email Address")]
        public string UserEmailId { get; set; }


        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Password)]
        public string UserPwd { get; set; }


        public List<UserLogin> ListUserLogin { get; set; }
    }
}