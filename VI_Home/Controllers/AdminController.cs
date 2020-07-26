using AutoMapper;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VI_Home.Common.DTO;
using VI_Home.Common.Models;

namespace VI_Home.Controllers
{
    public class AdminController : Controller
    {
        IProductRepository repository;

        public AdminController(IProductRepository repo)
        {
            repository = repo;
        }
        public ViewResult Create()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ProductDTO, ProductViewModel>());
            // Настройка AutoMapper
            var mapper = new Mapper(config);
            // сопоставление
            var model = mapper.Map<ProductViewModel>(new ProductDTO());
            return View("Edit", model);
        }
        public ViewResult Index()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ProductDTO, ProductViewModel>());
            // Настройка AutoMapper
            var mapper = new Mapper(config);
            // сопоставление
            var model = mapper.Map<List<ProductViewModel>>(repository.Products);
            return View(model);
        }
        public ViewResult Edit(int Id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ProductDTO, ProductViewModel>());
            // Настройка AutoMapper
            var mapper = new Mapper(config);
            // сопоставление
            var model1 = mapper.Map<ProductViewModel>(repository.Products.FirstOrDefault(g => g.Id == Id));

            return View(model1);
        }
        [HttpPost]
        public ActionResult Edit(ProductViewModel product)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ProductViewModel, ProductDTO>());
            // Настройка AutoMapper
            var mapper = new Mapper(config);
            // сопоставление
            var prdto = mapper.Map<ProductViewModel, ProductDTO>(product);
            if (ModelState.IsValid)
            {
                repository.SaveProduct(prdto);
                TempData["message"] = string.Format("Изменения товара \"{0}\" были сохранены", product.Name);
                return RedirectToAction("Index");
            }
            else
            {

                return View(product);
            }
        }
    }
}