using kc_backend.DTOs.Requests.Route;

namespace kc_backend.DTOs.Responses.Vehicle
{
    public class DetailedVehicleResponseDTO : SimpleVehicleResponseDTO
    {
        public IEnumerable<SimpleRouteResponseDTO> InvolvedInRoutes { get; set; } = null!;
    }
}
