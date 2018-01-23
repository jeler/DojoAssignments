using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
 
namespace dojo_league.Models
{
    public abstract class BaseEntity{}
    public class Dojo: BaseEntity
    {
        public Dojo() {
            ninjas = new List<Ninja>();
        }
 
        [Key]
        public long id { get; set; }
 
        [Required]
        [MinLength(3)]
        public string name { get; set; }
 
        [Required]
        [MinLength(3)] 
        public string location { get; set; }

        [Required]
        [MinLength(10)]                
        public string information { get; set;}
 
        public ICollection<Ninja> ninjas { get; set; }
    }
}