using AutoMapper;
using Ninject;
using ShopAdo.BLL.DTO;
using ShopAdo.Ninject;
using ShopAdoAspNet.Helpers;
using ShopAdoAspNet.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ShopAdoAspNet
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            var ninjectModule = new ShopAdoNinjectModule();
            DependencyResolver.SetResolver(new ShopAdoDR(new StandardKernel(ninjectModule)));
        }
    }
}
