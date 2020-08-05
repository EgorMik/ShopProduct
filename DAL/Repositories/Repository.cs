using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VI_Home.Common.Entities;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web;

namespace DAL.Repositories
{
   public class Repository : IRepository
    {
        private ProductContext db;
        public Repository(ProductContext context)
        {
            db = context;
        }
       public PageVisit GetPageByUrl(System.Uri basse)
        {
            return db.PageVisits.Find(basse);
        }
        public void Update(PageVisit page)
        {
            db.Entry(page).State = EntityState.Modified;
        }
        public void Save(PageVisit visitPage)
        {

            db.PageVisits.Add(new PageVisit
            {
                PageUrl = visitPage.PageUrl,
                Visits = visitPage.Visits
                });

            }
        }
}
