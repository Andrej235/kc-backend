namespace kc_backend.DTOs.Responses.PriceList
{
    public class SimplePriceListResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int ItemCount { get; set; }
    }
}
