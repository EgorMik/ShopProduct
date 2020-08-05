using AutoMapper;
using DAL.Interfaces;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VI_Home.Common.DTO;
using VI_Home.Common.Models;

namespace VI_Home.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : BaseController
    {
        EFUnitOfWork unitOfWork;

        public AdminController()
        {
            unitOfWork = new EFUnitOfWork();
        }

        public ViewResult Create()
        {
            return View("Edit", Mapper.Map<ProductViewModel>(new ProductDTO()));
        }

        public ViewResult Index()
        {
            return View(Mapper.Map<List<ProductViewModel>>(unitOfWork.Products.products));
        }

        public ViewResult Edit(int Id)
        {
            return View(Mapper.Map<ProductViewModel>(unitOfWork.Products.products.FirstOrDefault(g => g.Id == Id)));
        }

        [HttpPost]
        public ActionResult Edit(ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Products.SaveProduct(Mapper.Map<ProductViewModel, ProductDTO>(product));
                TempData["message"] = string.Format("Изменения товара \"{0}\" были сохранены", product.Name);
                return RedirectToAction("Index");
            }
            else
            {

                return View(product);
            }
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            ProductDTO deletedproduct = unitOfWork.Products.DeleteProduct(Id);
            if (deletedproduct != null)
            {
                TempData["message"] = string.Format("Товар  \"{0}\" был удален",
                    deletedproduct.Name);
            }
            return RedirectToAction("Index");
        }
    }
}