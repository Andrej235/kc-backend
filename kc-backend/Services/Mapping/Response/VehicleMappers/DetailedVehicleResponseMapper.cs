using kc_backend.DTOs.Requests.Route;
using kc_backend.DTOs.Responses.Vehicle;
using kc_backend.Models;

namespace kc_backend.Services.Mapping.Response.VehicleMappers
{
    public class DetailedVehicleResponseMapper(IResponseMapper<Models.Route, SimpleRouteResponseDTO> routeMapper) : IResponseMapper<Vehicle, DetailedVehicleResponseDTO>
    {
        public DetailedVehicleResponseDTO Map(Vehicle from) => new()
        {
            Id = from.Id,
            PlateNumber = from.PlateNumber,
            LoadCapacity = from.LoadCapacity,
            Brand = from.Brand,
            Model = from.Model,
            InvolvedInRoutes = from.Routes.Select(routeMapper.Map),
        };
    }
}
