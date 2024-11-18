using kc_backend.DTOs.Requests.PriceList;
using kc_backend.DTOs.Responses.PriceList;
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
    [Route("api/pricelist")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public partial class PriceListController(ICreateService<PriceList> createService,
                                             IReadSingleService<PriceList> readSingleService,
                                             IReadSingleSelectedService<PriceList> readSingleSelectedService,
                                             IReadRangeService<PriceList> readRangeService,
                                             IUpdateSingleService<PriceList> updateSingleService,
                                             IDeleteService<PriceList> deleteService,
                                             IRequestMapper<CreatePriceListRequestDTO, PriceList> createMapper,
                                             IRequestMapper<UpdatePriceListRequestDTO, PriceList> updateMapper,
                                             IResponseMapper<PriceList, SimplePriceListResponseDTO> simpleResponseMapper,
                                             IResponseMapper<PriceList, DetailedPriceListResponseDTO> detailedResponseMapper) : ControllerBase
    {
        private readonly ICreateService<PriceList> createService = createService;
        private readonly IReadSingleService<PriceList> readSingleService = readSingleService;
        private readonly IReadSingleSelectedService<PriceList> readSingleSelectedService = readSingleSelectedService;
        private readonly IReadRangeService<PriceList> readRangeService = readRangeService;
        private readonly IUpdateSingleService<PriceList> updateSingleService = updateSingleService;
        private readonly IDeleteService<PriceList> deleteService = deleteService;
        private readonly IRequestMapper<CreatePriceListRequestDTO, PriceList> createMapper = createMapper;
        private readonly IRequestMapper<UpdatePriceListRequestDTO, PriceList> updateMapper = updateMapper;
        private readonly IResponseMapper<PriceList, SimplePriceListResponseDTO> simpleResponseMapper = simpleResponseMapper;
        private readonly IResponseMapper<PriceList, DetailedPriceListResponseDTO> detailedResponseMapper = detailedResponseMapper;
    }
}
