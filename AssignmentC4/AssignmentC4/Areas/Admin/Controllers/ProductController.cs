using AssignmentC4.Models;
using AssignmentC4.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.IO;
using System.Linq;

namespace AssignmentC4.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly AssignmentC4_Context _context;
        private readonly IWebHostEnvironment _env;

        public ProductController(AssignmentC4_Context context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: Index
        public IActionResult Index()
        {
            var list = _context.Products.ToList();
            return View(list);
        }

        // GET: Create
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_context.Categories, "MaDM", "TenDanhMuc");
            return View(new Product());
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            ViewBag.Categories = new SelectList(_context.Categories, "MaDM", "TenDanhMuc", product.MaDM);

            if (!ModelState.IsValid)
                return View(product);

            // Upload ảnh đại diện
            if (product.HinhAnhFile != null)
            {
                string fileName = Guid.NewGuid() + Path.GetExtension(product.HinhAnhFile.FileName);
                string path = Path.Combine(_env.WebRootPath, "images", fileName);
                using var stream = new FileStream(path, FileMode.Create);
                product.HinhAnhFile.CopyTo(stream);
                product.HinhAnhDaiDien = fileName;
            }

            // Lưu sản phẩm trước để có MaSP
            _context.Products.Add(product);
            _context.SaveChanges();

            // Lưu biến thể nếu có
            if (product.Variants != null)
            {
                foreach (var variant in product.Variants)
                {
                    variant.MaSP = product.MaSP;
                    _context.Variants.Add(variant);
                }
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Edit
        public IActionResult Edit(int id)
        {
            var product = _context.Products
                .Where(p => p.MaSP == id)
                .FirstOrDefault();

            if (product == null) return NotFound();

            ViewBag.Categories = new SelectList(_context.Categories, "MaDM", "TenDanhMuc", product.MaDM);

            // Load biến thể
            product.Variants = _context.Variants.Where(v => v.MaSP == id).ToList();

            return View(product);
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product product)
        {
            ViewBag.Categories = new SelectList(_context.Categories, "MaDM", "TenDanhMuc", product.MaDM);

            if (!ModelState.IsValid)
                return View(product);

            var existing = _context.Products.Find(product.MaSP);
            if (existing == null) return NotFound();

            existing.TenSanPham = product.TenSanPham;
            existing.GiaCoBan = product.GiaCoBan;
            existing.MoTa = product.MoTa;
            existing.MaDM = product.MaDM;
            existing.ThuongHieu = product.ThuongHieu;
            existing.LoaiGiay = product.LoaiGiay;

            if (product.HinhAnhFile != null)
            {
                string fileName = Guid.NewGuid() + Path.GetExtension(product.HinhAnhFile.FileName);
                string path = Path.Combine(_env.WebRootPath, "images", fileName);
                using var stream = new FileStream(path, FileMode.Create);
                product.HinhAnhFile.CopyTo(stream);
                existing.HinhAnhDaiDien = fileName;
            }

            // Xóa biến thể cũ
            var oldVariants = _context.Variants.Where(v => v.MaSP == product.MaSP).ToList();
            _context.Variants.RemoveRange(oldVariants);
            _context.SaveChanges();

            // Thêm biến thể mới
            if (product.Variants != null)
            {
                foreach (var variant in product.Variants)
                {
                    variant.MaSP = product.MaSP;
                    _context.Variants.Add(variant);
                }
            }

            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: Delete
        public IActionResult Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null) return NotFound();
            return View(product);
        }

        // POST: Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null) return NotFound();

            var variants = _context.Variants.Where(v => v.MaSP == id).ToList();
            _context.Variants.RemoveRange(variants);

            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
