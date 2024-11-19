using kc_backend.DTOs.Responses.Vehicle;
using kc_backend.Exceptions;
using kc_backend.Models;
using kc_backend.Services.Read;
using kc_backend.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace kc_backend.Controllers
{
    public partial class VehicleController
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SimpleVehicleResponseDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery] string? vehicleBrand, [FromQuery] string? vehicleModel, [FromQuery] string? plateNumber, [FromQuery] int? offset, [FromQuery] int? limit)
        {
            List<Expression<Func<Vehicle, bool>>> filters = [];

            if (vehicleBrand is not null)
                filters.Add(x => EF.Functions.Like(x.Brand, $"%{vehicleBrand}%"));

            if (vehicleModel is not null)
                filters.Add(x => EF.Functions.Like(x.Model, $"%{vehicleModel}%"));

            if (plateNumber is not null)
                filters.Add(x => EF.Functions.Like(x.PlateNumber, $"%{plateNumber}%"));

            IEnumerable<Vehicle> data = await readRangeService.Get(filters.Combine(ExpressionExtensions.CombineOperator.AND), offset, limit);
            return Ok(data.Select(simpleResponseMapper.Map));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(DetailedVehicleResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            if (id < 1)
                return NotFound();

            Vehicle vehicle = await readSingleService.Get(x => x.Id == id, x => x.Include(x => x.Routes)) ?? throw new NotFoundException($"Vehicle with id {id} not found.");
            return Ok(detailedResponseMapper.Map(vehicle));
        }
    }
}
