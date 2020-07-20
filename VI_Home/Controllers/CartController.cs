
using DAL.Interfaces;
using DAL.Repositories;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VI_Home.Common.Entities;
using VI_Home.Common.Models;

namespace VI_Home.Controllers
{
    
        public class CartController : Controller
        {
            private IProductRepository repository;
            public CartController()
            {
            IKernel ninjectKernel = new StandardKernel();
            ninjectKernel.Bind<IProductRepository>().To<EFProductRepository>();
            repository = ninjectKernel.Get<IProductRepository>();
        }

        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = GetCart(),
                ReturnUrl = returnUrl
            });
        }


        public RedirectToRouteResult AddToCart(int Id, string returnUrl)
            {
                Product product = repository.Products
                    .FirstOrDefault(g => g.Id == Id);

                if (product != null)
                {
                    GetCart().AddItem(product, 1);
                }
                return RedirectToAction("Index", new { returnUrl });
            }

            public RedirectToRouteResult RemoveFromCart(int Id, string returnUrl)
            {
              
                Product product = repository.Products
                     .FirstOrDefault(g => g.Id == Id);

            if (product != null)
                {
                    GetCart().RemoveLine(product);
                }
                return RedirectToAction("Index", new { returnUrl });
            }

            public Cart GetCart()
            {
                Cart cart = (Cart)Session["Cart"];
                if (cart == null)
                {
                    cart = new Cart();
                    Session["Cart"] = cart;
                }
                return cart;
            }
        }
 }