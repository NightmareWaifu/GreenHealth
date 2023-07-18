using Microsoft.AspNetCore.Mvc;

namespace GreenHealthWebsite.Controllers.Customer
{
    public class ShoppingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
