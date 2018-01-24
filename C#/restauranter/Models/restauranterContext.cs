using Microsoft.EntityFrameworkCore;
 
namespace restauranter.Models
{
    public class restauranterContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public restauranterContext(DbContextOptions<restauranterContext> options) : base(options) { }
    }
}