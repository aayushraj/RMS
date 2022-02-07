using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RMS.Utility;

namespace RMS.Controllers
{
    public class CommonController : Controller
    {
        // GET: Common
        public IActionResult GetDistrict(int stateId)
        {
            var districtList = Utilities.GetDistrict(stateId);

            return Json(new SelectList(districtList, "Value", "Text"));

        }

        public IActionResult GetFloor(int Id)
        {
            var Floor = Utility.Utilities.GetFloor(Id);
            return Json(Floor);
        }
            
    }
}