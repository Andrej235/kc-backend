namespace kc_backend.Models
{
    public class CreditNotes
    {
        public enum CreditNoteType
        {
            Approval,
            Charge
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public CreditNoteType Type { get; set; }
        public int Debt { get; set; }
        public string Note { get; set; }
        public bool Confirmed { get; set; }
        public int PartnerId { get; set; }
        public int InvoiceId { get; set; } //Sales
    }
}
