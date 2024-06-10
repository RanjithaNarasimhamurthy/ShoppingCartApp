using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartLibrary
{
    public class CartItem
    {
        public int Id { get; set; }
        public int productId { get; set; }
        public string productName { get; set; }
        public string productDescription { get; set; }
        public decimal price { get; set; }
        public string imageUrl { get; set; }
        public string categoryName { get; set; }
        public int quantity { get; set; } // Add this property
    }
}
