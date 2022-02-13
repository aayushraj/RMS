using RMS.Service.Report;
using Microsoft.AspNetCore.Mvc;
using RMS.Models;
using RMS.Service.TenantInfo;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using RMS.Service.Helpers;

namespace RMS.Controllers
{
    public class ReportController : Controller
    {
        private readonly IReportService _reportService;
        private readonly ITenantInfoService _tenantInfoService;
        public ReportController(IReportService reportService, ITenantInfoService tenantInfoService)
        {
            _reportService = reportService;
            _tenantInfoService = tenantInfoService;
        }
        public IActionResult MonthlyReport()
        {
            return View();
        }

        public IActionResult GetMonthlyReport(ReportModel model)
        {
            var list =  _reportService.Getlist(model);
            return View(list);
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
            ViewBag.Tenants = _tenantInfoService
                                    .GetList()
                                    .Select(x => new
                                    {
                                        Id = x.Id,
                                        Name = string.Format("{0} {1} {2}", x.FirstName, x.MiddleName, x.LastName)
                                    }).ToList();
            return View();
        }

        public IActionResult GetLastPaid(ReportModel model)
        {
            var lastPayment = _reportService.LastPaid(model.TenantId);
            return View(lastPayment);
        }

        public IActionResult GetMonthlySummary(ReportModel model)
        {
            model = _reportService.MonthlySummary(model);
            return View(model);
        }

    }
}