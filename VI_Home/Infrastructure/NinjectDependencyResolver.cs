using BLL.Interfaces;
using BLL.Services;
using DAL.Interfaces;
using DAL.Repositories;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VI_Home.Common.Entities;

namespace VI_Home.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<IOrderService>().To<OrderService>();
            kernel.Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument("ProductContext");
            kernel.Bind<IProductRepository>().To<EFProductRepository>();
            kernel.Bind<IRepository<Product>>().To<ProductRepository>();
            kernel.Bind<IRepository<Order>>().To<OrderRepository>();
            kernel.Bind<IClientManager>().To<ClientManager>();
            kernel.Bind<IUnitOfWork1>().To<IdentityUnitOfWork>();
            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IServiceCreator>().To<ServiceCreator>();
        }
    }
}