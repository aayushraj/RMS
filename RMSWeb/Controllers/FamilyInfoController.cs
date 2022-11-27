using System.Configuration;
using RMS.Service.TenantInfo;
using Microsoft.AspNetCore.Mvc;
using RMS.Models;
using Microsoft.AspNetCore.Authorization;

namespace RMS.Controllers
{
    [Authorize]
    public class FamilyInfoController : Controller
    {
        private string connString = System.Configuration.ConfigurationManager.ConnectionStrings["DBstring"].ToString();

        private readonly IFamilyInfoService _familyInfoService;

        public FamilyInfoController(IFamilyInfoService familyInfoService)
        {
            _familyInfoService = familyInfoService;
        }
        public IActionResult Index(int? id)
        {
            ViewBag.Id = id;
            if (id == null)
            {
                FamilyInfoModel model = new FamilyInfoModel();
                model.List = _familyInfoService.GetList();
                return View(model);
            }

            else
            {
                FamilyInfoModel model = new FamilyInfoModel();
                model.List = _familyInfoService.FamilyList(id);
                return View(model);
            }
        }
        public IActionResult Create(int? id)
        {

            FamilyInfoModel model = new FamilyInfoModel();

            model = _familyInfoService.Create(id);
            ViewBag.Name = model.FirstName;
            // ViewBag.Id = id;
            ViewBag.Floor = model.FloorId;

            return View();
        }

        [HttpPost]
        public IActionResult Create(FamilyInfoModel model)
        {
            var model2 = new FamilyInfoModel();
            model2 = _familyInfoService.Create(model);
            model2.List = _familyInfoService.GetList();
            return View("Index", model2);
        }


        public IActionResult Edit(int? id)
        {

            return View(_familyInfoService.GetById(id));
        }

        [HttpPost]
        public IActionResult Edit(FamilyInfoModel model)
        {
            var model2 = new FamilyInfoModel();
            model2 = _familyInfoService.Edit(model);
            model2.List = _familyInfoService.GetList();
            return View("Index", model2);
        }

        public IActionResult Delete(int? id)
        {
            return View(_familyInfoService.GetById(id));
        }

        [HttpPost]
        public IActionResult Delete(FamilyInfoModel model)
        {
            var model2 = new FamilyInfoModel();
            model2 = _familyInfoService.Delete(model);
            model2.List = _familyInfoService.GetList();

            return View("Index", model2);
        }

    }
}