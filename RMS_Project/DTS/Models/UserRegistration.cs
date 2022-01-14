using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DTS.Models
{
    public class UserRegistration
    {
        public int UserId { get; set; }
        public int UserTypeId { get; set; }
        public int CircleId_Assigned { get; set; }

        [Required(ErrorMessage = "Required")]        
        [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$",
        ErrorMessage = "Please Enter Correct Email Address")]
        public string UserEmailId { get; set; }



        [StringLength(30, ErrorMessage = "Password length must be Greater than or equal to 6 character", MinimumLength = 6)]
        [Required(ErrorMessage = "Required")] 
        [DataType(DataType.Password)]            
        public string UserPwd { get; set; }



        [Required(ErrorMessage = "Required")]            
        public string UserFname { get; set; }



        [Required(ErrorMessage = "Required")]       
        public string UserLname { get; set; }



        [Required(ErrorMessage = "Required")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(10, ErrorMessage = "The Mobile No must contains only 10 Digit without Prefix 0", MinimumLength = 10)]
        public string UserMobNo { get; set; }   
            

        public List<UserRegistration> ListUserRegistration { get; set; }
    }
}

