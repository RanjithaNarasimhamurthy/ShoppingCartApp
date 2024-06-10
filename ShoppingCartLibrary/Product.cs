using System.ComponentModel.DataAnnotations;

namespace ShoppingCartLibrary
{
    public class Product
    {
        
        public int Id { get; set; }
        public string productName { get; set; }
        public string productDescription { get; set; }
        public decimal price { get; set; }
        public string imageUrl { get; set; }
        public string categoryName { get; set; }
    }
}