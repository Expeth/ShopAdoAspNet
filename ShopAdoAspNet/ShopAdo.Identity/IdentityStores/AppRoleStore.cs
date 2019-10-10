using Microsoft.AspNet.Identity.EntityFramework;
using ShopAdo.Identity.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAdo.Identity.IdentityStores
{
    public class AppRoleStore<TRole> : RoleStore<TRole> where TRole: IdentityRole, new()
    {
        public AppRoleStore(AppDbContext context) : base(context) { }

        public AppRoleStore() : base() { }
    }
}
