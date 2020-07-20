using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VI_Home.Common.Models
{
    public class OrderViewModel
    {
        public int ProductId { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}