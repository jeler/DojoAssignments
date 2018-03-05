 using Microsoft.EntityFrameworkCore;

    namespace bright_ideas.Models
    {
        public class bright_ideasContext : DbContext
        {
            public DbSet<User> Users { get; set; }
            public DbSet<Idea> Ideas { get; set; }

            public DbSet<Like> Likes { get; set; }
            
            
            public bright_ideasContext(DbContextOptions<bright_ideasContext> options) : base(options) { }
        }
    }