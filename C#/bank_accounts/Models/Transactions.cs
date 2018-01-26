using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace bank_accounts.Models
{
    public class Transactions : BaseEntity
    {
        public Transactions() {
            this.created_at = DateTime.Now;
        }
        [Key]
        public long Id { get; set; }
 
 
        [Required]
        public int amount {get; set;}

        public long Userid {get; set;}

        public DateTime created_at{get; set;} 
    }
}