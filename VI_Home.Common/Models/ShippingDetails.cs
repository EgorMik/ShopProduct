using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VI_Home.Common.Entities
{
    public class ShippingDetails
    {
    
        public string Name { get; set; }

      
        [Display(Name = "Первый адрес")]
        public string Line1 { get; set; }

        [Display(Name = "Второй адрес")]
        public string Line2 { get; set; }

        [Display(Name = "Третий адрес")]
        public string Line3 { get; set; }

 
        [Display(Name = "Город")]
        public string City { get; set; }

       
        [Display(Name = "Страна")]
        public string Country { get; set; }

        public bool GiftWrap { get; set; }

    }
}
