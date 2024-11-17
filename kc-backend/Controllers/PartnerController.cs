using Microsoft.AspNetCore.Mvc;

namespace kc_backend.Controllers
{
    [Route("api/partner")]
    [ApiController]
    public class PartnerController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok("123");
    }
}
