using System;
using System.ComponentModel.DataAnnotations;

namespace restauranter.Models {
    public class ValidDateAttribute : ValidationAttribute {
        public override bool IsValid (object value) {
            DateTime d = Convert.ToDateTime (value);
            return d <= DateTime.Now;
        }
    }
    public abstract class BaseEntity {}
    public class Restaurant : BaseEntity {

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength (2, ErrorMessage = "Name must be greater than 2 characters!")]
        public string user_name { get; set; }

        [Required]
        [MinLength (2, ErrorMessage = "Restaurant Name must be greater than 2 characters!")]
        public string restaurant_name { get; set; }

        [Required]
        [MinLength (10, ErrorMessage = "Review must be greater than 10 characters!")]
        public string review { get; set; }

        [Required]
        [RangeAttribute(1,5, ErrorMessage = "Star Review must be between 1 and 5!")]
        public int stars { get; set; }

        [Required]
        // [DataType(DataType.Date)]
        [ValidDate(ErrorMessage ="Date can not be in the future!")]
        public DateTime visit_date { get; set; }
    }
}