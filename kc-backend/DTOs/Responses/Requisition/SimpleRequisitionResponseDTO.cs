using kc_backend.DTOs.Responses.Object;

namespace kc_backend.DTOs.Responses.Requisition
{
    public class SimpleRequisitionResponseDTO
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public float Discount { get; set; }

        public string PriceListName { get; set; } = null!;
        public int ItemCount { get; set; }

        public DetailedObjectResponseDTO Object { get; set; } = null!;
    }
}
