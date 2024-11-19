using kc_backend.DTOs.Requests.Vehicle;
using kc_backend.Models;

namespace kc_backend.Services.Mapping.Request.VehicleMappers
{
    public class UpdateVehicleRequestMapper : IRequestMapper<UpdateVehicleRequestDTO, Vehicle>
    {
        public Vehicle Map(UpdateVehicleRequestDTO from) => new()
        {
            Id = from.Id,
            Brand = from.Brand,
            Model = from.Model,
            LoadCapacity = from.LoadCapacity,
            PlateNumber = from.PlateNumber
        };
    }
}
