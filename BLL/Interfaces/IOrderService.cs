using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IOrderService
    {
        void MakeOrder(OrderDTO orderDto);
        ProductDTO GetPhone(int? id);
        IEnumerable<ProductDTO> GetPhones();
        void Dispose();
    }
}
