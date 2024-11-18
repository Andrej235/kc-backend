using kc_backend.DTOs.Responses.Warehouse;
using kc_backend.Exceptions;
using kc_backend.Services.Read;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace kc_backend.Controllers
{
    public partial class WarehouseController
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SimpleWarehouseResponseDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery] string? nameFilter, [FromQuery] int? offset, [FromQuery] int? limit)
        {
            IEnumerable<Models.Warehouse> data = nameFilter is null
                ? await readRangeService.Get(_ => true, offset, limit)
                : await readRangeService.Get(x => EF.Functions.Like(x.Name, $"%{nameFilter}%"), offset, limit);

            return Ok(data.Select(simpleResponseMapper.Map));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(DetailedWarehouseResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            if (id < 1)
                return NotFound();

            Models.Warehouse warehouse = await readSingleService.Get(
                x => x.Id == id,
                x => x.Include(x => x.Items).ThenInclude(x => x.Item))
                ?? throw new NotFoundException($"Warehouse with id {id} not found");
            return Ok(detailedResponseMapper.Map(warehouse));
        }
    }
}
