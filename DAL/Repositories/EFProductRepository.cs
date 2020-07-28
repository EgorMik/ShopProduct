using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VI_Home.Common.DTO;
using VI_Home.Common.Entities;
using System.Web.Mvc;

namespace DAL.Repositories
{
    public class EFProductRepository : IProductRepository<ProductDTO>
    {
        ProductContext _context;


        public EFProductRepository(ProductContext context)
        {
            _context = context;
        }
        public IEnumerable<ProductDTO> products
        {
            get { return _context.Products; }
        }

       
        public ProductDTO DeleteProduct(int Id)
        {
            ProductDTO dbEntry = _context.Products.Find(Id);
            if (dbEntry != null)
            {
                _context.Products.Remove(dbEntry);
                _context.SaveChanges();
            }
            return dbEntry;
        }

        public ProductDTO Get(int id)
        {
            return _context.Products.Find(id);
        }

        public void SaveProduct(ProductDTO product)
        {

            if (product.Id == 0)
            {

                _context.Products.Add(new ProductDTO
                {
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    Category = product.Category,
                });

            }

            else
            {

                ProductDTO dbEntry = _context.Products.Find(product.Id);
                if (dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Description = product.Description;
                    dbEntry.Price = product.Price;
                    dbEntry.Category = product.Category;
                }
            }
            _context.SaveChanges();
        }


    }
}
