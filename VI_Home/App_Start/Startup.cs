using BLL.Interfaces;
using BLL.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNet;

[assembly: OwinStartup(typeof(VI_Home.App_Start.Startup))]

namespace VI_Home.App_Start
{
    public class Startup
    {
            IServiceCreator serviceCreator = new ServiceCreator();
        public void Configuration(IAppBuilder app)
        {
            
            app.CreatePerOwinContext<IUserService>(CreateUserService);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });
            //app.Use<CountMiddleware>();
        }

        private IUserService CreateUserService()
        {
            return serviceCreator.CreateUserService("DbConnection");
        }
    }
    
}