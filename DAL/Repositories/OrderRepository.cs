
using DAL.EF;

using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VI_Home.Common.DTO;
using VI_Home.Common.Entities;

namespace DAL.Repositories
{
    public class OrderRepository : IOrderRepository<OrderDTO>
    {
        private ProductContext db;

        public OrderRepository(ProductContext context)
        {
            this.db = context;
        }

        public IEnumerable<OrderDTO> GetAll()
        {
            return db.Orders.Include(o => o.Products);
        }

        public OrderDTO Get(int id)
        {
            return db.Orders.Find(id);
        }

        public void Create(OrderDTO order)
        {
            db.Orders.Add(order);
        }

        public void Update(OrderDTO order)
        {
            db.Entry(order).State = EntityState.Modified;
        }
        public IEnumerable<OrderDTO> Find(Func<OrderDTO, Boolean> predicate)
        {
            return db.Orders.Include(o => o.Products).Where(predicate).ToList();
        }
        public void Delete(int id)
        {
            OrderDTO order = db.Orders.Find(id);
            if (order != null)
                db.Orders.Remove(order);
        }
    }
}