using kc_backend.DTOs.Requests.Object;
using kc_backend.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace kc_backend.Controllers
{
    public partial class ObjectController
    {
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromBody] UpdateObjectRequestDTO request)
        {
            _ = await readSingleSelectedService.Get(x => new { }, x => x.Id == request.Id) ?? throw new NotFoundException();

            Models.Object updatedEntity = updateMapper.Map(request);
            await executeSingleService.Update(x => x.Id == request.Id, x => x.SetProperty(x => x.Address, request.Address).SetProperty(x => x.LocalCode, request.LocalCode));
            return NoContent();
        }
    }
}
