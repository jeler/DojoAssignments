using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace bright_ideas.Models {
    public abstract class BaseEntity { }

    public class User : BaseEntity {

        public int UserId { get; set; }

        public string name { get; set; }

        public string alias { get; set; }

        public string email { get; set; }

        public string password { get; set; }

        public List<Like> Likes { get; set; }

        public List<Idea> Ideas {get; set;}
        

        public User () {
            Likes = new List<Like> ();
            Ideas = new List<Idea> ();
        }

    }
    public class UserReg : BaseEntity {

        [Required]
        public int UserId { get; set; }

        [Required]
        [MinLength (3, ErrorMessage = "First Name must be at least 3 characters long!")]
        [RegularExpression("^[A-Za-z]+$", ErrorMessage="First name can contain letters only")]
        public string name { get; set; }

        [Required]
        [MinLength (3, ErrorMessage = "Alias must be at least 3 characters long!")]
        public string alias { get; set; }

        [Required]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        [DataType (DataType.Password)]
        // [RegularExpression]
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