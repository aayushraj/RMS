using RMS.Service.Report;
using Microsoft.AspNetCore.Mvc;
using RMS.Models;

namespace RMS.Controllers
{
    public class ReportController : Controller
    {
        private readonly IReportService _reportService;
        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }
        public IActionResult MonthlyReport()
        {
            return View();
        }

        public IActionResult GetMonthlyReport(ReportModel model)
        {
            model.list = _reportService.Getlist(model);
            return View(model);
        }

        public IActionResult GetDailyReportDate()
        {
            return View();
        }

        public IActionResult GetDailyReport(ReportModel model)
        {
            model = _reportService.DailyReport(model);
            return View(model);

        }

        public IActionResult GetTenant()
        {
            return View();
        }

        public IActionResult GetLastPaid(ReportModel model)
        {

            model = _reportService.LastPaid(model.TenantId);
            return View(model);
        }

        public IActionResult GetMonthlySummary(ReportModel model)
        {
            model = _reportService.MonthlySummary(model);
            return View(model);
        }

    }
}