using Microsoft.AspNet.Identity.EntityFramework;
using ShopAdo.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ShopAdo.Identity.IdentityModels
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public Address Address { get; set; }

        public AppUser() : base() { }

        public AppUser(string username) : base(username) { }
    }
}
