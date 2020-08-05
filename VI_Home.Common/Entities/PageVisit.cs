using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace VI_Home.Common.Entities
{
   public class PageVisit
    {
        public int Id { get; set; }
        public string PageUrl { get; set; }
        public int Visits { get; set; }
    }
}
