using DAL.EF;

using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VI_Home.Common.DTO;
using VI_Home.Common.Entities;

namespace DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private Repository rep;
        private ProductContext db;
        private EFProductRepository productRepository;
        private OrderRepository orderRepository;
        public EFUnitOfWork()
        {
            db = new ProductContext();
        }

        public IProductRepository<ProductDTO> Products
        {
            get
            {
                if (productRepository == null)
                    productRepository = new EFProductRepository(db);
                return productRepository;
            }
        }

        public IOrderRepository<OrderDTO> Orders
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new OrderRepository(db);
                return orderRepository;
            }
        }
        public IRepository Repo
        {
            get
            {
                if (rep == null)
                    rep = new Repository(db);
                return rep;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
