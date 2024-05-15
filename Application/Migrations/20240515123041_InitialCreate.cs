using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Application.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    AdminId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.AdminId);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceCenters",
                columns: table => new
                {
                    MaintenanceCenterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaintenanceCenterName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaintenanceCenterDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<float>(type: "real", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceCenters", x => x.MaintenanceCenterId);
                });

            migrationBuilder.CreateTable(
                name: "VehiclesBrand",
                columns: table => new
                {
                    VehiclesBrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VehiclesBrandName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiclesBrand", x => x.VehiclesBrandId);
                });

            migrationBuilder.CreateTable(
                name: "FeedBacks",
                columns: table => new
                {
                    FeedBackId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vote = table.Column<int>(type: "int", nullable: false),
                    MaintenanceCenterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReceiptId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedBacks", x => x.FeedBackId);
                    table.ForeignKey(
                        name: "FK_FeedBacks_MaintenanceCenters_MaintenanceCenterId",
                        column: x => x.MaintenanceCenterId,
                        principalTable: "MaintenanceCenters",
                        principalColumn: "MaintenanceCenterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServiceCaresCost",
                columns: table => new
                {
                    ServiceCareCostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActuralCost = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ServiceCareId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaintenanceCenterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceCaresCost", x => x.ServiceCareCostId);
                    table.ForeignKey(
                        name: "FK_ServiceCaresCost_MaintenanceCenters_MaintenanceCenterId",
                        column: x => x.MaintenanceCenterId,
                        principalTable: "MaintenanceCenters",
                        principalColumn: "MaintenanceCenterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SparePartsCost",
                columns: table => new
                {
                    SparePartsCostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActuralCost = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    SparePartsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaintenanceCenterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SparePartsCost", x => x.SparePartsCostId);
                    table.ForeignKey(
                        name: "FK_SparePartsCost_MaintenanceCenters_MaintenanceCenterId",
                        column: x => x.MaintenanceCenterId,
                        principalTable: "MaintenanceCenters",
                        principalColumn: "MaintenanceCenterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StaffCare",
                columns: table => new
                {
                    StaffCareId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime", nullable: false),
                    StaffCareDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CenterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffCare", x => x.StaffCareId);
                    table.ForeignKey(
                        name: "FK_StaffCare_MaintenanceCenters_CenterId",
                        column: x => x.CenterId,
                        principalTable: "MaintenanceCenters",
                        principalColumn: "MaintenanceCenterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VehicleModel",
                columns: table => new
                {
                    VehicleModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VehicleModelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    VehiclesBrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleModel", x => x.VehicleModelId);
                    table.ForeignKey(
                        name: "FK_VehicleModel_VehiclesBrand_VehiclesBrandId",
                        column: x => x.VehiclesBrandId,
                        principalTable: "VehiclesBrand",
                        principalColumn: "VehiclesBrandId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Receipts",
                columns: table => new
                {
                    ReceiptId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReceiptName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubTotal = table.Column<double>(type: "float", nullable: false),
                    VAT = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<double>(type: "float", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InformationMaintenanceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OdoHistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receipts", x => x.ReceiptId);
                    table.ForeignKey(
                        name: "FK_Receipts_FeedBacks_ReceiptId",
                        column: x => x.ReceiptId,
                        principalTable: "FeedBacks",
                        principalColumn: "FeedBackId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountID);
                    table.ForeignKey(
                        name: "FK_Accounts_Admins_AccountID",
                        column: x => x.AccountID,
                        principalTable: "Admins",
                        principalColumn: "AdminId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Accounts_Clients_AccountID",
                        column: x => x.AccountID,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Accounts_MaintenanceCenters_AccountID",
                        column: x => x.AccountID,
                        principalTable: "MaintenanceCenters",
                        principalColumn: "MaintenanceCenterId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Accounts_StaffCare_AccountID",
                        column: x => x.AccountID,
                        principalTable: "StaffCare",
                        principalColumn: "StaffCareId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MaintananceSchedules",
                columns: table => new
                {
                    MaintananceScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Odo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    VehicleModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintananceSchedules", x => x.MaintananceScheduleId);
                    table.ForeignKey(
                        name: "FK_MaintananceSchedules_VehicleModel_VehicleModelId",
                        column: x => x.VehicleModelId,
                        principalTable: "VehicleModel",
                        principalColumn: "VehicleModelId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    VehiclesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LicensePlate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Odo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.VehiclesId);
                    table.ForeignKey(
                        name: "FK_Vehicles_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleModel_VehicleModelId",
                        column: x => x.VehicleModelId,
                        principalTable: "VehicleModel",
                        principalColumn: "VehicleModelId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InformationMaintenances",
                columns: table => new
                {
                    InformationMaintenanceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InformationMaintenanceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    FinishedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StaffCareId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InformationMaintenances", x => x.InformationMaintenanceId);
                    table.ForeignKey(
                        name: "FK_InformationMaintenances_Receipts_InformationMaintenanceId",
                        column: x => x.InformationMaintenanceId,
                        principalTable: "Receipts",
                        principalColumn: "ReceiptId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InformationMaintenances_StaffCare_StaffCareId",
                        column: x => x.StaffCareId,
                        principalTable: "StaffCare",
                        principalColumn: "StaffCareId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MaintenancePlans",
                columns: table => new
                {
                    MaintenancePlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaintenancePlanName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaintenancePlanDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaintananceScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenancePlans", x => x.MaintenancePlanId);
                    table.ForeignKey(
                        name: "FK_MaintenancePlans_MaintananceSchedules_MaintananceScheduleId",
                        column: x => x.MaintananceScheduleId,
                        principalTable: "MaintananceSchedules",
                        principalColumn: "MaintananceScheduleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    BookingDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaintenanceCenterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_Bookings_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bookings_MaintenanceCenters_MaintenanceCenterId",
                        column: x => x.MaintenanceCenterId,
                        principalTable: "MaintenanceCenters",
                        principalColumn: "MaintenanceCenterId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bookings_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "VehiclesId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OdoHistories",
                columns: table => new
                {
                    OdoHistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OdoHistoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Odo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehiclesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OdoHistories", x => x.OdoHistoryId);
                    table.ForeignKey(
                        name: "FK_OdoHistories_Receipts_OdoHistoryId",
                        column: x => x.OdoHistoryId,
                        principalTable: "Receipts",
                        principalColumn: "ReceiptId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OdoHistories_Vehicles_VehiclesId",
                        column: x => x.VehiclesId,
                        principalTable: "Vehicles",
                        principalColumn: "VehiclesId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceItems",
                columns: table => new
                {
                    MaintenanceItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaintenanceItemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false),
                    ActualCost = table.Column<double>(type: "float", nullable: false),
                    TotalCost = table.Column<double>(type: "float", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SparePartsCostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceCareCostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InformationMaintenanceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceItems", x => x.MaintenanceItemId);
                    table.ForeignKey(
                        name: "FK_MaintenanceItems_InformationMaintenances_InformationMaintenanceId",
                        column: x => x.InformationMaintenanceId,
                        principalTable: "InformationMaintenances",
                        principalColumn: "InformationMaintenanceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaintenanceItems_ServiceCaresCost_ServiceCareCostId",
                        column: x => x.ServiceCareCostId,
                        principalTable: "ServiceCaresCost",
                        principalColumn: "ServiceCareCostId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaintenanceItems_SparePartsCost_SparePartsCostId",
                        column: x => x.SparePartsCostId,
                        principalTable: "SparePartsCost",
                        principalColumn: "SparePartsCostId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServiceItem",
                columns: table => new
                {
                    ServiceItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Measurement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitCost = table.Column<double>(type: "float", nullable: false),
                    TotalCost = table.Column<double>(type: "float", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InformationMaintenanceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceItem", x => x.ServiceItemId);
                    table.ForeignKey(
                        name: "FK_ServiceItem_InformationMaintenances_InformationMaintenanceId",
                        column: x => x.InformationMaintenanceId,
                        principalTable: "InformationMaintenances",
                        principalColumn: "InformationMaintenanceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TechnicianCost",
                columns: table => new
                {
                    TechnicialCostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TechnicialCostName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Measurement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitCost = table.Column<double>(type: "float", nullable: false),
                    TotalCost = table.Column<double>(type: "float", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InformationMaintenanceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnicianCost", x => x.TechnicialCostId);
                    table.ForeignKey(
                        name: "FK_TechnicianCost_InformationMaintenances_InformationMaintenanceId",
                        column: x => x.InformationMaintenanceId,
                        principalTable: "InformationMaintenances",
                        principalColumn: "InformationMaintenanceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServiceCares",
                columns: table => new
                {
                    ServiceCareId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceCareName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceCareDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceCareType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    OriginalPrice = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaintenancePlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceCares", x => x.ServiceCareId);
                    table.ForeignKey(
                        name: "FK_ServiceCares_MaintenancePlans_MaintenancePlanId",
                        column: x => x.MaintenancePlanId,
                        principalTable: "MaintenancePlans",
                        principalColumn: "MaintenancePlanId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceCares_ServiceCaresCost_ServiceCareId",
                        column: x => x.ServiceCareId,
                        principalTable: "ServiceCaresCost",
                        principalColumn: "ServiceCareCostId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SpareParts",
                columns: table => new
                {
                    SparePartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SparePartName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SparePartDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SparePartType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    OriginalPrice = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaintenancePlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpareParts", x => x.SparePartId);
                    table.ForeignKey(
                        name: "FK_SpareParts_MaintenancePlans_MaintenancePlanId",
                        column: x => x.MaintenancePlanId,
                        principalTable: "MaintenancePlans",
                        principalColumn: "MaintenancePlanId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpareParts_SparePartsCost_SparePartId",
                        column: x => x.SparePartId,
                        principalTable: "SparePartsCost",
                        principalColumn: "SparePartsCostId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Email",
                table: "Accounts",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ClientId",
                table: "Bookings",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_MaintenanceCenterId",
                table: "Bookings",
                column: "MaintenanceCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_VehicleId",
                table: "Bookings",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_FeedBacks_MaintenanceCenterId",
                table: "FeedBacks",
                column: "MaintenanceCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_InformationMaintenances_StaffCareId",
                table: "InformationMaintenances",
                column: "StaffCareId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintananceSchedules_VehicleModelId",
                table: "MaintananceSchedules",
                column: "VehicleModelId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceItems_InformationMaintenanceId",
                table: "MaintenanceItems",
                column: "InformationMaintenanceId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceItems_ServiceCareCostId",
                table: "MaintenanceItems",
                column: "ServiceCareCostId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceItems_SparePartsCostId",
                table: "MaintenanceItems",
                column: "SparePartsCostId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenancePlans_MaintananceScheduleId",
                table: "MaintenancePlans",
                column: "MaintananceScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_OdoHistories_VehiclesId",
                table: "OdoHistories",
                column: "VehiclesId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceCares_MaintenancePlanId",
                table: "ServiceCares",
                column: "MaintenancePlanId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceCaresCost_MaintenanceCenterId",
                table: "ServiceCaresCost",
                column: "MaintenanceCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceItem_InformationMaintenanceId",
                table: "ServiceItem",
                column: "InformationMaintenanceId");

            migrationBuilder.CreateIndex(
                name: "IX_SpareParts_MaintenancePlanId",
                table: "SpareParts",
                column: "MaintenancePlanId");

            migrationBuilder.CreateIndex(
                name: "IX_SparePartsCost_MaintenanceCenterId",
                table: "SparePartsCost",
                column: "MaintenanceCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffCare_CenterId",
                table: "StaffCare",
                column: "CenterId");

            migrationBuilder.CreateIndex(
                name: "IX_TechnicianCost_InformationMaintenanceId",
                table: "TechnicianCost",
                column: "InformationMaintenanceId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleModel_VehiclesBrandId",
                table: "VehicleModel",
                column: "VehiclesBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ClientId",
                table: "Vehicles",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehicleModelId",
                table: "Vehicles",
                column: "VehicleModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "MaintenanceItems");

            migrationBuilder.DropTable(
                name: "OdoHistories");

            migrationBuilder.DropTable(
                name: "ServiceCares");

            migrationBuilder.DropTable(
                name: "ServiceItem");

            migrationBuilder.DropTable(
                name: "SpareParts");

            migrationBuilder.DropTable(
                name: "TechnicianCost");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "ServiceCaresCost");

            migrationBuilder.DropTable(
                name: "MaintenancePlans");

            migrationBuilder.DropTable(
                name: "SparePartsCost");

            migrationBuilder.DropTable(
                name: "InformationMaintenances");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "MaintananceSchedules");

            migrationBuilder.DropTable(
                name: "Receipts");

            migrationBuilder.DropTable(
                name: "StaffCare");

            migrationBuilder.DropTable(
                name: "VehicleModel");

            migrationBuilder.DropTable(
                name: "FeedBacks");

            migrationBuilder.DropTable(
                name: "VehiclesBrand");

            migrationBuilder.DropTable(
                name: "MaintenanceCenters");
        }
    }
}
