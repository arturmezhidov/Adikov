using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Adikov.Domain.Models;
using Adikov.Platform.Configuration;

namespace Adikov.Domain.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<ProductAttribute> ProductAttributes { get; set; }

        public DbSet<Product> Products { get; set; }

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