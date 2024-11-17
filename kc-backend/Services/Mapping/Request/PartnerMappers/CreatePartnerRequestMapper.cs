using kc_backend.DTOs.Requests.Partner;
using kc_backend.Models;

namespace kc_backend.Services.Mapping.Request.PartnerMappers
{
    public class CreatePartnerRequestMapper : IRequestMapper<CreatePartnerRequestDTO, Partner>
    {
        public Partner Map(CreatePartnerRequestDTO from) => new()
        {
            Address = from.Address,
            Name = from.Name,
            Phone = from.Phone,
            Phone2 = from.Phone2,
            BankAccount = from.BankAccount,
            City = from.City,
            Email = from.Email,
            IsActive = true,
            JMBG = from.JMBG,
            PostalCode = from.PostalCode,
            TaxId = from.TaxId,
            TaxObliged = from.TaxObliged,
            Type = from.Type,
            Objects = []
        };
    }
}
