
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VI_Home.Common.DTO;
using VI_Home.Common.Entities;

namespace BLL.Interfaces
{
    public interface IOrderService
{
        void MakeOrder(string id, Cart cart, CartLine cartline);
        //ClientProfile GetProduct(int? id);
        //IEnumerable<ClientProfile> GetProducts();
        void Dispose();
    }
}
