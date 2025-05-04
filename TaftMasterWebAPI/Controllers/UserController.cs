using Microsoft.AspNetCore.Mvc;

namespace TaftMasterWebAPI.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
