using RMS.Service.Payment;
using Microsoft.AspNetCore.Mvc;
using RMS.Models;
using RMS.Service.Helpers;

namespace RMS.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPaymentServices _paymentService;
        private readonly ICommonUtilityService _commonUtilityService;

        public PaymentController(IPaymentServices paymentService, ICommonUtilityService commonUtilityService)
        {
            _paymentService = paymentService;
            _commonUtilityService = commonUtilityService;
        }
        public IActionResult Index()
        {
            ViewBag.GetTenant = _commonUtilityService.GetTenantList()
                                                                   .Select(x => new
                                                                   {
                                                                       x.Value,
                                                                       x.Text
                                                                   }).ToList();
            return View();
        }

        public IActionResult Create()
        {
            ViewBag.GetTenant = _commonUtilityService.GetTenantList()
                                                                   .Select(x => new
                                                                   {
                                                                       x.Value,
                                                                       x.Text
                                                                   }).ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(PaymentModel model)
        {
            PaymentModel model1 = new PaymentModel();
            model1 = _paymentService.Create(model);

            return RedirectToAction("Index", "TenantInfo");
        }
    }
}