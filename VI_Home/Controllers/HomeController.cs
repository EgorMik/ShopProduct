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

namespace VI_Home.Controllers
{
    public class HomeController : Controller
    {
        ISearchProductService _search;
        IProductRepository repository;
        public HomeController(IProductRepository rep, ISearchProductService search)
        {
            repository = rep;
            _search = search;
        }
        public ViewResult Index()
        {
           
            return View(repository.Products);
        }
        public ActionResult ProductSearch(string name)
        {
            return PartialView(_search.ProductSearch(name));
        }
    }
}