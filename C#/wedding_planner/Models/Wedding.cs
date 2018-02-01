using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace wedding_planner.Models {
    
        public class ValidDateAttribute : ValidationAttribute {
            public override bool IsValid (object value) {
                DateTime d = Convert.ToDateTime (value);
                return d >= DateTime.Now;
            }
        }
    public class Wedding : BaseEntity {
        

        public int WeddingId {get; set;}


        [Required]
        public string wedder_one { get; set; }

        [Required]
        public string wedder_two { get; set; }

        [Required]
        [ValidDate(ErrorMessage ="Date must be in the future!")]
        public DateTime date {get; set;}

        [Required]
        public string address {get; set;}

        public int CreatorId {get; set;}
        // One to many user connector

        public User Creator {get; set;}
        // One to many user connector, returns user object so can access first_name, last_name, etc of user


        public List<RSVP> RSVPS {get; set;}
        // Connection point to getting to users

        public Wedding() {
            RSVPS = new List<RSVP>();
        }
    }
}