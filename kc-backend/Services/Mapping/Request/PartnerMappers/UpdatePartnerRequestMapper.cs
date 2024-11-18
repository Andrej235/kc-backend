using kc_backend.DTOs.Requests.Partner;
using kc_backend.Models;

namespace kc_backend.Services.Mapping.Request.PartnerMappers
{
    public class UpdatePartnerRequestMapper : IRequestMapper<UpdatePartnerRequestDTO, Partner>
    {
        public Partner Map(UpdatePartnerRequestDTO from) => new()
        {
            Id = from.Id,
            Address = from.Address,
            Name = from.Name,
            Phone = from.Phone,
            Phone2 = from.Phone2,
            BankAccount = from.BankAccount,
            City = from.City,
            Email = from.Email,
            IsActive = from.IsActive,
            JMBG = from.JMBG,
            PostalCode = from.PostalCode,
            TaxId = from.TaxId,
            TaxObliged = from.TaxObliged,
            Type = from.Type,
        };
    }
}
