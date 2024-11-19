using kc_backend.DTOs.Requests.Vehicle;
using kc_backend.Models;

namespace kc_backend.Services.Mapping.Request.VehicleMappers
{
    public class CreateVehicleRequestMapper : IRequestMapper<CreateVehicleRequestDTO, Vehicle>
    {
        public Vehicle Map(CreateVehicleRequestDTO from) => new()
        {
            Brand = from.Brand,
            Model = from.Model,
            LoadCapacity = from.LoadCapacity,
            PlateNumber = from.PlateNumber,
            Routes = []
        };
    }
}
