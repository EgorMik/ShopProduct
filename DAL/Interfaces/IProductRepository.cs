
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VI_Home.Common.DTO;
using VI_Home.Common.Entities;

namespace DAL.Interfaces
{
    public interface IProductRepository<T> where T : class
    {
         T Get(int id);
        IEnumerable<T> products { get; }
        void SaveProduct(T item);
        ProductDTO DeleteProduct(int Id);
     
    }
}
