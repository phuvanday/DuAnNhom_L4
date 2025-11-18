using Microsoft.AspNetCore.Mvc;
using AssignmentC4.Areas.Admin.Models;

namespace AssignmentC4.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NewsController : Controller
    {
        public IActionResult Index()
        {
            var newsList = new List<News>(); // TODO: Get from database
            return View(newsList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(News news)
        {
            if (ModelState.IsValid)
            {
                // TODO: Save to database
                TempData["Success"] = "Thêm tin tức thành công!";
                return RedirectToAction(nameof(Index));
            }
            return View(news);
        }

        public IActionResult Edit(int id)
        {
            var news = new News { Id = id }; // TODO: Get from database
            return View(news);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, News news)
        {
            if (ModelState.IsValid)
            {
                // TODO: Update database
                TempData["Success"] = "Cập nhật tin tức thành công!";
                return RedirectToAction(nameof(Index));
            }
            return View(news);
        }

        public IActionResult Delete(int id)
        {
            var news = new News { Id = id }; // TODO: Get from database
            return View(news);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // TODO: Delete from database
            TempData["Success"] = "Xóa tin tức thành công!";
            return RedirectToAction(nameof(Index));
        }
    }
}