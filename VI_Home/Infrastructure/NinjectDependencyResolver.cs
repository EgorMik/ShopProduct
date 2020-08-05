using BLL.Interfaces;
using BLL.Services;
using DAL.Interfaces;
using DAL.Repositories;
using Ninject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VI_Home.Common.DTO;
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
           
            kernel.Bind<IUnitOfWork>().To<EFUnitOfWork>();
            kernel.Bind<IProductRepository<ProductDTO>>().To<EFProductRepository>();
            kernel.Bind<IOrderService>().To<OrderService>();
            kernel.Bind<ISearchProductService>().To<SearchProductService>();
            kernel.Bind<IClientManager>().To<ClientManager>();
            kernel.Bind<IUnitOfWork1>().To<IdentityUnitOfWork>();
            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IServiceCreator>().To<ServiceCreator>();
            EmailSettings emailSettings = new EmailSettings
            {
                WriteAsFile = bool.Parse(ConfigurationManager
                  .AppSettings["Email.WriteAsFile"] ?? "false")
            };

            kernel.Bind<IOrderProcessor>().To<EmailOrderProcessor>()
                .WithConstructorArgument("settings", emailSettings);
        }
    }
}
