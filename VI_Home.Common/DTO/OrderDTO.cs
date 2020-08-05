using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VI_Home.Common.Entities;

namespace VI_Home.Common.DTO
{
    public class OrderDTO
    {
      
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime? Date { get; set; }
        public string ClientProfileId { get; set; }
        public ClientProfile ClientProfile { get; set; }
        public virtual ICollection<CartLine> Products { get; set; }
        public ProductDTO ProductDTO { get; set; }

    }
}
