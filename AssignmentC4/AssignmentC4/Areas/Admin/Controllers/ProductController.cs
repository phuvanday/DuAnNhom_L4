using AssignmentC4.Areas.Admin.Models;
using AssignmentC4.Areas.User.DB;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentC4.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly AssignmentC4_Context _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ProductController(AssignmentC4_Context context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: Admin/Product/Index
        public async Task<IActionResult> Index()
        {
            var products = await _context.Products
                .Include(p => p.BienThes)
                .OrderByDescending(p => p.MaSP)
                .ToListAsync();
            return View(products);
        }

        // GET: Admin/Product/Create
        public IActionResult Create()
        {
            ViewBag.DanhMucs = _context.DanhMucs.ToList();
            return View();
        }

        // POST: Admin/Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product, IFormFile HinhAnhFile)
        {
            // Xử lý upload file
            if (HinhAnhFile != null && HinhAnhFile.Length > 0)
            {
                string uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "images");

                // Tạo thư mục nếu chưa tồn tại
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                string uniqueFileName = Path.GetFileName(HinhAnhFile.FileName);
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await HinhAnhFile.CopyToAsync(fileStream);
                }

                product.HinhAnhDaiDien = uniqueFileName;
            }

            // Xóa validation cho BienThes
            ModelState.Remove("BienThes");

            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Thêm sản phẩm thành công!";
                return RedirectToAction(nameof(Index));
            }

            ViewBag.DanhMucs = _context.DanhMucs.ToList();
            return View(product);
        }

        // GET: Admin/Product/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            ViewBag.DanhMucs = _context.DanhMucs.ToList();
            return View(product);
        }

        // POST: Admin/Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product, IFormFile HinhAnhFile)
        {
            if (id != product.MaSP)
            {
                return NotFound();
            }

            // Xử lý upload file mới
            if (HinhAnhFile != null && HinhAnhFile.Length > 0)
            {
                // Xóa ảnh cũ nếu có
                if (!string.IsNullOrEmpty(product.HinhAnhDaiDien))
                {
                    string oldFilePath = Path.Combine(_hostEnvironment.WebRootPath, "images", product.HinhAnhDaiDien);
                    if (System.IO.File.Exists(oldFilePath))
                    {
                        System.IO.File.Delete(oldFilePath);
                    }
                }

                // Upload ảnh mới
                string uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "images");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                string uniqueFileName = Path.GetFileName(HinhAnhFile.FileName);
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await HinhAnhFile.CopyToAsync(fileStream);
                }

                product.HinhAnhDaiDien = uniqueFileName;
            }
            else
            {
                // Giữ lại ảnh cũ
                var existingProduct = await _context.Products.AsNoTracking().FirstOrDefaultAsync(p => p.MaSP == id);
                if (existingProduct != null)
                {
                    product.HinhAnhDaiDien = existingProduct.HinhAnhDaiDien;
                }
            }

            ModelState.Remove("BienThes");
            ModelState.Remove("HinhAnhFile");

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();

                    TempData["Success"] = "Cập nhật sản phẩm thành công!";
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.MaSP))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            ViewBag.DanhMucs = _context.DanhMucs.ToList();
            return View(product);
        }

        // GET: Admin/Product/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.MaSP == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Admin/Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product != null)
            {
                // Xóa ảnh khỏi thư mục
                if (!string.IsNullOrEmpty(product.HinhAnhDaiDien))
                {
                    string filePath = Path.Combine(_hostEnvironment.WebRootPath, "images", product.HinhAnhDaiDien);
                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                }

                _context.Products.Remove(product);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Xóa sản phẩm thành công!";
            }

            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.MaSP == id);
        }
    }
}