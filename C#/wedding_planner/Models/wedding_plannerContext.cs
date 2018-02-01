 using Microsoft.EntityFrameworkCore;

    namespace wedding_planner.Models
    {
        public class wedding_plannerContext : DbContext
        {
            public DbSet<User> Users { get; set; }
            public DbSet<Wedding> Weddings {get; set;}

            public DbSet<RSVP> RSVPS {get; set;}
            public wedding_plannerContext(DbContextOptions<wedding_plannerContext> options) : base(options) { }
        }
    }
