using AutoMapper;
using Ecom.core.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.Apl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BugsController : BaseController
    {
        public BugsController(IunitofWork iunitofWork, IMapper mapper) : base(iunitofWork, mapper)
        {
        }

        [HttpGet("not-found")]
        public async Task<IActionResult> GetNotFound()
        {
            var category = await iunitofWork.categoryRepositry.GetIdAsync(100);
            if (category == null)
                return NotFound(new { Status = 404, Message = "Category not found" });

            return Ok(category);
        }

        [HttpGet("server-error")]
        public async Task<IActionResult> ServerError()
        {
            try
            {
                var category = await iunitofWork.categoryRepositry.GetIdAsync(100);
                if (category == null)
                    return NotFound(new { Status = 404, Message = "Category not found" });

                category.Name = "Error"; // Simulate modification
                return Ok(category);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Status = 500, Message = "Internal Server Error", Details = ex.Message });
            }
        }
        [HttpGet("bad-request/{id}")]
        public async Task<IActionResult> GetBadRequest(int id)
        {
            if (id <= 0)
                return BadRequest(new { Status = 400, Message = "Invalid ID. ID must be greater than zero." });

            return Ok(new { Status = 200, Message = "Valid Request", Id = id });
        }
        [HttpGet("bad-request/")]
        public IActionResult GetBadRequest()
        {
            return BadRequest(new { Status = 400, Message = "Bad Request Error" });
        }


    }
}
