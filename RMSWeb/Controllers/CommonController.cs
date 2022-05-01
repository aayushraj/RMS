using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RMS.Models.Common;
using RMS.Service.Helpers;

namespace RMS.Controllers
{
    public class CommonController : Controller
    {
        private readonly ICommonUtilityService _commonUtilityService;
        public CommonController(ICommonUtilityService commonUtilityService)
        {
            _commonUtilityService = commonUtilityService;   
        }
        //// GET: Common
        public IActionResult GetDistrict(int stateId)
        {
            var districtList = _commonUtilityService.GetDistricts(stateId);
            districtList.Add(new DDLModel { Text = "Select District", Value = "" });
            return Json(new SelectList(districtList.OrderBy(x=>x.Value), "Value", "Text"));
        }

        //public IActionResult GetFloor(int Id)
        //{
        //    var Floor = Utility.Utilities.GetFloor(Id);
        //    return Json(Floor);
        //}

        //public SelectList GetState()
        //{
        //    var sql = "Select 1 as Key, 'Bagmati' as Value";
        //    var list = _dapperService.Query<DDLModel>(sql);
        //    return new SelectList(list, "Key", "Value");
        //}

    }
}