using Microsoft.AspNetCore.Mvc;
using RMS.Models;
using RMS.Service.Helpers;
using RMS.Service.TenantInfo;
using RMS.Service.Report;
using Microsoft.AspNetCore.Authorization;
//using RMS.Utility;
namespace RMS.Controllers
{
    [Authorize]
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
        public IActionResult Index(TenantInfoModel model1)
        {
            TenantInfoModel model = new TenantInfoModel();
            model1.List = _tenantInfoService.GetList();
            //return View(model1);
            return View(model1);

        }
        public PartialViewResult SearchTenant(string search)
        {
            TenantInfoModel model = new TenantInfoModel();
            model.List = _tenantInfoService.GetList();
            if(String.IsNullOrEmpty(search))
            {
                return PartialView("_TenantDetails",model);
            }
            else
            {
                model.List = model.List.Where(x => x.FirstName.ToLower().Contains(search.ToLower())).ToList();
                return PartialView("_TenantDetails", model);
            }
            
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
            return Json(model.FloorId);
        }

        [HttpPost]
        public IActionResult Create(TenantInfoModel model)
        {
            if(!ModelState.IsValid)
            {
                var model2 = new TenantInfoModel();
                model2 = _tenantInfoService.Create(model);
                model2.List = _tenantInfoService.GetList();
                return View("Index", model2);
            }
            return View();
            
        }

        public IActionResult Edit(int? id)
        {
            TenantInfoModel model = new TenantInfoModel();
            model = _tenantInfoService.GetById(id);
            ViewBag.GetState = _commonUtilityService.GetStates().Select(x => new
                                                            {
                                                                x.Value,
                                                                x.Text
                                                            }).ToList();
            ViewBag.GetDistrict = _commonUtilityService.GetDistricts(model.StateId).Select(x => new
                                                                            {
                                                                                 x.Value,
                                                                                 x.Text
                                                                             }).ToList();

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(TenantInfoModel model)
        {
             _tenantInfoService.Edit(model);
            return RedirectToAction("Index");
        }


        public IActionResult Delete(int? id)
        {
            var model = _tenantInfoService.Delete(id);
            return RedirectToAction("Index",model);
        }

       

    }
}