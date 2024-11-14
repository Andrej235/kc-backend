namespace kc_backend.Models
{
    public class RouteRequisition
    {
        public int RouteId { get; set; }
        public Route Route { get; set; } = null!;

        public int RequisitionId { get; set; }
        public Requisition Requisition { get; set; } = null!;
    }
}
