using kc_backend.DTOs.Requests.Partner;
using Microsoft.AspNetCore.Mvc;

namespace kc_backend.Controllers
{
    public partial class PartnerController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody] CreatePartnerRequestDTO request)
        {
            _ = await createService.Add(createMapper.Map(request));
            return Created();
        }
    }
}
