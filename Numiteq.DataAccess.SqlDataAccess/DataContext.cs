using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Numiteq.Common.Entities;

namespace Numiteq.DataAccess.SqlDataAccess
{
    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Expertise> Expertises { get; set; }

        public DbSet<File> Files { get; set; }

        public DbSet<MainService> MainServices { get; set; }

        public DbSet<Number> Numbers { get; set; }

        public DbSet<Service> Services { get; set; }

        public DbSet<Setting> Settings { get; set; }

        public DbSet<Step> Steps { get; set; }

        public DbSet<Technology> Technologies { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
