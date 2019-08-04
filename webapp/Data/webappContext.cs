using Microsoft.EntityFrameworkCore;

namespace webapp.Models
{
    public class webappContext : DbContext
    {
        public webappContext (DbContextOptions<webappContext> options)
            : base(options)
        {
        }

        public DbSet<webapp.Models.Temperature> Temperature { get; set; }
    }
}