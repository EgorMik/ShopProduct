
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VI_Home.Common.Entities;

namespace DAL.EF
{
    public class ProductContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        static ProductContext()
        {
            Database.SetInitializer<ProductContext>(new StoreDbInitializer());
        }
        public ProductContext(string connectionString)
            : base(connectionString)
        {
        }
    }

    public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<ProductContext>
    {
        protected override void Seed(ProductContext db)
        {
            db.Products.Add(new Product { Name = "Духовой шкаф", Company = "Bosch", Price = 220 });
            db.Products.Add(new Product { Name = "Варочная панель", Company = "Gefest", Price = 320 });
            db.Products.Add(new Product { Name = "Вытяжная система", Company = "Bosch", Price = 260 });
            db.Products.Add(new Product { Name = "Посудомоечная машина", Company = "Samsung", Price = 300 });
            db.Products.Add(new Product { Name = "Посудомоечная машина", Company = "Bosch", Price = 400 });
            db.Products.Add(new Product { Name = "Холодильник", Company = "Atlant", Price = 400 });
            db.SaveChanges();
        }
    }
}
