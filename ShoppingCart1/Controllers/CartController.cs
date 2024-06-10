using Microsoft.AspNetCore.Mvc;
using ShoppingCartLibrary;

namespace ShoppingCart1.Controllers
{
    public class CartController : Controller { 
     private readonly ICartDataAccess _cartDataAccess;

    public CartController(ICartDataAccess cartDataAccess)
    {
        _cartDataAccess = cartDataAccess;
    }

    [HttpPost]
        public IActionResult AddToCart(int productId)
        {
            var product = _cartDataAccess.GetProductById(productId);
            if (product != null)
            {
                var existingCartItem = _cartDataAccess.GetCartItemById(productId);

                if (existingCartItem != null)
                {
                    TempData["Message"] = "Product already exists in the cart.";
                    return RedirectToAction("ViewCart", "Cart");
                }

                var cartItem = new CartItem
                {
                    Id = product.Id,
                    productName = product.productName,
                    productDescription = product.productDescription,
                    price = product.price,
                    imageUrl = product.imageUrl,
                    categoryName = product.categoryName,
                    quantity = 1
                };

                _cartDataAccess.AddToCart(cartItem);
                TempData["Message"] = "Product added to cart successfully.";
            }

            return RedirectToAction("ViewCart", "Cart");
        }


        public IActionResult ViewCart()
    {
        var cartItems = _cartDataAccess.GetCartItems();
        return View(cartItems);
    }

    [HttpGet]
    public IActionResult RemoveFromCart(int Id)
    {
        _cartDataAccess.RemoveFromCart(Id);
        return RedirectToAction("ViewCart");
    }
    public IActionResult EditCart(int Id)
    {
        var cartItem = _cartDataAccess.GetCartItemById(Id);
        return View(cartItem);

    }
    [HttpPost]
    public IActionResult EditCart(CartItem cItem)
    {
        var cartItem = _cartDataAccess.GetCartItemById(cItem.Id);
        if (cartItem != null)
        {
            cartItem.quantity = cItem.quantity;
            _cartDataAccess.EditCart(cartItem);
        }
        //return View(cartItem);
        return RedirectToAction("ViewCart");
    }



    public IActionResult ProductDetails(int Id)
    {
        var cartprod = _cartDataAccess.GetProductById(Id);
        return View(cartprod);
    }

    public IActionResult Checkout()
    {
        decimal totalPrice = _cartDataAccess.GetTotalPrice();
        // Perform checkout process (e.g., payment, order creation)
        // Clear cart after checkout
        //  _cartDataAccess.ClearCart();
        return View(totalPrice);
    }
}

}
