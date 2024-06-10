using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartLibrary
{
    public interface ICartDataAccess
    {
        void AddToCart(CartItem cartItem);
        List<CartItem> GetCartItems();
        Product GetProductById(int Id);
        CartItem GetCartItemById(int cartItemId);

        void RemoveFromCart(int Id);
        void EditCart(CartItem cartItem);
        decimal GetTotalPrice();
    }
}
