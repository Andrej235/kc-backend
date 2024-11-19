using kc_backend.DTOs.Requests.Vehicle;
using kc_backend.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace kc_backend.Controllers
{
    public partial class VehicleController
    {
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromBody] UpdateVehicleRequestDTO request)
        {
            _ = await readSingleSelectedService.Get(x => new { }, x => x.Id == request.Id) ?? throw new NotFoundException();

            Models.Vehicle updatedEntity = updateMapper.Map(request);
            await updateService.Update(updatedEntity);
            return NoContent();
        }
    }
}
