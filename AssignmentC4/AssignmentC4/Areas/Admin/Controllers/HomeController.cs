using Microsoft.AspNetCore.Mvc;

namespace AssignmentC4.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // Dashboard với thống kê tổng quan
            ViewBag.TotalProducts = 150; // Sẽ lấy từ DB
            ViewBag.TotalOrders = 89;
            ViewBag.TotalRevenue = 125000000;
            ViewBag.TotalUsers = 245;
            return View();
        }
    }
}