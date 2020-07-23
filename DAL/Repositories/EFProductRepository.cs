using DAL.EF;

using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VI_Home.Common.Entities;

namespace DAL.Repositories
{
    public class EFProductRepository : IProductRepository
    {
        ProductContext context = new ProductContext("DefaultConnection");

        public IEnumerable<Product> Products
        {
            get { return context.Products; }
        }
    }
}
