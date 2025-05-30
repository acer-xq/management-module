using Microsoft.EntityFrameworkCore;

namespace ManagementModule.EntityModel
{
    public class ManagementModuleContext : DbContext
    {
        public ManagementModuleContext(DbContextOptions<ManagementModuleContext> options) : base(options) {
        
        }
        
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
