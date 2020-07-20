using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VI_Home.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public decimal Price { get; set; }
    }
}