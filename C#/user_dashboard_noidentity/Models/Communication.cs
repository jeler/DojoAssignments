using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace user_dashboard.Models {
    public class Message : BaseEntity {
        public int MessageId { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
        public int ReceiverId { get; set; }


        [Required]
        [MinLength (3, ErrorMessage = "Message must be greater than 3 characters!")]
        public string message { get; set; }

        public DateTime created_at { get; set; }

        public List<Comment> Comments { get; set; }

        public Message () {
            Comments = new List<Comment> ();
        }
    }
    public class Comment : BaseEntity {

        public int CommentId { get; set; }

        public int MessageId { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        [Required]
        [MinLength (3, ErrorMessage = "Comment must be greater than 3 characters!")]
        public string comment { get; set; }

        public DateTime created_at { get; set; }
    }
    public class CommunicationViewModels 
    {
        public Message Mess {get; set;}

        public Comment Comm {get; set;}
    }
}