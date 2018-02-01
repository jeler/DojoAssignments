using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace wedding_planner.Models {
    public abstract class BaseEntity { }

    public class User : BaseEntity {

        public int UserId { get; set; }

        public string first_name { get; set; }

        public string last_name { get; set; }

        public string email { get; set; }

        public string password { get; set; }

        public List<Wedding> Weddings { get; set; }
        // One to many user connector (user can plan many weddings therefore need list of all weddings)

        public List<RSVP> RSVPS {get; set;}
        // Forgot this one
        // Connector to many to many field

        public User () {
            Weddings = new List<Wedding> ();
            RSVPS = new List<RSVP> ();
        }

    }
    public class UserReg : BaseEntity {

        [Required]
        public int id { get; set; }

        [Required]
        [MinLength (3, ErrorMessage = "First Name must be at least 3 characters long!")]
        public string first_name { get; set; }

        [Required]
        [MinLength (3, ErrorMessage = "Last Name must be at least 3 characters long!")]
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

    public class UserViewModels {
        public UserReg Reg { get; set; }
        public UserLog Log { get; set; }
    }
}