//using RMS.Service.Payment;
//using Microsoft.AspNetCore.Mvc;
//using RMS.Models;

//namespace RMS.Controllers
//{
//    public class PaymentController : Controller
//    {
//        private readonly IPaymentServices ser;

//        public PaymentController()
//        {
//            ser = new PaymentServices();
//        }
//        public IActionResult Index()
//        {
//            return View();
//        }

//        public IActionResult Create()
//        {
//            return View();
//        }

//        [HttpPost]
//        public IActionResult Create(PaymentModel model)
//        {
//            PaymentModel model1 = new PaymentModel();
//            model1 = ser.Create(model);

//            return RedirectToAction("Index", "TenantInfo");
//        }
//    }
//}