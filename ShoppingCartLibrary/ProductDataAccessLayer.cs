using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartLibrary
{
  public class ProductDataAccessLayer : IProductDataAccess { 
        private readonly ShoppingDbContext _productDbContext;
    public ProductDataAccessLayer(ShoppingDbContext productDbContext)
    {
        _productDbContext = productDbContext;
    }
   
        public List<Product> GetProduct()
        {
            var records = _productDbContext.Products.ToList();
            return records;
        }
        /// <summary>
        /// to get a product by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Product GetProductById(int id)
        {
            var record = _productDbContext.Products.Find(id);
            return record;
        }
    }
}
