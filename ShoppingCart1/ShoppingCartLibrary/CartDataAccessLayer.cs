using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartLibrary
{
    public class CartDataAccessLayer : ICartDataAccess
    {
        private readonly ShoppingDbContext _cartDbContext;

        public CartDataAccessLayer(ShoppingDbContext cartDbContext)
        {
            _cartDbContext = cartDbContext;
        }
        public void AddToCart(CartItem cartItem)
        {
            _cartDbContext.CartItems.Add(cartItem);
            _cartDbContext.SaveChanges();
        }

        public void EditCart(CartItem cartItem)
        {
            var existingCartItem = _cartDbContext.CartItems.Find(cartItem.Id);
            if (existingCartItem != null)
            {
                existingCartItem.quantity = cartItem.quantity;
                _cartDbContext.SaveChanges();
            }
        }

        public CartItem GetCartItemById(int Id)
        {
            return _cartDbContext.CartItems.Find(Id);
        }

        public List<CartItem> GetCartItems()
        {
            return _cartDbContext.CartItems.ToList();
        }

        public Product GetProductById(int productId)
        {
            return _cartDbContext.Products.Find(productId);
        }

        public decimal GetTotalPrice()
        {
            {
                var cartItems = _cartDbContext.CartItems.ToList();
                decimal total = 0;
                foreach (var cartItem in cartItems)
                {
                    var product = _cartDbContext.Products.Find(cartItem.Id);
                    total += (cartItem.quantity * product.price);
                }
                return total;
            }
        }

        public void RemoveFromCart(int Id)
        {
            var cartItem = _cartDbContext.CartItems.Find(Id);
            if (cartItem != null)
            {
                _cartDbContext.CartItems.Remove(cartItem);
                _cartDbContext.SaveChanges();
            }
        }
    }
}
