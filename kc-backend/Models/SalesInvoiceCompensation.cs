﻿namespace kc_backend.Models
{
    public class SalesInvoiceCompensation
    {
        public int InvoiceId { get; set; }
        public SalesInvoice SalesInvoices { get; set; } = null!;

        public int CompensationId { get; set; }
        public Compensation Compensation { get; set; } = null!;
    }
}
