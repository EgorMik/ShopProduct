
using BLL.Interfaces;
using BLL.Services;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.AspNet.Identity;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VI_Home.Common.DTO;
using VI_Home.Common.Entities;
using VI_Home.Common.Models;


namespace VI_Home.Controllers
{
    [Authorize]
    public class CartController : Controller
        {
        private IOrderService _orderService;
        private EFUnitOfWork unitofwork;
        private IOrderProcessor _orderProcessor;

        public CartController(
        IOrderProcessor orderProcessor,
        IOrderService orderService)
        {
            _orderService = orderService;
            unitofwork = new EFUnitOfWork();
         _orderProcessor = orderProcessor;
        }
       
        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

        public RedirectToRouteResult AddToCart(Cart cart, int Id, string returnUrl)
            {
            
            
                ProductDTO product = unitofwork.Products.products
                    .FirstOrDefault(g => g.Id == Id);

                if (product != null)
                {
                cart.AddItem(product, 1);
                }
                return RedirectToAction("Index", new { returnUrl });
            }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int Id, string returnUrl)
        {
            ProductDTO product = unitofwork.Products.products
                .FirstOrDefault(g => g.Id == Id);

            if (product != null)
            {
                cart.RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

      
        public ViewResult Checkout()
        {
            return View(new ShippingDetails());
        }
 
        [HttpPost]
        public ViewResult Checkout(Cart cart, CartLine cartline, ShippingDetails shippingDetails /*UserDTO user*/)
        {


            var id = User.Identity.GetUserId();
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Извините, ваша корзина пуста!");
            }

            if (ModelState.IsValid)
            {
                //_orderProcessor.ProcessOrder(cart, shippingDetails);
                _orderService.MakeOrder(id, cart, cartline);
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(shippingDetails);
            }
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