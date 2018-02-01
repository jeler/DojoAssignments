using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    namespace user_dashboard.Models
    {
        public class Message : BaseEntity {
            public int MessageId {get; set;}

            public int UserId {get; set;}

            [Required]
            [MinLength(3, ErrorMessage ="Message must be greater than 3 characters!")]
            public string message {get; set;}

            public DateTime created_at {get; set;}

            public List<Comment> Comments {get; set;}

            public Message() {
                Comments = new List<Comment>();
            }
        }
    }