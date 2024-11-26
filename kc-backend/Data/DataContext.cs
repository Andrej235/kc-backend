using kc_backend.Models;
using Microsoft.EntityFrameworkCore;
using Object = kc_backend.Models.Object;
using Route = kc_backend.Models.Route;

namespace kc_backend.Data
{
    public class DataContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<AdvanceCustomerInvoice> AdvanceCustomerInvoices { get; set; } = null!; //
        public DbSet<AdvancePurchaseInvoice> AdvancePurchaseInvoices { get; set; } = null!; //
        public DbSet<AdvancePurchaseInvoiceItem> AdvancePurchaseInvoiceItems { get; set; } = null!; //
        public DbSet<AdvanceSalesInvoice> AdvanceSalesInvoices { get; set; } = null!; //
        public DbSet<AdvanceSalesInvoiceItem> AdvanceSalesInvoiceItems { get; set; } = null!; //
        public DbSet<AdvanceSupplierInvoice> AdvanceSupplierInvoices { get; set; } = null!; //
        public DbSet<Compensation> Compensations { get; set; } = null!; //
        public DbSet<CreditNote> CreditNotes { get; set; } = null!; //
        public DbSet<DispatchNote> DispatchNotes { get; set; } = null!; //
        public DbSet<DispatchNoteItem> DispatchNoteItems { get; set; } = null!; //
        public DbSet<Item> Items { get; set; } = null!; //
        public DbSet<Object> Objects { get; set; } = null!; //
        public DbSet<Partner> Partners { get; set; } = null!; //
        public DbSet<PartnerPayment> PartnerPayments { get; set; } = null!; //
        public DbSet<PaymentsToPartners> PaymentsToPartners { get; set; } = null!; //
        public DbSet<PriceList> PriceLists { get; set; } = null!; //
        public DbSet<PriceListItem> PriceListItems { get; set; } = null!; //
        public DbSet<ProformaInvoice> ProformaInvoices { get; set; } = null!; //
        public DbSet<ProformaInvoiceItem> ProformaInvoiceItems { get; set; } = null!; //
        public DbSet<PurchaseInvoice> PurchaseInvoices { get; set; } = null!; //
        public DbSet<PurchaseInvoiceCompensation> PurchaseInvoiceCompensations { get; set; } = null!; //
        public DbSet<PurchaseInvoiceItem> PurchaseInvoiceItems { get; set; } = null!; //
        public DbSet<Requisition> Requisitions { get; set; } = null!; //
        public DbSet<RequisitionItem> RequisitionItems { get; set; } = null!; //
        public DbSet<Route> Routes { get; set; } = null!; // 
        public DbSet<RouteRequisition> RouteRequisitions { get; set; } = null!; //
        public DbSet<SalesInvoice> SalesInvoices { get; set; } = null!; //
        public DbSet<SalesInvoiceCompensation> SalesInvoiceCompensations { get; set; } = null!; //
        public DbSet<SalesInvoiceItem> SalesInvoiceItems { get; set; } = null!; //
        public DbSet<Vehicle> Vehicles { get; set; } = null!; //
        public DbSet<Warehouse> Warehouses { get; set; } = null!; //
        public DbSet<WarehouseItem> WarehouseItems { get; set; } = null!; //
        public DbSet<User> Users { get; set; } = null!; //
        public DbSet<RefreshToken> RefreshTokens { get; set; } = null!; //

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _ = modelBuilder.Entity<User>(user =>
            {
                _ = user.HasKey(x => x.Id);

                _ = user.HasIndex(x => x.Username).IsUnique();
                _ = user.HasIndex(x => x.Email).IsUnique();
            });

            _ = modelBuilder.Entity<RefreshToken>(refreshToken =>
            {
                _ = refreshToken.HasKey(x => x.Token);

                _ = refreshToken.HasOne(x => x.User)
                    .WithMany()
                    .HasForeignKey(x => x.UserId);
            });

            _ = modelBuilder.Entity<AdvanceCustomerInvoice>(advanceCustomerInvoice =>
            {
                _ = advanceCustomerInvoice.HasKey(x => x.Id);

                _ = advanceCustomerInvoice.HasOne(x => x.Partner)
                    .WithMany()
                    .HasForeignKey(x => x.PartnerId);

                _ = advanceCustomerInvoice.HasOne(x => x.PriceList)
                    .WithMany()
                    .HasForeignKey(x => x.PriceListId);

                _ = advanceCustomerInvoice.HasIndex(x => x.PartnerId);
            });

            _ = modelBuilder.Entity<AdvancePurchaseInvoice>(advancePurchaseInvoice =>
            {
                _ = advancePurchaseInvoice.HasKey(x => x.Id);

                _ = advancePurchaseInvoice.HasOne(x => x.Warehouse)
                    .WithMany()
                    .HasForeignKey(x => x.WarehouseId);

                _ = advancePurchaseInvoice.HasOne(x => x.PriceList)
                    .WithMany()
                    .HasForeignKey(x => x.PriceListId);

                _ = advancePurchaseInvoice.HasIndex(x => x.WarehouseId);
            });

            _ = modelBuilder.Entity<AdvancePurchaseInvoiceItem>(advancePurchaseInvoiceItem =>
            {
                _ = advancePurchaseInvoiceItem.HasKey(x => new { x.ItemId, x.AdvancePurchaseInvoiceId, x.WarehouseId });

                _ = advancePurchaseInvoiceItem.HasOne(x => x.AdvancePurchaseInvoice)
                    .WithMany(x => x.Items)
                    .HasForeignKey(x => x.AdvancePurchaseInvoiceId);

                _ = advancePurchaseInvoiceItem.HasOne(x => x.Warehouse)
                    .WithMany()
                    .HasForeignKey(x => x.WarehouseId)
                    .OnDelete(DeleteBehavior.NoAction);

                _ = advancePurchaseInvoiceItem.HasOne(x => x.Item)
                    .WithMany()
                    .HasForeignKey(x => x.ItemId);
            });

            _ = modelBuilder.Entity<AdvanceSalesInvoice>(advanceSalesInvoice =>
            {
                _ = advanceSalesInvoice.HasKey(x => x.Id);

                _ = advanceSalesInvoice.HasOne(x => x.Object)
                    .WithMany()
                    .HasForeignKey(x => x.ObjectId);

                _ = advanceSalesInvoice.HasOne(x => x.PriceList)
                    .WithMany()
                    .HasForeignKey(x => x.PriceListId);
            });

            _ = modelBuilder.Entity<AdvanceSalesInvoiceItem>(advanceSalesInvoiceItem =>
            {
                _ = advanceSalesInvoiceItem.HasKey(x => new { x.WarehouseId, x.ItemId, x.AdvanceSalesInvoiceId });

                _ = advanceSalesInvoiceItem.HasOne(x => x.Warehouse)
                    .WithMany()
                    .HasForeignKey(x => x.WarehouseId);

                _ = advanceSalesInvoiceItem.HasOne(x => x.Item)
                    .WithMany()
                    .HasForeignKey(x => x.ItemId);

                _ = advanceSalesInvoiceItem.HasOne(x => x.AdvanceSalesInvoice)
                    .WithMany()
                    .HasForeignKey(x => x.AdvanceSalesInvoiceId);
            });

            _ = modelBuilder.Entity<AdvanceSupplierInvoice>(AdvanceSupplierInvoice =>
            {
                _ = AdvanceSupplierInvoice.HasKey(x => x.Id);

                _ = AdvanceSupplierInvoice.HasOne(x => x.Partner)
                    .WithMany()
                    .HasForeignKey(x => x.PartnerId);
            });

            _ = modelBuilder.Entity<Compensation>(compensation =>
            {
                _ = compensation.HasKey(x => x.Id);

                _ = compensation.HasOne(x => x.Partner)
                    .WithMany()
                    .HasForeignKey(x => x.PartnerId);
            });

            _ = modelBuilder.Entity<CreditNote>(creditNote =>
            {
                _ = creditNote.HasKey(x => x.Id);

                _ = creditNote.HasOne(x => x.Partner)
                     .WithMany()
                     .HasForeignKey(x => x.PartnerId);

                _ = creditNote.HasOne(x => x.Invoice)
                     .WithMany()
                     .HasForeignKey(x => x.InvoiceId)
                     .OnDelete(DeleteBehavior.NoAction);
            });

            _ = modelBuilder.Entity<DispatchNote>(dispatchNote =>
            {
                _ = dispatchNote.HasKey(x => x.Id);

                _ = dispatchNote.HasOne(x => x.Object)
                    .WithMany()
                    .HasForeignKey(x => x.ObjectId);

                _ = dispatchNote.HasOne(x => x.PriceList)
                    .WithMany()
                    .HasForeignKey(x => x.PriceListId);
            });

            _ = modelBuilder.Entity<DispatchNoteItem>(dispatchNoteItem =>
            {
                _ = dispatchNoteItem.HasKey(x => new { x.WarehouseId, x.ItemId, x.DispatchNoteId });

                _ = dispatchNoteItem.HasOne(x => x.Warehouse)
                    .WithMany()
                    .HasForeignKey(x => x.WarehouseId);

                _ = dispatchNoteItem.HasOne(x => x.Item)
                    .WithMany()
                    .HasForeignKey(x => x.ItemId);

                _ = dispatchNoteItem.HasOne(x => x.DispatchNote)
                    .WithMany()
                    .HasForeignKey(x => x.DispatchNoteId);
            });

            _ = modelBuilder.Entity<Item>(item => _ = item.HasKey(x => x.Id));

            _ = modelBuilder.Entity<Object>(obj =>
            {
                _ = obj.HasKey(x => x.Id);

                _ = obj.HasOne(x => x.Owner)
                    .WithMany(x => x.Objects)
                    .HasForeignKey(x => x.OwnerId);
            });

            _ = modelBuilder.Entity<Partner>(partner => _ = partner.HasKey(x => x.Id));

            _ = modelBuilder.Entity<PartnerPayment>(partnerPayment =>
            {
                _ = partnerPayment.HasKey(x => x.Id);

                _ = partnerPayment.HasOne(x => x.Partner)
                    .WithMany()
                    .HasForeignKey(x => x.PartnerId);
            });

            _ = modelBuilder.Entity<PaymentsToPartners>(paymentsToPartners =>
            {
                _ = paymentsToPartners.HasKey(x => x.Id);

                _ = paymentsToPartners.HasOne(x => x.Partner)
                    .WithMany()
                    .HasForeignKey(x => x.PartnerId);
            });

            _ = modelBuilder.Entity<PriceList>(priceList => _ = priceList.HasKey(x => x.Id));

            _ = modelBuilder.Entity<PriceListItem>(priceListItem =>
            {
                _ = priceListItem.HasKey(x => new { x.PriceListId, x.ItemId });

                _ = priceListItem.HasOne(x => x.PriceList)
                    .WithMany(x => x.Items)
                    .HasForeignKey(x => x.PriceListId);

                _ = priceListItem.HasOne(x => x.Item)
                    .WithMany()
                    .HasForeignKey(x => x.ItemId);
            });

            _ = modelBuilder.Entity<ProformaInvoice>(proformaInvoice =>
            {
                _ = proformaInvoice.HasKey(x => x.Id);

                _ = proformaInvoice.HasOne(x => x.Partner)
                    .WithMany()
                    .HasForeignKey(x => x.PartnerId);

                _ = proformaInvoice.HasOne(x => x.PriceList)
                    .WithMany()
                    .HasForeignKey(x => x.PriceListId);
            });

            _ = modelBuilder.Entity<ProformaInvoiceItem>(proformaInvoiceItem =>
            {
                _ = proformaInvoiceItem.HasKey(x => new { x.ItemId, x.ProformaInvoiceId, x.WarehouseId });

                _ = proformaInvoiceItem.HasOne(x => x.ProformaInvoice)
                    .WithMany(x => x.Items)
                    .HasForeignKey(x => x.ProformaInvoiceId);

                _ = proformaInvoiceItem.HasOne(x => x.Warehouse)
                    .WithMany()
                    .HasForeignKey(x => x.WarehouseId);

                _ = proformaInvoiceItem.HasOne(x => x.Item)
                    .WithMany()
                    .HasForeignKey(x => x.ItemId);
            });

            _ = modelBuilder.Entity<PurchaseInvoice>(purchaseInvoice =>
            {
                _ = purchaseInvoice.HasKey(x => x.Id);

                _ = purchaseInvoice.HasOne(x => x.Partner)
                    .WithMany()
                    .HasForeignKey(x => x.PartnerId);
            });

            _ = modelBuilder.Entity<PurchaseInvoiceCompensation>(purchaseInvoiceCompensation =>
            {
                _ = purchaseInvoiceCompensation.HasKey(x => new { x.CompensationId, x.InvoiceId });

                _ = purchaseInvoiceCompensation.HasOne(x => x.Compensation)
                    .WithMany()
                    .HasForeignKey(x => x.CompensationId);

                _ = purchaseInvoiceCompensation.HasOne(x => x.PurchaseInvoice)
                    .WithMany()
                    .HasForeignKey(x => x.InvoiceId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            _ = modelBuilder.Entity<PurchaseInvoiceItem>(purchaseInvoiceItem =>
            {
                _ = purchaseInvoiceItem.HasKey(x => new { x.ItemId, x.PurchaseInvoiceId, x.WarehouseId });

                _ = purchaseInvoiceItem.HasOne(x => x.PurchaseInvoice)
                    .WithMany(x => x.Items)
                    .HasForeignKey(x => x.PurchaseInvoiceId);

                _ = purchaseInvoiceItem.HasOne(x => x.Warehouse)
                    .WithMany()
                    .HasForeignKey(x => x.WarehouseId);

                _ = purchaseInvoiceItem.HasOne(x => x.Item)
                    .WithMany()
                    .HasForeignKey(x => x.ItemId);
            });

            _ = modelBuilder.Entity<Requisition>(requisition =>
            {
                _ = requisition.HasKey(x => x.Id);

                _ = requisition.HasOne(x => x.Object)
                    .WithMany()
                    .HasForeignKey(x => x.ObjectId);

                _ = requisition.HasOne(x => x.PriceList)
                    .WithMany()
                    .HasForeignKey(x => x.PriceListId);
            });

            _ = modelBuilder.Entity<RequisitionItem>(requisitionItem =>
            {
                _ = requisitionItem.HasKey(x => new { x.ItemId, x.RequisitionId, x.WarehouseId });

                _ = requisitionItem.HasOne(x => x.Requisition)
                    .WithMany(x => x.Items)
                    .HasForeignKey(x => x.RequisitionId);

                _ = requisitionItem.HasOne(x => x.Warehouse)
                    .WithMany()
                    .HasForeignKey(x => x.WarehouseId);

                _ = requisitionItem.HasOne(x => x.Item)
                    .WithMany()
                    .HasForeignKey(x => x.ItemId);
            });

            _ = modelBuilder.Entity<Route>(route =>
            {
                _ = route.HasKey(x => x.Id);

                _ = route.HasOne(x => x.Vehicle)
                    .WithMany(x => x.Routes)
                    .HasForeignKey(x => x.VehicleId);

                _ = route.HasMany(x => x.Requisitions)
                    .WithMany(x => x.UsedInRoutes)
                    .UsingEntity<RouteRequisition>(routeRequisitions =>
                    {
                        _ = routeRequisitions.HasKey(x => new { x.RequisitionId, x.RouteId });

                        _ = routeRequisitions.HasOne(x => x.Requisition)
                            .WithMany()
                            .HasForeignKey(x => x.RequisitionId);

                        _ = routeRequisitions.HasOne(x => x.Route)
                            .WithMany()
                            .HasForeignKey(x => x.RouteId);
                    });
            });

            _ = modelBuilder.Entity<SalesInvoice>(salesInvoice =>
            {
                _ = salesInvoice.HasKey(x => x.Id);

                _ = salesInvoice.HasOne(x => x.PriceList)
                    .WithMany()
                    .HasForeignKey(x => x.PriceListId);

                _ = salesInvoice.HasOne(x => x.Object)
                    .WithMany()
                    .HasForeignKey(x => x.ObjectId);
            });

            _ = modelBuilder.Entity<SalesInvoiceCompensation>(salesInvoiceCompensation =>
            {
                _ = salesInvoiceCompensation.HasKey(x => new { x.CompensationId, x.InvoiceId });

                _ = salesInvoiceCompensation.HasOne(x => x.Compensation)
                    .WithMany()
                    .HasForeignKey(x => x.CompensationId);

                _ = salesInvoiceCompensation.HasOne(x => x.SalesInvoice)
                    .WithMany()
                    .HasForeignKey(x => x.InvoiceId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            _ = modelBuilder.Entity<SalesInvoiceItem>(salesInvoiceItem =>
            {
                _ = salesInvoiceItem.HasKey(x => new { x.ItemId, x.SalesInvoiceId, x.WarehouseId });

                _ = salesInvoiceItem.HasOne(x => x.SalesInvoice)
                    .WithMany(x => x.Items)
                    .HasForeignKey(x => x.SalesInvoiceId);

                _ = salesInvoiceItem.HasOne(x => x.Warehouse)
                    .WithMany()
                    .HasForeignKey(x => x.WarehouseId);

                _ = salesInvoiceItem.HasOne(x => x.Item)
                    .WithMany()
                    .HasForeignKey(x => x.ItemId);
            });

            _ = modelBuilder.Entity<Vehicle>(vehicle => _ = vehicle.HasKey(x => x.Id));

            _ = modelBuilder.Entity<Warehouse>(warehouse => _ = warehouse.HasKey(x => x.Id));

            _ = modelBuilder.Entity<WarehouseItem>(warehouseItem =>
            {
                _ = warehouseItem.HasKey(x => new { x.ItemId, x.WarehouseId });

                _ = warehouseItem.HasOne(x => x.Item)
                    .WithMany()
                    .HasForeignKey(x => x.ItemId);

                _ = warehouseItem.HasOne(x => x.Warehouse)
                    .WithMany(x => x.Items)
                    .HasForeignKey(x => x.WarehouseId);
            });
        }
    }
}
