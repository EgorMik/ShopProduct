using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
   public interface ICart
    {

        void AddItem(Product product, int quantity);
        void RemoveLine(Product product);
        decimal ComputeTotalValue();
        void Clear();
        IEnumerable<CartLine> Lines
        {
            get;
        }
    }
}
