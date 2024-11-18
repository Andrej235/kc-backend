using kc_backend.DTOs.Requests.Warehouse;
using Microsoft.AspNetCore.Mvc;

namespace kc_backend.Controllers
{
    public partial class WarehouseController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody] CreateWarehouseRequestDTO request)
        {
            _ = await createService.Add(createMapper.Map(request));
            return Created();
        }
    }
}
