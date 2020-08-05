using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VI_Home.Common.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string PhoneNumber { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Line1 { get; set; }
        public DateTime Date { get; set; }
    }
}
