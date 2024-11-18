using kc_backend.DTOs.Responses.Object;
using kc_backend.Exceptions;
using kc_backend.Services.Read;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace kc_backend.Controllers
{
    public partial class ObjectController
    {
        [HttpGet("from/{ownerId}")]
        [ProducesResponseType(typeof(IEnumerable<SimpleObjectResponseDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(int ownerId, [FromQuery] string? localCode, [FromQuery] int? offset, [FromQuery] int? limit)
        {
            IEnumerable<Models.Object> data = localCode is null
                ? await readRangeService.Get(x => x.OwnerId == ownerId, offset, limit)
                : await readRangeService.Get(x => x.OwnerId == ownerId && EF.Functions.Like(x.LocalCode, $"%{localCode}%"), offset, limit);

            return Ok(data.Select(simpleResponseMapper.Map));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(DetailedObjectResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            if (id < 1)
                return NotFound();

            Models.Object @object = await readSingleService.Get(x => x.Id == id, x => x.Include(x => x.Owner)) ?? throw new NotFoundException($"Object with id {id} not found.");
            return Ok(detailedResponseMapper.Map(@object));
        }
    }
}
