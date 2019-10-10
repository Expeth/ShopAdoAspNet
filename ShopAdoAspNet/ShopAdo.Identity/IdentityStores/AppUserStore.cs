using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopAdo.Identity.DatabaseContext;

namespace ShopAdo.Identity.IdentityStores
{
    public class AppUserStore<TUser> : UserStore <TUser> where TUser: IdentityUser
    {
        public AppUserStore(AppDbContext context) : base(context) { }

        public AppUserStore() : base() { }
    }
}
