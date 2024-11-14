using kc_backend.Models;
using Microsoft.EntityFrameworkCore;
using Object = kc_backend.Models.Object;
using Route = kc_backend.Models.Route;

namespace kc_backend.Data
{
    public class DataContext : DbContext
    {
        public DbSet<AdvanceCustomerInvoice> AdvanceCustomerInvoices { get; set; } = null!;
        public DbSet<AdvancePurchaseInvoice> AdvancePurchaseInvoices { get; set; } = null!;
        public DbSet<AdvancePurchaseInvoiceItem> AdvancePurchaseInvoiceItems { get; set; } = null!;
        public DbSet<AdvanceSalesInvoice> AdvanceSalesInvoices { get; set; } = null!;
        public DbSet<AdvanceSalesInvoiceItem> AdvanceSalesInvoiceItems { get; set; } = null!;
        public DbSet<AdvanceSupplierInvoice> AdvanceSupplierInvoices { get; set; } = null!;
        public DbSet<Compensation> Compensations { get; set; } = null!;
        public DbSet<CreditNote> CreditNotes { get; set; } = null!;
        public DbSet<DispatchNote> DispatchNotes { get; set; } = null!;
        public DbSet<DispatchNoteItem> DispatchNoteItems { get; set; } = null!;
        public DbSet<Item> Items { get; set; } = null!;
        public DbSet<Object> Objects { get; set; } = null!;
        public DbSet<Partner> Partners { get; set; } = null!;
        public DbSet<PartnerPayment> PartnerPayments { get; set; } = null!;
        public DbSet<PaymentsToPartners> PaymentsToPartners { get; set; } = null!;
        public DbSet<PriceList> PriceLists { get; set; } = null!;
        public DbSet<PriceListItem> PriceListItems { get; set; } = null!;
        public DbSet<ProformaInvoice> ProformaInvoices { get; set; } = null!;
        public DbSet<ProformaInvoiceItem> ProformaInvoiceItems { get; set; } = null!;
        public DbSet<PurchaseInvoice> PurchaseInvoices { get; set; } = null!;
        public DbSet<PurchaseInvoiceCompensation> PurchaseInvoiceCompensations { get; set; } = null!;
        public DbSet<PurchaseInvoiceItem> PurchaseInvoiceItems { get; set; } = null!;
        public DbSet<Requisition> Requisitions { get; set; } = null!;
        public DbSet<RequisitionItem> RequisitionItems { get; set; } = null!;
        public DbSet<Route> Routes { get; set; } = null!;
        public DbSet<RouteRequisition> RouteRequisitions { get; set; } = null!;
        public DbSet<SalesInvoiceCompensation> SalesInvoiceCompensations { get; set; } = null!;
        public DbSet<SalesInvoiceItem> SalesInvoiceItems { get; set; } = null!;
        public DbSet<SalesInvoices> SalesInvoices { get; set; } = null!;
        public DbSet<Vehicles> Vehicles { get; set; } = null!;
        public DbSet<Warehouse> Warehouses { get; set; } = null!;
        public DbSet<WarehouseItems> WarehouseItems { get; set; } = null!;
    }
}
