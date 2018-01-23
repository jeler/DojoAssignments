using System.ComponentModel.DataAnnotations;
using System;
namespace dojo_league.Models
{

    public class Ninja : BaseEntity
    {
        [Key]
        public long id { get; set; }

        public long dojos_id {get; set;}

        public string dojoname {get; set;}
 
        [Required]
        [MinLength(3)] 

        public string name { get; set; }
 
        [Required]
        [RangeAttribute(0, 10, ErrorMessage = "You need to enter a number!")]        
        public string level { get; set; }

        public string description { get; set;}
 
        public Dojo dojo { get; set; }
        // Dont need if want to use joins for queries
        // Need if you want to do weird Lync queries
        
    }
}