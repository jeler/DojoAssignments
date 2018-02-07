    using Microsoft.EntityFrameworkCore;

    namespace user_dashboard.Models
    {
        public class user_dashboardContext : DbContext
        {
            public DbSet<User> Users { get; set; }
            public DbSet<Message> Messages { get; set; }

            public DbSet<Comment> Comments { get; set; }            
            
            public user_dashboardContext(DbContextOptions<user_dashboardContext> options) : base(options) { }
        }
    }