using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersistenceService.Migrations
{
    /// <inheritdoc />
    public partial class _19032025 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "org");

            migrationBuilder.EnsureSchema(
                name: "system");

            migrationBuilder.EnsureSchema(
                name: "master");

            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "RefDataType",
                schema: "system",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefDataType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RefEnumType",
                schema: "system",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefEnumType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RefGender",
                schema: "master",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefGender", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RefIndustry",
                schema: "system",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefIndustry", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RefRole",
                schema: "system",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RefSubscription",
                schema: "master",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    DiscountRate = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefSubscription", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RefEnumValue",
                schema: "system",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EnumTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefEnumValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefEnumValue_RefEnumType_EnumTypeId",
                        column: x => x.EnumTypeId,
                        principalSchema: "system",
                        principalTable: "RefEnumType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "RefUser",
                schema: "master",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OTPAttempts = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefUser_RefGender_GenderId",
                        column: x => x.GenderId,
                        principalSchema: "master",
                        principalTable: "RefGender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "RefCategory",
                schema: "system",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IndustryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefCategory_RefIndustry_IndustryId",
                        column: x => x.IndustryId,
                        principalSchema: "system",
                        principalTable: "RefIndustry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "RefOrganization",
                schema: "master",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IndustryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsMobile = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefOrganization", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefOrganization_RefIndustry_IndustryId",
                        column: x => x.IndustryId,
                        principalSchema: "system",
                        principalTable: "RefIndustry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CoreAddress",
                schema: "org",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Town = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pincode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoreAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoreAddress_RefOrganization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalSchema: "master",
                        principalTable: "RefOrganization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CoreAsset",
                schema: "org",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganizationID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssetNo = table.Column<int>(type: "int", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    SlotInterval = table.Column<int>(type: "int", nullable: false),
                    IsOnline = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoreAsset", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoreAsset_RefCategory_CategoryID",
                        column: x => x.CategoryID,
                        principalSchema: "system",
                        principalTable: "RefCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CoreAsset_RefOrganization_OrganizationID",
                        column: x => x.OrganizationID,
                        principalSchema: "master",
                        principalTable: "RefOrganization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CoreTransaction",
                schema: "org",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Particular = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    IsCredited = table.Column<bool>(type: "bit", nullable: false),
                    TransactionStatusEnumValueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EnumValueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoreTransaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoreTransaction_RefEnumValue_EnumValueId",
                        column: x => x.EnumValueId,
                        principalSchema: "system",
                        principalTable: "RefEnumValue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CoreTransaction_RefOrganization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalSchema: "master",
                        principalTable: "RefOrganization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "RefOrganizationRole",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefOrganizationRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefOrganizationRole_RefOrganization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalSchema: "master",
                        principalTable: "RefOrganization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_RefOrganizationRole_RefRole_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "system",
                        principalTable: "RefRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_RefOrganizationRole_RefUser_UserId",
                        column: x => x.UserId,
                        principalSchema: "master",
                        principalTable: "RefUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CoreAssetBooking",
                schema: "org",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Advance = table.Column<int>(type: "int", nullable: false),
                    Balance = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CoreAssetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoreAssetBooking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoreAssetBooking_CoreAsset_CoreAssetId",
                        column: x => x.CoreAssetId,
                        principalSchema: "org",
                        principalTable: "CoreAsset",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CoreAssetCancellationPolicy",
                schema: "org",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PriorUptillPeriod = table.Column<int>(type: "int", nullable: false),
                    ReturnRate = table.Column<int>(type: "int", nullable: false),
                    CoreAssetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoreAssetCancellationPolicy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoreAssetCancellationPolicy_CoreAsset_CoreAssetId",
                        column: x => x.CoreAssetId,
                        principalSchema: "org",
                        principalTable: "CoreAsset",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CoreAssetCustomTemplate",
                schema: "org",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    CoreAssetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoreAssetCustomTemplate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoreAssetCustomTemplate_CoreAsset_CoreAssetId",
                        column: x => x.CoreAssetId,
                        principalSchema: "org",
                        principalTable: "CoreAsset",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CoreAssetSubscription",
                schema: "org",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AmountPaid = table.Column<int>(type: "int", nullable: false),
                    DaysLeftForExpiry = table.Column<int>(type: "int", nullable: false),
                    IsExpired = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CoreAssetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoreAssetSubscription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoreAssetSubscription_CoreAsset_CoreAssetId",
                        column: x => x.CoreAssetId,
                        principalSchema: "org",
                        principalTable: "CoreAsset",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CoreAssetTemplate",
                schema: "org",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DayEnumValueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    EnumValueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CoreAssetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoreAssetTemplate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoreAssetTemplate_CoreAsset_CoreAssetId",
                        column: x => x.CoreAssetId,
                        principalSchema: "org",
                        principalTable: "CoreAsset",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CoreAssetTemplate_RefEnumValue_EnumValueId",
                        column: x => x.EnumValueId,
                        principalSchema: "system",
                        principalTable: "RefEnumValue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CoreAssetBookingCancellation",
                schema: "org",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssetBookingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Refund = table.Column<int>(type: "int", nullable: false),
                    BankAccountName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankAccountNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankIfscCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CoreAssetBookingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoreAssetBookingCancellation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoreAssetBookingCancellation_CoreAssetBooking_CoreAssetBookingId",
                        column: x => x.CoreAssetBookingId,
                        principalSchema: "org",
                        principalTable: "CoreAssetBooking",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CoreAssetBookingSlot",
                schema: "org",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssetBookingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SlotDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CoreAssetBookingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoreAssetBookingSlot", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoreAssetBookingSlot_CoreAssetBooking_CoreAssetBookingId",
                        column: x => x.CoreAssetBookingId,
                        principalSchema: "org",
                        principalTable: "CoreAssetBooking",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoreAddress_OrganizationId",
                schema: "org",
                table: "CoreAddress",
                column: "OrganizationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CoreAsset_CategoryID",
                schema: "org",
                table: "CoreAsset",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_CoreAsset_OrganizationID",
                schema: "org",
                table: "CoreAsset",
                column: "OrganizationID");

            migrationBuilder.CreateIndex(
                name: "IX_CoreAssetBooking_CoreAssetId",
                schema: "org",
                table: "CoreAssetBooking",
                column: "CoreAssetId");

            migrationBuilder.CreateIndex(
                name: "IX_CoreAssetBookingCancellation_CoreAssetBookingId",
                schema: "org",
                table: "CoreAssetBookingCancellation",
                column: "CoreAssetBookingId");

            migrationBuilder.CreateIndex(
                name: "IX_CoreAssetBookingSlot_CoreAssetBookingId",
                schema: "org",
                table: "CoreAssetBookingSlot",
                column: "CoreAssetBookingId");

            migrationBuilder.CreateIndex(
                name: "IX_CoreAssetCancellationPolicy_CoreAssetId",
                schema: "org",
                table: "CoreAssetCancellationPolicy",
                column: "CoreAssetId");

            migrationBuilder.CreateIndex(
                name: "IX_CoreAssetCustomTemplate_CoreAssetId",
                schema: "org",
                table: "CoreAssetCustomTemplate",
                column: "CoreAssetId");

            migrationBuilder.CreateIndex(
                name: "IX_CoreAssetSubscription_CoreAssetId",
                schema: "org",
                table: "CoreAssetSubscription",
                column: "CoreAssetId");

            migrationBuilder.CreateIndex(
                name: "IX_CoreAssetTemplate_CoreAssetId",
                schema: "org",
                table: "CoreAssetTemplate",
                column: "CoreAssetId");

            migrationBuilder.CreateIndex(
                name: "IX_CoreAssetTemplate_EnumValueId",
                schema: "org",
                table: "CoreAssetTemplate",
                column: "EnumValueId");

            migrationBuilder.CreateIndex(
                name: "IX_CoreTransaction_EnumValueId",
                schema: "org",
                table: "CoreTransaction",
                column: "EnumValueId");

            migrationBuilder.CreateIndex(
                name: "IX_CoreTransaction_OrganizationId",
                schema: "org",
                table: "CoreTransaction",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_RefCategory_IndustryId",
                schema: "system",
                table: "RefCategory",
                column: "IndustryId");

            migrationBuilder.CreateIndex(
                name: "IX_RefEnumValue_EnumTypeId",
                schema: "system",
                table: "RefEnumValue",
                column: "EnumTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RefOrganization_IndustryId",
                schema: "master",
                table: "RefOrganization",
                column: "IndustryId");

            migrationBuilder.CreateIndex(
                name: "IX_RefOrganizationRole_OrganizationId",
                schema: "dbo",
                table: "RefOrganizationRole",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_RefOrganizationRole_RoleId",
                schema: "dbo",
                table: "RefOrganizationRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RefOrganizationRole_UserId",
                schema: "dbo",
                table: "RefOrganizationRole",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RefUser_GenderId",
                schema: "master",
                table: "RefUser",
                column: "GenderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoreAddress",
                schema: "org");

            migrationBuilder.DropTable(
                name: "CoreAssetBookingCancellation",
                schema: "org");

            migrationBuilder.DropTable(
                name: "CoreAssetBookingSlot",
                schema: "org");

            migrationBuilder.DropTable(
                name: "CoreAssetCancellationPolicy",
                schema: "org");

            migrationBuilder.DropTable(
                name: "CoreAssetCustomTemplate",
                schema: "org");

            migrationBuilder.DropTable(
                name: "CoreAssetSubscription",
                schema: "org");

            migrationBuilder.DropTable(
                name: "CoreAssetTemplate",
                schema: "org");

            migrationBuilder.DropTable(
                name: "CoreTransaction",
                schema: "org");

            migrationBuilder.DropTable(
                name: "RefDataType",
                schema: "system");

            migrationBuilder.DropTable(
                name: "RefOrganizationRole",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "RefSubscription",
                schema: "master");

            migrationBuilder.DropTable(
                name: "CoreAssetBooking",
                schema: "org");

            migrationBuilder.DropTable(
                name: "RefEnumValue",
                schema: "system");

            migrationBuilder.DropTable(
                name: "RefRole",
                schema: "system");

            migrationBuilder.DropTable(
                name: "RefUser",
                schema: "master");

            migrationBuilder.DropTable(
                name: "CoreAsset",
                schema: "org");

            migrationBuilder.DropTable(
                name: "RefEnumType",
                schema: "system");

            migrationBuilder.DropTable(
                name: "RefGender",
                schema: "master");

            migrationBuilder.DropTable(
                name: "RefCategory",
                schema: "system");

            migrationBuilder.DropTable(
                name: "RefOrganization",
                schema: "master");

            migrationBuilder.DropTable(
                name: "RefIndustry",
                schema: "system");
        }
    }
}
