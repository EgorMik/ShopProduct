using DAL.EF;

using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VI_Home.Common.DTO;
using VI_Home.Common.Entities;

namespace DAL.Repositories
{
    public class EFProductRepository : IProductRepository
    {
        ProductContext context = new ProductContext();

        public IEnumerable<ProductDTO> Products
        {
            get { return context.Products; }
        }

        public ProductDTO DeleteProduct(int Id)
        {
            ProductDTO dbEntry = context.Products.Find(Id);
            if (dbEntry != null)
            {
                context.Products.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public void SaveProduct(ProductDTO product)
        {

            if (product.Id == 0)
            {

                context.Products.Add(new ProductDTO
                {
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    Category = product.Category,
                });

            }

            else
            {

                ProductDTO dbEntry = context.Products.Find(product.Id);
                if (dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Description = product.Description;
                    dbEntry.Price = product.Price;
                    dbEntry.Category = product.Category;
                }
            }
            context.SaveChanges();
        }


    }
}
