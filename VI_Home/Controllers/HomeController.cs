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
        IProductRepository repository;
        public HomeController(IProductRepository rep)
        {
            repository = rep;
        }
        public ViewResult Index()
        {
           
            return View(repository.Products);
        }
    }
}