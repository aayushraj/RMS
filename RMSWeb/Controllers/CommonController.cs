using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RMS.Models.Common;
using RMS.Repository;

namespace RMS.Controllers
{
    public class CommonController : Controller
    {
        //private readonly IDapperService _dapperService;
        //public CommonController(IDapperService dapperService)
        //{
        //    _dapperService = dapperService;
        //}
        //// GET: Common
        //public IActionResult GetDistrict(int stateId)
        //{
        //    var districtList = Utilities.GetDistrict(stateId);

        //    return Json(new SelectList(districtList, "Value", "Text"));

        //}

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