using kc_backend.DTOs.Requests.PriceList;
using Microsoft.AspNetCore.Mvc;

namespace kc_backend.Controllers
{
    public partial class PriceListController
    {
        [HttpPost("{priceListId}/items")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AddItemToPriceList(int priceListId, [FromBody] CreatePriceListItemRequestDTO request)
        {
            _ = await itemCreateService.Add(new Models.PriceListItem
            {
                PriceListId = priceListId,
                ItemId = request.ItemId,
                Price = request.Price
            });

            return Created();
        }

        [HttpPatch("{priceListId}/items/{itemId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateItemPrice(int priceListId, int itemId, [FromBody] UpdatePriceListItemRequestDTO request)
        {
            await itemExecuteUpdateSingleService.Update(x => x.PriceListId == priceListId && x.ItemId == itemId, x => x.SetProperty(x => x.Price, request.Price));
            return Created();
        }

        [HttpDelete("{priceListId}/items/{itemId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RemoveItemFromPriceList(int priceListId, int itemId)
        {
            await itemDeleteService.Delete(x => x.PriceListId == priceListId && x.ItemId == itemId);
            return Created();
        }
    }
}
