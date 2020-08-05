using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VI_Home.Common.DTO;
using VI_Home.Common.Entities;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository Repo { get; }
        IProductRepository<ProductDTO> Products { get; }
        IOrderRepository<OrderDTO> Orders { get; }
        void Save();
    }
}
