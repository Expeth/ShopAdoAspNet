using Ninject;
using Ninject.Modules;
using ShopAdo.Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopAdoAspNet.Helpers
{
    public class ShopAdoDR : IDependencyResolver
    {
        private readonly IKernel _kernel;

        public ShopAdoDR(IKernel kernel)
        {
            _kernel = kernel;
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }
    }
}