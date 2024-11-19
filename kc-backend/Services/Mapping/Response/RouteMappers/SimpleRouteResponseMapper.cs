using kc_backend.DTOs.Requests.Route;

namespace kc_backend.Services.Mapping.Response.RouteMappers
{
    public class SimpleRouteResponseMapper : IResponseMapper<Models.Route, SimpleRouteResponseDTO>
    {
        public SimpleRouteResponseDTO Map(Models.Route from) => new()
        {
            Id = from.Id,
            CreationDate = from.CreationDate,
            Description = from.Description,
            GoodsWeight = from.GoodsWeight,
            VehicleId = from.VehicleId
        };
    }
}
