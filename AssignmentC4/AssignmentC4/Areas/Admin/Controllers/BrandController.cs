using Microsoft.AspNetCore.Mvc;
using AssignmentC4.Areas.Admin.Models;

namespace AssignmentC4.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BrandController : Controller
    {
        public IActionResult Index()
        {
            var brands = new List<Brand>(); // TODO: Get from database
            return View(brands);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Brand brand)
        {
            if (ModelState.IsValid)
            {
                // TODO: Save to database
                TempData["Success"] = "Thêm hãng giày thành công!";
                return RedirectToAction(nameof(Index));
            }
            return View(brand);
        }

        public IActionResult Edit(int id)
        {
            var brand = new Brand { Id = id }; // TODO: Get from database
            return View(brand);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Brand brand)
        {
            if (ModelState.IsValid)
            {
                // TODO: Update database
                TempData["Success"] = "Cập nhật hãng giày thành công!";
                return RedirectToAction(nameof(Index));
            }
            return View(brand);
        }

        public IActionResult Delete(int id)
        {
            var brand = new Brand { Id = id }; // TODO: Get from database
            return View(brand);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // TODO: Delete from database
            TempData["Success"] = "Xóa hãng giày thành công!";
            return RedirectToAction(nameof(Index));
        }
    }
}