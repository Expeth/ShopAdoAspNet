using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAdo.Identity.IdentityManagers
{
    public class AppRoleManager<TRole> : RoleManager<TRole> where TRole : class, IRole<string>
    {
        public AppRoleManager(IRoleStore<TRole, string> store) : base(store) { }
    }
}
