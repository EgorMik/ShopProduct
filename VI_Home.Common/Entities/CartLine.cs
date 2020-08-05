using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VI_Home.Common.DTO;

namespace VI_Home.Common.Entities
{
   public class CartLine
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public ProductDTO Product { get; set; }
        
    }
}
