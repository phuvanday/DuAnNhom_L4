using Microsoft.AspNetCore.Mvc;
using AssignmentC4.Areas.Admin.Models;

namespace AssignmentC4.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        public IActionResult Index(string status = "all")
        {
            // Lọc đơn hàng theo trạng thái
            var orders = new List<Order>(); // TODO: Get from database
            ViewBag.Status = status;
            return View(orders);
        }

        public IActionResult Detail(int id)
        {
            // Chi tiết đơn hàng
            var order = new Order { Id = id }; // TODO: Get from database
            return View(order);
        }

        [HttpPost]
        public IActionResult UpdateStatus(int id, string status)
        {
            // Cập nhật trạng thái đơn hàng
            // TODO: Update database
            TempData["Success"] = "Cập nhật trạng thái thành công!";
            return RedirectToAction(nameof(Index));
        }
    }
}