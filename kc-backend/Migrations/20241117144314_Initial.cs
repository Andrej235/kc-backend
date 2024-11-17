using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kc_backend.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuantityPerPackage = table.Column<int>(type: "int", nullable: false),
                    Barcode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table => table.PrimaryKey("PK_Items", x => x.Id));

            _ = migrationBuilder.CreateTable(
                name: "Partners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JMBG = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxObliged = table.Column<bool>(type: "bit", nullable: false),
                    TaxId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankAccount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table => table.PrimaryKey("PK_Partners", x => x.Id));

            _ = migrationBuilder.CreateTable(
                name: "PriceLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table => table.PrimaryKey("PK_PriceLists", x => x.Id));

            _ = migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Salt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table => table.PrimaryKey("PK_Users", x => x.Id));

            _ = migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlateNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoadCapacity = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table => table.PrimaryKey("PK_Vehicles", x => x.Id));

            _ = migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table => table.PrimaryKey("PK_Warehouses", x => x.Id));

            _ = migrationBuilder.CreateTable(
                name: "AdvanceSupplierInvoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Demand = table.Column<int>(type: "int", nullable: false),
                    PartnerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_AdvanceSupplierInvoices", x => x.Id);
                    _ = table.ForeignKey(
                        name: "FK_AdvanceSupplierInvoices_Partners_PartnerId",
                        column: x => x.PartnerId,
                        principalTable: "Partners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateTable(
                name: "Compensations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompensationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RealizationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Debt = table.Column<int>(type: "int", nullable: false),
                    Demand = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    PartnerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_Compensations", x => x.Id);
                    _ = table.ForeignKey(
                        name: "FK_Compensations_Partners_PartnerId",
                        column: x => x.PartnerId,
                        principalTable: "Partners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateTable(
                name: "Objects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_Objects", x => x.Id);
                    _ = table.ForeignKey(
                        name: "FK_Objects_Partners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Partners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateTable(
                name: "PartnerPayments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    TotalPaid = table.Column<int>(type: "int", nullable: false),
                    Currency = table.Column<int>(type: "int", nullable: false),
                    PartnerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_PartnerPayments", x => x.Id);
                    _ = table.ForeignKey(
                        name: "FK_PartnerPayments_Partners_PartnerId",
                        column: x => x.PartnerId,
                        principalTable: "Partners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateTable(
                name: "PaymentsToPartners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    TotalPaid = table.Column<int>(type: "int", nullable: false),
                    Currency = table.Column<int>(type: "int", nullable: false),
                    PartnerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_PaymentsToPartners", x => x.Id);
                    _ = table.ForeignKey(
                        name: "FK_PaymentsToPartners_Partners_PartnerId",
                        column: x => x.PartnerId,
                        principalTable: "Partners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateTable(
                name: "PurchaseInvoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentDueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TaxPaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NonTaxableAmount = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PartnerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_PurchaseInvoices", x => x.Id);
                    _ = table.ForeignKey(
                        name: "FK_PurchaseInvoices_Partners_PartnerId",
                        column: x => x.PartnerId,
                        principalTable: "Partners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateTable(
                name: "AdvanceCustomerInvoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Demand = table.Column<int>(type: "int", nullable: false),
                    PartnerId = table.Column<int>(type: "int", nullable: false),
                    PriceListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_AdvanceCustomerInvoices", x => x.Id);
                    _ = table.ForeignKey(
                        name: "FK_AdvanceCustomerInvoices_Partners_PartnerId",
                        column: x => x.PartnerId,
                        principalTable: "Partners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    _ = table.ForeignKey(
                        name: "FK_AdvanceCustomerInvoices_PriceLists_PriceListId",
                        column: x => x.PriceListId,
                        principalTable: "PriceLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateTable(
                name: "PriceListItems",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    PriceListId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_PriceListItems", x => new { x.PriceListId, x.ItemId });
                    _ = table.ForeignKey(
                        name: "FK_PriceListItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    _ = table.ForeignKey(
                        name: "FK_PriceListItems_PriceLists_PriceListId",
                        column: x => x.PriceListId,
                        principalTable: "PriceLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateTable(
                name: "ProformaInvoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentDueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Discount = table.Column<float>(type: "real", nullable: false),
                    PartnerId = table.Column<int>(type: "int", nullable: false),
                    PriceListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_ProformaInvoices", x => x.Id);
                    _ = table.ForeignKey(
                        name: "FK_ProformaInvoices_Partners_PartnerId",
                        column: x => x.PartnerId,
                        principalTable: "Partners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    _ = table.ForeignKey(
                        name: "FK_ProformaInvoices_PriceLists_PriceListId",
                        column: x => x.PriceListId,
                        principalTable: "PriceLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Token = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JwtId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_RefreshTokens", x => x.Token);
                    _ = table.ForeignKey(
                        name: "FK_RefreshTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GoodsWeight = table.Column<float>(type: "real", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_Routes", x => x.Id);
                    _ = table.ForeignKey(
                        name: "FK_Routes_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateTable(
                name: "AdvancePurchaseInvoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WarehouseId = table.Column<int>(type: "int", nullable: false),
                    PriceListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_AdvancePurchaseInvoices", x => x.Id);
                    _ = table.ForeignKey(
                        name: "FK_AdvancePurchaseInvoices_PriceLists_PriceListId",
                        column: x => x.PriceListId,
                        principalTable: "PriceLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    _ = table.ForeignKey(
                        name: "FK_AdvancePurchaseInvoices_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateTable(
                name: "WarehouseItems",
                columns: table => new
                {
                    WarehouseId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_WarehouseItems", x => new { x.ItemId, x.WarehouseId });
                    _ = table.ForeignKey(
                        name: "FK_WarehouseItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    _ = table.ForeignKey(
                        name: "FK_WarehouseItems_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateTable(
                name: "AdvanceSalesInvoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ObjectId = table.Column<int>(type: "int", nullable: false),
                    PriceListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_AdvanceSalesInvoices", x => x.Id);
                    _ = table.ForeignKey(
                        name: "FK_AdvanceSalesInvoices_Objects_ObjectId",
                        column: x => x.ObjectId,
                        principalTable: "Objects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    _ = table.ForeignKey(
                        name: "FK_AdvanceSalesInvoices_PriceLists_PriceListId",
                        column: x => x.PriceListId,
                        principalTable: "PriceLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateTable(
                name: "DispatchNotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<float>(type: "real", nullable: false),
                    ObjectId = table.Column<int>(type: "int", nullable: false),
                    PriceListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_DispatchNotes", x => x.Id);
                    _ = table.ForeignKey(
                        name: "FK_DispatchNotes_Objects_ObjectId",
                        column: x => x.ObjectId,
                        principalTable: "Objects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    _ = table.ForeignKey(
                        name: "FK_DispatchNotes_PriceLists_PriceListId",
                        column: x => x.PriceListId,
                        principalTable: "PriceLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateTable(
                name: "Requisitions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Discount = table.Column<float>(type: "real", nullable: false),
                    ObjectId = table.Column<int>(type: "int", nullable: false),
                    PriceListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_Requisitions", x => x.Id);
                    _ = table.ForeignKey(
                        name: "FK_Requisitions_Objects_ObjectId",
                        column: x => x.ObjectId,
                        principalTable: "Objects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    _ = table.ForeignKey(
                        name: "FK_Requisitions_PriceLists_PriceListId",
                        column: x => x.PriceListId,
                        principalTable: "PriceLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateTable(
                name: "SalesInvoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentDueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TaxPaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ObjectId = table.Column<int>(type: "int", nullable: false),
                    PriceListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_SalesInvoices", x => x.Id);
                    _ = table.ForeignKey(
                        name: "FK_SalesInvoices_Objects_ObjectId",
                        column: x => x.ObjectId,
                        principalTable: "Objects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    _ = table.ForeignKey(
                        name: "FK_SalesInvoices_PriceLists_PriceListId",
                        column: x => x.PriceListId,
                        principalTable: "PriceLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateTable(
                name: "PurchaseInvoiceCompensations",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    CompensationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_PurchaseInvoiceCompensations", x => new { x.CompensationId, x.InvoiceId });
                    _ = table.ForeignKey(
                        name: "FK_PurchaseInvoiceCompensations_Compensations_CompensationId",
                        column: x => x.CompensationId,
                        principalTable: "Compensations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    _ = table.ForeignKey(
                        name: "FK_PurchaseInvoiceCompensations_PurchaseInvoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "PurchaseInvoices",
                        principalColumn: "Id");
                });

            _ = migrationBuilder.CreateTable(
                name: "PurchaseInvoiceItems",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    WarehouseId = table.Column<int>(type: "int", nullable: false),
                    PurchaseInvoiceId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_PurchaseInvoiceItems", x => new { x.ItemId, x.PurchaseInvoiceId, x.WarehouseId });
                    _ = table.ForeignKey(
                        name: "FK_PurchaseInvoiceItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    _ = table.ForeignKey(
                        name: "FK_PurchaseInvoiceItems_PurchaseInvoices_PurchaseInvoiceId",
                        column: x => x.PurchaseInvoiceId,
                        principalTable: "PurchaseInvoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    _ = table.ForeignKey(
                        name: "FK_PurchaseInvoiceItems_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateTable(
                name: "ProformaInvoiceItems",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    WarehouseId = table.Column<int>(type: "int", nullable: false),
                    ProformaInvoiceId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_ProformaInvoiceItems", x => new { x.ItemId, x.ProformaInvoiceId, x.WarehouseId });
                    _ = table.ForeignKey(
                        name: "FK_ProformaInvoiceItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    _ = table.ForeignKey(
                        name: "FK_ProformaInvoiceItems_ProformaInvoices_ProformaInvoiceId",
                        column: x => x.ProformaInvoiceId,
                        principalTable: "ProformaInvoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    _ = table.ForeignKey(
                        name: "FK_ProformaInvoiceItems_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateTable(
                name: "AdvancePurchaseInvoiceItems",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    WarehouseId = table.Column<int>(type: "int", nullable: false),
                    AdvancePurchaseInvoiceId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_AdvancePurchaseInvoiceItems", x => new { x.ItemId, x.AdvancePurchaseInvoiceId, x.WarehouseId });
                    _ = table.ForeignKey(
                        name: "FK_AdvancePurchaseInvoiceItems_AdvancePurchaseInvoices_AdvancePurchaseInvoiceId",
                        column: x => x.AdvancePurchaseInvoiceId,
                        principalTable: "AdvancePurchaseInvoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    _ = table.ForeignKey(
                        name: "FK_AdvancePurchaseInvoiceItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    _ = table.ForeignKey(
                        name: "FK_AdvancePurchaseInvoiceItems_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id");
                });

            _ = migrationBuilder.CreateTable(
                name: "AdvanceSalesInvoiceItems",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    WarehouseId = table.Column<int>(type: "int", nullable: false),
                    AdvanceSalesInvoiceId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_AdvanceSalesInvoiceItems", x => new { x.WarehouseId, x.ItemId, x.AdvanceSalesInvoiceId });
                    _ = table.ForeignKey(
                        name: "FK_AdvanceSalesInvoiceItems_AdvanceSalesInvoices_AdvanceSalesInvoiceId",
                        column: x => x.AdvanceSalesInvoiceId,
                        principalTable: "AdvanceSalesInvoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    _ = table.ForeignKey(
                        name: "FK_AdvanceSalesInvoiceItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    _ = table.ForeignKey(
                        name: "FK_AdvanceSalesInvoiceItems_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateTable(
                name: "DispatchNoteItems",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    WarehouseId = table.Column<int>(type: "int", nullable: false),
                    DispatchNoteId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_DispatchNoteItems", x => new { x.WarehouseId, x.ItemId, x.DispatchNoteId });
                    _ = table.ForeignKey(
                        name: "FK_DispatchNoteItems_DispatchNotes_DispatchNoteId",
                        column: x => x.DispatchNoteId,
                        principalTable: "DispatchNotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    _ = table.ForeignKey(
                        name: "FK_DispatchNoteItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    _ = table.ForeignKey(
                        name: "FK_DispatchNoteItems_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateTable(
                name: "RequisitionItems",
                columns: table => new
                {
                    RequisitionId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    WarehouseId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_RequisitionItems", x => new { x.ItemId, x.RequisitionId, x.WarehouseId });
                    _ = table.ForeignKey(
                        name: "FK_RequisitionItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    _ = table.ForeignKey(
                        name: "FK_RequisitionItems_Requisitions_RequisitionId",
                        column: x => x.RequisitionId,
                        principalTable: "Requisitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    _ = table.ForeignKey(
                        name: "FK_RequisitionItems_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateTable(
                name: "RouteRequisitions",
                columns: table => new
                {
                    RouteId = table.Column<int>(type: "int", nullable: false),
                    RequisitionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_RouteRequisitions", x => new { x.RequisitionId, x.RouteId });
                    _ = table.ForeignKey(
                        name: "FK_RouteRequisitions_Requisitions_RequisitionId",
                        column: x => x.RequisitionId,
                        principalTable: "Requisitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    _ = table.ForeignKey(
                        name: "FK_RouteRequisitions_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateTable(
                name: "CreditNotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Debt = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Confirmed = table.Column<bool>(type: "bit", nullable: false),
                    PartnerId = table.Column<int>(type: "int", nullable: false),
                    InvoiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_CreditNotes", x => x.Id);
                    _ = table.ForeignKey(
                        name: "FK_CreditNotes_Partners_PartnerId",
                        column: x => x.PartnerId,
                        principalTable: "Partners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    _ = table.ForeignKey(
                        name: "FK_CreditNotes_SalesInvoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "SalesInvoices",
                        principalColumn: "Id");
                });

            _ = migrationBuilder.CreateTable(
                name: "SalesInvoiceCompensations",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    CompensationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_SalesInvoiceCompensations", x => new { x.CompensationId, x.InvoiceId });
                    _ = table.ForeignKey(
                        name: "FK_SalesInvoiceCompensations_Compensations_CompensationId",
                        column: x => x.CompensationId,
                        principalTable: "Compensations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    _ = table.ForeignKey(
                        name: "FK_SalesInvoiceCompensations_SalesInvoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "SalesInvoices",
                        principalColumn: "Id");
                });

            _ = migrationBuilder.CreateTable(
                name: "SalesInvoiceItems",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    WarehouseId = table.Column<int>(type: "int", nullable: false),
                    SalesInvoiceId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_SalesInvoiceItems", x => new { x.ItemId, x.SalesInvoiceId, x.WarehouseId });
                    _ = table.ForeignKey(
                        name: "FK_SalesInvoiceItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    _ = table.ForeignKey(
                        name: "FK_SalesInvoiceItems_SalesInvoices_SalesInvoiceId",
                        column: x => x.SalesInvoiceId,
                        principalTable: "SalesInvoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    _ = table.ForeignKey(
                        name: "FK_SalesInvoiceItems_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateIndex(
                name: "IX_AdvanceCustomerInvoices_PartnerId",
                table: "AdvanceCustomerInvoices",
                column: "PartnerId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_AdvanceCustomerInvoices_PriceListId",
                table: "AdvanceCustomerInvoices",
                column: "PriceListId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_AdvancePurchaseInvoiceItems_AdvancePurchaseInvoiceId",
                table: "AdvancePurchaseInvoiceItems",
                column: "AdvancePurchaseInvoiceId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_AdvancePurchaseInvoiceItems_WarehouseId",
                table: "AdvancePurchaseInvoiceItems",
                column: "WarehouseId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_AdvancePurchaseInvoices_PriceListId",
                table: "AdvancePurchaseInvoices",
                column: "PriceListId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_AdvancePurchaseInvoices_WarehouseId",
                table: "AdvancePurchaseInvoices",
                column: "WarehouseId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_AdvanceSalesInvoiceItems_AdvanceSalesInvoiceId",
                table: "AdvanceSalesInvoiceItems",
                column: "AdvanceSalesInvoiceId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_AdvanceSalesInvoiceItems_ItemId",
                table: "AdvanceSalesInvoiceItems",
                column: "ItemId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_AdvanceSalesInvoices_ObjectId",
                table: "AdvanceSalesInvoices",
                column: "ObjectId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_AdvanceSalesInvoices_PriceListId",
                table: "AdvanceSalesInvoices",
                column: "PriceListId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_AdvanceSupplierInvoices_PartnerId",
                table: "AdvanceSupplierInvoices",
                column: "PartnerId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_Compensations_PartnerId",
                table: "Compensations",
                column: "PartnerId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_CreditNotes_InvoiceId",
                table: "CreditNotes",
                column: "InvoiceId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_CreditNotes_PartnerId",
                table: "CreditNotes",
                column: "PartnerId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_DispatchNoteItems_DispatchNoteId",
                table: "DispatchNoteItems",
                column: "DispatchNoteId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_DispatchNoteItems_ItemId",
                table: "DispatchNoteItems",
                column: "ItemId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_DispatchNotes_ObjectId",
                table: "DispatchNotes",
                column: "ObjectId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_DispatchNotes_PriceListId",
                table: "DispatchNotes",
                column: "PriceListId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_Objects_OwnerId",
                table: "Objects",
                column: "OwnerId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_PartnerPayments_PartnerId",
                table: "PartnerPayments",
                column: "PartnerId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_PaymentsToPartners_PartnerId",
                table: "PaymentsToPartners",
                column: "PartnerId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_PriceListItems_ItemId",
                table: "PriceListItems",
                column: "ItemId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_ProformaInvoiceItems_ProformaInvoiceId",
                table: "ProformaInvoiceItems",
                column: "ProformaInvoiceId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_ProformaInvoiceItems_WarehouseId",
                table: "ProformaInvoiceItems",
                column: "WarehouseId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_ProformaInvoices_PartnerId",
                table: "ProformaInvoices",
                column: "PartnerId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_ProformaInvoices_PriceListId",
                table: "ProformaInvoices",
                column: "PriceListId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoiceCompensations_InvoiceId",
                table: "PurchaseInvoiceCompensations",
                column: "InvoiceId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoiceItems_PurchaseInvoiceId",
                table: "PurchaseInvoiceItems",
                column: "PurchaseInvoiceId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoiceItems_WarehouseId",
                table: "PurchaseInvoiceItems",
                column: "WarehouseId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoices_PartnerId",
                table: "PurchaseInvoices",
                column: "PartnerId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_RequisitionItems_RequisitionId",
                table: "RequisitionItems",
                column: "RequisitionId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_RequisitionItems_WarehouseId",
                table: "RequisitionItems",
                column: "WarehouseId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_Requisitions_ObjectId",
                table: "Requisitions",
                column: "ObjectId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_Requisitions_PriceListId",
                table: "Requisitions",
                column: "PriceListId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_RouteRequisitions_RouteId",
                table: "RouteRequisitions",
                column: "RouteId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_Routes_VehicleId",
                table: "Routes",
                column: "VehicleId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_SalesInvoiceCompensations_InvoiceId",
                table: "SalesInvoiceCompensations",
                column: "InvoiceId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_SalesInvoiceItems_SalesInvoiceId",
                table: "SalesInvoiceItems",
                column: "SalesInvoiceId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_SalesInvoiceItems_WarehouseId",
                table: "SalesInvoiceItems",
                column: "WarehouseId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_SalesInvoices_ObjectId",
                table: "SalesInvoices",
                column: "ObjectId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_SalesInvoices_PriceListId",
                table: "SalesInvoices",
                column: "PriceListId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);

            _ = migrationBuilder.CreateIndex(
                name: "IX_WarehouseItems_WarehouseId",
                table: "WarehouseItems",
                column: "WarehouseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.DropTable(
                name: "AdvanceCustomerInvoices");

            _ = migrationBuilder.DropTable(
                name: "AdvancePurchaseInvoiceItems");

            _ = migrationBuilder.DropTable(
                name: "AdvanceSalesInvoiceItems");

            _ = migrationBuilder.DropTable(
                name: "AdvanceSupplierInvoices");

            _ = migrationBuilder.DropTable(
                name: "CreditNotes");

            _ = migrationBuilder.DropTable(
                name: "DispatchNoteItems");

            _ = migrationBuilder.DropTable(
                name: "PartnerPayments");

            _ = migrationBuilder.DropTable(
                name: "PaymentsToPartners");

            _ = migrationBuilder.DropTable(
                name: "PriceListItems");

            _ = migrationBuilder.DropTable(
                name: "ProformaInvoiceItems");

            _ = migrationBuilder.DropTable(
                name: "PurchaseInvoiceCompensations");

            _ = migrationBuilder.DropTable(
                name: "PurchaseInvoiceItems");

            _ = migrationBuilder.DropTable(
                name: "RefreshTokens");

            _ = migrationBuilder.DropTable(
                name: "RequisitionItems");

            _ = migrationBuilder.DropTable(
                name: "RouteRequisitions");

            _ = migrationBuilder.DropTable(
                name: "SalesInvoiceCompensations");

            _ = migrationBuilder.DropTable(
                name: "SalesInvoiceItems");

            _ = migrationBuilder.DropTable(
                name: "WarehouseItems");

            _ = migrationBuilder.DropTable(
                name: "AdvancePurchaseInvoices");

            _ = migrationBuilder.DropTable(
                name: "AdvanceSalesInvoices");

            _ = migrationBuilder.DropTable(
                name: "DispatchNotes");

            _ = migrationBuilder.DropTable(
                name: "ProformaInvoices");

            _ = migrationBuilder.DropTable(
                name: "PurchaseInvoices");

            _ = migrationBuilder.DropTable(
                name: "Users");

            _ = migrationBuilder.DropTable(
                name: "Requisitions");

            _ = migrationBuilder.DropTable(
                name: "Routes");

            _ = migrationBuilder.DropTable(
                name: "Compensations");

            _ = migrationBuilder.DropTable(
                name: "SalesInvoices");

            _ = migrationBuilder.DropTable(
                name: "Items");

            _ = migrationBuilder.DropTable(
                name: "Warehouses");

            _ = migrationBuilder.DropTable(
                name: "Vehicles");

            _ = migrationBuilder.DropTable(
                name: "Objects");

            _ = migrationBuilder.DropTable(
                name: "PriceLists");

            _ = migrationBuilder.DropTable(
                name: "Partners");
        }
    }
}
