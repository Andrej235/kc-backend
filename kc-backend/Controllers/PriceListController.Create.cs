using kc_backend.DTOs.Requests.PriceList;
using Microsoft.AspNetCore.Mvc;

namespace kc_backend.Controllers
{
    public partial class PriceListController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody] CreatePriceListRequestDTO request)
        {
            _ = await createService.Add(createMapper.Map(request));
            return Created();
        }
    }
}
