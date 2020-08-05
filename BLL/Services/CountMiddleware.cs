using BLL.Interfaces;
using DAL.EF;
using DAL.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using VI_Home.Common.Entities;

namespace BLL.Services
{
    public class CountMiddleware : ActionFilterAttribute
    {
        EFUnitOfWork _unit;
        public CountMiddleware(EFUnitOfWork unit)
        {
        _unit = unit;
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);


            PageVisit page = new PageVisit();

            var pageUrl = filterContext.HttpContext.Request.Url;

            var pages = _unit.Repo.GetPageByUrl(pageUrl);
            if (page == null)
            {
                page = new PageVisit {/* PageUrl = pageUrl, Visits = 1 */};
                _unit.Repo.Save(page);
            }
            else
            {
                page.Visits++;
                _unit.Repo.Update(pages);
            }
        }


    }
}
