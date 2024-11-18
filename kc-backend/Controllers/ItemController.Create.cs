using kc_backend.DTOs.Requests.Item;
using Microsoft.AspNetCore.Mvc;

namespace kc_backend.Controllers
{
    public partial class ItemController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody] CreateItemRequestDTO request)
        {
            _ = await createService.Add(createMapper.Map(request));
            return Created();
        }
    }
}
