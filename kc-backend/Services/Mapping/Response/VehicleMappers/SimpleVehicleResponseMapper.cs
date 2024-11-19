using kc_backend.DTOs.Responses.Vehicle;
using kc_backend.Models;

namespace kc_backend.Services.Mapping.Response.VehicleMappers
{
    public class SimpleVehicleResponseMapper : IResponseMapper<Vehicle, SimpleVehicleResponseDTO>
    {
        public SimpleVehicleResponseDTO Map(Vehicle from) => new()
        {
            Id = from.Id,
            PlateNumber = from.PlateNumber,
            LoadCapacity = from.LoadCapacity,
            Brand = from.Brand,
            Model = from.Model,
        };
    }
}
