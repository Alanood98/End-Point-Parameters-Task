using Microsoft.EntityFrameworkCore;

using EndPointParametersTask.Models;

namespace EndPointParametersTask
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        
    }
}
