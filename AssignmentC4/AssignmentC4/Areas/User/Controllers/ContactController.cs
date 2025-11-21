using AssignmentC4.Areas.User.Services;
using AssignmentC4.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AssignmentC4.Areas.User.Controllers
{
    [Area("User")]
    public class ContactController : Controller
    {
        private readonly EmailService _emailService;

        public ContactController()
        {
            _emailService = new EmailService();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ContactModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                string noiDungMail = $@"
                    <h3>Khách hàng liên hệ</h3>
                    <p><b>Tên:</b> {model.Ten}</p>
                    <p><b>Email:</b> {model.Email}</p>
                    <p><b>Tiêu đề:</b> {model.TieuDe}</p>
                    <p><b>Nội dung:</b><br/>{model.NoiDung}</p>
                ";

                await _emailService.SendEmailAsync("admin@yoursite.com", model.TieuDe, noiDungMail);

                ViewBag.ThongBao = "Gửi thành công! Chúng tôi sẽ phản hồi sớm.";
            }
            catch (Exception ex)
            {
                ViewBag.ThongBao = "Gửi email thất bại. Lỗi: " + ex.Message;
            }

            return View();
        }
    }
}
