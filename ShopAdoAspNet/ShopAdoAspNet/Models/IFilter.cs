using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAdoAspNet.Models
{
    public interface IFilter<T> where T : class
    {
        bool Equals(T obj);
    }
}
