using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace bright_ideas.Models {
    public class Like: BaseEntity {

    public int LikeId {get; set;}

    public int UserId {get; set;}
    public User User {get; set;}

    public int IdeaId {get; set;}
    public Idea Idea {get; set;}
    }
}