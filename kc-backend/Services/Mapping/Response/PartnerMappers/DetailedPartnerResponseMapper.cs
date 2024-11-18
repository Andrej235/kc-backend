using kc_backend.DTOs.Responses.Object;
using kc_backend.DTOs.Responses.Partner;
using kc_backend.Models;

namespace kc_backend.Services.Mapping.Response.PartnerMappers
{
    public class DetailedPartnerResponseMapper(IResponseMapper<Models.Object, SimpleObjectResponseDTO> objectMapper) : IResponseMapper<Partner, DetailedPartnerResponseDTO>
    {
        private readonly IResponseMapper<Models.Object, SimpleObjectResponseDTO> objectMapper = objectMapper;

        public DetailedPartnerResponseDTO Map(Partner from) => new()
        {
            Id = from.Id,
            Address = from.Address,
            BankAccount = from.BankAccount,
            City = from.City,
            Email = from.Email,
            IsActive = from.IsActive,
            JMBG = from.JMBG,
            Name = from.Name,
            Phone = from.Phone,
            Phone2 = from.Phone2,
            PostalCode = from.PostalCode,
            TaxId = from.TaxId,
            TaxObliged = from.TaxObliged,
            Type = from.Type,
            Objects = from.Objects.Select(objectMapper.Map),
        };
    }
}
