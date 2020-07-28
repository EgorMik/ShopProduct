using DAL.EF;

using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VI_Home.Common.Entities;

namespace DAL.Repositories
{
    public class EFUnitOfWork /*: IUnitOfWork*/
    {
        //private ProductContext db;
        //private EFProductRepository productRepository;
        //private OrderRepository orderRepository;

        //public EFUnitOfWork()
        //{
        //    db = new ProductContext();
        //}
        //public IRepository<Product> Products
        //{
        //    get
        //    {
        //        if (productRepository == null)
        //            productRepository = new ProductRepository(db);
        //        return productRepository;
        //    }
        //}

        //public IRepository<Order> Orders
        //{
        //    get
        //    {
        //        if (orderRepository == null)
        //            orderRepository = new OrderRepository(db);
        //        return orderRepository;
        //    }
        //}



        //public void Save()
        //{
        //    db.SaveChanges();
        //}

        //private bool disposed = false;

        //public virtual void Dispose(bool disposing)
        //{
        //    if (!this.disposed)
        //    {
        //        if (disposing)
        //        {
        //            db.Dispose();
        //        }
        //        this.disposed = true;
        //    }
        //}

        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}
    }
}
