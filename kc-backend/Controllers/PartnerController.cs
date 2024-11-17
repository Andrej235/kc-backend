using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace kc_backend.Controllers
{
    [Authorize(AuthenticationSchemes = "Default")]
    [Route("api/partner")]
    [ApiController]
    public class PartnerController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok("123");
    }
}
