using Ecom.Apl.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.Apl.Controllers
{
    [Route("Errors/{statuscode}")]
    [ApiController]
    public class ErrorController : ControllerBase

    {
        [HttpGet]
        public IActionResult Error(int statuscode)
        {
            return new ObjectResult(new ResponseApi(statuscode));
        }
    }
}
