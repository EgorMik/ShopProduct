using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VI_Home.Common.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        public string Category { get; set; }

        public int? OrdertId { get; set; }
        public OrderDTO OrdersDTO { get; set; }
    }
}
