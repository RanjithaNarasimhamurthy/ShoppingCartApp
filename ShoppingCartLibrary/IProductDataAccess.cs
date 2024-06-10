using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartLibrary
{
    public interface IProductDataAccess
    {
        List<Product> GetProduct();
        Product GetProductById(int id);
    }
}
