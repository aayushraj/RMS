using Microsoft.AspNetCore.Mvc;
using RMS.Models;
using RMS.Service.TenantInfo;
//using RMS.Utility;
namespace RMS.Controllers
{
    public class TenantInfoController : Controller
    {
        private readonly ITenantInfoService ser;

        public TenantInfoController()
        {
            ser = new TenantInfoService();
        }
        public IActionResult Index()
        {
            TenantInfoModel model = new TenantInfoModel();
            model.List = ser.GetList();
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TenantInfoModel model)
        {
            var model2 = new TenantInfoModel();
            model2 = ser.Create(model);
            model2.List = ser.GetList();
            return View("Index", model2);
        }

        public IActionResult Edit(int? id)
        {
            TenantInfoModel model = new TenantInfoModel();
            model = ser.GetById(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(TenantInfoModel model)
        {
            var model1 = ser.Edit(model);
            model.List = ser.GetList();
            return View("Index", model1);
        }


        public IActionResult Delete(int? id)
        {
            TenantInfoModel model = new TenantInfoModel();
            model = ser.GetById(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(TenantInfoModel model)
        {
            var model1 = ser.Delete(model);
            model1.List = ser.GetList();
            return View("Index", model1);
        }


    }
}