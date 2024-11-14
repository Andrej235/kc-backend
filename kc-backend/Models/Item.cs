namespace kc_backend.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int QuantityPerPackage { get; set; }
        public string Barcode { get; set; } = null!;
    }
}
