using Microsoft.AspNetCore.Mvc;
//using System.Web.Http;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace RMSWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Test : ControllerBase
    
    {
        [Route("Test/{id}")]
        public IActionResult Index(int id)
        {
            string test = "";
            if (id==1)
            {
                test = "Test API Called";

            }
            return Ok(test);
        }
    }
}
