using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RMS.Models;
using RMS.Service;

namespace RMS.Controllers
{
    [Authorize]
    public class SetupController : Controller
    {
        private readonly ISetupServices _setupService;
        public SetupController(ISetupServices setupService)
        {
            _setupService = setupService;
        }
        // GET: Setup

        public IActionResult Index()
        {
            SetupModel model = new SetupModel();
            model.list = _setupService.GetList();
            return View(model);
        }


        public IActionResult CreateFlor()
        {
            return View();
        }

        public IActionResult CreateRent()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(SetupModel model)
        {
            if(ModelState.IsValid)
            {
                SetupModel model1 = new SetupModel();
                model1 = _setupService.Create(model);
                model1.list = _setupService.GetList();
                return View("Index", model1);
            }
            return View();
            
        }

        public IActionResult Edit(int? id)
        {
            SetupModel model = new SetupModel();
            model = _setupService.GetById(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(SetupModel model)
        {
            SetupModel model1 = new SetupModel();
            model1 = _setupService.Edit(model);
            model1.list = _setupService.GetList();
            return View("Index", model1);
        }

        public IActionResult Delete(int? id)
        {
            return View(_setupService.GetById(id));
        }

        [HttpPost]
        public IActionResult Delete(SetupModel model)
        {
            model = _setupService.Delete(model);
            model.list = _setupService.GetList();
            return RedirectToAction("Index", model);
        }


    }
}