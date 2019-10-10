using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAdo.Identity.IdentityModels
{
    public class AppRole : IdentityRole
    {
        public AppRole(string rolename) : base(rolename) { }

        public AppRole() : base() { }
    }
}
