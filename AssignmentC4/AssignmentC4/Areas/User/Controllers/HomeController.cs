using AssignmentC4.Models;
using AssignmentC4.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
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

        public IActionResult Index()
        {
            var dsSanPham = _context.Products
                .Include(p => p.Category)
                .Include(p => p.Variants).ThenInclude(v => v.Images)
                .ToList();
            return View(dsSanPham);
        }

        public IActionResult ProductDetail(int id)
        {
            var chiTietSanPham = _context.Products
                .Include(p => p.Variants).ThenInclude(v => v.Images)
                .Include(p => p.Category)
                .FirstOrDefault(p => p.MaSP == id);

            if (chiTietSanPham == null)
                return Content("Không tìm thấy sản phẩm!");

            return View(chiTietSanPham);
        }

        public IActionResult ThayDoiHinh(int maBT)
        {
            var anhBienThe = _context.Images.FirstOrDefault(x => x.MaBT == maBT);
            if (anhBienThe == null)
                return Json(new { imgUrl = "/images/no-image.jpg" });

            return Json(new { imgUrl = "/images/" + anhBienThe.HinhAnh });
        }

        public IActionResult Privacy() => View();
        public IActionResult Men() => View();
        public IActionResult Women() => View();
        public IActionResult About() => View();
        public IActionResult Contact() => View();
        public IActionResult Login() => View();
        public IActionResult Checkout() => View();
        public IActionResult Cart() => View();
        public IActionResult AddToWhistList() => View();
        public IActionResult OrderComplete() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
