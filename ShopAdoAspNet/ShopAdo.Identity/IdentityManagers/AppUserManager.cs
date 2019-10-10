using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ShopAdo.Identity.IdentityStores;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopAdo.Identity.IdentityManagers
{
    public class AppUserManager<TUser> : UserManager<TUser> where TUser : class, IUser<string>
    {
        public AppUserManager(IUserStore<TUser> store) : base(store) { }
    }
}
