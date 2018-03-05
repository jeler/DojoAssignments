using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace bright_ideas.Models {
    
        public class ValidDateAttribute : ValidationAttribute {
            public override bool IsValid (object value) {
                DateTime d = Convert.ToDateTime (value);
                return d >= DateTime.Now;
            }
        }
    public class Idea : BaseEntity {
        

        public int IdeaId {get; set;}


        [Required]
        [MinLength (3, ErrorMessage = "Idea must be at least 3 characters long!")]
        public string idea { get; set; }

        public int CreatorId {get; set;}
        // One to many user connector

        public User Creator {get; set;}


        public List<Like> Likes {get; set;}


        public Idea() {
            Likes = new List<Like>();
        }
    }
}