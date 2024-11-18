using kc_backend.DTOs.Responses.Item;
using kc_backend.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace kc_backend.Controllers
{
    public partial class ItemController
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SimpleItemResponseDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery] string? nameFilter, [FromQuery] int? offset, [FromQuery] int? limit)
        {
            IEnumerable<Models.Item> data = nameFilter is null
                ? await readRangeService.Get(_ => true, offset, limit)
                : await readRangeService.Get(x => EF.Functions.Like(x.Name, $"%{nameFilter}%"), offset, limit);

            return Ok(data.Select(responseMapper.Map));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(SimpleItemResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            if (id < 1)
                return NotFound();

            Models.Item item = await readSingleService.Get(x => x.Id == id) ?? throw new NotFoundException($"Item with id {id} not found");
            return Ok(responseMapper.Map(item));
        }
    }
}
