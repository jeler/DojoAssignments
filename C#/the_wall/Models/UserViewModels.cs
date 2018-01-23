using System.ComponentModel.DataAnnotations;
using DbConnection;

namespace the_wall.Models
{
    public abstract class BaseEntity{}

    public class UserReg:BaseEntity 
    {

        [Required]
        [MinLength(2, ErrorMessage = "First name must be at least two characters long")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name can only contain letters")]
        public string First_Name { get; set; }
        
        [Required]
        [MinLength(2, ErrorMessage = "Last name must be at least two characters long")]

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name can only contain letters")]
        public string Last_Name { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
 
        [Required]
        [MinLength(8)]
        [DataType(DataType.Password, ErrorMessage = "Password must be 8 characters long!")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Password and confirmation must match.")]
        [DataType(DataType.Password)]
        public string PasswordConfirmation { get; set; }

    }

    public class UserLogin: BaseEntity 
    {

        [Required]
        [EmailAddress]
        public string Email { get; set; }


        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }

    public class WrapperMessage: BaseEntity 
    {
        [Required]
        [MinLength (2, ErrorMessage = "You need to enter a message!")]
        public string Message {get; set;}
    }

    public class WrapperComment: BaseEntity 
    {
        [Required]
        [MinLength (2, ErrorMessage = "You need to enter a comment!")]
        public string Comment {get; set;}
        
    }

    public class UserViewModels 
    {
        public UserReg Reg{ get; set;}
        public UserLogin Log{ get; set;}
    }

    public class WrapperViewModels
    {
        public WrapperMessage Mes {get; set;}
        public WrapperComment Com {get; set;}
    }
    
}