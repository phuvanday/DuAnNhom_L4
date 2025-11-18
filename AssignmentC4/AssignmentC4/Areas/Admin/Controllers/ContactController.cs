using Microsoft.AspNetCore.Mvc;
using AssignmentC4.Areas.Admin.Models;

namespace AssignmentC4.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        public IActionResult Index(string status = "all")
        {
            // Danh sách liên hệ từ khách hàng
            var contacts = new List<Contact>(); // TODO: Get from database
            ViewBag.Status = status;
            return View(contacts);
        }

        [HttpPost]
        public IActionResult MarkAsRead(int id)
        {
            // Đánh dấu đã đọc
            // TODO: Update database
            TempData["Success"] = "Đã đánh dấu là đã đọc!";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Reply(int id, string message)
        {
            // Trả lời liên hệ
            // TODO: Send email and save to database
            TempData["Success"] = "Đã gửi phản hồi!";
            return RedirectToAction(nameof(Index));
        }
    }
}