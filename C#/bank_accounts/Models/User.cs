using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace bank_accounts.Models
{
    public abstract class BaseEntity {}

    public class User: BaseEntity {
        public long id {get; set;}

        public string first_name {get; set;}

        public string last_name {get; set;}

        public string email {get; set;}

        public string password {get; set; }

        public double balance { get; set; }

        public List<Transactions> Transactions { get; set;}

        public User() {
            Transactions = new List<Transactions>();
        }
    }
    public class UserReg : BaseEntity
    {
        [Key]
        public long id { get; set; }
 
        [Required]
        [MinLength(3, ErrorMessage ="Name must contain at least three characters!")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name can only contain letters")]
        public string first_name { get; set; }
 
        [Required]
        [MinLength(3, ErrorMessage ="Name must contain at least three letters!")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name can only contain letters")]
        public string last_name {get; set;}

        [Required]
        [EmailAddress]       
        public string email {get; set;}

        [Required]
        [MinLength(8, ErrorMessage = "Password must be at least eight characters long!")]
        [DataType(DataType.Password, ErrorMessage = "Password must be 8 characters long!")]
        public string password { get; set; }

        [Required]
        [Compare("password", ErrorMessage = "Password and confirmation must match.")]
        [DataType(DataType.Password)]
        public string passwordconfirmation { get; set; }
 
    }

    public class UserLog : BaseEntity {

        [Required]
        [EmailAddress]      
        public string email {get; set;}

        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }

    }

    public class UserViewModels {
        public UserReg Reg{ get; set;}
        public UserLog Log{ get; set;}
    }
}