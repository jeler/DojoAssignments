using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace user_dashboard.Models {
    public class Comment: BaseEntity {

        public int CommentId {get; set;}

        public int MessageId {get; set;}

        [Required]
        [MinLength(3)]
        public string comment {get; set;}
        
        public DateTime created_at {get; set;}
    }
}