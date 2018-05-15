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

        public DbSet<TableColumn> TableColumns { get; set; }

        public DbSet<Row> Rows { get; set; }

        public DbSet<Cell> Cells { get; set; }

        public DbSet<File> Files { get; set; }

        public DbSet<FaqCategory> FaqCategories { get; set; }

        public DbSet<FaqItem> FaqItems { get; set; }

        public DbSet<FaqRequest> FaqRequests { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<Setting> Settings { get; set; }

        public DbSet<Blog> Blogs { get; set; }

        public ApplicationDbContext() : base(PlatformConfiguration.ConnectionString, throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}