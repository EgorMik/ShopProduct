using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VI_Home.Common.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime? Date { get; set; }
        public ICollection<ProductDTO> Products { get; set; }
        public ICollection<UserDTO> Users { get; set; }
        public OrderDTO()
        {
           Users = new List<UserDTO>();
           Products = new List<ProductDTO>();
        }
    }
}
