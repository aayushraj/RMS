//using Microsoft.AspNetCore.Mvc;
//using RMS.Models;
//using RMS.Service;

//namespace RMS.Controllers
//{
//    public class SetupController : Controller
//    {
//        private readonly ISetupServices ser;
//        public SetupController()
//        {
//            ser = new SetupService();
//        }
//        // GET: Setup
        
//        public IActionResult Index()
//        {
//            SetupModel model = new SetupModel();

//            model.list = ser.GetList();

//            return View(model);
//        }
        

//        public IActionResult CreateFlor()
//        {
//            return View();
//        }

//        public IActionResult CreateRent()
//        {
//            return View();
//        }

//        public IActionResult Create()
//        {
//            return View();
//        }
//        [HttpPost]
//        public IActionResult Create(SetupModel model)
//        {
//            SetupModel model1 = new SetupModel();
            
//            model1 = ser.Create(model);
//            model1.list = ser.GetList();
//            return View("Index",model1);
//        }

//        public IActionResult Edit(int? id)
//        {
//            SetupModel model = new SetupModel();

//            model = ser.GetById(id);

//            return View(model);
//        }

//        [HttpPost]
//        public IActionResult Edit(SetupModel model)
//        {
//            SetupModel model1 = new SetupModel();

//            model1 = ser.Edit(model);
//            model1.list = ser.GetList();

//            return View("Index", model1);
//        } 

//        public IActionResult Delete(int? id)
//        {
//            return View(ser.GetById(id));
//        }

//        [HttpPost]
//        public IActionResult Delete(SetupModel model)
//        {
//            model = ser.Delete(model);
//            model.list = ser.GetList();
//            return RedirectToAction("Index",model);
//        }


//    }
//}