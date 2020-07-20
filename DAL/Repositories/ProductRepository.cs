using DAL.EF;

using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VI_Home.Common.Entities;

namespace DAL.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private ProductContext db;

        public ProductRepository(ProductContext context)
        {
            this.db = context;
        }

        public IEnumerable<Product> GetAll()
        {
            return db.Products;
        }

        public Product Get(int id)
        {
            return db.Products.Find(id);
        }

        public void Create(Product book)
        {
            db.Products.Add(book);
        }

        public void Update(Product book)
        {
            db.Entry(book).State = EntityState.Modified;
        }

        public IEnumerable<Product> Find(Func<Product, Boolean> predicate)
        {
            return db.Products.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Product book = db.Products.Find(id);
            if (book != null)
                db.Products.Remove(book);
        }
    }
}
