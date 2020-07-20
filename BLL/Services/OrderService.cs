using AutoMapper;
using BLL.BusinessModels;
using BLL.DTO;
using BLL.Infrastructure;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class OrderService : IOrderService
    {
        IUnitOfWork Database { get; set; }

        public OrderService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public void MakeOrder(OrderDTO orderDto)
        {
            Product product = Database.Products.Get(orderDto.ProductId);

            // валидация
            if (product == null)
                throw new ValidationException("Телефон не найден", "");
            // применяем скидку
            decimal sum = new Discount(0.1m).GetDiscountedPrice(product.Price);
            Order order = new Order
            {
                Date = DateTime.Now,
                Address = orderDto.Address,
                ProductId = product.Id,
                Sum = sum,
                PhoneNumber = orderDto.PhoneNumber
            };
            Database.Orders.Create(order);
            Database.Save();
        }

        public IEnumerable<ProductDTO> GetPhones()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Product>, List<ProductDTO>>(Database.Products.GetAll());
        }

        public ProductDTO GetPhone(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id телефона", "");
            var phone = Database.Products.Get(id.Value);
            if (phone == null)
                throw new ValidationException("Телефон не найден", "");

            return new ProductDTO { Company = phone.Company, Id = phone.Id, Name = phone.Name, Price = phone.Price };
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
