using kc_backend.DTOs.Responses.Partner;
using kc_backend.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace kc_backend.Controllers
{
    public partial class PartnerController
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SimplePartnerResponseDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery] string? nameFilter, [FromQuery] int? offset, [FromQuery] int? limit)
        {
            IEnumerable<Models.Partner> data = nameFilter is null
                ? await readRangeService.Get(_ => true, offset, limit)
                : await readRangeService.Get(x => EF.Functions.Like(x.Name, $"%{nameFilter}%"), offset, limit);

            return Ok(data.Select(simpleResponseMapper.Map));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(DetailedPartnerResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            if (id < 1)
                return NotFound();

            Models.Partner partner = await readSingleService.Get(x => x.Id == id) ?? throw new NotFoundException();
            return Ok(detailedResponseMapper.Map(partner));
        }
    }
}
