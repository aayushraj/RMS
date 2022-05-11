using Microsoft.AspNetCore.Mvc;
using RMS.Models;
using RMS.Service.Helpers;
using RMS.Service.TenantInfo;
using RMS.Service.Report;
//using RMS.Utility;
namespace RMS.Controllers
{
    public class TenantInfoController : Controller
    {
        private readonly ITenantInfoService _tenantInfoService;
        private readonly ICommonUtilityService _commonUtilityService;
        private readonly IReportService _reportService;

        public TenantInfoController(ITenantInfoService tenantInfoService, ICommonUtilityService commonUtilityService, IReportService reportService)
        {
            _tenantInfoService = tenantInfoService;
            _commonUtilityService = commonUtilityService;
            _reportService = reportService;
        }
        public IActionResult Index()
        {
            TenantInfoModel model = new TenantInfoModel();
            model.List = _tenantInfoService.GetList();
            //var check = model.List.Select(x => x.FirstName).Contains("Nitish");
            return View(model);
            //return Ok(model.List);
        }

        public IActionResult Create()
        {
            ViewBag.GetStates = _commonUtilityService.GetStates()
                                                        .Select(x => new
                                                        {
                                                            x.Value,
                                                            x.Text
                                                        }).ToList();
            ViewBag.GetRelationships = _commonUtilityService
                                                        .GetRelationship()
                                                        .Select(x => new
                                                        {
                                                            x.Value,
                                                            x.Text
                                                        }).ToList();
            return View();
        }
        public IActionResult GetTenantDetails(int id)
        {
            var model = _tenantInfoService.GetById(id);
            var reportModel = _reportService.LastPaid(id);
            try
            {
                model.DueAmount = reportModel.DueAmount;
                model.PaymentDate = reportModel.PaymentDate;
                model.Advance = reportModel.Advance;
                model.PaidAmount = reportModel.PaidAmount;
                return View(model);
            }
            catch (Exception ex)
            {
                model.DueAmount = 0;
                model.PaymentDate = DateTime.Now;
                model.Advance = 0;
                model.PaidAmount = 0;
                return View(model);
            }
            
        }
        public IActionResult GetById(int id) 
        {
            var model = _tenantInfoService.GetById(id);
            return Json(model.FloorNumber);
        }

        [HttpPost]
        public IActionResult Create(TenantInfoModel model)
        {
            var model2 = new TenantInfoModel();
            model2 = _tenantInfoService.Create(model);
            model2.List = _tenantInfoService.GetList();
            return View("Index", model2);
        }

        public IActionResult Edit(int? id)
        {
            ViewBag.GetState = _commonUtilityService.GetStates().Select(x => new
                                                            {
                                                                x.Value,
                                                                x.Text
                                                            }).ToList();
            TenantInfoModel model = new TenantInfoModel();
            model = _tenantInfoService.GetById(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(TenantInfoModel model)
        {
            var model1 = _tenantInfoService.Edit(model);
            model.List = _tenantInfoService.GetList();
            return View("Index", model1);
        }


        public IActionResult Delete(int? id)
        {
            TenantInfoModel model = new TenantInfoModel();
            model = _tenantInfoService.GetById(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(TenantInfoModel model)
        {
            var model1 = _tenantInfoService.Delete(model);
            model1.List = _tenantInfoService.GetList();
            return View("Index", model1);
        }


    }
}