namespace kc_backend.DTOs.Requests.Requisition
{
    public class CreateRequisitionRequestDTO
    {
        public DateTime CreationDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public float Discount { get; set; }
        public int ObjectId { get; set; }
        public int PriceListId { get; set; }
    }
}
