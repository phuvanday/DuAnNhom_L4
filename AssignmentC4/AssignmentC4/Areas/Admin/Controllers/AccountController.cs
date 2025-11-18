using AssignmentC4.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;

namespace AssignmentC4.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            var accounts = new List<Account>(); // TODO: Get from database
            return View(accounts);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Account account)
        {
            if (ModelState.IsValid)
            {
                // TODO: Save to database (hash password)
                TempData["Success"] = "Thêm tài khoản thành công!";
                return RedirectToAction(nameof(Index));
            }
            return View(account);
        }

        public IActionResult Edit(int id)
        {
            var account = new Account { Id = id }; // TODO: Get from database
            return View(account);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Account account)
        {
            if (ModelState.IsValid)
            {
                // TODO: Update database
                TempData["Success"] = "Cập nhật tài khoản thành công!";
                return RedirectToAction(nameof(Index));
            }
            return View(account);
        }

        public IActionResult Delete(int id)
        {
            var account = new Account { Id = id }; // TODO: Get from database
            return View(account);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // TODO: Delete from database
            TempData["Success"] = "Xóa tài khoản thành công!";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult ToggleStatus(int id)
        {
            // Kích hoạt/Vô hiệu hóa tài khoản
            // TODO: Update database
            TempData["Success"] = "Cập nhật trạng thái tài khoản thành công!";
            return RedirectToAction(nameof(Index));
        }
    }
}