namespace kc_backend.DTOs.Responses.Item
{
    public class SimpleItemResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int QuantityPerPackage { get; set; }
        public string Barcode { get; set; } = null!;
    }
}
