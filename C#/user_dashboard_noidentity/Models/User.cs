using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace user_dashboard.Models {
    public abstract class BaseEntity { }

    public class User : BaseEntity 
    {

        public int UserId { get; set; }

        public string first_name { get; set; }

        public string last_name { get; set; }

        public string email { get; set; }

        public string password { get; set; }

        public int user_level {get; set;}

        public string description {get; set;}


        public List<Message> ReceivedMessages { get; set; }

        public DateTime created_at {get; set;}
        public User () {
            ReceivedMessages = new List<Message> ();
        }
    }
    public class UserReg : BaseEntity {

        [Required]
        public int id { get; set; }

        [Required]
        [MinLength (3, ErrorMessage = "First Name must be at least 3 characters long!")]
        [RegularExpression("^[A-Za-z]+$", ErrorMessage="First name can contain letters only")]
        public string first_name { get; set; }

        [Required]
        [MinLength (3, ErrorMessage = "Last Name must be at least 3 characters long!")]
        [RegularExpression("^[A-Za-z]+$", ErrorMessage="First name can contain letters only")]
        public string last_name { get; set; }

        [Required]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        [DataType (DataType.Password)]
        public string password { get; set; }

        [Required]
        [Compare ("password", ErrorMessage = "Password and password confirmation must match!")]
        [DataType (DataType.Password)]
        public string passwordconfirmation { get; set; }
    }

    public class UserLog : BaseEntity {

        [Required]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        [DataType (DataType.Password)]        
        public string password { get; set; }
    }

    public class AdminChangePass : BaseEntity 
    {
        [Required]
        [DataType (DataType.Password)]
        public string password { get; set; }

        [Required]
        [Compare ("password", ErrorMessage = "Password and password confirmation must match!")]
        [DataType (DataType.Password)]
        public string passwordconfirmation { get; set; }
    }
    public class AdminEditInfo: BaseEntity 
    {
        [Required]
        public int id { get; set; }

        [Required]
        [MinLength (3, ErrorMessage = "First Name must be at least 3 characters long!")]
        [RegularExpression("^[A-Za-z]+$", ErrorMessage="First name can contain letters only")]
        public string first_name { get; set; }

        [Required]
        [MinLength (3, ErrorMessage = "Last Name must be at least 3 characters long!")]
        [RegularExpression("^[A-Za-z]+$", ErrorMessage="Last name can contain letters only")]
        public string last_name { get; set; }

        [Required]
        [EmailAddress]
        public string email { get; set; }

        public int user_level {get; set;}
        
    }
    public class UserEdit: BaseEntity
    {
        [Required]
        [MinLength (3, ErrorMessage = "First Name must be at least 3 characters long!")]
        [RegularExpression("^[A-Za-z]+$", ErrorMessage="First name can contain letters only")]
        public string first_name { get; set; }

        [Required]
        [MinLength (3, ErrorMessage = "Last Name must be at least 3 characters long!")]
        [RegularExpression("^[A-Za-z]+$", ErrorMessage="First name can contain letters only")]
        public string last_name { get; set; }

        [Required]
        [EmailAddress]
        public string email { get; set; }
        
    }

    public class UserViewModels {
        public UserReg Reg { get; set; }
        public UserLog Log { get; set; }

        public AdminChangePass AdminPass {get; set;}

        public AdminEditInfo AdminEditInfo {get; set;}

        public UserEdit UserEdit {get; set;}

    }
}