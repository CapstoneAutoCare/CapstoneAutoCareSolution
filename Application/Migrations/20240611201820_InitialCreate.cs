using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Application.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Admins",
                columns: table => new
                {
                    AdminId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.AdminId);
                    table.ForeignKey(
                        name: "FK_Admins_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountID",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_Clients_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceCenters",
                columns: table => new
                {
                    MaintenanceCenterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaintenanceCenterName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaintenanceCenterDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<float>(type: "real", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceCenters", x => x.MaintenanceCenterId);
                    table.ForeignKey(
                        name: "FK_MaintenanceCenters_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    NotificationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.NotificationId);
                    table.ForeignKey(
                        name: "FK_Notification_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountID",
                        onDelete: ReferentialAction.Cascade);
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
                name: "CustomerCares",
                columns: table => new
                {
                    CustomerCareId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime", nullable: false),
                    CustomerCareDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CenterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerCares", x => x.CustomerCareId);
                    table.ForeignKey(
                        name: "FK_CustomerCares_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerCares_MaintenanceCenters_CenterId",
                        column: x => x.CenterId,
                        principalTable: "MaintenanceCenters",
                        principalColumn: "MaintenanceCenterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StaffCares",
                columns: table => new
                {
                    StaffCareId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_StaffCares", x => x.StaffCareId);
                    table.ForeignKey(
                        name: "FK_StaffCares_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaffCares_MaintenanceCenters_CenterId",
                        column: x => x.CenterId,
                        principalTable: "MaintenanceCenters",
                        principalColumn: "MaintenanceCenterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VehiclesMaintenances",
                columns: table => new
                {
                    MaintenanceCenterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VehiclesBrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiclesMaintenances", x => new { x.MaintenanceCenterId, x.VehiclesBrandId });
                    table.ForeignKey(
                        name: "FK_VehiclesMaintenances_MaintenanceCenters_MaintenanceCenterId",
                        column: x => x.MaintenanceCenterId,
                        principalTable: "MaintenanceCenters",
                        principalColumn: "MaintenanceCenterId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VehiclesMaintenances_VehiclesBrand_VehiclesBrandId",
                        column: x => x.VehiclesBrandId,
                        principalTable: "VehiclesBrand",
                        principalColumn: "VehiclesBrandId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MaintananceSchedules",
                columns: table => new
                {
                    MaintananceScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaintananceScheduleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    Odo = table.Column<int>(type: "int", nullable: false),
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
                    MaintananceScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceCares", x => x.ServiceCareId);
                    table.ForeignKey(
                        name: "FK_ServiceCares_MaintananceSchedules_MaintananceScheduleId",
                        column: x => x.MaintananceScheduleId,
                        principalTable: "MaintananceSchedules",
                        principalColumn: "MaintananceScheduleId",
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
                    MaintananceScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpareParts", x => x.SparePartId);
                    table.ForeignKey(
                        name: "FK_SpareParts_MaintananceSchedules_MaintananceScheduleId",
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
                    MaintenanceCenterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaintananceScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                        name: "FK_Bookings_MaintananceSchedules_MaintananceScheduleId",
                        column: x => x.MaintananceScheduleId,
                        principalTable: "MaintananceSchedules",
                        principalColumn: "MaintananceScheduleId");
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
                name: "ImageRepairReceipts",
                columns: table => new
                {
                    ImageRepairReceiptId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaintenanceCenterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageRepairReceipts", x => x.ImageRepairReceiptId);
                    table.ForeignKey(
                        name: "FK_ImageRepairReceipts_MaintenanceCenters_MaintenanceCenterId",
                        column: x => x.MaintenanceCenterId,
                        principalTable: "MaintenanceCenters",
                        principalColumn: "MaintenanceCenterId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ImageRepairReceipts_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "VehiclesId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceServices",
                columns: table => new
                {
                    MaintenanceServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ServiceCareId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MaintenanceCenterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceServices", x => x.MaintenanceServiceId);
                    table.ForeignKey(
                        name: "FK_MaintenanceServices_MaintenanceCenters_MaintenanceCenterId",
                        column: x => x.MaintenanceCenterId,
                        principalTable: "MaintenanceCenters",
                        principalColumn: "MaintenanceCenterId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaintenanceServices_ServiceCares_ServiceCareId",
                        column: x => x.ServiceCareId,
                        principalTable: "ServiceCares",
                        principalColumn: "ServiceCareId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SparePartsItem",
                columns: table => new
                {
                    SparePartsItemtId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    SparePartsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MaintenanceCenterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SparePartsItem", x => x.SparePartsItemtId);
                    table.ForeignKey(
                        name: "FK_SparePartsItem_MaintenanceCenters_MaintenanceCenterId",
                        column: x => x.MaintenanceCenterId,
                        principalTable: "MaintenanceCenters",
                        principalColumn: "MaintenanceCenterId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SparePartsItem_SpareParts_SparePartsId",
                        column: x => x.SparePartsId,
                        principalTable: "SpareParts",
                        principalColumn: "SparePartId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceInformations",
                columns: table => new
                {
                    InformationMaintenanceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InformationMaintenanceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    FinishedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookingId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CustomerCareId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceInformations", x => x.InformationMaintenanceId);
                    table.ForeignKey(
                        name: "FK_MaintenanceInformations_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "BookingId");
                    table.ForeignKey(
                        name: "FK_MaintenanceInformations_CustomerCares_CustomerCareId",
                        column: x => x.CustomerCareId,
                        principalTable: "CustomerCares",
                        principalColumn: "CustomerCareId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceServiceCosts",
                columns: table => new
                {
                    MaintenanceServiceCostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActuralCost = table.Column<double>(type: "float", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaintenanceServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceServiceCosts", x => x.MaintenanceServiceCostId);
                    table.ForeignKey(
                        name: "FK_MaintenanceServiceCosts_MaintenanceServices_MaintenanceServiceId",
                        column: x => x.MaintenanceServiceId,
                        principalTable: "MaintenanceServices",
                        principalColumn: "MaintenanceServiceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SparePartsItemCosts",
                columns: table => new
                {
                    SparePartsItemCostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActuralCost = table.Column<double>(type: "float", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SparePartsItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SparePartsItemCosts", x => x.SparePartsItemCostId);
                    table.ForeignKey(
                        name: "FK_SparePartsItemCosts_SparePartsItem_SparePartsItemId",
                        column: x => x.SparePartsItemId,
                        principalTable: "SparePartsItem",
                        principalColumn: "SparePartsItemtId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceHistoryStatuses",
                columns: table => new
                {
                    MaintenanceHistoryStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaintenanceInformationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceHistoryStatuses", x => x.MaintenanceHistoryStatusId);
                    table.ForeignKey(
                        name: "FK_MaintenanceHistoryStatuses_MaintenanceInformations_MaintenanceInformationId",
                        column: x => x.MaintenanceInformationId,
                        principalTable: "MaintenanceInformations",
                        principalColumn: "InformationMaintenanceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceServiceInfos",
                columns: table => new
                {
                    MaintenanceServiceInfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaintenanceServiceInfoName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false),
                    ActualCost = table.Column<double>(type: "float", nullable: false),
                    TotalCost = table.Column<double>(type: "float", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaintenanceServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InformationMaintenanceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceServiceInfos", x => x.MaintenanceServiceInfoId);
                    table.ForeignKey(
                        name: "FK_MaintenanceServiceInfos_MaintenanceInformations_InformationMaintenanceId",
                        column: x => x.InformationMaintenanceId,
                        principalTable: "MaintenanceInformations",
                        principalColumn: "InformationMaintenanceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaintenanceServiceInfos_MaintenanceServices_MaintenanceServiceId",
                        column: x => x.MaintenanceServiceId,
                        principalTable: "MaintenanceServices",
                        principalColumn: "MaintenanceServiceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceSparePartInfos",
                columns: table => new
                {
                    MaintenanceSparePartInfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaintenanceSparePartInfoName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false),
                    ActualCost = table.Column<double>(type: "float", nullable: false),
                    TotalCost = table.Column<double>(type: "float", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SparePartsItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InformationMaintenanceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceSparePartInfos", x => x.MaintenanceSparePartInfoId);
                    table.ForeignKey(
                        name: "FK_MaintenanceSparePartInfos_MaintenanceInformations_InformationMaintenanceId",
                        column: x => x.InformationMaintenanceId,
                        principalTable: "MaintenanceInformations",
                        principalColumn: "InformationMaintenanceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaintenanceSparePartInfos_SparePartsItem_SparePartsItemId",
                        column: x => x.SparePartsItemId,
                        principalTable: "SparePartsItem",
                        principalColumn: "SparePartsItemtId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OdoHistories",
                columns: table => new
                {
                    OdoHistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OdoHistoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Odo = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehiclesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaintenanceInformationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OdoHistories", x => x.OdoHistoryId);
                    table.ForeignKey(
                        name: "FK_OdoHistories_MaintenanceInformations_MaintenanceInformationId",
                        column: x => x.MaintenanceInformationId,
                        principalTable: "MaintenanceInformations",
                        principalColumn: "InformationMaintenanceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OdoHistories_Vehicles_VehiclesId",
                        column: x => x.VehiclesId,
                        principalTable: "Vehicles",
                        principalColumn: "VehiclesId",
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
                    InformationMaintenanceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receipts", x => x.ReceiptId);
                    table.ForeignKey(
                        name: "FK_Receipts_MaintenanceInformations_InformationMaintenanceId",
                        column: x => x.InformationMaintenanceId,
                        principalTable: "MaintenanceInformations",
                        principalColumn: "InformationMaintenanceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Technician",
                columns: table => new
                {
                    TechnicianId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TechnicialName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitCost = table.Column<double>(type: "float", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InformationMaintenanceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StaffCareId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technician", x => x.TechnicianId);
                    table.ForeignKey(
                        name: "FK_Technician_MaintenanceInformations_InformationMaintenanceId",
                        column: x => x.InformationMaintenanceId,
                        principalTable: "MaintenanceInformations",
                        principalColumn: "InformationMaintenanceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Technician_StaffCares_StaffCareId",
                        column: x => x.StaffCareId,
                        principalTable: "StaffCares",
                        principalColumn: "StaffCareId",
                        onDelete: ReferentialAction.Restrict);
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
                    table.ForeignKey(
                        name: "FK_FeedBacks_Receipts_ReceiptId",
                        column: x => x.ReceiptId,
                        principalTable: "Receipts",
                        principalColumn: "ReceiptId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountID", "CreatedDate", "Email", "Gender", "Logo", "Password", "Phone", "Role", "Status" },
                values: new object[,]
                {
                    { new Guid("1bb62188-ae64-45d5-a87f-c9e219da77ff"), new DateTime(2024, 6, 12, 3, 18, 19, 837, DateTimeKind.Local).AddTicks(7164), "c2", "1", "1", "1", "1", "CLIENT", "ACTIVE" },
                    { new Guid("66140116-49c5-4ca5-988e-a9735bf9527f"), new DateTime(2024, 6, 12, 3, 18, 19, 837, DateTimeKind.Local).AddTicks(7019), "center2", "1", "1", "1", "1", "CENTER", "ACTIVE" },
                    { new Guid("76aed2bd-0f45-4825-abdd-beb4b1159490"), new DateTime(2024, 6, 12, 3, 18, 19, 837, DateTimeKind.Local).AddTicks(7156), "c1", "1", "1", "1", "1", "CLIENT", "ACTIVE" },
                    { new Guid("c2290782-da92-4eb2-9dac-f58af6ffb3b4"), new DateTime(2024, 6, 12, 3, 18, 19, 837, DateTimeKind.Local).AddTicks(7006), "center1", "1", "1", "1", "1", "CENTER", "ACTIVE" }
                });

            migrationBuilder.InsertData(
                table: "VehiclesBrand",
                columns: new[] { "VehiclesBrandId", "CreatedDate", "Status", "VehiclesBrandName" },
                values: new object[,]
                {
                    { new Guid("0e7251f1-315f-4e5b-aaff-5362d4f89abe"), new DateTime(2024, 6, 12, 3, 18, 19, 837, DateTimeKind.Local).AddTicks(6846), "ACTIVE", "MEC" },
                    { new Guid("273fb064-92ae-4987-8714-769a3577f0b6"), new DateTime(2024, 6, 12, 3, 18, 19, 837, DateTimeKind.Local).AddTicks(6859), "ACTIVE", "TOYOTA" },
                    { new Guid("550b8d4f-ce2b-4c11-8c34-9847ad34bb3e"), new DateTime(2024, 6, 12, 3, 18, 19, 837, DateTimeKind.Local).AddTicks(6855), "ACTIVE", "AUDI" },
                    { new Guid("6858fac1-cc7a-48ad-b932-c87ce8007e41"), new DateTime(2024, 6, 12, 3, 18, 19, 837, DateTimeKind.Local).AddTicks(6537), "ACTIVE", "BMW" },
                    { new Guid("68928060-a94e-4ca5-b8d3-a1a51f7c0209"), new DateTime(2024, 6, 12, 3, 18, 19, 837, DateTimeKind.Local).AddTicks(6863), "ACTIVE", "HONDA" }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ClientId", "AccountId", "Address", "Birthday", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("e856c18d-a787-4931-b359-25fc22d007f6"), new Guid("1bb62188-ae64-45d5-a87f-c9e219da77ff"), "98C Đ. Hồ Bá Phấn, Phước Long A, Thủ Đức, Thành phố Hồ Chí Minh", new DateTime(2024, 6, 12, 3, 18, 19, 837, DateTimeKind.Local).AddTicks(7161), "F", "L" },
                    { new Guid("ea669325-74a5-435a-bebb-846c134ac6e7"), new Guid("76aed2bd-0f45-4825-abdd-beb4b1159490"), "98C Đ. Hồ Bá Phấn, Phước Long A, Thủ Đức, Thành phố Hồ Chí Minh", new DateTime(2024, 6, 12, 3, 18, 19, 837, DateTimeKind.Local).AddTicks(7152), "P", "D" }
                });

            migrationBuilder.InsertData(
                table: "MaintenanceCenters",
                columns: new[] { "MaintenanceCenterId", "AccountId", "Address", "City", "Country", "CreateDate", "District", "MaintenanceCenterDescription", "MaintenanceCenterName", "Rating" },
                values: new object[,]
                {
                    { new Guid("c1d12eaf-1d29-48e9-aa20-5efef61b7154"), new Guid("66140116-49c5-4ca5-988e-a9735bf9527f"), "98C Đ. Hồ Bá Phấn, Phước Long A, Thủ Đức, Thành phố Hồ Chí Minh", "Thành phố Hồ Chí Minh", "VN", new DateTime(2024, 6, 12, 3, 18, 19, 837, DateTimeKind.Local).AddTicks(7012), "Quận 9", "Gara Phi Long Ô Tô BK", "Gara Phi Long Ô Tô BK", 5f },
                    { new Guid("f308446e-c60c-4c29-b911-c3db272a4e83"), new Guid("c2290782-da92-4eb2-9dac-f58af6ffb3b4"), "98C Đ. Hồ Bá Phấn, Phước Long A, Thủ Đức, Thành phố Hồ Chí Minh", "Thành phố Hồ Chí Minh", "VN", new DateTime(2024, 6, 12, 3, 18, 19, 837, DateTimeKind.Local).AddTicks(6995), "Quận 9", "Gara Phi Long Ô Tô BK", "Gara Phi Long Ô Tô BK", 5f }
                });

            migrationBuilder.InsertData(
                table: "VehicleModel",
                columns: new[] { "VehicleModelId", "CreatedDate", "Image", "Status", "VehicleModelName", "VehiclesBrandId" },
                values: new object[,]
                {
                    { new Guid("14a3b3e5-49d3-4c15-8296-df58a1d82d11"), new DateTime(2024, 6, 12, 3, 18, 19, 837, DateTimeKind.Local).AddTicks(7288), "i7", "ACTIVE", "i7", new Guid("6858fac1-cc7a-48ad-b932-c87ce8007e41") },
                    { new Guid("191a8325-014f-49c5-a15f-ef8d222c53e8"), new DateTime(2024, 6, 12, 3, 18, 19, 837, DateTimeKind.Local).AddTicks(7292), "740Li", "ACTIVE", "740Li", new Guid("6858fac1-cc7a-48ad-b932-c87ce8007e41") },
                    { new Guid("1d84739a-2708-4b78-aa99-f9b032cc3ccd"), new DateTime(2024, 6, 12, 3, 18, 19, 837, DateTimeKind.Local).AddTicks(7279), "328i", "ACTIVE", "328i", new Guid("6858fac1-cc7a-48ad-b932-c87ce8007e41") },
                    { new Guid("25581285-c34f-4068-85ad-b7718b6dc17e"), new DateTime(2024, 6, 12, 3, 18, 19, 837, DateTimeKind.Local).AddTicks(7454), "Fortuner", "ACTIVE", "Fortuner", new Guid("273fb064-92ae-4987-8714-769a3577f0b6") },
                    { new Guid("2776370a-a95c-4c34-8213-3d2f9c3fe5bf"), new DateTime(2024, 6, 12, 3, 18, 19, 837, DateTimeKind.Local).AddTicks(7389), "A1", "ACTIVE", "A1", new Guid("550b8d4f-ce2b-4c11-8c34-9847ad34bb3e") },
                    { new Guid("28b5d468-3d1d-4e4b-87e8-20e558df3866"), new DateTime(2024, 6, 12, 3, 18, 19, 837, DateTimeKind.Local).AddTicks(7502), "Jazz", "ACTIVE", "Jazz", new Guid("68928060-a94e-4ca5-b8d3-a1a51f7c0209") },
                    { new Guid("2f1c6283-a81f-4b45-9fc4-9c52c825ef53"), new DateTime(2024, 6, 12, 3, 18, 19, 837, DateTimeKind.Local).AddTicks(7462), "Harrier", "ACTIVE", "Harrier", new Guid("273fb064-92ae-4987-8714-769a3577f0b6") },
                    { new Guid("331130ee-2a50-432b-ad72-d2504226b6bb"), new DateTime(2024, 6, 12, 3, 18, 19, 837, DateTimeKind.Local).AddTicks(7488), "Civic", "ACTIVE", "Civic", new Guid("68928060-a94e-4ca5-b8d3-a1a51f7c0209") },
                    { new Guid("4659bbc7-ef66-44e9-bd15-12c643dae850"), new DateTime(2024, 6, 12, 3, 18, 19, 837, DateTimeKind.Local).AddTicks(7346), "C300", "ACTIVE", "C300", new Guid("0e7251f1-315f-4e5b-aaff-5362d4f89abe") },
                    { new Guid("479ed113-6b70-48b3-b836-e956c98ef00d"), new DateTime(2024, 6, 12, 3, 18, 19, 837, DateTimeKind.Local).AddTicks(7509), "Ridgeline", "ACTIVE", "Ridgeline", new Guid("68928060-a94e-4ca5-b8d3-a1a51f7c0209") },
                    { new Guid("4db9a332-b2db-4ec2-bacc-f4e0a94ad4cf"), new DateTime(2024, 6, 12, 3, 18, 19, 837, DateTimeKind.Local).AddTicks(7407), "A4", "ACTIVE", "A4", new Guid("550b8d4f-ce2b-4c11-8c34-9847ad34bb3e") },
                    { new Guid("64c918c6-3df2-4a60-bc44-62ee983de65b"), new DateTime(2024, 6, 12, 3, 18, 19, 837, DateTimeKind.Local).AddTicks(7352), "C200", "ACTIVE", "C200", new Guid("0e7251f1-315f-4e5b-aaff-5362d4f89abe") },
                    { new Guid("7a2c7ab4-63a7-4dda-bb6d-c6f6d788774b"), new DateTime(2024, 6, 12, 3, 18, 19, 837, DateTimeKind.Local).AddTicks(7457), "Alphard", "ACTIVE", "Alphard", new Guid("273fb064-92ae-4987-8714-769a3577f0b6") },
                    { new Guid("80964d7e-3e9f-4f00-af93-94854933520d"), new DateTime(2024, 6, 12, 3, 18, 19, 837, DateTimeKind.Local).AddTicks(7359), "GLC 300", "ACTIVE", "GLC 300", new Guid("0e7251f1-315f-4e5b-aaff-5362d4f89abe") },
                    { new Guid("9f394d47-1b85-48c1-9ac9-c2cd55ca067a"), new DateTime(2024, 6, 12, 3, 18, 19, 837, DateTimeKind.Local).AddTicks(7273), "320i", "ACTIVE", "320i", new Guid("6858fac1-cc7a-48ad-b932-c87ce8007e41") },
                    { new Guid("a2f265e0-dfd4-4a09-b814-57cbab5c76af"), new DateTime(2024, 6, 12, 3, 18, 19, 837, DateTimeKind.Local).AddTicks(7400), "A5", "ACTIVE", "A5", new Guid("550b8d4f-ce2b-4c11-8c34-9847ad34bb3e") },
                    { new Guid("acf67e48-869a-4f7f-a40f-798dc8904f79"), new DateTime(2024, 6, 12, 3, 18, 19, 837, DateTimeKind.Local).AddTicks(7339), "E180", "ACTIVE", "E180", new Guid("0e7251f1-315f-4e5b-aaff-5362d4f89abe") },
                    { new Guid("aeb6ec81-d254-44f9-b3e8-d2cfdc7a02ba"), new DateTime(2024, 6, 12, 3, 18, 19, 837, DateTimeKind.Local).AddTicks(7493), "City", "ACTIVE", "City", new Guid("68928060-a94e-4ca5-b8d3-a1a51f7c0209") },
                    { new Guid("ba740480-3786-4231-bbf5-75cce3be44eb"), new DateTime(2024, 6, 12, 3, 18, 19, 837, DateTimeKind.Local).AddTicks(7343), "S450", "ACTIVE", "S450", new Guid("0e7251f1-315f-4e5b-aaff-5362d4f89abe") },
                    { new Guid("ba7caa05-ec8d-4b09-a379-f1298bd22afd"), new DateTime(2024, 6, 12, 3, 18, 19, 837, DateTimeKind.Local).AddTicks(7445), "Camry", "ACTIVE", "Camry", new Guid("273fb064-92ae-4987-8714-769a3577f0b6") },
                    { new Guid("c1962bf0-f2af-4aa3-a65a-2435e1533827"), new DateTime(2024, 6, 12, 3, 18, 19, 837, DateTimeKind.Local).AddTicks(7282), "330i", "ACTIVE", "330i", new Guid("6858fac1-cc7a-48ad-b932-c87ce8007e41") },
                    { new Guid("c9cfaf8f-1170-40ac-899f-38b160bb8a2c"), new DateTime(2024, 6, 12, 3, 18, 19, 837, DateTimeKind.Local).AddTicks(7349), "C250", "ACTIVE", "C250", new Guid("0e7251f1-315f-4e5b-aaff-5362d4f89abe") },
                    { new Guid("cbb0713f-edf0-4ceb-b1bd-d74f60dd2929"), new DateTime(2024, 6, 12, 3, 18, 19, 837, DateTimeKind.Local).AddTicks(7403), "A6", "ACTIVE", "A6", new Guid("550b8d4f-ce2b-4c11-8c34-9847ad34bb3e") },
                    { new Guid("d2b94e36-0de2-4ba7-9326-6f8a9a9b11c2"), new DateTime(2024, 6, 12, 3, 18, 19, 837, DateTimeKind.Local).AddTicks(7297), "M6", "ACTIVE", "M6", new Guid("6858fac1-cc7a-48ad-b932-c87ce8007e41") },
                    { new Guid("d49b07fa-425f-4bca-8e41-1af469cf972c"), new DateTime(2024, 6, 12, 3, 18, 19, 837, DateTimeKind.Local).AddTicks(7397), "Q7", "ACTIVE", "Q7", new Guid("550b8d4f-ce2b-4c11-8c34-9847ad34bb3e") },
                    { new Guid("d6b25e0c-22ee-4a5a-9e92-efe8fc24c8cc"), new DateTime(2024, 6, 12, 3, 18, 19, 837, DateTimeKind.Local).AddTicks(7435), "Vios", "ACTIVE", "Vios", new Guid("273fb064-92ae-4987-8714-769a3577f0b6") },
                    { new Guid("e13550a1-802c-4171-ad48-01fb7199c88d"), new DateTime(2024, 6, 12, 3, 18, 19, 837, DateTimeKind.Local).AddTicks(7496), "Brio", "ACTIVE", "Brio", new Guid("68928060-a94e-4ca5-b8d3-a1a51f7c0209") },
                    { new Guid("e6cc0e27-172f-4412-b206-e4b1bc7e1e38"), new DateTime(2024, 6, 12, 3, 18, 19, 837, DateTimeKind.Local).AddTicks(7393), "A3", "ACTIVE", "A3", new Guid("550b8d4f-ce2b-4c11-8c34-9847ad34bb3e") },
                    { new Guid("ec49bb97-5e3c-4cff-93cb-47160cef17dc"), new DateTime(2024, 6, 12, 3, 18, 19, 837, DateTimeKind.Local).AddTicks(7442), "Yaris", "ACTIVE", "Yaris", new Guid("273fb064-92ae-4987-8714-769a3577f0b6") },
                    { new Guid("ffd61408-5d75-496c-a766-165b5192086f"), new DateTime(2024, 6, 12, 3, 18, 19, 837, DateTimeKind.Local).AddTicks(7505), "BR-V", "ACTIVE", "BR-V", new Guid("68928060-a94e-4ca5-b8d3-a1a51f7c0209") }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "VehiclesId", "ClientId", "Color", "CreatedDate", "Description", "LicensePlate", "Odo", "Status", "VehicleModelId" },
                values: new object[,]
                {
                    { new Guid("03e482cc-7014-4391-903d-387639d52c35"), new Guid("e856c18d-a787-4931-b359-25fc22d007f6"), "RED", new DateTime(2024, 6, 12, 3, 18, 19, 837, DateTimeKind.Local).AddTicks(7860), "Vehicle", "1111", 1000, "ACTIVE", new Guid("479ed113-6b70-48b3-b836-e956c98ef00d") },
                    { new Guid("091ac76b-6665-4ef4-b140-a5f56e7fba1d"), new Guid("ea669325-74a5-435a-bebb-846c134ac6e7"), "BLUE", new DateTime(2024, 6, 12, 3, 18, 19, 837, DateTimeKind.Local).AddTicks(7722), "Vehicle", "1112", 10000, "ACTIVE", new Guid("479ed113-6b70-48b3-b836-e956c98ef00d") },
                    { new Guid("0ff1995e-324c-4ba5-aa10-2b8d2ab6c185"), new Guid("e856c18d-a787-4931-b359-25fc22d007f6"), "BLUE", new DateTime(2024, 6, 12, 3, 18, 19, 837, DateTimeKind.Local).AddTicks(7817), "Vehicle", "1112", 10000, "ACTIVE", new Guid("28b5d468-3d1d-4e4b-87e8-20e558df3866") },
                    { new Guid("1f9f7199-365c-472f-8a43-338b5a9ee3c8"), new Guid("e856c18d-a787-4931-b359-25fc22d007f6"), "RED", new DateTime(2024, 6, 12, 3, 18, 19, 837, DateTimeKind.Local).AddTicks(7836), "Vehicle", "1111", 1000, "ACTIVE", new Guid("ffd61408-5d75-496c-a766-165b5192086f") },
                    { new Guid("40aea3e7-867b-4d49-877e-52a1566efaf3"), new Guid("ea669325-74a5-435a-bebb-846c134ac6e7"), "BLUE", new DateTime(2024, 6, 12, 3, 18, 19, 837, DateTimeKind.Local).AddTicks(7550), "Vehicle", "1112", 10000, "ACTIVE", new Guid("331130ee-2a50-432b-ad72-d2504226b6bb") },
                    { new Guid("46d11c73-7db1-44ea-9449-82f7251e12d4"), new Guid("ea669325-74a5-435a-bebb-846c134ac6e7"), "BLUE", new DateTime(2024, 6, 12, 3, 18, 19, 837, DateTimeKind.Local).AddTicks(7616), "Vehicle", "1112", 10000, "ACTIVE", new Guid("aeb6ec81-d254-44f9-b3e8-d2cfdc7a02ba") },
                    { new Guid("58eea64a-72d5-46b4-b611-ca39eef441b0"), new Guid("e856c18d-a787-4931-b359-25fc22d007f6"), "BLUE", new DateTime(2024, 6, 12, 3, 18, 19, 837, DateTimeKind.Local).AddTicks(7842), "Vehicle", "1112", 10000, "ACTIVE", new Guid("ffd61408-5d75-496c-a766-165b5192086f") },
                    { new Guid("59a4c87a-38ee-4f99-bfba-d4084bc1506e"), new Guid("ea669325-74a5-435a-bebb-846c134ac6e7"), "RED", new DateTime(2024, 6, 12, 3, 18, 19, 837, DateTimeKind.Local).AddTicks(7613), "Vehicle", "1111", 1000, "ACTIVE", new Guid("aeb6ec81-d254-44f9-b3e8-d2cfdc7a02ba") },
                    { new Guid("613895a8-befd-4d3d-a820-b62d8b331d63"), new Guid("e856c18d-a787-4931-b359-25fc22d007f6"), "BLUE", new DateTime(2024, 6, 12, 3, 18, 19, 837, DateTimeKind.Local).AddTicks(7863), "Vehicle", "1112", 10000, "ACTIVE", new Guid("479ed113-6b70-48b3-b836-e956c98ef00d") },
                    { new Guid("69985689-3c8d-43e4-96d5-86f13cdd6806"), new Guid("e856c18d-a787-4931-b359-25fc22d007f6"), "RED", new DateTime(2024, 6, 12, 3, 18, 19, 837, DateTimeKind.Local).AddTicks(7768), "Vehicle", "1111", 1000, "ACTIVE", new Guid("aeb6ec81-d254-44f9-b3e8-d2cfdc7a02ba") },
                    { new Guid("6b8176b5-5840-4680-824f-6a0d3b3966da"), new Guid("ea669325-74a5-435a-bebb-846c134ac6e7"), "RED", new DateTime(2024, 6, 12, 3, 18, 19, 837, DateTimeKind.Local).AddTicks(7719), "Vehicle", "1111", 1000, "ACTIVE", new Guid("479ed113-6b70-48b3-b836-e956c98ef00d") },
                    { new Guid("80ba7c60-ec95-4589-87e3-76485559edda"), new Guid("ea669325-74a5-435a-bebb-846c134ac6e7"), "BLUE", new DateTime(2024, 6, 12, 3, 18, 19, 837, DateTimeKind.Local).AddTicks(7644), "Vehicle", "1112", 10000, "ACTIVE", new Guid("e13550a1-802c-4171-ad48-01fb7199c88d") },
                    { new Guid("8280fc69-c494-4a7e-964b-3f2ce1e51b96"), new Guid("e856c18d-a787-4931-b359-25fc22d007f6"), "BLUE", new DateTime(2024, 6, 12, 3, 18, 19, 837, DateTimeKind.Local).AddTicks(7771), "Vehicle", "1112", 10000, "ACTIVE", new Guid("aeb6ec81-d254-44f9-b3e8-d2cfdc7a02ba") },
                    { new Guid("8c16cff7-d39c-45f9-b013-e1a74dc2a2b2"), new Guid("ea669325-74a5-435a-bebb-846c134ac6e7"), "BLUE", new DateTime(2024, 6, 12, 3, 18, 19, 837, DateTimeKind.Local).AddTicks(7692), "Vehicle", "1112", 10000, "ACTIVE", new Guid("ffd61408-5d75-496c-a766-165b5192086f") },
                    { new Guid("b2b732fb-6faa-4907-87c7-95bb65a8ad3e"), new Guid("ea669325-74a5-435a-bebb-846c134ac6e7"), "RED", new DateTime(2024, 6, 12, 3, 18, 19, 837, DateTimeKind.Local).AddTicks(7544), "Vehicle", "1111", 1000, "ACTIVE", new Guid("331130ee-2a50-432b-ad72-d2504226b6bb") },
                    { new Guid("b755ff48-1d79-4b0e-8948-1fb07de1d56a"), new Guid("e856c18d-a787-4931-b359-25fc22d007f6"), "RED", new DateTime(2024, 6, 12, 3, 18, 19, 837, DateTimeKind.Local).AddTicks(7814), "Vehicle", "1111", 1000, "ACTIVE", new Guid("28b5d468-3d1d-4e4b-87e8-20e558df3866") },
                    { new Guid("b99ead2b-0296-4e7e-9fa4-07f1308930c7"), new Guid("e856c18d-a787-4931-b359-25fc22d007f6"), "RED", new DateTime(2024, 6, 12, 3, 18, 19, 837, DateTimeKind.Local).AddTicks(7743), "Vehicle", "1111", 1000, "ACTIVE", new Guid("331130ee-2a50-432b-ad72-d2504226b6bb") },
                    { new Guid("d673cec0-62da-4f48-8c3d-e247925c5d91"), new Guid("ea669325-74a5-435a-bebb-846c134ac6e7"), "RED", new DateTime(2024, 6, 12, 3, 18, 19, 837, DateTimeKind.Local).AddTicks(7665), "Vehicle", "1111", 1000, "ACTIVE", new Guid("28b5d468-3d1d-4e4b-87e8-20e558df3866") },
                    { new Guid("db2fa383-9d77-4521-b130-61cbfaef34c2"), new Guid("e856c18d-a787-4931-b359-25fc22d007f6"), "BLUE", new DateTime(2024, 6, 12, 3, 18, 19, 837, DateTimeKind.Local).AddTicks(7794), "Vehicle", "1112", 10000, "ACTIVE", new Guid("e13550a1-802c-4171-ad48-01fb7199c88d") },
                    { new Guid("dc57e7fa-5f32-4c2a-8921-f8067fea3fe8"), new Guid("ea669325-74a5-435a-bebb-846c134ac6e7"), "RED", new DateTime(2024, 6, 12, 3, 18, 19, 837, DateTimeKind.Local).AddTicks(7689), "Vehicle", "1111", 1000, "ACTIVE", new Guid("ffd61408-5d75-496c-a766-165b5192086f") },
                    { new Guid("dd428279-261d-494e-b929-bae9da499911"), new Guid("e856c18d-a787-4931-b359-25fc22d007f6"), "BLUE", new DateTime(2024, 6, 12, 3, 18, 19, 837, DateTimeKind.Local).AddTicks(7749), "Vehicle", "1112", 10000, "ACTIVE", new Guid("331130ee-2a50-432b-ad72-d2504226b6bb") },
                    { new Guid("e0069d95-8c46-41e9-8323-587197adeb17"), new Guid("ea669325-74a5-435a-bebb-846c134ac6e7"), "RED", new DateTime(2024, 6, 12, 3, 18, 19, 837, DateTimeKind.Local).AddTicks(7638), "Vehicle", "1111", 1000, "ACTIVE", new Guid("e13550a1-802c-4171-ad48-01fb7199c88d") },
                    { new Guid("e19c3f95-606e-439c-abeb-a0754b69cdd3"), new Guid("ea669325-74a5-435a-bebb-846c134ac6e7"), "BLUE", new DateTime(2024, 6, 12, 3, 18, 19, 837, DateTimeKind.Local).AddTicks(7669), "Vehicle", "1112", 10000, "ACTIVE", new Guid("28b5d468-3d1d-4e4b-87e8-20e558df3866") },
                    { new Guid("fa0d12a7-f252-40ce-a065-74dfe5ff8f3d"), new Guid("e856c18d-a787-4931-b359-25fc22d007f6"), "RED", new DateTime(2024, 6, 12, 3, 18, 19, 837, DateTimeKind.Local).AddTicks(7790), "Vehicle", "1111", 1000, "ACTIVE", new Guid("e13550a1-802c-4171-ad48-01fb7199c88d") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Email",
                table: "Accounts",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Admins_AccountId",
                table: "Admins",
                column: "AccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ClientId",
                table: "Bookings",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_MaintananceScheduleId",
                table: "Bookings",
                column: "MaintananceScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_MaintenanceCenterId",
                table: "Bookings",
                column: "MaintenanceCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_VehicleId",
                table: "Bookings",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_AccountId",
                table: "Clients",
                column: "AccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerCares_AccountId",
                table: "CustomerCares",
                column: "AccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerCares_CenterId",
                table: "CustomerCares",
                column: "CenterId");

            migrationBuilder.CreateIndex(
                name: "IX_FeedBacks_MaintenanceCenterId",
                table: "FeedBacks",
                column: "MaintenanceCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_FeedBacks_ReceiptId",
                table: "FeedBacks",
                column: "ReceiptId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ImageRepairReceipts_MaintenanceCenterId",
                table: "ImageRepairReceipts",
                column: "MaintenanceCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageRepairReceipts_VehicleId",
                table: "ImageRepairReceipts",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintananceSchedules_VehicleModelId",
                table: "MaintananceSchedules",
                column: "VehicleModelId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceCenters_AccountId",
                table: "MaintenanceCenters",
                column: "AccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceHistoryStatuses_MaintenanceInformationId",
                table: "MaintenanceHistoryStatuses",
                column: "MaintenanceInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceInformations_BookingId",
                table: "MaintenanceInformations",
                column: "BookingId",
                unique: true,
                filter: "[BookingId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceInformations_CustomerCareId",
                table: "MaintenanceInformations",
                column: "CustomerCareId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceServiceCosts_MaintenanceServiceId",
                table: "MaintenanceServiceCosts",
                column: "MaintenanceServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceServiceInfos_InformationMaintenanceId_MaintenanceServiceId",
                table: "MaintenanceServiceInfos",
                columns: new[] { "InformationMaintenanceId", "MaintenanceServiceId" },
                unique: true,
                filter: "[MaintenanceServiceId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceServiceInfos_MaintenanceServiceId",
                table: "MaintenanceServiceInfos",
                column: "MaintenanceServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceServices_MaintenanceCenterId",
                table: "MaintenanceServices",
                column: "MaintenanceCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceServices_ServiceCareId",
                table: "MaintenanceServices",
                column: "ServiceCareId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceSparePartInfos_InformationMaintenanceId_SparePartsItemId",
                table: "MaintenanceSparePartInfos",
                columns: new[] { "InformationMaintenanceId", "SparePartsItemId" },
                unique: true,
                filter: "[SparePartsItemId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceSparePartInfos_SparePartsItemId",
                table: "MaintenanceSparePartInfos",
                column: "SparePartsItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_AccountId",
                table: "Notification",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_OdoHistories_MaintenanceInformationId",
                table: "OdoHistories",
                column: "MaintenanceInformationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OdoHistories_VehiclesId",
                table: "OdoHistories",
                column: "VehiclesId");

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_InformationMaintenanceId",
                table: "Receipts",
                column: "InformationMaintenanceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceCares_MaintananceScheduleId",
                table: "ServiceCares",
                column: "MaintananceScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_SpareParts_MaintananceScheduleId",
                table: "SpareParts",
                column: "MaintananceScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_SparePartsItem_MaintenanceCenterId",
                table: "SparePartsItem",
                column: "MaintenanceCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_SparePartsItem_SparePartsId",
                table: "SparePartsItem",
                column: "SparePartsId");

            migrationBuilder.CreateIndex(
                name: "IX_SparePartsItemCosts_SparePartsItemId",
                table: "SparePartsItemCosts",
                column: "SparePartsItemId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffCares_AccountId",
                table: "StaffCares",
                column: "AccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StaffCares_CenterId",
                table: "StaffCares",
                column: "CenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Technician_InformationMaintenanceId",
                table: "Technician",
                column: "InformationMaintenanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Technician_StaffCareId",
                table: "Technician",
                column: "StaffCareId");

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

            migrationBuilder.CreateIndex(
                name: "IX_VehiclesMaintenances_VehiclesBrandId",
                table: "VehiclesMaintenances",
                column: "VehiclesBrandId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "FeedBacks");

            migrationBuilder.DropTable(
                name: "ImageRepairReceipts");

            migrationBuilder.DropTable(
                name: "MaintenanceHistoryStatuses");

            migrationBuilder.DropTable(
                name: "MaintenanceServiceCosts");

            migrationBuilder.DropTable(
                name: "MaintenanceServiceInfos");

            migrationBuilder.DropTable(
                name: "MaintenanceSparePartInfos");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "OdoHistories");

            migrationBuilder.DropTable(
                name: "SparePartsItemCosts");

            migrationBuilder.DropTable(
                name: "Technician");

            migrationBuilder.DropTable(
                name: "VehiclesMaintenances");

            migrationBuilder.DropTable(
                name: "Receipts");

            migrationBuilder.DropTable(
                name: "MaintenanceServices");

            migrationBuilder.DropTable(
                name: "SparePartsItem");

            migrationBuilder.DropTable(
                name: "StaffCares");

            migrationBuilder.DropTable(
                name: "MaintenanceInformations");

            migrationBuilder.DropTable(
                name: "ServiceCares");

            migrationBuilder.DropTable(
                name: "SpareParts");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "CustomerCares");

            migrationBuilder.DropTable(
                name: "MaintananceSchedules");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "MaintenanceCenters");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "VehicleModel");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "VehiclesBrand");
        }
    }
}
