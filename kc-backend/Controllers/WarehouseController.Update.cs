﻿using kc_backend.DTOs.Requests.Warehouse;
using kc_backend.Exceptions;
using kc_backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace kc_backend.Controllers
{
    public partial class WarehouseController
    {
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromBody] UpdateWarehouseRequestDTO request)
        {
            _ = await readSingleSelectedService.Get(x => new { }, x => x.Id == request.Id) ?? throw new NotFoundException();

            Warehouse updatedEntity = updateMapper.Map(request);
            await updateSingleService.Update(updatedEntity);
            return NoContent();
        }
    }
}