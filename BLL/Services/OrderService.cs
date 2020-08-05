using AutoMapper;
using BLL.BusinessModels;
using BLL.Infrastructure;
using BLL.Interfaces;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VI_Home.Common.DTO;
using VI_Home.Common.Entities;
using Microsoft.AspNet.Identity;
using DAL.Identity;


namespace BLL.Services
{
    public class OrderService : IOrderService
    {
        IUnitOfWork Database { get; set; }

        public OrderService(IUnitOfWork uow)
        {
            Database = uow;
        }
        
        public void MakeOrder(string id, Cart cart, CartLine cartline)
        {
            ProductDTO product = Database.Products.Get(cartline.Id);
         

            OrderDTO order = new OrderDTO
            {
                ClientProfileId = id,
            };
            Database.Orders.Create(order);
            Database.Save();
        }
        
        public void Dispose()
        {
            Database.Dispose();
        }
        
    }
}
