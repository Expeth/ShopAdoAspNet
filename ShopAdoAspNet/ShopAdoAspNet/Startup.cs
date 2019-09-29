using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopAdoAspNet
{
    public class Startup
    {
        public void Configuration(IAppBuilder builder)
        {
            builder.UseCookieAuthentication(new Microsoft.Owin.Security.Cookies.CookieAuthenticationOptions
            {
                AuthenticationType = "CookieAuth",
                LoginPath = new Microsoft.Owin.PathString("/Auth/Login/")
            });
        }
    }
}