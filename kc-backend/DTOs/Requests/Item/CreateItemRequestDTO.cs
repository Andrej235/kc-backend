namespace kc_backend.DTOs.Requests.Item
{
    public class CreateItemRequestDTO
    {
        public string Name { get; set; } = null!;
        public int QuantityPerPackage { get; set; }
        public string Barcode { get; set; } = null!;
    }
}
