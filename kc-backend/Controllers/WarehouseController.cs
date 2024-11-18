using kc_backend.DTOs.Requests.Warehouse;
using kc_backend.DTOs.Responses.Warehouse;
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
    [Route("api/warehouse")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public partial class WarehouseController(ICreateService<Warehouse> createService,
                                             ICreateService<WarehouseItem> warehouseItemCreateService,
                                             IReadSingleService<Warehouse> readSingleService,
                                             IReadSingleSelectedService<Warehouse> readSingleSelectedService,
                                             IReadRangeService<Warehouse> readRangeService,
                                             IUpdateSingleService<Warehouse> updateSingleService,
                                             IExecuteUpdateService<WarehouseItem> warehouseItemExecuteUpdateService,
                                             IDeleteService<Warehouse> deleteService,
                                             IDeleteService<WarehouseItem> warehouseItemDeleteService,
                                             IRequestMapper<CreateWarehouseRequestDTO, Warehouse> createMapper,
                                             IRequestMapper<UpdateWarehouseRequestDTO, Warehouse> updateMapper,
                                             IResponseMapper<Warehouse, SimpleWarehouseResponseDTO> simpleResponseMapper,
                                             IResponseMapper<Warehouse, DetailedWarehouseResponseDTO> detailedResponseMapper) : ControllerBase
    {
        private readonly ICreateService<Warehouse> createService = createService;
        private readonly ICreateService<WarehouseItem> warehouseItemCreateService = warehouseItemCreateService;
        private readonly IReadSingleService<Warehouse> readSingleService = readSingleService;
        private readonly IReadSingleSelectedService<Warehouse> readSingleSelectedService = readSingleSelectedService;
        private readonly IReadRangeService<Warehouse> readRangeService = readRangeService;
        private readonly IUpdateSingleService<Warehouse> updateSingleService = updateSingleService;
        private readonly IExecuteUpdateService<WarehouseItem> warehouseItemExecuteUpdateService = warehouseItemExecuteUpdateService;
        private readonly IDeleteService<Warehouse> deleteService = deleteService;
        private readonly IDeleteService<WarehouseItem> warehouseItemDeleteService = warehouseItemDeleteService;
        private readonly IRequestMapper<CreateWarehouseRequestDTO, Warehouse> createMapper = createMapper;
        private readonly IRequestMapper<UpdateWarehouseRequestDTO, Warehouse> updateMapper = updateMapper;
        private readonly IResponseMapper<Warehouse, SimpleWarehouseResponseDTO> simpleResponseMapper = simpleResponseMapper;
        private readonly IResponseMapper<Warehouse, DetailedWarehouseResponseDTO> detailedResponseMapper = detailedResponseMapper;
    }
}
