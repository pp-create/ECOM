using AutoMapper;
using Ecom.core.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.Apl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected readonly IunitofWork iunitofWork;
        protected readonly IMapper Mapper;

        public BaseController(IunitofWork iunitofWork, IMapper mapper)
        {
            this.iunitofWork = iunitofWork;
            Mapper = mapper;
        }
    }
}
