using kc_backend.DTOs.Requests.Item;
using kc_backend.DTOs.Responses.Item;
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
    [Route("api/item")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public partial class ItemController(ICreateService<Item> createService,
                                        IReadSingleService<Item> readSingleService,
                                        IReadSingleSelectedService<Item> readSingleSelectedService,
                                        IReadRangeService<Item> readRangeService,
                                        IUpdateSingleService<Item> updateSingleService,
                                        IDeleteService<Item> deleteService,
                                        IRequestMapper<CreateItemRequestDTO, Item> createMapper,
                                        IRequestMapper<UpdateItemRequestDTO, Item> updateMapper,
                                        IResponseMapper<Item, SimpleItemResponseDTO> responseMapper) : ControllerBase
    {
        private readonly ICreateService<Item> createService = createService;
        private readonly IReadSingleService<Item> readSingleService = readSingleService;
        private readonly IReadSingleSelectedService<Item> readSingleSelectedService = readSingleSelectedService;
        private readonly IReadRangeService<Item> readRangeService = readRangeService;
        private readonly IUpdateSingleService<Item> updateSingleService = updateSingleService;
        private readonly IDeleteService<Item> deleteService = deleteService;
        private readonly IRequestMapper<CreateItemRequestDTO, Item> createMapper = createMapper;
        private readonly IRequestMapper<UpdateItemRequestDTO, Item> updateMapper = updateMapper;
        private readonly IResponseMapper<Item, SimpleItemResponseDTO> responseMapper = responseMapper;
    }
}
