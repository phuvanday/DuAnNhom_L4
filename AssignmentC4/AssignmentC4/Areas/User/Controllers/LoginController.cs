using Microsoft.AspNetCore.Mvc;

namespace AssignmentC4.Areas.User.Controllers
{
    [Area("User")]
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult register()
        {
            return View();
        }
        public IActionResult forgotPassword()
        {
            return View();
        }
        public IActionResult changePassword()
        {
            return View();
        }
    }
}
