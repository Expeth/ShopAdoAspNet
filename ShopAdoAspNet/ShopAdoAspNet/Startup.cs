using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin;
using ShopAdoAspNet;
using ShopAdo.Identity.DatabaseContext;
using System.Configuration;
using ShopAdo.Identity.IdentityStores;
using ShopAdo.Identity.IdentityModels;
using Microsoft.AspNet.Identity.Owin;
using ShopAdo.Identity.IdentityManagers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security.Cookies;

[assembly:OwinStartup(typeof(Startup), "Configure")]

namespace ShopAdoAspNet
{
    public class Startup
    {
        public void Configure(IAppBuilder app)
        {
            app.CreatePerOwinContext<AppDbContext>((opt, cont) => new AppDbContext(AppDbContext.GetConnectionString()));
            app.CreatePerOwinContext<AppUserStore<AppUser>>((opt, cont) => new AppUserStore<AppUser>(cont.Get<AppDbContext>()));
            app.CreatePerOwinContext<AppUserManager<AppUser>>((opt, cont) => new AppUserManager<AppUser>(cont.Get<AppUserStore<AppUser>>()));
            
            app.CreatePerOwinContext<AppRoleStore<AppRole>>((opt, cont) => new AppRoleStore<AppRole>(cont.Get<AppDbContext>()));
            app.CreatePerOwinContext<AppRoleManager<AppRole>>((opt, cont) => new AppRoleManager<AppRole>(cont.Get<AppRoleStore<AppRole>>()));

            app.CreatePerOwinContext<SignInManager<AppUser, string>>((opt, cont) => new SignInManager<AppUser, string>(cont.Get<AppUserManager<AppUser>>(), cont.Authentication));

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                ExpireTimeSpan = TimeSpan.FromMinutes(15),
                LoginPath = new PathString("/Auth/Login")
            });
        }
    }
}