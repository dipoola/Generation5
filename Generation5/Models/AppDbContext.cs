using Microsoft.EntityFrameworkCore;

namespace Generation5.Models
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)

        {
        }

       
        public DbSet<Hotel>Hotels { get; set; } 

      
    }
}
