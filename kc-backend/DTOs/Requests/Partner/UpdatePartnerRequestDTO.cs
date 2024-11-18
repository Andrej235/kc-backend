namespace kc_backend.DTOs.Requests.Partner
{
    public class UpdatePartnerRequestDTO : CreatePartnerRequestDTO
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
    }
}
