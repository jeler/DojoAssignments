using System.ComponentModel.DataAnnotations;

namespace form_submission.Models
{
    public class User
    {
        [Required]
        [MinLength(4)]
        public string First_Name { get; set; }

        [Required]
        [MinLength(4)]
        public string Last_Name { get; set; }
        
        [Required]
        [Range(0, int.MaxValue)]
        public int Age {get; set;}
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }


        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}