using Microsoft.AspNetCore.Mvc;

namespace ITM_College.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("Error/AccessDenied")]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
