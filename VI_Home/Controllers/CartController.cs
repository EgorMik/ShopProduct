
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

        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }


        public RedirectToRouteResult AddToCart(Cart cart,int Id, string returnUrl)
            {
                Product product = repository.Products
                    .FirstOrDefault(g => g.Id == Id);

                if (product != null)
                {
                    cart.AddItem(product, 1);
                }
                return RedirectToAction("Index", new { returnUrl });
            }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int Id, string returnUrl)
        {
            Product game = repository.Products
                .FirstOrDefault(g => g.Id == Id);

            if (game != null)
            {
                cart.RemoveLine(game);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
        {
            return View(new ShippingDetails());
        }
    }
 }