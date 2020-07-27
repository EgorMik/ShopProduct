
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VI_Home.Common.DTO;
using VI_Home.Common.Entities;

namespace DAL.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<ProductDTO> Products { get; }
        void SaveProduct(ProductDTO productview);
        ProductDTO DeleteProduct(int Id);
     
    }
}
