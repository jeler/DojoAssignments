using System.ComponentModel.DataAnnotations;
namespace lost_in_woods.Models
{
    public abstract class BaseEntity {}
    public class Hike : BaseEntity
    {
        [Key]
        public long Id { get; set; }
 
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
 
        [Required]
        [MinLength(10)]
        public string Description {get; set;}

        [Required]
        [RangeAttribute(0, 100, ErrorMessage = "You need to enter a number!")]        
        public float Length {get; set;}

        [Required]
        [RangeAttribute(0, 10000, ErrorMessage = "You need to enter a number!")]
        public int Elevation {get; set;}

        [Required]
        [RangeAttribute(0, 200, ErrorMessage = "You need to enter a number!")]
        public float Latitude  { get; set; }

        [Required]
        [RangeAttribute(0, 200, ErrorMessage = "You need to enter a number!")]
        public float Longitude {get; set;}
 
    }
}