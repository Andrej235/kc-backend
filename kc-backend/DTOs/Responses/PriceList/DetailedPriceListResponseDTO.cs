namespace kc_backend.DTOs.Responses.PriceList
{
    public class DetailedPriceListResponseDTO : SimplePriceListResponseDTO
    {
        public IEnumerable<PriceListItemResponseDTO> Items { get; set; } = null!;
    }
}
