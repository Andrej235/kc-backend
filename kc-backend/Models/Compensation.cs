namespace kc_backend.Models
{
    public class Compensation
    {
        public int Id { get; set; }
        public DateTime CompensationDate { get; set; }
        public DateTime RealizationDate { get; set; }
        public string Description { get; set; } = null!;
        public int Debt { get; set; }
        public int Demand { get; set; }
        public int Status { get; set; }

        public int PartnerId { get; set; }
        public Partner Partner { get; set; } = null!;
    }
}
