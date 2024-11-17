using kc_backend.DTOs.Requests.Partner;
using kc_backend.Models;
using kc_backend.Services.Create;
using kc_backend.Services.Mapping.Request;
using Microsoft.AspNetCore.Mvc;

namespace kc_backend.Controllers
{
    [Route("api/partner")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public partial class PartnerController(ICreateService<Partner> createService,
                                           IRequestMapper<CreatePartnerRequestDTO, Partner> createMapper) : ControllerBase
    {
        private readonly ICreateService<Partner> createService = createService;
        private readonly IRequestMapper<CreatePartnerRequestDTO, Partner> createMapper = createMapper;
    }
}
