using Microsoft.AspNetCore.Mvc;

namespace AssignmentC4.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ReportController : Controller
    {
        public IActionResult Index(string period = "month")
        {
            // Báo cáo doanh thu theo ngày/tuần/tháng/năm
            ViewBag.Period = period;
            ViewBag.TotalRevenue = 125000000;
            ViewBag.TotalOrders = 89;
            ViewBag.AverageOrderValue = 1404494;

            // TODO: Get data from database và tạo chart
            return View();
        }
    }
}