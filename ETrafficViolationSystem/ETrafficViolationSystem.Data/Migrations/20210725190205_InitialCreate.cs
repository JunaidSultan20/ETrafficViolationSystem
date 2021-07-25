using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ETrafficViolationSystem.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    BankId = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    ShortCode = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "GetDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.BankId);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryTitle = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    ShortCode = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    CountryCode = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    DialingCode = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "GetDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "Designation",
                columns: table => new
                {
                    DesignationId = table.Column<byte>(type: "tinyint", nullable: false),
                    Title = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    ReportsTo = table.Column<byte>(type: "tinyint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "GetDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designation", x => x.DesignationId);
                });

            migrationBuilder.CreateTable(
                name: "ExceptionLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExceptionMessage = table.Column<string>(type: "varchar", nullable: false),
                    InnerException = table.Column<string>(type: "varchar", nullable: false),
                    Url = table.Column<string>(type: "varchar", nullable: false),
                    Method = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Body = table.Column<string>(type: "varchar", nullable: false),
                    RemoteIp = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "GetDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExceptionLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Infractions",
                columns: table => new
                {
                    InfractionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Penalty = table.Column<int>(type: "int", nullable: false),
                    Points = table.Column<byte>(type: "tinyint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "GetDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Infractions", x => x.InfractionId);
                });

            migrationBuilder.CreateTable(
                name: "LicenseTypes",
                columns: table => new
                {
                    LicenseTypeId = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "GetDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicenseTypes", x => x.LicenseTypeId);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMode",
                columns: table => new
                {
                    PaymentModeId = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "GetDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMode", x => x.PaymentModeId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleBodyType",
                columns: table => new
                {
                    BodyId = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BodyType = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "GetDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleBodyType", x => x.BodyId);
                });

            migrationBuilder.CreateTable(
                name: "VehicleClass",
                columns: table => new
                {
                    ClassId = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassTitle = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "GetDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleClass", x => x.ClassId);
                });

            migrationBuilder.CreateTable(
                name: "VehicleColorType",
                columns: table => new
                {
                    ColorTypeId = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColorTypeTitle = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "GetDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleColorType", x => x.ColorTypeId);
                });

            migrationBuilder.CreateTable(
                name: "CarMake",
                columns: table => new
                {
                    MakeId = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MakeTitle = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    OriginCountryId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "GetDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarMake", x => x.MakeId);
                    table.ForeignKey(
                        name: "FK_CarMake_Country",
                        column: x => x.OriginCountryId,
                        principalTable: "Country",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    StateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateTitle = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "GetDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.StateId);
                    table.ForeignKey(
                        name: "FK_States_Country",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LicenseSubTypes",
                columns: table => new
                {
                    LicenseSubTypeId = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicenseTypeId = table.Column<byte>(type: "tinyint", nullable: false),
                    Title = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    SubTypeClass = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "GetDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicenseSubTypes", x => x.LicenseSubTypeId);
                    table.ForeignKey(
                        name: "FK_LicenseSubTypes_LicenseTypes",
                        column: x => x.LicenseTypeId,
                        principalTable: "LicenseTypes",
                        principalColumn: "LicenseTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaim_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogin",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogin", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogin_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRole_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleColors",
                columns: table => new
                {
                    ColorId = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColorTypeId = table.Column<byte>(type: "tinyint", nullable: false),
                    ColorName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    ColorCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "GetDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleColors", x => x.ColorId);
                    table.ForeignKey(
                        name: "FK_VehicleColors_VehicleColorType",
                        column: x => x.ColorTypeId,
                        principalTable: "VehicleColorType",
                        principalColumn: "ColorTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CarModel",
                columns: table => new
                {
                    ModelId = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    ModelTitle = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    ProductionYear = table.Column<int>(type: "int", nullable: false),
                    MakeId = table.Column<short>(type: "smallint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "GetDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarModel", x => x.ModelId);
                    table.ForeignKey(
                        name: "FK_CarModel_CarMake",
                        column: x => x.MakeId,
                        principalTable: "CarMake",
                        principalColumn: "MakeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityTitle = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    PostalCode = table.Column<int>(type: "int", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "GetDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.CityId);
                    table.ForeignKey(
                        name: "FK_City_States",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChassisNo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    EngineNo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    FrameNo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    MakeId = table.Column<short>(type: "smallint", nullable: false),
                    Year = table.Column<short>(type: "smallint", nullable: false),
                    CategoryId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BodyTypeId = table.Column<byte>(type: "tinyint", nullable: false),
                    ClassId = table.Column<byte>(type: "tinyint", nullable: false),
                    Capacity = table.Column<byte>(type: "tinyint", nullable: false),
                    HorsePower = table.Column<short>(type: "smallint", nullable: false),
                    Cylinders = table.Column<byte>(type: "tinyint", nullable: false),
                    ColorId = table.Column<short>(type: "smallint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "GetDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.VehicleId);
                    table.ForeignKey(
                        name: "FK_Vehicles_CarMake",
                        column: x => x.MakeId,
                        principalTable: "CarMake",
                        principalColumn: "MakeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleBodyType",
                        column: x => x.BodyTypeId,
                        principalTable: "VehicleBodyType",
                        principalColumn: "BodyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleClass",
                        column: x => x.ClassId,
                        principalTable: "VehicleClass",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleColors",
                        column: x => x.ColorId,
                        principalTable: "VehicleColors",
                        principalColumn: "ColorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BankBranch",
                columns: table => new
                {
                    BankBranchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchCode = table.Column<int>(type: "int", nullable: false),
                    BranchTitle = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    BankId = table.Column<byte>(type: "tinyint", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "GetDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankBranch", x => x.BankBranchId);
                    table.ForeignKey(
                        name: "FK_BankBranch_Banks",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "BankId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BankBranch_City",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DriverDetails",
                columns: table => new
                {
                    DriverId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    MiddleName = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    LastName = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    FatherName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    CNIC = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    Dob = table.Column<DateTime>(type: "datetime", nullable: false),
                    Gender = table.Column<byte>(type: "tinyint", nullable: false),
                    Religion = table.Column<byte>(type: "tinyint", nullable: false),
                    PostalAddress = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    PermanentAddress = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    MobileNumber = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    HomePhone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    BloodGroupId = table.Column<byte>(type: "tinyint", nullable: false),
                    Height = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: false),
                    Mark = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Disability = table.Column<bool>(type: "bit", nullable: false),
                    DisabilityDescription = table.Column<string>(type: "varchar", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "GetDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverDetails", x => x.DriverId);
                    table.ForeignKey(
                        name: "FK_DriverDetails_City",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Officers",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfficerId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    FatherName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Cnic = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    Dob = table.Column<DateTime>(type: "date", nullable: false),
                    Gender = table.Column<byte>(type: "tinyint", nullable: false),
                    Religion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    PostalAddress = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    PermanentAddress = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    MobileNumber = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    HomePhone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    BloodGroupId = table.Column<byte>(type: "tinyint", nullable: false),
                    DesignationId = table.Column<byte>(type: "tinyint", nullable: false),
                    OfficerImage = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "GetDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Officers", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Officers_City",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Officers_Designation",
                        column: x => x.DesignationId,
                        principalTable: "Designation",
                        principalColumn: "DesignationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Officers_Users",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OwnerDetails",
                columns: table => new
                {
                    OwnerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    FatherName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    CNIC = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Dob = table.Column<DateTime>(type: "date", nullable: false),
                    Gender = table.Column<byte>(type: "tinyint", nullable: false),
                    Religion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    PostalAddress = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    PermanentAddress = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    MobileNumber = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    HomePhone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    OwnerImage = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "GetDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnerDetails", x => x.OwnerId);
                    table.ForeignKey(
                        name: "FK_OwnerDetails_City",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    ChallanNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalAmount = table.Column<int>(type: "int", nullable: false),
                    PaidAmount = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<DateTime>(type: "date", nullable: false),
                    PaymentModeId = table.Column<byte>(type: "tinyint", nullable: false),
                    BankBranchId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "GetDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.ChallanNo);
                    table.ForeignKey(
                        name: "FK_Payments_BankBranch",
                        column: x => x.BankBranchId,
                        principalTable: "BankBranch",
                        principalColumn: "BankBranchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payments_PaymentMode",
                        column: x => x.PaymentModeId,
                        principalTable: "PaymentMode",
                        principalColumn: "PaymentModeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LicenseRecords",
                columns: table => new
                {
                    LicenseNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriverId = table.Column<int>(type: "int", nullable: false),
                    LicenseTypeId = table.Column<byte>(type: "tinyint", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "date", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "date", nullable: false),
                    PdlNo = table.Column<int>(type: "int", nullable: true),
                    Points = table.Column<int>(type: "int", nullable: false),
                    Suspended = table.Column<bool>(type: "bit", nullable: false),
                    SuspensionEndDate = table.Column<DateTime>(type: "date", nullable: true),
                    Terminated = table.Column<bool>(type: "bit", nullable: false),
                    LicenseImageFront = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    LicenseImageBack = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "GetDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicenseRecords", x => x.LicenseNo);
                    table.ForeignKey(
                        name: "FK_LicenseRecords_DriverDetails",
                        column: x => x.DriverId,
                        principalTable: "DriverDetails",
                        principalColumn: "DriverId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LicenseRecords_LicenseTypes",
                        column: x => x.LicenseTypeId,
                        principalTable: "LicenseTypes",
                        principalColumn: "LicenseTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TaxDetails",
                columns: table => new
                {
                    TaxId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    TaxFilerType = table.Column<byte>(type: "tinyint", nullable: false),
                    AmountPaid = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaidDate = table.Column<DateTime>(type: "date", nullable: false),
                    PaidUpToDate = table.Column<DateTime>(type: "date", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "GetDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxDetails", x => x.TaxId);
                    table.ForeignKey(
                        name: "FK_TaxDetails_OwnerDetails",
                        column: x => x.OwnerId,
                        principalTable: "OwnerDetails",
                        principalColumn: "OwnerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TaxDetails_Vehicles",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VehicleDetails",
                columns: table => new
                {
                    VehicleDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    RegistrationNo = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    RegistrationCityId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    ClearanceStatus = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "GetDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleDetails", x => x.VehicleDetailId);
                    table.ForeignKey(
                        name: "FK_VehicleDetails_City",
                        column: x => x.RegistrationCityId,
                        principalTable: "City",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VehicleDetails_OwnerDetails",
                        column: x => x.OwnerId,
                        principalTable: "OwnerDetails",
                        principalColumn: "OwnerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VehicleDetails_Vehicles",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ViolationRecords",
                columns: table => new
                {
                    ViolationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicenseNo = table.Column<int>(type: "int", nullable: false),
                    VehicleDetailId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    LocationLatitude = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    LocationLongitude = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    PointsDeducted = table.Column<int>(type: "int", nullable: false),
                    ChallanNo = table.Column<int>(type: "int", nullable: false),
                    BookedBy = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "GetDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViolationRecords", x => x.ViolationId);
                    table.ForeignKey(
                        name: "FK_ViolationRecords_City",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ViolationRecords_LicenseRecords",
                        column: x => x.LicenseNo,
                        principalTable: "LicenseRecords",
                        principalColumn: "LicenseNo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ViolationRecords_VehicleDetails",
                        column: x => x.VehicleDetailId,
                        principalTable: "VehicleDetails",
                        principalColumn: "VehicleDetailId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ViolationRecordDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ViolationId = table.Column<int>(type: "int", nullable: false),
                    InfractionId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GetDate()"),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "GetDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViolationRecordDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ViolationRecordDetails_Infractions",
                        column: x => x.InfractionId,
                        principalTable: "Infractions",
                        principalColumn: "InfractionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ViolationRecordDetails_ViolationRecords",
                        column: x => x.ViolationId,
                        principalTable: "ViolationRecords",
                        principalColumn: "ViolationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankBranch_BankId",
                table: "BankBranch",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_BankBranch_CityId",
                table: "BankBranch",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Banks_Title",
                table: "Banks",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarMake_OriginCountryId",
                table: "CarMake",
                column: "OriginCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_CarModel_MakeId",
                table: "CarModel",
                column: "MakeId");

            migrationBuilder.CreateIndex(
                name: "IX_City_CityTitle",
                table: "City",
                column: "CityTitle",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_City_StateId",
                table: "City",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Country_CountryTitle",
                table: "Country",
                column: "CountryTitle",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DriverDetails_CityId",
                table: "DriverDetails",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_DriverDetails_CNIC",
                table: "DriverDetails",
                column: "CNIC",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DriverDetails_Email",
                table: "DriverDetails",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_LicenseRecords_DriverId",
                table: "LicenseRecords",
                column: "DriverId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LicenseRecords_LicenseTypeId",
                table: "LicenseRecords",
                column: "LicenseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LicenseRecords_PdlNo",
                table: "LicenseRecords",
                column: "PdlNo",
                unique: true,
                filter: "[PdlNo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_LicenseSubTypes_LicenseTypeId",
                table: "LicenseSubTypes",
                column: "LicenseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Officers_CityId",
                table: "Officers",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Officers_Cnic",
                table: "Officers",
                column: "Cnic",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Officers_DesignationId",
                table: "Officers",
                column: "DesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_Officers_Email",
                table: "Officers",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Officers_UserId",
                table: "Officers",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OwnerDetails_CityId",
                table: "OwnerDetails",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnerDetails_CNIC",
                table: "OwnerDetails",
                column: "CNIC",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMode_Title",
                table: "PaymentMode",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_BankBranchId",
                table: "Payments",
                column: "BankBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PaymentModeId",
                table: "Payments",
                column: "PaymentModeId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_States_CountryId",
                table: "States",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_States_StateTitle",
                table: "States",
                column: "StateTitle",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaxDetails_OwnerId",
                table: "TaxDetails",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxDetails_VehicleId",
                table: "TaxDetails",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaim_UserId",
                table: "UserClaim",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogin_UserId",
                table: "UserLogin",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleClass_ClassTitle",
                table: "VehicleClass",
                column: "ClassTitle",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleColors_ColorTypeId",
                table: "VehicleColors",
                column: "ColorTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleDetails_OwnerId",
                table: "VehicleDetails",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleDetails_RegistrationCityId",
                table: "VehicleDetails",
                column: "RegistrationCityId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleDetails_RegistrationNo",
                table: "VehicleDetails",
                column: "RegistrationNo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleDetails_VehicleId",
                table: "VehicleDetails",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_BodyTypeId",
                table: "Vehicles",
                column: "BodyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ChassisNo",
                table: "Vehicles",
                column: "ChassisNo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ClassId",
                table: "Vehicles",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ColorId",
                table: "Vehicles",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_EngineNo",
                table: "Vehicles",
                column: "EngineNo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_FrameNo",
                table: "Vehicles",
                column: "FrameNo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_MakeId",
                table: "Vehicles",
                column: "MakeId");

            migrationBuilder.CreateIndex(
                name: "IX_ViolationRecordDetails_InfractionId",
                table: "ViolationRecordDetails",
                column: "InfractionId");

            migrationBuilder.CreateIndex(
                name: "IX_ViolationRecordDetails_ViolationId",
                table: "ViolationRecordDetails",
                column: "ViolationId");

            migrationBuilder.CreateIndex(
                name: "IX_ViolationRecords_CityId",
                table: "ViolationRecords",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_ViolationRecords_LicenseNo",
                table: "ViolationRecords",
                column: "LicenseNo");

            migrationBuilder.CreateIndex(
                name: "IX_ViolationRecords_VehicleDetailId",
                table: "ViolationRecords",
                column: "VehicleDetailId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarModel");

            migrationBuilder.DropTable(
                name: "ExceptionLog");

            migrationBuilder.DropTable(
                name: "LicenseSubTypes");

            migrationBuilder.DropTable(
                name: "Officers");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "TaxDetails");

            migrationBuilder.DropTable(
                name: "UserClaim");

            migrationBuilder.DropTable(
                name: "UserLogin");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "ViolationRecordDetails");

            migrationBuilder.DropTable(
                name: "Designation");

            migrationBuilder.DropTable(
                name: "BankBranch");

            migrationBuilder.DropTable(
                name: "PaymentMode");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Infractions");

            migrationBuilder.DropTable(
                name: "ViolationRecords");

            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropTable(
                name: "LicenseRecords");

            migrationBuilder.DropTable(
                name: "VehicleDetails");

            migrationBuilder.DropTable(
                name: "DriverDetails");

            migrationBuilder.DropTable(
                name: "LicenseTypes");

            migrationBuilder.DropTable(
                name: "OwnerDetails");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "CarMake");

            migrationBuilder.DropTable(
                name: "VehicleBodyType");

            migrationBuilder.DropTable(
                name: "VehicleClass");

            migrationBuilder.DropTable(
                name: "VehicleColors");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "VehicleColorType");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
