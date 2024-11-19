using kc_backend.DTOs.Requests.Warehouse;
using Microsoft.AspNetCore.Mvc;

namespace kc_backend.Controllers
{
    public partial class WarehouseController
    {
        [HttpPatch("{warehouseId}/stock/{itemId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateStock(int warehouseId, int itemId, [FromBody] UpdateWarehouseItemRequestDTO request)
        {
            await warehouseItemExecuteUpdateService.Update(
               x => x.WarehouseId == warehouseId && x.ItemId == itemId,
               x => x.SetProperty(x => x.Quantity, request.Quantity));

            return NoContent();
        }

        [HttpPost("{warehouseId}/stock")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AddToStock(int warehouseId, [FromBody] CreateWarehouseItemRequestDTO request)
        {
            Models.WarehouseItem warehouseItem = new()
            {
                ItemId = request.ItemId,
                WarehouseId = warehouseId,
                Quantity = request.Quantity
            };

            _ = await warehouseItemCreateService.Add(warehouseItem);
            return NoContent();
        }

        [HttpDelete("{warehouseId}/stock/{itemId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RemoveFromStock(int warehouseId, int itemId)
        {
            await warehouseItemDeleteService.Delete(x => x.WarehouseId == warehouseId && x.ItemId == itemId);
            return NoContent();
        }
    }
}
