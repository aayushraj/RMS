using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RMS.Models;
using RMS.Service;
using RMS.Service.Dashboard;

namespace RMSWeb.Controllers
{
    
    public class DashboardController : Controller
    {
        private readonly IDashboardService _dashboardSerivce;
        private readonly ISetupServices _setupService;
        public DashboardController(IDashboardService dashboardSerivce, ISetupServices setupService)
        {
            _dashboardSerivce = dashboardSerivce;
            _setupService = setupService;
        }
        [Authorize]
        public IActionResult Index()
        {
            var model = _dashboardSerivce.GetRecords();
            model.Setuplist = _setupService.GetList();
            return View(model);
        }
        public IActionResult GetAmountPaidByTenant()
        {
            DashboardModel model = new DashboardModel();
            model.list = _dashboardSerivce.GetAmountPaidByTenant();
            return View(model);
        }
        public IActionResult GetAdvance()
        {
            DashboardModel model = new DashboardModel();
            model.list = _dashboardSerivce.GetAdvance();
            return View(model);
        }
        public IActionResult GetDue()
        {
            DashboardModel model = new DashboardModel();
            model.list = _dashboardSerivce.GetDue();
            return View(model);
        }

    }
}
