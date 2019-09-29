using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAdo.BLL.DTO
{
    public class PhotoDTO
    {
        public int PhotoId { get; set; }
        public int? GoodId { get; set; }
        public string PhotoPath { get; set; }
    }
}
