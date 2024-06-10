using Microsoft.AspNetCore.Mvc;
using ShoppingCart1.Models;
using ShoppingCartLibrary;
using System.Diagnostics;

namespace ShoppingCart1.Controllers
{
    public class ProductController : Controller
    {
        public readonly IProductDataAccess _dal;
        // public  readonly IProductDataAccess _productData;
        private readonly ICartDataAccess _cartData;
        private readonly ShoppingDbContext _shoppingDbContext;
        public ProductController(IProductDataAccess dal, ICartDataAccess cartData, ShoppingDbContext shoppingDbContext)
        {
            _dal = dal;
            _cartData = cartData;
            _shoppingDbContext = shoppingDbContext;
        }
        //public IActionResult Search(string searchKeyword)
        //{
        //    var products = _dal.Products
        //    .Where(p => p.Category.Contains(searchKeyword))
        //    .ToList();

        //    return View(products);
        //}

        // Action to display product details
        public IActionResult Details()
        {
            List<Product> productList = _dal.GetProduct();
            return View(productList);
        }
        public IActionResult Search(string searchKeyword)
        {
             
            var products = _shoppingDbContext.Products
                .Where(p => p.categoryName.Contains(searchKeyword))
                .ToList();
if(products.Count > 0) { return View(products); }
            
           else  {
                TempData["SearchMessage"] = "Product Category doesnot exist!.";
                return RedirectToAction("Details","Product"); }
        }
            [HttpPost]
        public IActionResult AddToCart(int productId)
        {
            var product = _dal.GetProductById(productId);
            if (product != null)
            {
                _cartData.AddToCart(new CartItem
                {
                    Id = product.Id,
                    productName = product.productName,
                    productDescription = product.productDescription,
                    price = product.price,
                    imageUrl = product.imageUrl,
                    categoryName = product.categoryName,
                    quantity = 1 // You can set the initial quantity here
                });
            }

            return RedirectToAction("ViewCart", "Cart");
        }
    }

}