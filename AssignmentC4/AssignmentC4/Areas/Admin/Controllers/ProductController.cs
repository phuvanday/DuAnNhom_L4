using Microsoft.AspNetCore.Mvc;
using AssignmentC4.Areas.Admin.Models;

namespace AssignmentC4.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        // GET: Admin/Product
        public IActionResult Index()
        {
            // Lấy danh sách sản phẩm từ DB
            var products = new List<Product>(); // TODO: Get from database
            return View(products);
        }

        // GET: Admin/Product/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                // TODO: Save to database
                TempData["Success"] = "Thêm sản phẩm thành công!";
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Admin/Product/Edit/5
        public IActionResult Edit(int id)
        {
            // TODO: Get product from database
            var product = new Product { Id = id };
            return View(product);
        }

        // POST: Admin/Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Product product)
        {
            if (ModelState.IsValid)
            {
                // TODO: Update database
                TempData["Success"] = "Cập nhật sản phẩm thành công!";
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Admin/Product/Delete/5
        public IActionResult Delete(int id)
        {
            // TODO: Get product from database
            var product = new Product { Id = id };
            return View(product);
        }

        // POST: Admin/Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // TODO: Delete from database
            TempData["Success"] = "Xóa sản phẩm thành công!";
            return RedirectToAction(nameof(Index));
        }
    }
}