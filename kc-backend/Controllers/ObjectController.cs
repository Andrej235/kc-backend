using kc_backend.DTOs.Requests.Object;
using kc_backend.DTOs.Responses.Object;
using kc_backend.Models;
using kc_backend.Services.Create;
using kc_backend.Services.Delete;
using kc_backend.Services.Mapping.Request;
using kc_backend.Services.Mapping.Response;
using kc_backend.Services.Read;
using kc_backend.Services.Update;
using Microsoft.AspNetCore.Mvc;
using Object = kc_backend.Models.Object;

namespace kc_backend.Controllers
{
    [Route("api/object")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public partial class ObjectController(ICreateService<Object> createService,
                                          IReadSingleService<Object> readSingleService,
                                          IReadSingleSelectedService<Object> readSingleSelectedService,
                                          IReadRangeService<Object> readRangeService,
                                          IExecuteUpdateService<Object> executeSingleService,
                                          IDeleteService<Object> deleteService,
                                          IRequestMapper<CreateObjectRequestDTO, Object> createMapper,
                                          IRequestMapper<UpdateObjectRequestDTO, Object> updateMapper,
                                          IResponseMapper<Object, SimpleObjectResponseDTO> simpleResponseMapper,
                                          IResponseMapper<Object, DetailedObjectResponseDTO> detailedResponseMapper) : ControllerBase
    {
        private readonly ICreateService<Object> createService = createService;
        private readonly IReadSingleService<Object> readSingleService = readSingleService;
        private readonly IReadSingleSelectedService<Object> readSingleSelectedService = readSingleSelectedService;
        private readonly IReadRangeService<Object> readRangeService = readRangeService;
        private readonly IExecuteUpdateService<Object> executeSingleService = executeSingleService;
        private readonly IDeleteService<Object> deleteService = deleteService;
        private readonly IRequestMapper<CreateObjectRequestDTO, Object> createMapper = createMapper;
        private readonly IRequestMapper<UpdateObjectRequestDTO, Object> updateMapper = updateMapper;
        private readonly IResponseMapper<Object, SimpleObjectResponseDTO> simpleResponseMapper = simpleResponseMapper;
        private readonly IResponseMapper<Object, DetailedObjectResponseDTO> detailedResponseMapper = detailedResponseMapper;
    }
}

