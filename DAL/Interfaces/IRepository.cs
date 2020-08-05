using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VI_Home.Common.Entities;

namespace DAL.Interfaces
{
    public interface IRepository
    {
        PageVisit GetPageByUrl(System.Uri basse);
        void Update(PageVisit page);
        void Save(PageVisit visitPage);
    }
}
