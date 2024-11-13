namespace kc_backend.Models
{
    public class Models
    {
        /*
         Warehouseid: primary key
      Name

      Public class Items
      Id: primary key
      Name
      QuantityPerPackage
      Barcode

      Public class PriceList
      Id: primary key
      Name

      Public class PriceListItem
      ItemId: primary key, foreign key
      PriceListId: primary key, foreign key
      Price

      Public class WarehouseItems
      WarehouseId: primary key, foreign key
      ItemId: primary key, foreign key
      Quantity

      Public class Partners
      Id: primary key
      Name
      Phone
      Phone2
      City
      PostalCode
      Address
      RegistrationNumber
      TaxObliged
      TaxId
      Email
      IsActive
      BankAccount
      Type

      Public class Object
      Id: primary key
      Address
      LocalCode
      PartnerId: foreign key

      Public class AdvanceSalesInvoice
      Id: primary key
      PaymentDate
      IssueDate
      TransactionDate
      ObjectId: foreign key
      PriceListId: foreign key

      Public class AdvanceSalesInvoiceItem
      ItemId: primary key, foreign key
      WarehouseId: primary key, foreign key
      AdvanceSalesInvoiceId: primary key, foreign key
      Quantity

      Public class AdvancePurchaseInvoice
      Id: primary key
      PaymentDate
      IssueDate
      TransactionDate
      WarehouseId: foreign key
      PartnerId: foreign key

      Public class AdvancePurchaseInvoiceItem
      ItemId: primary key, foreign key
      WarehouseId: primary key, foreign key
      AdvancePurchaseInvoiceId: primary key, foreign key
      Quantity

      Public class DispatchNote
      Id: primary key
      IssueDate
      TransactionDate
      PaymentDueDate
      Status
      Discount
      ObjectId: foreign key
      PriceListId: foreign key

      Public class DispatchNoteItem
      ItemId: primary key, foreign key
      WarehouseId: primary key, foreign key
      DispatchNoteId: primary key, foreign key
      PackageQuantity
      TotalItemQuantity

      Public class ProformaInvoice (Quotation / Offer / Proposal)
      Id: primary key
      IssueDate
      PaymentDueDate
      Discount
      PartnerId: foreign key
      PriceListId: foreign key

      Public class ProformaInvoiceItem
      ItemId: primary key, foreign key
      WarehouseId: primary key, foreign key
      ProformaInvoiceId: primary key, foreign key
      PackageQuantity
      TotalItemQuantity

      Public class SalesInvoices
      Id
      IssueDate
      PaymentDueDate
      TaxPaymentDate
      Status
      ObjectId: foreign key
      PriceListId: foreign key

      Public class SalesInvoiceItem
      ItemId: primary key, foreign key
      WarehouseId: primary key, foreign key
      SalesInvoiceId: primary key, foreign key
      Quantity

      Public class PurchaseInvoices
      Id
      IssueDate
      PaymentDueDate
      TaxPaymentDate
      NonTaxableAmount
      Note
      PartnerId: foreign key

      Public class PurchaseInvoiceItem
      ItemId: primary key, foreign key
      WarehouseId: primary key, foreign key
      PurchaseInvoiceId: primary key, foreign key
      Quantity

      Public class PartnerPayment
      Id: primary key
      BankName
      Description
      Date
      Status
      TotalPaid
      Currency
      PartnerId: foreign key

      Public class PaymentsToPartners
      Id: primary key
      BankName
      Description
      Date
      Status
      TotalPaid
      Currency
      PartnerId: foreign key

      Public class Compensations
      Id: primary key
      CompensationDate
      RealizationDate
      Description
      Debt
      Demand
      Status
      PartnerId: foreign key

      Public class PurchaseInvoiceCompensation
      InvoiceId: primary key, foreign key
      CompensationId: primary key, foreign key

      Public class SalesInvoiceCompensation
      InvoiceId: primary key, foreign key
      CompensationId: primary key, foreign key

      Public class AdvanceCustomerInvoice
      Id: primary key
      PaymentDate
      Description
      Demand
      PartnerId: foreign key
      PriceListId: foreign key

      Public class AdvanceSupplierInvoice
      Id: primary key
      PaymentDate
      Description
      Demand
      PartnerId: foreign key

      Public class CreditNotes
      Id: primary key
      Date
      Type (approval or charge)
      Debt
      Note
      Confirmed
      PartnerId: foreign key
      InvoiceId (sales): foreign key

      Public class Requisitions
      Id: primary key
      CreationDate
      DeliveryDate
      Discount
      ObjectId: foreign key
      PriceListId: foreign key

      Public class RequisitionItem
      RequisitionId: primary key, foreign key
      ItemId: primary key, foreign key
      WarehouseId: primary key, foreign key
      Quantity

      Public class Vehicles
      Id
      Brand
      Model
      PlateNumber
      LoadCapacity

      Public class Routes
      Id: primary key
      CreationDate
      Description
      GoodsWeight
      VehicleId: foreign key

      Public class RouteRequisition
      RouteId: primary key, foreign key
      requisitionId: primary key, foreign key
         */
    }
}
