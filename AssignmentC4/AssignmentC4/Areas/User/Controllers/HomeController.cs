using AssignmentC4.Areas.User.DB;
using AssignmentC4.Areas.User.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AssignmentC4.Areas.User.Controllers
{
    [Area("User")]
    public class HomeController : Controller
    {
        private readonly AssignmentC4_Context _context;

        public HomeController(AssignmentC4_Context context)
        {
            _context = context;
        }

        // ===== CÁC ACTION GỐC =====
        public IActionResult Index()
        {
            var dsSanPham = _context.Products.ToList();
            return View(dsSanPham);
        }
        public IActionResult ProductDetail(int id)
        {
            var chiTietSanPham = _context.Products.Include(x => x.BienThes).ThenInclude(bt => bt.HinhAnh).FirstOrDefault(x => x.MaSP == id);
            if (chiTietSanPham == null)
            {
                return Content("Không tìm thấy sản phẩm!");
            }
            Console.WriteLine(chiTietSanPham);
            return View(chiTietSanPham);
        }
        public IActionResult ThayDoiHinh(int maBT)
        {
            var anhBienThe = _context.HinhAnh.FirstOrDefault(x => x.MaBT == maBT);
            return Json(new { imgUrl = anhBienThe.Url });

        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Men()
        {
            return View();
        }

        public IActionResult Women()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Checkout()
        {
            return View();
        }

        public IActionResult Cart()
        {
            return View();
        }

        public IActionResult AddToWhistList()
        {
            return View();
        }

        public IActionResult OrderComplete()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}