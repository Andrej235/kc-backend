using kc_backend.DTOs.Responses.PriceList;
using kc_backend.Exceptions;
using kc_backend.Services.Read;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace kc_backend.Controllers
{
    public partial class PriceListController
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SimplePriceListResponseDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery] string? nameFilter, [FromQuery] int? offset, [FromQuery] int? limit)
        {
            var data = await readRangeSelectedService.Get(
                    x => new
                    {
                        Entity = x,
                        ItemCount = x.Items.Count
                    },
                    nameFilter is null ? _ => true : x => EF.Functions.Like(x.Name, $"%{nameFilter}%"),
                    offset, limit);

            return Ok(data.Select(x =>
            {
                SimplePriceListResponseDTO y = simpleResponseMapper.Map(x.Entity);
                y.ItemCount = x.ItemCount;
                return y;
            }));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(DetailedPriceListResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            if (id < 1)
                return NotFound();

            Models.PriceList priceList = await readSingleService.Get(
                x => x.Id == id,
                x => x.Include(x => x.Items).ThenInclude(x => x.Item))
                ?? throw new NotFoundException($"PriceList with id {id} not found.");

            return Ok(detailedResponseMapper.Map(priceList));
        }
    }
}
