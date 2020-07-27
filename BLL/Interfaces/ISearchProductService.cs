using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VI_Home.Common.DTO;

namespace BLL.Interfaces
{
    public interface ISearchProductService
    {
        List<ProductDTO> ProductSearch(string search);
    }
}
