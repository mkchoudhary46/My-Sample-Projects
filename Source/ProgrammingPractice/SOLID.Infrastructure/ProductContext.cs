using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using SOLID.Core.DAO;

namespace SOLID.Repository
{
    public class ProductContext : DbContext, IProductContext
    {
        static ProductContext()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<ProductContext>());
        }

        public ProductContext()
            : base("name=ProductAppConnectionString")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
        public DbSet<Product> Products { get; set; }
    }

    public interface IProductContext
    {
        DbSet<Product> Products { get; set; }
        int SaveChanges();
    }
}
