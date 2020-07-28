using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VI_Home.Common.DTO;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository<ProductDTO> Products { get; }
        IOrderRepository<OrderDTO> Orders { get; }
        void Save();
    }
}
