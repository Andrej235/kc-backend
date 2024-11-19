using kc_backend.DTOs.Requests.Vehicle;
using kc_backend.DTOs.Responses.Vehicle;
using kc_backend.Models;
using kc_backend.Services.Create;
using kc_backend.Services.Delete;
using kc_backend.Services.Mapping.Request;
using kc_backend.Services.Mapping.Response;
using kc_backend.Services.Read;
using kc_backend.Services.Update;
using Microsoft.AspNetCore.Mvc;

namespace kc_backend.Controllers
{
    [Route("api/vehicle")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public partial class VehicleController(ICreateService<Vehicle> createService,
                                   IReadSingleService<Vehicle> readSingleService,
                                   IReadSingleSelectedService<Vehicle> readSingleSelectedService,
                                   IReadRangeService<Vehicle> readRangeService,
                                   IUpdateSingleService<Vehicle> updateService,
                                   IDeleteService<Vehicle> deleteService,
                                   IRequestMapper<CreateVehicleRequestDTO, Vehicle> createMapper,
                                   IRequestMapper<UpdateVehicleRequestDTO, Vehicle> updateMapper,
                                   IResponseMapper<Vehicle, SimpleVehicleResponseDTO> simpleResponseMapper,
                                   IResponseMapper<Vehicle, DetailedVehicleResponseDTO> detailedResponseMapper) : ControllerBase
    {
        private readonly ICreateService<Vehicle> createService = createService;
        private readonly IReadSingleService<Vehicle> readSingleService = readSingleService;
        private readonly IReadSingleSelectedService<Vehicle> readSingleSelectedService = readSingleSelectedService;
        private readonly IReadRangeService<Vehicle> readRangeService = readRangeService;
        private readonly IUpdateSingleService<Vehicle> updateService = updateService;
        private readonly IDeleteService<Vehicle> deleteService = deleteService;
        private readonly IRequestMapper<CreateVehicleRequestDTO, Vehicle> createMapper = createMapper;
        private readonly IRequestMapper<UpdateVehicleRequestDTO, Vehicle> updateMapper = updateMapper;
        private readonly IResponseMapper<Vehicle, SimpleVehicleResponseDTO> simpleResponseMapper = simpleResponseMapper;
        private readonly IResponseMapper<Vehicle, DetailedVehicleResponseDTO> detailedResponseMapper = detailedResponseMapper;
    }
}
