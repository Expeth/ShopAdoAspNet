using Microsoft.AspNet.Identity.EntityFramework;
using ShopAdo.Identity.IdentityModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAdo.Identity.DatabaseContext
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(string connectionString) : base(connectionString) { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUser>();

            base.OnModelCreating(modelBuilder);
        }

        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["identityDB"].ConnectionString;
        }
    }
}
