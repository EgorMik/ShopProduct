using BLL.Interfaces;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VI_Home.Common.DTO;

namespace BLL.Services
{
   public class SearchProductService : ISearchProductService
    {
        ProductContext context = new ProductContext();
        public List<ProductDTO> ProductSearch(string search)
        {
            var allproducts = context.Products.Where(a => a.Name.Contains(search)).ToList();

            return allproducts;
        }

      
    }
}
