using AutoMapper;
using BLL.Infrastructure;
using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VI_Home.Common.DTO;
using VI_Home.Common.Models;
using VI_Home.Common;
using DAL.Interfaces;
using DAL.Repositories;

namespace VI_Home.Controllers
{
    //[Authorize(Roles = "user")]
    public class HomeController : Controller
    {
        EFUnitOfWork unitofwork;
           ISearchProductService _search;
        
        public HomeController( ISearchProductService search)
        {
            unitofwork = new EFUnitOfWork();
            _search = search;
        }
        public ViewResult Index()
        {
           
            return View(unitofwork.Products.products);
        }
        public ActionResult ProductSearch(string name)
        {
            return PartialView(_search.ProductSearch(name));
        }
    }
}