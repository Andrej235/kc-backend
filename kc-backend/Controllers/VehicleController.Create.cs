using kc_backend.DTOs.Requests.Vehicle;
using Microsoft.AspNetCore.Mvc;

namespace kc_backend.Controllers
{
    public partial class VehicleController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody] CreateVehicleRequestDTO request)
        {
            _ = await createService.Add(createMapper.Map(request));
            return Created();
        }
    }
}
