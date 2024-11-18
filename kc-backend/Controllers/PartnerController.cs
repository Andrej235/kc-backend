using kc_backend.DTOs.Requests.Partner;
using kc_backend.DTOs.Responses.Partner;
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
    [Route("api/partner")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public partial class PartnerController(ICreateService<Partner> createService,
                                           IReadSingleService<Partner> readSingleService,
                                           IReadSingleSelectedService<Partner> readSingleSelectedService,
                                           IReadRangeService<Partner> readRangeService,
                                           IUpdateSingleService<Partner> updateSingleService,
                                           IDeleteService<Partner> deleteService,
                                           IRequestMapper<CreatePartnerRequestDTO, Partner> createMapper,
                                           IRequestMapper<UpdatePartnerRequestDTO, Partner> updateMapper,
                                           IResponseMapper<Partner, SimplePartnerResponseDTO> simpleResponseMapper,
                                           IResponseMapper<Partner, DetailedPartnerResponseDTO> detailedResponseMapper) : ControllerBase
    {
        private readonly ICreateService<Partner> createService = createService;
        private readonly IReadRangeService<Partner> readRangeService = readRangeService;
        private readonly IReadSingleService<Partner> readSingleService = readSingleService;
        private readonly IReadSingleSelectedService<Partner> readSingleSelectedService = readSingleSelectedService;
        private readonly IUpdateSingleService<Partner> updateSingleService = updateSingleService;
        private readonly IDeleteService<Partner> deleteService = deleteService;
        private readonly IRequestMapper<CreatePartnerRequestDTO, Partner> createMapper = createMapper;
        private readonly IRequestMapper<UpdatePartnerRequestDTO, Partner> updateMapper = updateMapper;
        private readonly IResponseMapper<Partner, SimplePartnerResponseDTO> simpleResponseMapper = simpleResponseMapper;
        private readonly IResponseMapper<Partner, DetailedPartnerResponseDTO> detailedResponseMapper = detailedResponseMapper;
    }
}
