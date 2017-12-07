using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Adikov.Domain.Models;
using Adikov.Platform.Configuration;

namespace Adikov.Domain.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Table> Tables { get; set; }

        public DbSet<Column> Columns { get; set; }

        public DbSet<File> Files { get; set; }

        public ApplicationDbContext() : base(PlatformConfiguration.ConnectionString, throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}