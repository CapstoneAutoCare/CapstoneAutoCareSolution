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
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceInformations",
                columns: table => new
                {
                    InformationMaintenanceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InformationMaintenanceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    FinishedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerCareId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StaffCareId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceInformations", x => x.InformationMaintenanceId);
                    table.ForeignKey(
                        name: "FK_MaintenanceInformations_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "BookingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaintenanceInformations_CustomerCares_CustomerCareId",
                        column: x => x.CustomerCareId,
                        principalTable: "CustomerCares",
                        principalColumn: "CustomerCareId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaintenanceInformations_StaffCares_StaffCareId",
                        column: x => x.StaffCareId,
                        principalTable: "StaffCares",
                        principalColumn: "StaffCareId");
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceServices",
                columns: table => new
                {
                    MaintenanceCenterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaintenanceServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActuralCost = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ServiceCareId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceServices", x => x.MaintenanceCenterId);
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
                    ActuralCost = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    SparePartsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                name: "OdoHistories",
                columns: table => new
                {
                    OdoHistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OdoHistoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Odo = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                        name: "FK_MaintenanceItems_MaintenanceInformations_InformationMaintenanceId",
                        column: x => x.InformationMaintenanceId,
                        principalTable: "MaintenanceInformations",
                        principalColumn: "InformationMaintenanceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaintenanceItems_MaintenanceServices_ServiceCareCostId",
                        column: x => x.ServiceCareCostId,
                        principalTable: "MaintenanceServices",
                        principalColumn: "MaintenanceCenterId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaintenanceItems_SparePartsItem_SparePartsCostId",
                        column: x => x.SparePartsCostId,
                        principalTable: "SparePartsItem",
                        principalColumn: "SparePartsItemtId",
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
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceInformations_CustomerCareId",
                table: "MaintenanceInformations",
                column: "CustomerCareId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceInformations_StaffCareId",
                table: "MaintenanceInformations",
                column: "StaffCareId");

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
                name: "IX_MaintenanceServices_ServiceCareId",
                table: "MaintenanceServices",
                column: "ServiceCareId");

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
                name: "IX_ServiceCares_MaintenancePlanId",
                table: "ServiceCares",
                column: "MaintenancePlanId");

            migrationBuilder.CreateIndex(
                name: "IX_SpareParts_MaintenancePlanId",
                table: "SpareParts",
                column: "MaintenancePlanId");

            migrationBuilder.CreateIndex(
                name: "IX_SparePartsItem_MaintenanceCenterId",
                table: "SparePartsItem",
                column: "MaintenanceCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_SparePartsItem_SparePartsId",
                table: "SparePartsItem",
                column: "SparePartsId");

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
                name: "MaintenanceHistoryStatuses");

            migrationBuilder.DropTable(
                name: "MaintenanceItems");

            migrationBuilder.DropTable(
                name: "OdoHistories");

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
                name: "StaffCares");

            migrationBuilder.DropTable(
                name: "MaintenancePlans");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "MaintenanceCenters");

            migrationBuilder.DropTable(
                name: "MaintananceSchedules");

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
