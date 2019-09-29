using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopAdo.DAL.Repositories
{
    public class PhotoRepository : GenericRepository<Photo>
    {
        public PhotoRepository(ShopAdo context) : base(context) { }
    }
}
