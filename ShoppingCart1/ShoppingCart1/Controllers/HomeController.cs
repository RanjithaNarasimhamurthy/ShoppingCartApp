using Microsoft.AspNetCore.Mvc;
using ShoppingCartLibrary;

namespace ShoppingCart1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ShoppingDbContext _shoppingDbContext;

        public HomeController(ShoppingDbContext shoppingDbContext)
        {
            _shoppingDbContext = shoppingDbContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        
           // return RedirectToAction("Search");
        

    }
}
