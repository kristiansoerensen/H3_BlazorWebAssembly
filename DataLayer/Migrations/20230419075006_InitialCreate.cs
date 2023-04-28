using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentProvider",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentProvider", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: true),
                    SKU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    active = table.Column<bool>(type: "bit", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: true),
                    Featured = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Filename = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BillingAddressId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Address_BillingAddressId",
                        column: x => x.BillingAddressId,
                        principalTable: "Address",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Baskets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Total = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: true),
                    BillingAddressId = table.Column<int>(type: "int", nullable: true),
                    ShippingAddressId = table.Column<int>(type: "int", nullable: true),
                    PaymentProviderId = table.Column<int>(type: "int", nullable: true),
                    state = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baskets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Baskets_Address_BillingAddressId",
                        column: x => x.BillingAddressId,
                        principalTable: "Address",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Baskets_Address_ShippingAddressId",
                        column: x => x.ShippingAddressId,
                        principalTable: "Address",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Baskets_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Baskets_PaymentProvider_PaymentProviderId",
                        column: x => x.PaymentProviderId,
                        principalTable: "PaymentProvider",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => new { x.ProductId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ProductCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BasketItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BasketId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    QTY = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BasketItems_Baskets_BasketId",
                        column: x => x.BasketId,
                        principalTable: "Baskets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BasketItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c7b013f0-5201-4317-abd8-c211f91b7330", "2", "HR", "Human Resource" },
                    { "fab4fac1-c546-41de-aebc-a14da6895711", "1", "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BillingAddressId", "ConcurrencyStamp", "CreateDate", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "ModifiedDate", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b74ddd14-6340-4840-95c2-db12554843e5", 0, null, "7c3de54d-032f-4b88-9369-dbf6d464b703", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", "admin@gmail.com", false, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "1234567890", false, "4e3fd1c5-85a5-4023-8b01-14d98199ecbc", false, "Admin" });

            migrationBuilder.InsertData(
                table: "Baskets",
                columns: new[] { "Id", "BillingAddressId", "CreateDate", "ModifiedDate", "PaymentProviderId", "ShippingAddressId", "Total", "UserId", "state" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2023, 1, 18, 15, 29, 53, 512, DateTimeKind.Local).AddTicks(9252), new DateTime(2023, 3, 9, 23, 43, 3, 918, DateTimeKind.Local).AddTicks(5311), null, null, null, null, "draft" },
                    { 2, null, new DateTime(2022, 10, 30, 22, 49, 17, 182, DateTimeKind.Local).AddTicks(4658), new DateTime(2022, 7, 11, 18, 34, 58, 390, DateTimeKind.Local).AddTicks(8321), null, null, null, null, "draft" },
                    { 3, null, new DateTime(2022, 8, 22, 9, 58, 10, 148, DateTimeKind.Local).AddTicks(4674), new DateTime(2022, 11, 12, 10, 39, 33, 868, DateTimeKind.Local).AddTicks(2901), null, null, null, null, "draft" },
                    { 4, null, new DateTime(2022, 12, 11, 4, 3, 40, 414, DateTimeKind.Local).AddTicks(176), new DateTime(2022, 5, 9, 21, 36, 5, 243, DateTimeKind.Local).AddTicks(210), null, null, null, null, "draft" },
                    { 5, null, new DateTime(2023, 3, 13, 10, 44, 27, 103, DateTimeKind.Local).AddTicks(5950), new DateTime(2022, 8, 27, 21, 55, 27, 589, DateTimeKind.Local).AddTicks(9664), null, null, null, null, "draft" },
                    { 6, null, new DateTime(2023, 4, 8, 22, 58, 35, 457, DateTimeKind.Local).AddTicks(2525), new DateTime(2023, 1, 18, 21, 5, 58, 849, DateTimeKind.Local).AddTicks(5606), null, null, null, null, "draft" },
                    { 7, null, new DateTime(2022, 12, 23, 13, 40, 12, 870, DateTimeKind.Local).AddTicks(5808), new DateTime(2022, 4, 23, 3, 28, 29, 213, DateTimeKind.Local).AddTicks(4002), null, null, null, null, "draft" },
                    { 8, null, new DateTime(2022, 8, 13, 10, 26, 11, 306, DateTimeKind.Local).AddTicks(4423), new DateTime(2022, 8, 23, 9, 1, 1, 577, DateTimeKind.Local).AddTicks(7686), null, null, null, null, "draft" },
                    { 9, null, new DateTime(2023, 1, 6, 5, 7, 37, 175, DateTimeKind.Local).AddTicks(8716), new DateTime(2022, 9, 6, 19, 24, 1, 651, DateTimeKind.Local).AddTicks(7200), null, null, null, null, "draft" },
                    { 10, null, new DateTime(2022, 8, 5, 8, 35, 29, 557, DateTimeKind.Local).AddTicks(3523), new DateTime(2022, 8, 6, 6, 5, 46, 26, DateTimeKind.Local).AddTicks(6347), null, null, null, null, "draft" },
                    { 11, null, new DateTime(2022, 5, 7, 17, 46, 32, 881, DateTimeKind.Local).AddTicks(3504), new DateTime(2023, 3, 16, 7, 45, 6, 857, DateTimeKind.Local).AddTicks(3520), null, null, null, null, "draft" },
                    { 12, null, new DateTime(2023, 2, 19, 16, 17, 16, 974, DateTimeKind.Local).AddTicks(3301), new DateTime(2022, 11, 30, 23, 46, 6, 76, DateTimeKind.Local).AddTicks(3972), null, null, null, null, "draft" },
                    { 13, null, new DateTime(2022, 7, 2, 3, 48, 47, 402, DateTimeKind.Local).AddTicks(5326), new DateTime(2023, 2, 16, 13, 18, 9, 842, DateTimeKind.Local).AddTicks(5568), null, null, null, null, "draft" },
                    { 14, null, new DateTime(2022, 7, 3, 16, 17, 25, 657, DateTimeKind.Local).AddTicks(5274), new DateTime(2022, 12, 28, 6, 30, 56, 137, DateTimeKind.Local).AddTicks(2163), null, null, null, null, "draft" },
                    { 15, null, new DateTime(2022, 6, 23, 0, 6, 21, 406, DateTimeKind.Local).AddTicks(2428), new DateTime(2022, 5, 30, 20, 21, 42, 550, DateTimeKind.Local).AddTicks(6001), null, null, null, null, "draft" },
                    { 16, null, new DateTime(2022, 9, 28, 8, 37, 36, 151, DateTimeKind.Local).AddTicks(4034), new DateTime(2022, 7, 31, 19, 14, 42, 327, DateTimeKind.Local).AddTicks(6253), null, null, null, null, "draft" },
                    { 17, null, new DateTime(2022, 8, 7, 4, 0, 12, 619, DateTimeKind.Local).AddTicks(6239), new DateTime(2023, 4, 14, 10, 34, 22, 181, DateTimeKind.Local).AddTicks(7630), null, null, null, null, "draft" },
                    { 18, null, new DateTime(2022, 4, 22, 9, 0, 1, 404, DateTimeKind.Local).AddTicks(9416), new DateTime(2022, 6, 29, 2, 37, 58, 571, DateTimeKind.Local).AddTicks(8730), null, null, null, null, "draft" },
                    { 19, null, new DateTime(2022, 6, 9, 23, 14, 27, 842, DateTimeKind.Local).AddTicks(2033), new DateTime(2023, 3, 27, 14, 18, 21, 130, DateTimeKind.Local).AddTicks(4423), null, null, null, null, "draft" },
                    { 20, null, new DateTime(2022, 10, 13, 15, 44, 44, 569, DateTimeKind.Local).AddTicks(369), new DateTime(2022, 10, 9, 16, 34, 21, 991, DateTimeKind.Local).AddTicks(9555), null, null, null, null, "draft" },
                    { 21, null, new DateTime(2023, 1, 9, 19, 53, 11, 789, DateTimeKind.Local).AddTicks(8970), new DateTime(2022, 4, 21, 16, 10, 44, 290, DateTimeKind.Local).AddTicks(4116), null, null, null, null, "draft" },
                    { 22, null, new DateTime(2022, 8, 10, 3, 45, 36, 748, DateTimeKind.Local).AddTicks(8600), new DateTime(2022, 11, 29, 7, 5, 0, 73, DateTimeKind.Local).AddTicks(1533), null, null, null, null, "draft" },
                    { 23, null, new DateTime(2022, 11, 11, 21, 4, 11, 240, DateTimeKind.Local).AddTicks(619), new DateTime(2022, 8, 15, 21, 16, 57, 185, DateTimeKind.Local).AddTicks(4554), null, null, null, null, "draft" },
                    { 24, null, new DateTime(2022, 8, 15, 3, 58, 17, 521, DateTimeKind.Local).AddTicks(8425), new DateTime(2022, 10, 28, 19, 27, 9, 991, DateTimeKind.Local).AddTicks(9326), null, null, null, null, "draft" },
                    { 25, null, new DateTime(2023, 1, 20, 3, 51, 2, 697, DateTimeKind.Local).AddTicks(7683), new DateTime(2022, 12, 11, 9, 18, 51, 70, DateTimeKind.Local).AddTicks(8781), null, null, null, null, "draft" },
                    { 26, null, new DateTime(2022, 10, 9, 7, 51, 42, 530, DateTimeKind.Local).AddTicks(9802), new DateTime(2023, 2, 16, 13, 39, 7, 62, DateTimeKind.Local).AddTicks(8689), null, null, null, null, "draft" },
                    { 27, null, new DateTime(2022, 12, 13, 21, 43, 32, 736, DateTimeKind.Local).AddTicks(6515), new DateTime(2022, 8, 9, 22, 35, 13, 582, DateTimeKind.Local).AddTicks(1153), null, null, null, null, "draft" },
                    { 28, null, new DateTime(2022, 11, 26, 4, 22, 53, 188, DateTimeKind.Local).AddTicks(3139), new DateTime(2023, 2, 21, 17, 34, 52, 638, DateTimeKind.Local).AddTicks(5345), null, null, null, null, "draft" },
                    { 29, null, new DateTime(2022, 5, 7, 17, 15, 52, 927, DateTimeKind.Local).AddTicks(1544), new DateTime(2023, 3, 19, 8, 53, 17, 89, DateTimeKind.Local).AddTicks(176), null, null, null, null, "draft" },
                    { 30, null, new DateTime(2022, 4, 29, 0, 36, 16, 971, DateTimeKind.Local).AddTicks(2490), new DateTime(2022, 10, 23, 6, 30, 6, 288, DateTimeKind.Local).AddTicks(8602), null, null, null, null, "draft" },
                    { 31, null, new DateTime(2022, 8, 29, 4, 12, 14, 193, DateTimeKind.Local).AddTicks(7131), new DateTime(2023, 4, 2, 7, 22, 50, 259, DateTimeKind.Local).AddTicks(7516), null, null, null, null, "draft" },
                    { 32, null, new DateTime(2023, 3, 6, 7, 19, 49, 819, DateTimeKind.Local).AddTicks(7329), new DateTime(2023, 1, 31, 0, 12, 50, 535, DateTimeKind.Local).AddTicks(9498), null, null, null, null, "draft" },
                    { 33, null, new DateTime(2023, 3, 18, 23, 7, 57, 421, DateTimeKind.Local).AddTicks(5186), new DateTime(2022, 12, 26, 13, 33, 59, 112, DateTimeKind.Local).AddTicks(5829), null, null, null, null, "draft" },
                    { 34, null, new DateTime(2022, 10, 1, 2, 55, 52, 212, DateTimeKind.Local).AddTicks(8931), new DateTime(2022, 12, 28, 12, 55, 56, 671, DateTimeKind.Local).AddTicks(7741), null, null, null, null, "draft" },
                    { 35, null, new DateTime(2022, 4, 20, 4, 18, 33, 791, DateTimeKind.Local).AddTicks(4157), new DateTime(2022, 6, 3, 17, 38, 18, 717, DateTimeKind.Local).AddTicks(5265), null, null, null, null, "draft" },
                    { 36, null, new DateTime(2022, 7, 2, 19, 36, 39, 718, DateTimeKind.Local).AddTicks(5233), new DateTime(2023, 1, 29, 0, 39, 22, 28, DateTimeKind.Local).AddTicks(3871), null, null, null, null, "draft" },
                    { 37, null, new DateTime(2023, 3, 13, 13, 29, 23, 65, DateTimeKind.Local).AddTicks(6417), new DateTime(2023, 2, 13, 1, 51, 13, 548, DateTimeKind.Local).AddTicks(3555), null, null, null, null, "draft" },
                    { 38, null, new DateTime(2022, 11, 13, 20, 2, 40, 219, DateTimeKind.Local).AddTicks(6970), new DateTime(2022, 5, 5, 11, 25, 54, 573, DateTimeKind.Local).AddTicks(8982), null, null, null, null, "draft" },
                    { 39, null, new DateTime(2022, 11, 23, 13, 49, 36, 91, DateTimeKind.Local).AddTicks(4520), new DateTime(2022, 7, 10, 19, 2, 22, 884, DateTimeKind.Local).AddTicks(1369), null, null, null, null, "draft" },
                    { 40, null, new DateTime(2022, 5, 8, 12, 32, 0, 819, DateTimeKind.Local).AddTicks(2962), new DateTime(2023, 3, 5, 16, 21, 56, 200, DateTimeKind.Local).AddTicks(382), null, null, null, null, "draft" },
                    { 41, null, new DateTime(2022, 10, 21, 19, 9, 58, 303, DateTimeKind.Local).AddTicks(6758), new DateTime(2022, 12, 23, 6, 40, 21, 648, DateTimeKind.Local).AddTicks(5562), null, null, null, null, "draft" },
                    { 42, null, new DateTime(2023, 3, 27, 12, 29, 59, 422, DateTimeKind.Local).AddTicks(4102), new DateTime(2022, 10, 30, 0, 37, 36, 318, DateTimeKind.Local).AddTicks(3231), null, null, null, null, "draft" },
                    { 43, null, new DateTime(2022, 12, 8, 22, 20, 6, 2, DateTimeKind.Local).AddTicks(5791), new DateTime(2022, 11, 29, 4, 48, 35, 71, DateTimeKind.Local).AddTicks(4935), null, null, null, null, "draft" },
                    { 44, null, new DateTime(2022, 12, 5, 7, 21, 15, 573, DateTimeKind.Local).AddTicks(9335), new DateTime(2023, 4, 16, 15, 15, 5, 20, DateTimeKind.Local).AddTicks(4684), null, null, null, null, "draft" },
                    { 45, null, new DateTime(2022, 9, 5, 16, 1, 34, 976, DateTimeKind.Local).AddTicks(4095), new DateTime(2022, 6, 18, 1, 15, 14, 749, DateTimeKind.Local).AddTicks(3676), null, null, null, null, "draft" },
                    { 46, null, new DateTime(2022, 6, 10, 19, 12, 11, 627, DateTimeKind.Local).AddTicks(6797), new DateTime(2022, 7, 11, 0, 11, 16, 736, DateTimeKind.Local).AddTicks(1467), null, null, null, null, "draft" },
                    { 47, null, new DateTime(2023, 3, 17, 23, 32, 10, 142, DateTimeKind.Local).AddTicks(1552), new DateTime(2023, 4, 9, 19, 4, 44, 263, DateTimeKind.Local).AddTicks(1386), null, null, null, null, "draft" },
                    { 48, null, new DateTime(2022, 5, 30, 22, 12, 13, 781, DateTimeKind.Local).AddTicks(2050), new DateTime(2023, 1, 26, 22, 20, 27, 513, DateTimeKind.Local).AddTicks(1081), null, null, null, null, "draft" },
                    { 49, null, new DateTime(2022, 6, 4, 18, 41, 0, 453, DateTimeKind.Local).AddTicks(6420), new DateTime(2022, 10, 27, 13, 22, 52, 195, DateTimeKind.Local).AddTicks(8736), null, null, null, null, "draft" },
                    { 50, null, new DateTime(2022, 12, 30, 17, 47, 8, 634, DateTimeKind.Local).AddTicks(5987), new DateTime(2023, 3, 5, 17, 20, 18, 110, DateTimeKind.Local).AddTicks(4430), null, null, null, null, "draft" },
                    { 51, null, new DateTime(2023, 3, 4, 4, 11, 10, 955, DateTimeKind.Local).AddTicks(5269), new DateTime(2022, 12, 5, 0, 52, 26, 833, DateTimeKind.Local).AddTicks(332), null, null, null, null, "draft" },
                    { 52, null, new DateTime(2022, 10, 28, 0, 58, 42, 183, DateTimeKind.Local).AddTicks(4823), new DateTime(2022, 12, 5, 20, 2, 49, 963, DateTimeKind.Local).AddTicks(2072), null, null, null, null, "draft" },
                    { 53, null, new DateTime(2022, 9, 27, 23, 32, 17, 335, DateTimeKind.Local).AddTicks(3239), new DateTime(2022, 12, 28, 17, 2, 26, 485, DateTimeKind.Local).AddTicks(5620), null, null, null, null, "draft" },
                    { 54, null, new DateTime(2023, 3, 25, 9, 59, 49, 980, DateTimeKind.Local).AddTicks(1970), new DateTime(2023, 2, 17, 5, 42, 25, 171, DateTimeKind.Local).AddTicks(2658), null, null, null, null, "draft" },
                    { 55, null, new DateTime(2023, 1, 13, 12, 22, 39, 345, DateTimeKind.Local).AddTicks(3887), new DateTime(2022, 11, 10, 2, 47, 4, 597, DateTimeKind.Local).AddTicks(3864), null, null, null, null, "draft" },
                    { 56, null, new DateTime(2022, 7, 18, 13, 35, 22, 530, DateTimeKind.Local).AddTicks(536), new DateTime(2023, 2, 14, 8, 3, 36, 25, DateTimeKind.Local).AddTicks(9887), null, null, null, null, "draft" },
                    { 57, null, new DateTime(2023, 2, 28, 6, 11, 22, 252, DateTimeKind.Local).AddTicks(6935), new DateTime(2022, 6, 12, 18, 4, 26, 754, DateTimeKind.Local).AddTicks(1827), null, null, null, null, "draft" },
                    { 58, null, new DateTime(2022, 4, 20, 21, 10, 13, 968, DateTimeKind.Local).AddTicks(1571), new DateTime(2022, 12, 24, 7, 21, 58, 528, DateTimeKind.Local).AddTicks(1294), null, null, null, null, "draft" },
                    { 59, null, new DateTime(2022, 4, 25, 4, 42, 56, 820, DateTimeKind.Local).AddTicks(3147), new DateTime(2022, 8, 24, 16, 32, 19, 484, DateTimeKind.Local).AddTicks(3832), null, null, null, null, "draft" },
                    { 60, null, new DateTime(2022, 6, 11, 11, 42, 50, 516, DateTimeKind.Local).AddTicks(3447), new DateTime(2022, 8, 7, 4, 9, 28, 332, DateTimeKind.Local).AddTicks(9992), null, null, null, null, "draft" },
                    { 61, null, new DateTime(2022, 5, 10, 16, 2, 49, 521, DateTimeKind.Local).AddTicks(6241), new DateTime(2022, 10, 3, 21, 30, 53, 175, DateTimeKind.Local).AddTicks(3995), null, null, null, null, "draft" },
                    { 62, null, new DateTime(2022, 8, 11, 6, 44, 27, 678, DateTimeKind.Local).AddTicks(3401), new DateTime(2023, 2, 19, 12, 53, 25, 25, DateTimeKind.Local).AddTicks(238), null, null, null, null, "draft" },
                    { 63, null, new DateTime(2023, 4, 12, 8, 16, 13, 72, DateTimeKind.Local).AddTicks(8230), new DateTime(2023, 4, 11, 5, 15, 28, 965, DateTimeKind.Local).AddTicks(3528), null, null, null, null, "draft" },
                    { 64, null, new DateTime(2023, 3, 2, 10, 57, 17, 869, DateTimeKind.Local).AddTicks(2089), new DateTime(2023, 3, 23, 4, 14, 44, 785, DateTimeKind.Local).AddTicks(4802), null, null, null, null, "draft" },
                    { 65, null, new DateTime(2023, 1, 2, 13, 29, 5, 750, DateTimeKind.Local).AddTicks(1282), new DateTime(2023, 2, 4, 7, 32, 18, 689, DateTimeKind.Local).AddTicks(5668), null, null, null, null, "draft" },
                    { 66, null, new DateTime(2023, 3, 20, 2, 35, 0, 103, DateTimeKind.Local).AddTicks(2345), new DateTime(2022, 5, 16, 10, 16, 49, 878, DateTimeKind.Local).AddTicks(5570), null, null, null, null, "draft" },
                    { 67, null, new DateTime(2022, 10, 28, 11, 5, 20, 232, DateTimeKind.Local).AddTicks(5173), new DateTime(2022, 6, 22, 5, 1, 48, 691, DateTimeKind.Local).AddTicks(8323), null, null, null, null, "draft" },
                    { 68, null, new DateTime(2022, 4, 20, 22, 0, 51, 227, DateTimeKind.Local).AddTicks(4911), new DateTime(2023, 3, 6, 4, 7, 37, 453, DateTimeKind.Local).AddTicks(6225), null, null, null, null, "draft" },
                    { 69, null, new DateTime(2022, 6, 14, 15, 31, 45, 448, DateTimeKind.Local).AddTicks(546), new DateTime(2022, 8, 9, 2, 17, 15, 442, DateTimeKind.Local).AddTicks(1836), null, null, null, null, "draft" },
                    { 70, null, new DateTime(2022, 5, 21, 10, 55, 24, 965, DateTimeKind.Local).AddTicks(9834), new DateTime(2023, 3, 30, 15, 7, 45, 500, DateTimeKind.Local).AddTicks(13), null, null, null, null, "draft" },
                    { 71, null, new DateTime(2022, 12, 24, 4, 38, 51, 74, DateTimeKind.Local).AddTicks(2814), new DateTime(2023, 2, 4, 11, 28, 56, 385, DateTimeKind.Local).AddTicks(6526), null, null, null, null, "draft" },
                    { 72, null, new DateTime(2022, 7, 21, 12, 42, 31, 658, DateTimeKind.Local).AddTicks(653), new DateTime(2023, 2, 12, 23, 4, 36, 362, DateTimeKind.Local).AddTicks(88), null, null, null, null, "draft" },
                    { 73, null, new DateTime(2023, 3, 19, 21, 29, 58, 202, DateTimeKind.Local).AddTicks(3003), new DateTime(2022, 8, 13, 20, 58, 41, 584, DateTimeKind.Local).AddTicks(6773), null, null, null, null, "draft" },
                    { 74, null, new DateTime(2022, 8, 30, 3, 50, 0, 466, DateTimeKind.Local).AddTicks(4403), new DateTime(2023, 1, 22, 15, 17, 49, 370, DateTimeKind.Local).AddTicks(9595), null, null, null, null, "draft" },
                    { 75, null, new DateTime(2023, 4, 8, 7, 44, 36, 277, DateTimeKind.Local).AddTicks(9693), new DateTime(2022, 9, 24, 0, 40, 21, 236, DateTimeKind.Local).AddTicks(634), null, null, null, null, "draft" },
                    { 76, null, new DateTime(2023, 1, 21, 3, 27, 36, 675, DateTimeKind.Local).AddTicks(7847), new DateTime(2023, 1, 28, 11, 58, 46, 952, DateTimeKind.Local).AddTicks(2504), null, null, null, null, "draft" },
                    { 77, null, new DateTime(2022, 9, 4, 11, 30, 7, 662, DateTimeKind.Local).AddTicks(5212), new DateTime(2022, 9, 11, 23, 27, 46, 284, DateTimeKind.Local).AddTicks(5917), null, null, null, null, "draft" },
                    { 78, null, new DateTime(2023, 2, 12, 11, 7, 34, 571, DateTimeKind.Local).AddTicks(8118), new DateTime(2022, 9, 17, 16, 30, 23, 763, DateTimeKind.Local).AddTicks(1205), null, null, null, null, "draft" },
                    { 79, null, new DateTime(2022, 8, 13, 3, 58, 5, 137, DateTimeKind.Local).AddTicks(6867), new DateTime(2022, 12, 25, 21, 55, 23, 141, DateTimeKind.Local).AddTicks(4524), null, null, null, null, "draft" },
                    { 80, null, new DateTime(2022, 12, 12, 21, 36, 42, 873, DateTimeKind.Local).AddTicks(3787), new DateTime(2022, 10, 6, 4, 6, 54, 352, DateTimeKind.Local).AddTicks(9627), null, null, null, null, "draft" },
                    { 81, null, new DateTime(2023, 2, 14, 15, 55, 14, 599, DateTimeKind.Local).AddTicks(3454), new DateTime(2022, 4, 21, 15, 35, 11, 177, DateTimeKind.Local).AddTicks(7091), null, null, null, null, "draft" },
                    { 82, null, new DateTime(2022, 6, 4, 2, 3, 25, 404, DateTimeKind.Local).AddTicks(1307), new DateTime(2023, 3, 28, 14, 40, 26, 638, DateTimeKind.Local).AddTicks(8150), null, null, null, null, "draft" },
                    { 83, null, new DateTime(2022, 12, 10, 10, 2, 10, 477, DateTimeKind.Local).AddTicks(1456), new DateTime(2022, 6, 21, 13, 8, 38, 634, DateTimeKind.Local).AddTicks(4905), null, null, null, null, "draft" },
                    { 84, null, new DateTime(2022, 8, 6, 6, 48, 21, 776, DateTimeKind.Local).AddTicks(4658), new DateTime(2022, 12, 26, 10, 59, 39, 543, DateTimeKind.Local).AddTicks(8557), null, null, null, null, "draft" },
                    { 85, null, new DateTime(2022, 6, 11, 5, 53, 41, 509, DateTimeKind.Local).AddTicks(6869), new DateTime(2022, 6, 4, 2, 52, 42, 497, DateTimeKind.Local).AddTicks(5298), null, null, null, null, "draft" },
                    { 86, null, new DateTime(2022, 10, 29, 1, 40, 19, 63, DateTimeKind.Local).AddTicks(708), new DateTime(2023, 1, 3, 12, 15, 47, 361, DateTimeKind.Local).AddTicks(1271), null, null, null, null, "draft" },
                    { 87, null, new DateTime(2022, 7, 23, 15, 27, 0, 501, DateTimeKind.Local).AddTicks(3964), new DateTime(2022, 7, 1, 6, 25, 10, 999, DateTimeKind.Local).AddTicks(3402), null, null, null, null, "draft" },
                    { 88, null, new DateTime(2022, 12, 1, 9, 20, 43, 241, DateTimeKind.Local).AddTicks(7151), new DateTime(2022, 7, 23, 14, 23, 59, 118, DateTimeKind.Local).AddTicks(9690), null, null, null, null, "draft" },
                    { 89, null, new DateTime(2022, 7, 2, 18, 38, 27, 500, DateTimeKind.Local).AddTicks(3322), new DateTime(2022, 10, 15, 17, 29, 57, 299, DateTimeKind.Local).AddTicks(3294), null, null, null, null, "draft" },
                    { 90, null, new DateTime(2023, 3, 22, 1, 13, 32, 805, DateTimeKind.Local).AddTicks(7221), new DateTime(2022, 12, 16, 21, 7, 37, 471, DateTimeKind.Local).AddTicks(1445), null, null, null, null, "draft" },
                    { 91, null, new DateTime(2022, 11, 29, 11, 15, 34, 481, DateTimeKind.Local).AddTicks(9148), new DateTime(2022, 5, 28, 5, 29, 34, 481, DateTimeKind.Local).AddTicks(2519), null, null, null, null, "draft" },
                    { 92, null, new DateTime(2023, 4, 3, 6, 20, 14, 490, DateTimeKind.Local).AddTicks(5139), new DateTime(2022, 7, 28, 22, 38, 50, 497, DateTimeKind.Local).AddTicks(679), null, null, null, null, "draft" },
                    { 93, null, new DateTime(2022, 5, 3, 13, 54, 47, 996, DateTimeKind.Local).AddTicks(7888), new DateTime(2022, 6, 9, 0, 26, 19, 133, DateTimeKind.Local).AddTicks(9908), null, null, null, null, "draft" },
                    { 94, null, new DateTime(2022, 12, 29, 8, 36, 48, 199, DateTimeKind.Local).AddTicks(433), new DateTime(2022, 6, 4, 21, 27, 39, 930, DateTimeKind.Local).AddTicks(9331), null, null, null, null, "draft" },
                    { 95, null, new DateTime(2022, 8, 27, 3, 44, 20, 103, DateTimeKind.Local).AddTicks(287), new DateTime(2022, 11, 20, 15, 20, 33, 447, DateTimeKind.Local).AddTicks(3789), null, null, null, null, "draft" },
                    { 96, null, new DateTime(2022, 11, 10, 9, 59, 38, 298, DateTimeKind.Local).AddTicks(9447), new DateTime(2022, 10, 7, 3, 26, 28, 289, DateTimeKind.Local).AddTicks(6111), null, null, null, null, "draft" },
                    { 97, null, new DateTime(2022, 12, 14, 14, 30, 38, 551, DateTimeKind.Local).AddTicks(8146), new DateTime(2022, 12, 2, 16, 38, 36, 596, DateTimeKind.Local).AddTicks(303), null, null, null, null, "draft" },
                    { 98, null, new DateTime(2022, 6, 2, 9, 2, 36, 883, DateTimeKind.Local).AddTicks(6662), new DateTime(2022, 12, 21, 22, 53, 45, 879, DateTimeKind.Local).AddTicks(5826), null, null, null, null, "draft" },
                    { 99, null, new DateTime(2022, 12, 20, 19, 15, 36, 964, DateTimeKind.Local).AddTicks(5329), new DateTime(2022, 8, 12, 7, 52, 11, 2, DateTimeKind.Local).AddTicks(2614), null, null, null, null, "draft" },
                    { 100, null, new DateTime(2022, 6, 22, 22, 52, 31, 867, DateTimeKind.Local).AddTicks(8750), new DateTime(2023, 1, 15, 18, 11, 25, 550, DateTimeKind.Local).AddTicks(8217), null, null, null, null, "draft" },
                    { 101, null, new DateTime(2022, 4, 27, 0, 0, 25, 791, DateTimeKind.Local).AddTicks(2240), new DateTime(2022, 12, 22, 2, 40, 26, 905, DateTimeKind.Local).AddTicks(5972), null, null, null, null, "draft" },
                    { 102, null, new DateTime(2022, 11, 30, 19, 14, 13, 844, DateTimeKind.Local).AddTicks(2858), new DateTime(2023, 2, 21, 14, 41, 59, 763, DateTimeKind.Local).AddTicks(4527), null, null, null, null, "draft" },
                    { 103, null, new DateTime(2023, 3, 15, 8, 50, 8, 156, DateTimeKind.Local).AddTicks(65), new DateTime(2022, 5, 7, 1, 1, 55, 297, DateTimeKind.Local).AddTicks(6687), null, null, null, null, "draft" },
                    { 104, null, new DateTime(2022, 10, 25, 6, 21, 52, 433, DateTimeKind.Local).AddTicks(8656), new DateTime(2022, 6, 23, 14, 55, 2, 646, DateTimeKind.Local).AddTicks(1926), null, null, null, null, "draft" },
                    { 105, null, new DateTime(2023, 1, 28, 23, 57, 9, 25, DateTimeKind.Local).AddTicks(8888), new DateTime(2022, 11, 9, 6, 33, 41, 435, DateTimeKind.Local).AddTicks(8551), null, null, null, null, "draft" },
                    { 106, null, new DateTime(2022, 7, 5, 7, 42, 2, 245, DateTimeKind.Local).AddTicks(8011), new DateTime(2023, 2, 14, 20, 18, 13, 821, DateTimeKind.Local).AddTicks(3703), null, null, null, null, "draft" },
                    { 107, null, new DateTime(2023, 1, 23, 6, 31, 56, 318, DateTimeKind.Local).AddTicks(7438), new DateTime(2023, 4, 15, 10, 19, 11, 385, DateTimeKind.Local).AddTicks(2478), null, null, null, null, "draft" },
                    { 108, null, new DateTime(2023, 2, 24, 2, 41, 25, 854, DateTimeKind.Local).AddTicks(650), new DateTime(2023, 1, 6, 20, 15, 46, 101, DateTimeKind.Local).AddTicks(1107), null, null, null, null, "draft" },
                    { 109, null, new DateTime(2022, 5, 7, 19, 5, 2, 670, DateTimeKind.Local).AddTicks(2131), new DateTime(2023, 2, 23, 13, 14, 40, 890, DateTimeKind.Local).AddTicks(807), null, null, null, null, "draft" },
                    { 110, null, new DateTime(2023, 3, 14, 10, 35, 44, 625, DateTimeKind.Local).AddTicks(448), new DateTime(2022, 10, 20, 19, 25, 57, 326, DateTimeKind.Local).AddTicks(1733), null, null, null, null, "draft" },
                    { 111, null, new DateTime(2022, 10, 10, 14, 21, 56, 418, DateTimeKind.Local).AddTicks(4665), new DateTime(2022, 6, 20, 19, 10, 47, 828, DateTimeKind.Local).AddTicks(5520), null, null, null, null, "draft" },
                    { 112, null, new DateTime(2022, 8, 18, 17, 5, 25, 423, DateTimeKind.Local).AddTicks(8469), new DateTime(2022, 11, 8, 0, 23, 14, 45, DateTimeKind.Local).AddTicks(3280), null, null, null, null, "draft" },
                    { 113, null, new DateTime(2022, 11, 11, 2, 43, 10, 181, DateTimeKind.Local).AddTicks(6058), new DateTime(2022, 5, 11, 8, 3, 56, 756, DateTimeKind.Local).AddTicks(4803), null, null, null, null, "draft" },
                    { 114, null, new DateTime(2022, 5, 9, 7, 35, 14, 792, DateTimeKind.Local).AddTicks(3337), new DateTime(2022, 12, 8, 8, 38, 29, 888, DateTimeKind.Local).AddTicks(3875), null, null, null, null, "draft" },
                    { 115, null, new DateTime(2022, 5, 18, 7, 12, 40, 98, DateTimeKind.Local).AddTicks(6960), new DateTime(2023, 3, 29, 20, 17, 3, 345, DateTimeKind.Local).AddTicks(1546), null, null, null, null, "draft" },
                    { 116, null, new DateTime(2022, 11, 20, 4, 58, 28, 137, DateTimeKind.Local).AddTicks(4587), new DateTime(2023, 3, 9, 20, 36, 22, 481, DateTimeKind.Local).AddTicks(936), null, null, null, null, "draft" },
                    { 117, null, new DateTime(2022, 8, 12, 4, 27, 31, 414, DateTimeKind.Local).AddTicks(4778), new DateTime(2022, 6, 23, 16, 52, 13, 237, DateTimeKind.Local).AddTicks(9239), null, null, null, null, "draft" },
                    { 118, null, new DateTime(2022, 12, 9, 6, 57, 17, 662, DateTimeKind.Local).AddTicks(9446), new DateTime(2023, 3, 27, 18, 25, 13, 559, DateTimeKind.Local).AddTicks(3390), null, null, null, null, "draft" },
                    { 119, null, new DateTime(2022, 10, 14, 20, 5, 26, 619, DateTimeKind.Local).AddTicks(9881), new DateTime(2022, 5, 30, 1, 28, 20, 710, DateTimeKind.Local).AddTicks(832), null, null, null, null, "draft" },
                    { 120, null, new DateTime(2022, 9, 1, 23, 38, 48, 324, DateTimeKind.Local).AddTicks(841), new DateTime(2023, 4, 15, 22, 42, 58, 682, DateTimeKind.Local).AddTicks(1427), null, null, null, null, "draft" },
                    { 121, null, new DateTime(2022, 12, 2, 3, 54, 32, 683, DateTimeKind.Local).AddTicks(1486), new DateTime(2022, 10, 25, 3, 31, 51, 535, DateTimeKind.Local).AddTicks(8741), null, null, null, null, "draft" },
                    { 122, null, new DateTime(2022, 8, 24, 7, 20, 36, 888, DateTimeKind.Local).AddTicks(684), new DateTime(2023, 2, 4, 7, 0, 44, 650, DateTimeKind.Local).AddTicks(1977), null, null, null, null, "draft" },
                    { 123, null, new DateTime(2022, 9, 4, 17, 28, 37, 184, DateTimeKind.Local).AddTicks(6024), new DateTime(2023, 1, 12, 23, 31, 30, 460, DateTimeKind.Local).AddTicks(5992), null, null, null, null, "draft" },
                    { 124, null, new DateTime(2023, 1, 1, 6, 44, 37, 953, DateTimeKind.Local).AddTicks(8927), new DateTime(2022, 12, 18, 14, 1, 33, 149, DateTimeKind.Local).AddTicks(5924), null, null, null, null, "draft" },
                    { 125, null, new DateTime(2023, 1, 25, 23, 47, 16, 724, DateTimeKind.Local).AddTicks(9914), new DateTime(2022, 9, 12, 22, 36, 56, 765, DateTimeKind.Local).AddTicks(5817), null, null, null, null, "draft" },
                    { 126, null, new DateTime(2022, 12, 3, 13, 38, 49, 192, DateTimeKind.Local).AddTicks(3964), new DateTime(2023, 2, 13, 15, 51, 2, 57, DateTimeKind.Local).AddTicks(4791), null, null, null, null, "draft" },
                    { 127, null, new DateTime(2022, 9, 17, 7, 6, 32, 360, DateTimeKind.Local).AddTicks(2442), new DateTime(2022, 12, 20, 13, 16, 40, 524, DateTimeKind.Local).AddTicks(7292), null, null, null, null, "draft" },
                    { 128, null, new DateTime(2022, 7, 25, 13, 39, 35, 115, DateTimeKind.Local).AddTicks(3835), new DateTime(2023, 2, 23, 14, 39, 43, 945, DateTimeKind.Local).AddTicks(7030), null, null, null, null, "draft" },
                    { 129, null, new DateTime(2022, 8, 22, 19, 25, 7, 464, DateTimeKind.Local).AddTicks(7819), new DateTime(2022, 5, 12, 4, 41, 5, 781, DateTimeKind.Local).AddTicks(9897), null, null, null, null, "draft" },
                    { 130, null, new DateTime(2022, 7, 30, 21, 48, 55, 564, DateTimeKind.Local).AddTicks(8795), new DateTime(2023, 2, 21, 10, 36, 17, 382, DateTimeKind.Local).AddTicks(5587), null, null, null, null, "draft" },
                    { 131, null, new DateTime(2023, 4, 17, 3, 16, 46, 488, DateTimeKind.Local).AddTicks(3682), new DateTime(2023, 3, 6, 7, 33, 28, 528, DateTimeKind.Local).AddTicks(5116), null, null, null, null, "draft" },
                    { 132, null, new DateTime(2022, 5, 25, 17, 32, 28, 530, DateTimeKind.Local).AddTicks(5305), new DateTime(2023, 2, 18, 13, 30, 11, 663, DateTimeKind.Local).AddTicks(7683), null, null, null, null, "draft" },
                    { 133, null, new DateTime(2023, 4, 8, 11, 25, 19, 281, DateTimeKind.Local).AddTicks(4310), new DateTime(2022, 8, 14, 20, 55, 45, 747, DateTimeKind.Local).AddTicks(7424), null, null, null, null, "draft" },
                    { 134, null, new DateTime(2022, 10, 23, 1, 40, 48, 389, DateTimeKind.Local).AddTicks(9278), new DateTime(2022, 11, 18, 23, 29, 49, 63, DateTimeKind.Local).AddTicks(8554), null, null, null, null, "draft" },
                    { 135, null, new DateTime(2022, 8, 24, 13, 11, 59, 705, DateTimeKind.Local).AddTicks(3391), new DateTime(2023, 3, 18, 18, 6, 18, 277, DateTimeKind.Local).AddTicks(7622), null, null, null, null, "draft" },
                    { 136, null, new DateTime(2022, 7, 12, 10, 0, 25, 464, DateTimeKind.Local).AddTicks(1594), new DateTime(2023, 3, 28, 3, 26, 47, 943, DateTimeKind.Local).AddTicks(1667), null, null, null, null, "draft" },
                    { 137, null, new DateTime(2022, 10, 10, 23, 25, 58, 549, DateTimeKind.Local).AddTicks(341), new DateTime(2023, 3, 17, 21, 42, 51, 925, DateTimeKind.Local).AddTicks(9396), null, null, null, null, "draft" },
                    { 138, null, new DateTime(2023, 3, 8, 1, 21, 30, 626, DateTimeKind.Local).AddTicks(629), new DateTime(2023, 4, 4, 20, 40, 10, 865, DateTimeKind.Local).AddTicks(6306), null, null, null, null, "draft" },
                    { 139, null, new DateTime(2023, 2, 13, 21, 40, 16, 923, DateTimeKind.Local).AddTicks(5224), new DateTime(2022, 10, 31, 19, 54, 46, 756, DateTimeKind.Local).AddTicks(6882), null, null, null, null, "draft" },
                    { 140, null, new DateTime(2022, 6, 22, 16, 44, 42, 843, DateTimeKind.Local).AddTicks(7651), new DateTime(2023, 2, 15, 13, 1, 45, 704, DateTimeKind.Local).AddTicks(462), null, null, null, null, "draft" },
                    { 141, null, new DateTime(2022, 8, 27, 11, 9, 24, 785, DateTimeKind.Local).AddTicks(6278), new DateTime(2022, 9, 8, 3, 23, 47, 625, DateTimeKind.Local).AddTicks(7816), null, null, null, null, "draft" },
                    { 142, null, new DateTime(2023, 3, 1, 18, 41, 19, 146, DateTimeKind.Local).AddTicks(4369), new DateTime(2022, 12, 22, 18, 25, 49, 316, DateTimeKind.Local).AddTicks(1553), null, null, null, null, "draft" },
                    { 143, null, new DateTime(2022, 8, 13, 16, 28, 20, 135, DateTimeKind.Local).AddTicks(7999), new DateTime(2023, 1, 23, 22, 57, 32, 63, DateTimeKind.Local).AddTicks(213), null, null, null, null, "draft" },
                    { 144, null, new DateTime(2022, 10, 9, 23, 19, 56, 103, DateTimeKind.Local).AddTicks(8915), new DateTime(2022, 12, 10, 1, 0, 56, 872, DateTimeKind.Local).AddTicks(7910), null, null, null, null, "draft" },
                    { 145, null, new DateTime(2023, 3, 18, 13, 2, 44, 105, DateTimeKind.Local).AddTicks(5835), new DateTime(2023, 2, 2, 2, 7, 39, 700, DateTimeKind.Local).AddTicks(2874), null, null, null, null, "draft" },
                    { 146, null, new DateTime(2022, 11, 22, 8, 50, 12, 77, DateTimeKind.Local).AddTicks(6035), new DateTime(2022, 9, 22, 1, 14, 26, 821, DateTimeKind.Local).AddTicks(449), null, null, null, null, "draft" },
                    { 147, null, new DateTime(2023, 2, 16, 13, 29, 31, 128, DateTimeKind.Local).AddTicks(2511), new DateTime(2022, 10, 28, 22, 52, 36, 924, DateTimeKind.Local).AddTicks(5725), null, null, null, null, "draft" },
                    { 148, null, new DateTime(2023, 4, 18, 5, 16, 18, 176, DateTimeKind.Local).AddTicks(8224), new DateTime(2023, 1, 15, 6, 11, 10, 137, DateTimeKind.Local).AddTicks(6850), null, null, null, null, "draft" },
                    { 149, null, new DateTime(2022, 9, 18, 19, 49, 28, 988, DateTimeKind.Local).AddTicks(3922), new DateTime(2022, 10, 23, 3, 40, 31, 207, DateTimeKind.Local).AddTicks(3489), null, null, null, null, "draft" },
                    { 150, null, new DateTime(2023, 2, 15, 5, 25, 31, 351, DateTimeKind.Local).AddTicks(8160), new DateTime(2022, 5, 10, 6, 22, 57, 419, DateTimeKind.Local).AddTicks(9096), null, null, null, null, "draft" }
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "CreateDate", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 9, 23, 43, 3, 913, DateTimeKind.Local).AddTicks(4985), new DateTime(2022, 10, 30, 22, 49, 17, 177, DateTimeKind.Local).AddTicks(4372), "Chrysler" },
                    { 2, new DateTime(2022, 8, 22, 9, 58, 10, 143, DateTimeKind.Local).AddTicks(4451), new DateTime(2022, 11, 12, 10, 39, 33, 863, DateTimeKind.Local).AddTicks(2681), "Polestar" },
                    { 3, new DateTime(2022, 5, 9, 21, 36, 5, 237, DateTimeKind.Local).AddTicks(9997), new DateTime(2023, 3, 13, 10, 44, 27, 98, DateTimeKind.Local).AddTicks(5735), "Ford" },
                    { 4, new DateTime(2023, 4, 8, 22, 58, 35, 452, DateTimeKind.Local).AddTicks(2312), new DateTime(2023, 1, 18, 21, 5, 58, 844, DateTimeKind.Local).AddTicks(5394), "Mazda" },
                    { 5, new DateTime(2022, 4, 23, 3, 28, 29, 208, DateTimeKind.Local).AddTicks(3792), new DateTime(2022, 8, 13, 10, 26, 11, 301, DateTimeKind.Local).AddTicks(4210), "Fiat" },
                    { 6, new DateTime(2023, 1, 6, 5, 7, 37, 170, DateTimeKind.Local).AddTicks(8504), new DateTime(2022, 9, 6, 19, 24, 1, 646, DateTimeKind.Local).AddTicks(6987), "Mazda" },
                    { 7, new DateTime(2022, 8, 6, 6, 5, 46, 21, DateTimeKind.Local).AddTicks(6136), new DateTime(2022, 5, 7, 17, 46, 32, 876, DateTimeKind.Local).AddTicks(3290), "Mini" },
                    { 8, new DateTime(2023, 2, 19, 16, 17, 16, 969, DateTimeKind.Local).AddTicks(3088), new DateTime(2022, 11, 30, 23, 46, 6, 71, DateTimeKind.Local).AddTicks(3758), "Bentley" },
                    { 9, new DateTime(2023, 2, 16, 13, 18, 9, 837, DateTimeKind.Local).AddTicks(5356), new DateTime(2022, 7, 3, 16, 17, 25, 652, DateTimeKind.Local).AddTicks(5059), "Porsche" },
                    { 10, new DateTime(2022, 6, 23, 0, 6, 21, 401, DateTimeKind.Local).AddTicks(2177), new DateTime(2022, 5, 30, 20, 21, 42, 545, DateTimeKind.Local).AddTicks(5750), "Ferrari" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreateDate", "Description", "ImageId", "ModifiedDate", "Name" },
                values: new object[] { 10, new DateTime(2022, 6, 23, 0, 6, 21, 402, DateTimeKind.Local).AddTicks(7509), null, null, new DateTime(2022, 5, 30, 20, 21, 42, 547, DateTimeKind.Local).AddTicks(1082), "Home" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CreateDate", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 9, 23, 43, 3, 911, DateTimeKind.Local).AddTicks(8328), new DateTime(2022, 10, 30, 22, 49, 17, 175, DateTimeKind.Local).AddTicks(7735), "Ecuador" },
                    { 2, new DateTime(2022, 8, 22, 9, 58, 10, 141, DateTimeKind.Local).AddTicks(7817), new DateTime(2022, 11, 12, 10, 39, 33, 861, DateTimeKind.Local).AddTicks(6046), "Samoa" },
                    { 3, new DateTime(2022, 5, 9, 21, 36, 5, 236, DateTimeKind.Local).AddTicks(3359), new DateTime(2023, 3, 13, 10, 44, 27, 96, DateTimeKind.Local).AddTicks(9096), "Guatemala" },
                    { 4, new DateTime(2023, 4, 8, 22, 58, 35, 450, DateTimeKind.Local).AddTicks(5673), new DateTime(2023, 1, 18, 21, 5, 58, 842, DateTimeKind.Local).AddTicks(8754), "Nicaragua" },
                    { 5, new DateTime(2022, 4, 23, 3, 28, 29, 206, DateTimeKind.Local).AddTicks(7151), new DateTime(2022, 8, 13, 10, 26, 11, 299, DateTimeKind.Local).AddTicks(7570), "Germany" },
                    { 6, new DateTime(2023, 1, 6, 5, 7, 37, 169, DateTimeKind.Local).AddTicks(1864), new DateTime(2022, 9, 6, 19, 24, 1, 645, DateTimeKind.Local).AddTicks(347), "Niue" },
                    { 7, new DateTime(2022, 8, 6, 6, 5, 46, 19, DateTimeKind.Local).AddTicks(9496), new DateTime(2022, 5, 7, 17, 46, 32, 874, DateTimeKind.Local).AddTicks(6650), "Philippines" },
                    { 8, new DateTime(2023, 2, 19, 16, 17, 16, 967, DateTimeKind.Local).AddTicks(6449), new DateTime(2022, 11, 30, 23, 46, 6, 69, DateTimeKind.Local).AddTicks(7119), "Benin" },
                    { 9, new DateTime(2023, 2, 16, 13, 18, 9, 835, DateTimeKind.Local).AddTicks(8716), new DateTime(2022, 7, 3, 16, 17, 25, 650, DateTimeKind.Local).AddTicks(8419), "Seychelles" },
                    { 10, new DateTime(2022, 6, 23, 0, 6, 21, 399, DateTimeKind.Local).AddTicks(5536), new DateTime(2022, 5, 30, 20, 21, 42, 543, DateTimeKind.Local).AddTicks(9109), "French Southern Territories" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "fab4fac1-c546-41de-aebc-a14da6895711", "b74ddd14-6340-4840-95c2-db12554843e5" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CreateDate", "Description", "Featured", "ModifiedDate", "Name", "Price", "SKU", "active" },
                values: new object[,]
                {
                    { 1, 3, new DateTime(2022, 12, 23, 13, 40, 12, 868, DateTimeKind.Local).AddTicks(6830), null, false, new DateTime(2022, 4, 23, 3, 28, 29, 211, DateTimeKind.Local).AddTicks(5105), "Gorgeous Wooden Shoes", 55m, "64391601", true },
                    { 2, 2, new DateTime(2022, 7, 3, 16, 17, 25, 655, DateTimeKind.Local).AddTicks(6475), null, false, new DateTime(2022, 12, 28, 6, 30, 56, 135, DateTimeKind.Local).AddTicks(3367), "Handcrafted Metal Ball", 54m, "77901378", true },
                    { 3, 6, new DateTime(2023, 1, 9, 19, 53, 11, 788, DateTimeKind.Local).AddTicks(165), null, false, new DateTime(2022, 4, 21, 16, 10, 44, 288, DateTimeKind.Local).AddTicks(5313), "Licensed Fresh Towels", 55m, "60988058", true },
                    { 4, 7, new DateTime(2022, 11, 26, 4, 22, 53, 186, DateTimeKind.Local).AddTicks(4326), null, false, new DateTime(2023, 2, 21, 17, 34, 52, 636, DateTimeKind.Local).AddTicks(6533), "Handcrafted Cotton Table", 54m, "64235134", true },
                    { 5, 4, new DateTime(2022, 4, 20, 4, 18, 33, 789, DateTimeKind.Local).AddTicks(5333), null, false, new DateTime(2022, 6, 3, 17, 38, 18, 715, DateTimeKind.Local).AddTicks(6441), "Tasty Steel Chips", 52m, "60120359", true },
                    { 6, 4, new DateTime(2023, 3, 27, 12, 29, 59, 420, DateTimeKind.Local).AddTicks(5317), null, false, new DateTime(2022, 10, 30, 0, 37, 36, 316, DateTimeKind.Local).AddTicks(4448), "Licensed Concrete Computer", 49m, "49479140", true },
                    { 7, 3, new DateTime(2022, 6, 4, 18, 41, 0, 451, DateTimeKind.Local).AddTicks(7628), null, false, new DateTime(2022, 10, 27, 13, 22, 52, 193, DateTimeKind.Local).AddTicks(9945), "Fantastic Cotton Pants", 56m, "68870089", true },
                    { 8, 5, new DateTime(2022, 7, 18, 13, 35, 22, 528, DateTimeKind.Local).AddTicks(1704), null, false, new DateTime(2023, 2, 14, 8, 3, 36, 24, DateTimeKind.Local).AddTicks(1055), "Incredible Wooden Keyboard", 51m, "43530120", true },
                    { 9, 2, new DateTime(2023, 4, 12, 8, 16, 13, 70, DateTimeKind.Local).AddTicks(9383), null, false, new DateTime(2023, 4, 11, 5, 15, 28, 963, DateTimeKind.Local).AddTicks(4681), "Rustic Fresh Chips", 51m, "96869567", true },
                    { 10, 7, new DateTime(2022, 5, 21, 10, 55, 24, 964, DateTimeKind.Local).AddTicks(972), null, false, new DateTime(2023, 3, 30, 15, 7, 45, 498, DateTimeKind.Local).AddTicks(1151), "Rustic Steel Gloves", 50m, "09489189", true },
                    { 11, 3, new DateTime(2022, 9, 4, 11, 30, 7, 660, DateTimeKind.Local).AddTicks(6304), null, false, new DateTime(2022, 9, 11, 23, 27, 46, 282, DateTimeKind.Local).AddTicks(7011), "Incredible Concrete Fish", 49m, "06620523", true },
                    { 12, 9, new DateTime(2022, 8, 6, 6, 48, 21, 774, DateTimeKind.Local).AddTicks(5739), null, false, new DateTime(2022, 12, 26, 10, 59, 39, 541, DateTimeKind.Local).AddTicks(9638), "Intelligent Rubber Chicken", 51m, "35198031", true },
                    { 13, 4, new DateTime(2022, 11, 29, 11, 15, 34, 480, DateTimeKind.Local).AddTicks(185), null, true, new DateTime(2022, 5, 28, 5, 29, 34, 479, DateTimeKind.Local).AddTicks(3557), "Refined Fresh Shoes", 50m, "78377509", true },
                    { 14, 4, new DateTime(2022, 6, 2, 9, 2, 36, 881, DateTimeKind.Local).AddTicks(7716), null, false, new DateTime(2022, 12, 21, 22, 53, 45, 877, DateTimeKind.Local).AddTicks(6881), "Small Metal Chips", 56m, "38644535", true },
                    { 15, 9, new DateTime(2023, 1, 28, 23, 57, 9, 23, DateTimeKind.Local).AddTicks(9930), null, false, new DateTime(2022, 11, 9, 6, 33, 41, 433, DateTimeKind.Local).AddTicks(9593), "Incredible Metal Bacon", 50m, "93310949", true },
                    { 16, 9, new DateTime(2022, 8, 18, 17, 5, 25, 421, DateTimeKind.Local).AddTicks(9499), null, false, new DateTime(2022, 11, 8, 0, 23, 14, 43, DateTimeKind.Local).AddTicks(4310), "Licensed Wooden Bike", 49m, "12910458", true },
                    { 17, 1, new DateTime(2022, 10, 14, 20, 5, 26, 618, DateTimeKind.Local).AddTicks(898), null, false, new DateTime(2022, 5, 30, 1, 28, 20, 708, DateTimeKind.Local).AddTicks(1851), "Practical Frozen Sausages", 51m, "90416835", true },
                    { 18, 6, new DateTime(2022, 12, 3, 13, 38, 49, 190, DateTimeKind.Local).AddTicks(4970), null, false, new DateTime(2023, 2, 13, 15, 51, 2, 55, DateTimeKind.Local).AddTicks(5797), "Generic Steel Shirt", 52m, "62622325", true },
                    { 19, 2, new DateTime(2023, 4, 8, 11, 25, 19, 279, DateTimeKind.Local).AddTicks(5274), null, false, new DateTime(2022, 8, 14, 20, 55, 45, 745, DateTimeKind.Local).AddTicks(8388), "Awesome Plastic Fish", 49m, "69710193", true },
                    { 20, 5, new DateTime(2022, 6, 22, 16, 44, 42, 841, DateTimeKind.Local).AddTicks(8601), null, false, new DateTime(2023, 2, 15, 13, 1, 45, 702, DateTimeKind.Local).AddTicks(1414), "Sleek Cotton Tuna", 56m, "70501018", true },
                    { 21, 6, new DateTime(2023, 2, 16, 13, 29, 31, 126, DateTimeKind.Local).AddTicks(3477), null, false, new DateTime(2022, 10, 28, 22, 52, 36, 922, DateTimeKind.Local).AddTicks(6693), "Generic Rubber Keyboard", 51m, "62530248", true },
                    { 22, 4, new DateTime(2022, 8, 23, 2, 15, 9, 489, DateTimeKind.Local).AddTicks(5927), null, false, new DateTime(2022, 10, 19, 19, 13, 46, 415, DateTimeKind.Local).AddTicks(4526), "Small Concrete Towels", 52m, "19786186", true },
                    { 23, 8, new DateTime(2023, 2, 22, 7, 25, 55, 624, DateTimeKind.Local).AddTicks(9992), null, false, new DateTime(2023, 3, 2, 10, 29, 57, 498, DateTimeKind.Local).AddTicks(2854), "Intelligent Metal Chips", 49m, "15539540", true },
                    { 24, 9, new DateTime(2022, 11, 25, 15, 11, 3, 631, DateTimeKind.Local).AddTicks(4767), null, false, new DateTime(2022, 7, 15, 3, 54, 35, 893, DateTimeKind.Local).AddTicks(6922), "Incredible Cotton Chicken", 49m, "80084624", true },
                    { 25, 7, new DateTime(2022, 5, 3, 23, 25, 44, 325, DateTimeKind.Local).AddTicks(7448), null, false, new DateTime(2022, 9, 9, 5, 23, 19, 312, DateTimeKind.Local).AddTicks(3393), "Unbranded Frozen Shoes", 51m, "50132249", true },
                    { 26, 7, new DateTime(2022, 11, 20, 2, 47, 12, 666, DateTimeKind.Local).AddTicks(3420), null, false, new DateTime(2022, 12, 11, 2, 34, 55, 391, DateTimeKind.Local).AddTicks(4434), "Gorgeous Steel Chair", 51m, "76524646", true },
                    { 27, 2, new DateTime(2022, 4, 24, 7, 14, 16, 507, DateTimeKind.Local).AddTicks(2199), null, false, new DateTime(2022, 5, 13, 10, 3, 57, 66, DateTimeKind.Local).AddTicks(6500), "Gorgeous Plastic Salad", 50m, "17490122", true },
                    { 28, 8, new DateTime(2023, 2, 2, 7, 6, 51, 961, DateTimeKind.Local).AddTicks(9378), null, false, new DateTime(2022, 8, 10, 12, 49, 0, 740, DateTimeKind.Local).AddTicks(4396), "Intelligent Granite Fish", 50m, "04546900", true },
                    { 29, 3, new DateTime(2023, 2, 25, 22, 14, 28, 648, DateTimeKind.Local).AddTicks(2473), null, false, new DateTime(2023, 1, 9, 7, 37, 6, 87, DateTimeKind.Local).AddTicks(8127), "Awesome Fresh Sausages", 57m, "67193240", true },
                    { 30, 10, new DateTime(2022, 7, 13, 14, 53, 29, 675, DateTimeKind.Local).AddTicks(6401), null, false, new DateTime(2022, 7, 7, 12, 0, 50, 267, DateTimeKind.Local).AddTicks(4119), "Unbranded Fresh Keyboard", 54m, "66098157", true },
                    { 31, 2, new DateTime(2022, 7, 9, 15, 59, 25, 566, DateTimeKind.Local).AddTicks(3993), null, false, new DateTime(2023, 1, 15, 21, 17, 53, 902, DateTimeKind.Local).AddTicks(1121), "Generic Frozen Keyboard", 51m, "57421254", true },
                    { 32, 6, new DateTime(2022, 8, 22, 10, 50, 0, 611, DateTimeKind.Local).AddTicks(2475), null, false, new DateTime(2022, 10, 5, 5, 56, 57, 16, DateTimeKind.Local).AddTicks(8936), "Rustic Granite Bacon", 56m, "33577401", true },
                    { 33, 4, new DateTime(2022, 6, 28, 4, 40, 33, 890, DateTimeKind.Local).AddTicks(9994), null, false, new DateTime(2022, 8, 8, 6, 36, 34, 780, DateTimeKind.Local).AddTicks(1427), "Tasty Soft Table", 54m, "03330067", true },
                    { 34, 5, new DateTime(2023, 1, 18, 5, 48, 8, 789, DateTimeKind.Local).AddTicks(4292), null, false, new DateTime(2022, 6, 27, 10, 40, 18, 319, DateTimeKind.Local).AddTicks(3818), "Handmade Frozen Keyboard", 52m, "87833669", true },
                    { 35, 5, new DateTime(2022, 5, 22, 22, 47, 57, 799, DateTimeKind.Local).AddTicks(2305), null, false, new DateTime(2022, 6, 21, 16, 18, 34, 677, DateTimeKind.Local).AddTicks(994), "Intelligent Metal Gloves", 57m, "19237817", true },
                    { 36, 9, new DateTime(2022, 8, 7, 14, 36, 6, 313, DateTimeKind.Local).AddTicks(9921), null, false, new DateTime(2022, 9, 20, 8, 18, 21, 882, DateTimeKind.Local).AddTicks(5799), "Practical Metal Bike", 57m, "58082676", true },
                    { 37, 9, new DateTime(2022, 11, 10, 13, 13, 54, 429, DateTimeKind.Local).AddTicks(2579), null, false, new DateTime(2022, 12, 15, 4, 16, 26, 308, DateTimeKind.Local).AddTicks(412), "Practical Soft Car", 53m, "15037725", true },
                    { 38, 5, new DateTime(2022, 7, 23, 5, 30, 46, 288, DateTimeKind.Local).AddTicks(798), null, false, new DateTime(2022, 11, 27, 7, 58, 16, 71, DateTimeKind.Local).AddTicks(9474), "Rustic Plastic Ball", 52m, "80964698", true },
                    { 39, 4, new DateTime(2022, 7, 26, 13, 9, 26, 940, DateTimeKind.Local).AddTicks(2308), null, false, new DateTime(2023, 4, 1, 22, 0, 25, 423, DateTimeKind.Local).AddTicks(7303), "Practical Metal Mouse", 50m, "26997629", true },
                    { 40, 7, new DateTime(2022, 9, 7, 4, 51, 44, 181, DateTimeKind.Local).AddTicks(6182), null, false, new DateTime(2022, 6, 30, 21, 19, 23, 149, DateTimeKind.Local).AddTicks(174), "Tasty Granite Fish", 54m, "37793302", true },
                    { 41, 8, new DateTime(2022, 11, 24, 4, 25, 2, 836, DateTimeKind.Local).AddTicks(6153), null, false, new DateTime(2023, 2, 23, 14, 8, 42, 872, DateTimeKind.Local).AddTicks(5113), "Fantastic Cotton Soap", 55m, "77915061", true },
                    { 42, 1, new DateTime(2022, 8, 15, 13, 55, 49, 533, DateTimeKind.Local).AddTicks(2768), null, false, new DateTime(2022, 10, 28, 12, 12, 48, 896, DateTimeKind.Local).AddTicks(5911), "Awesome Metal Keyboard", 52m, "29699308", true },
                    { 43, 1, new DateTime(2023, 3, 11, 19, 51, 26, 183, DateTimeKind.Local).AddTicks(1595), null, false, new DateTime(2022, 6, 13, 14, 6, 58, 703, DateTimeKind.Local).AddTicks(4996), "Incredible Fresh Bike", 53m, "01539554", true },
                    { 44, 7, new DateTime(2023, 3, 7, 5, 29, 19, 779, DateTimeKind.Local).AddTicks(2590), null, false, new DateTime(2022, 11, 3, 18, 23, 45, 713, DateTimeKind.Local).AddTicks(449), "Tasty Metal Chips", 54m, "35361541", true },
                    { 45, 3, new DateTime(2022, 9, 24, 23, 12, 20, 873, DateTimeKind.Local).AddTicks(2115), null, false, new DateTime(2023, 1, 15, 10, 21, 57, 320, DateTimeKind.Local).AddTicks(6101), "Sleek Plastic Chicken", 55m, "04767169", true },
                    { 46, 2, new DateTime(2023, 3, 20, 9, 20, 9, 292, DateTimeKind.Local).AddTicks(7257), null, false, new DateTime(2022, 8, 17, 17, 27, 34, 876, DateTimeKind.Local).AddTicks(131), "Handmade Rubber Sausages", 50m, "88923369", true },
                    { 47, 7, new DateTime(2023, 3, 23, 23, 32, 6, 938, DateTimeKind.Local).AddTicks(4012), null, false, new DateTime(2022, 12, 4, 15, 16, 0, 585, DateTimeKind.Local).AddTicks(1769), "Handmade Metal Keyboard", 51m, "01768701", true },
                    { 48, 3, new DateTime(2022, 10, 15, 18, 54, 18, 251, DateTimeKind.Local).AddTicks(175), null, false, new DateTime(2023, 1, 3, 0, 26, 51, 484, DateTimeKind.Local).AddTicks(2602), "Unbranded Fresh Sausages", 54m, "91955180", true },
                    { 49, 5, new DateTime(2022, 10, 31, 14, 47, 14, 669, DateTimeKind.Local).AddTicks(4988), null, false, new DateTime(2023, 4, 8, 13, 34, 11, 40, DateTimeKind.Local).AddTicks(5684), "Tasty Plastic Computer", 57m, "31809320", true },
                    { 50, 10, new DateTime(2022, 7, 28, 17, 11, 24, 599, DateTimeKind.Local).AddTicks(8567), null, false, new DateTime(2023, 2, 10, 8, 58, 17, 810, DateTimeKind.Local).AddTicks(4544), "Handmade Wooden Ball", 49m, "75344610", true },
                    { 51, 10, new DateTime(2022, 10, 16, 13, 5, 32, 258, DateTimeKind.Local).AddTicks(2304), null, false, new DateTime(2022, 6, 22, 16, 28, 32, 348, DateTimeKind.Local).AddTicks(1557), "Ergonomic Frozen Shoes", 55m, "65756027", true },
                    { 52, 10, new DateTime(2022, 4, 29, 17, 13, 27, 377, DateTimeKind.Local).AddTicks(5176), null, false, new DateTime(2022, 11, 2, 0, 29, 18, 763, DateTimeKind.Local).AddTicks(2637), "Unbranded Rubber Bacon", 53m, "69848759", true },
                    { 53, 10, new DateTime(2023, 1, 1, 11, 7, 54, 752, DateTimeKind.Local).AddTicks(1978), null, false, new DateTime(2023, 2, 14, 20, 38, 37, 308, DateTimeKind.Local).AddTicks(2630), "Unbranded Granite Bacon", 52m, "36998487", true },
                    { 54, 9, new DateTime(2022, 12, 14, 18, 23, 24, 911, DateTimeKind.Local).AddTicks(8701), null, false, new DateTime(2022, 8, 21, 16, 6, 27, 202, DateTimeKind.Local).AddTicks(4669), "Practical Wooden Sausages", 55m, "04577522", true },
                    { 55, 9, new DateTime(2022, 6, 10, 4, 18, 54, 835, DateTimeKind.Local).AddTicks(74), null, false, new DateTime(2022, 5, 16, 11, 57, 16, 889, DateTimeKind.Local).AddTicks(2275), "Ergonomic Soft Bike", 54m, "52622854", true },
                    { 56, 5, new DateTime(2022, 6, 3, 7, 13, 59, 389, DateTimeKind.Local).AddTicks(7464), null, false, new DateTime(2023, 3, 11, 20, 15, 13, 368, DateTimeKind.Local).AddTicks(7946), "Licensed Plastic Fish", 55m, "66077787", true },
                    { 57, 1, new DateTime(2022, 10, 6, 18, 33, 14, 239, DateTimeKind.Local).AddTicks(9255), null, false, new DateTime(2023, 1, 24, 11, 36, 58, 352, DateTimeKind.Local).AddTicks(4517), "Handcrafted Concrete Keyboard", 53m, "33802145", true },
                    { 58, 7, new DateTime(2022, 8, 26, 19, 34, 32, 613, DateTimeKind.Local).AddTicks(5416), null, false, new DateTime(2022, 12, 5, 23, 6, 9, 97, DateTimeKind.Local).AddTicks(2062), "Unbranded Wooden Bike", 50m, "66048510", true },
                    { 59, 6, new DateTime(2023, 4, 2, 20, 11, 59, 33, DateTimeKind.Local).AddTicks(5516), null, false, new DateTime(2022, 8, 6, 22, 39, 39, 696, DateTimeKind.Local).AddTicks(7407), "Tasty Granite Bacon", 53m, "35506041", true },
                    { 60, 3, new DateTime(2023, 3, 18, 12, 17, 25, 246, DateTimeKind.Local).AddTicks(7260), null, false, new DateTime(2023, 1, 22, 21, 44, 8, 777, DateTimeKind.Local).AddTicks(4530), "Small Rubber Ball", 53m, "17865685", true },
                    { 61, 10, new DateTime(2022, 8, 1, 15, 40, 29, 801, DateTimeKind.Local).AddTicks(5667), null, false, new DateTime(2022, 6, 5, 4, 12, 53, 511, DateTimeKind.Local).AddTicks(3029), "Practical Rubber Shirt", 54m, "65173367", true },
                    { 62, 9, new DateTime(2022, 10, 6, 9, 38, 9, 55, DateTimeKind.Local).AddTicks(1902), null, false, new DateTime(2023, 1, 3, 17, 7, 4, 339, DateTimeKind.Local).AddTicks(8832), "Practical Concrete Fish", 56m, "63413557", true },
                    { 63, 6, new DateTime(2022, 9, 15, 1, 31, 21, 719, DateTimeKind.Local).AddTicks(2148), null, false, new DateTime(2023, 1, 14, 15, 33, 31, 986, DateTimeKind.Local).AddTicks(8215), "Tasty Concrete Bike", 49m, "42506881", true },
                    { 64, 8, new DateTime(2022, 6, 19, 11, 49, 7, 896, DateTimeKind.Local).AddTicks(2193), null, false, new DateTime(2023, 1, 13, 12, 8, 2, 438, DateTimeKind.Local).AddTicks(44), "Incredible Fresh Chips", 49m, "09238763", true },
                    { 65, 5, new DateTime(2022, 12, 29, 0, 48, 16, 51, DateTimeKind.Local).AddTicks(2902), null, false, new DateTime(2022, 11, 30, 5, 58, 30, 662, DateTimeKind.Local).AddTicks(3824), "Gorgeous Soft Computer", 55m, "98811458", true },
                    { 66, 6, new DateTime(2023, 3, 27, 23, 25, 30, 391, DateTimeKind.Local).AddTicks(5254), null, false, new DateTime(2022, 8, 24, 4, 19, 6, 625, DateTimeKind.Local).AddTicks(9766), "Awesome Frozen Mouse", 56m, "71846477", true },
                    { 67, 8, new DateTime(2022, 11, 9, 4, 19, 3, 178, DateTimeKind.Local).AddTicks(4427), null, false, new DateTime(2023, 2, 4, 15, 59, 46, 601, DateTimeKind.Local).AddTicks(305), "Incredible Granite Towels", 54m, "43787050", true },
                    { 68, 7, new DateTime(2022, 12, 2, 10, 28, 25, 565, DateTimeKind.Local).AddTicks(3477), null, false, new DateTime(2022, 6, 10, 3, 29, 19, 223, DateTimeKind.Local).AddTicks(7592), "Handmade Granite Soap", 54m, "68795504", true },
                    { 69, 1, new DateTime(2022, 9, 15, 21, 7, 15, 197, DateTimeKind.Local).AddTicks(7809), null, false, new DateTime(2022, 7, 31, 16, 27, 10, 701, DateTimeKind.Local).AddTicks(9978), "Rustic Metal Chips", 52m, "71778891", true },
                    { 70, 3, new DateTime(2022, 5, 27, 23, 11, 23, 13, DateTimeKind.Local).AddTicks(333), null, false, new DateTime(2022, 12, 2, 21, 32, 37, 416, DateTimeKind.Local).AddTicks(4048), "Intelligent Wooden Hat", 57m, "76618192", true },
                    { 71, 3, new DateTime(2022, 11, 13, 10, 50, 24, 330, DateTimeKind.Local).AddTicks(6058), null, false, new DateTime(2023, 4, 14, 4, 55, 0, 680, DateTimeKind.Local).AddTicks(528), "Unbranded Steel Tuna", 55m, "99600105", true },
                    { 72, 7, new DateTime(2023, 2, 20, 13, 16, 34, 778, DateTimeKind.Local).AddTicks(9985), null, false, new DateTime(2023, 3, 29, 6, 15, 20, 584, DateTimeKind.Local).AddTicks(3919), "Generic Metal Tuna", 54m, "20740092", true },
                    { 73, 7, new DateTime(2023, 4, 6, 14, 42, 48, 90, DateTimeKind.Local).AddTicks(3124), null, false, new DateTime(2023, 2, 6, 22, 45, 39, 734, DateTimeKind.Local).AddTicks(7517), "Unbranded Fresh Shoes", 53m, "23882201", true },
                    { 74, 9, new DateTime(2022, 9, 4, 18, 18, 55, 307, DateTimeKind.Local).AddTicks(5782), null, false, new DateTime(2022, 11, 7, 18, 13, 30, 578, DateTimeKind.Local).AddTicks(5814), "Small Cotton Sausages", 52m, "26415291", true },
                    { 75, 1, new DateTime(2023, 1, 31, 14, 57, 27, 47, DateTimeKind.Local).AddTicks(1327), null, false, new DateTime(2022, 6, 28, 10, 43, 26, 408, DateTimeKind.Local).AddTicks(5690), "Small Granite Cheese", 50m, "76126406", true },
                    { 76, 5, new DateTime(2022, 9, 15, 1, 49, 8, 444, DateTimeKind.Local).AddTicks(5214), null, false, new DateTime(2022, 7, 4, 11, 13, 21, 322, DateTimeKind.Local).AddTicks(9173), "Sleek Cotton Towels", 53m, "05461547", true },
                    { 77, 5, new DateTime(2023, 3, 18, 17, 38, 30, 857, DateTimeKind.Local).AddTicks(517), null, false, new DateTime(2022, 7, 20, 23, 17, 58, 432, DateTimeKind.Local).AddTicks(4447), "Incredible Concrete Towels", 52m, "73764885", true },
                    { 78, 1, new DateTime(2022, 4, 22, 7, 26, 18, 656, DateTimeKind.Local).AddTicks(9595), null, false, new DateTime(2022, 11, 17, 18, 33, 50, 140, DateTimeKind.Local).AddTicks(2804), "Handmade Cotton Table", 50m, "46606389", true },
                    { 79, 9, new DateTime(2023, 4, 11, 17, 31, 36, 440, DateTimeKind.Local).AddTicks(9600), null, false, new DateTime(2022, 7, 6, 18, 2, 29, 195, DateTimeKind.Local).AddTicks(6674), "Fantastic Concrete Cheese", 51m, "03949528", true },
                    { 80, 10, new DateTime(2023, 2, 17, 6, 14, 43, 279, DateTimeKind.Local).AddTicks(559), null, false, new DateTime(2023, 1, 23, 18, 38, 9, 47, DateTimeKind.Local).AddTicks(9960), "Tasty Soft Fish", 53m, "47971202", true },
                    { 81, 8, new DateTime(2022, 6, 27, 11, 42, 27, 511, DateTimeKind.Local).AddTicks(1765), null, false, new DateTime(2023, 1, 4, 9, 40, 24, 15, DateTimeKind.Local).AddTicks(7125), "Awesome Concrete Towels", 55m, "33320533", true },
                    { 82, 3, new DateTime(2022, 10, 16, 12, 47, 45, 430, DateTimeKind.Local).AddTicks(3053), null, false, new DateTime(2022, 8, 17, 11, 55, 24, 501, DateTimeKind.Local).AddTicks(523), "Awesome Fresh Sausages", 54m, "68196257", true },
                    { 83, 7, new DateTime(2022, 10, 28, 19, 29, 31, 407, DateTimeKind.Local).AddTicks(8360), null, false, new DateTime(2022, 7, 20, 19, 14, 1, 417, DateTimeKind.Local).AddTicks(1047), "Ergonomic Rubber Gloves", 57m, "17860543", true },
                    { 84, 4, new DateTime(2023, 3, 5, 3, 31, 36, 846, DateTimeKind.Local).AddTicks(4538), null, false, new DateTime(2022, 9, 8, 8, 46, 2, 357, DateTimeKind.Local).AddTicks(1307), "Handcrafted Wooden Bike", 55m, "86132329", true },
                    { 85, 2, new DateTime(2022, 11, 19, 12, 26, 38, 920, DateTimeKind.Local).AddTicks(2668), null, false, new DateTime(2022, 6, 12, 21, 38, 57, 973, DateTimeKind.Local).AddTicks(4857), "Awesome Plastic Keyboard", 55m, "86142267", true },
                    { 86, 9, new DateTime(2022, 10, 16, 8, 15, 48, 219, DateTimeKind.Local).AddTicks(8834), null, false, new DateTime(2022, 7, 10, 12, 57, 58, 598, DateTimeKind.Local).AddTicks(262), "Licensed Cotton Computer", 57m, "33250830", true },
                    { 87, 9, new DateTime(2022, 9, 13, 21, 41, 34, 909, DateTimeKind.Local).AddTicks(8370), null, false, new DateTime(2023, 2, 10, 6, 54, 5, 976, DateTimeKind.Local).AddTicks(9518), "Incredible Frozen Bacon", 56m, "52164477", true },
                    { 88, 8, new DateTime(2022, 12, 13, 3, 34, 48, 780, DateTimeKind.Local).AddTicks(2086), null, true, new DateTime(2023, 3, 27, 2, 12, 44, 112, DateTimeKind.Local).AddTicks(1688), "Refined Frozen Computer", 55m, "23482395", true },
                    { 89, 2, new DateTime(2022, 7, 30, 18, 46, 5, 430, DateTimeKind.Local).AddTicks(6440), null, false, new DateTime(2023, 3, 7, 9, 6, 58, 235, DateTimeKind.Local).AddTicks(2726), "Gorgeous Concrete Chicken", 57m, "13134754", true },
                    { 90, 2, new DateTime(2023, 1, 4, 23, 55, 27, 24, DateTimeKind.Local).AddTicks(3646), null, false, new DateTime(2022, 11, 10, 0, 37, 41, 217, DateTimeKind.Local).AddTicks(9028), "Tasty Metal Mouse", 53m, "70617665", true },
                    { 91, 3, new DateTime(2022, 4, 23, 4, 7, 33, 672, DateTimeKind.Local).AddTicks(5228), null, false, new DateTime(2022, 10, 12, 0, 38, 46, 161, DateTimeKind.Local).AddTicks(1471), "Handcrafted Granite Pizza", 56m, "90417863", true },
                    { 92, 3, new DateTime(2022, 11, 10, 22, 42, 6, 948, DateTimeKind.Local).AddTicks(549), null, false, new DateTime(2023, 2, 13, 5, 59, 10, 222, DateTimeKind.Local).AddTicks(9302), "Practical Plastic Ball", 54m, "53851499", true },
                    { 93, 7, new DateTime(2022, 8, 5, 19, 49, 46, 344, DateTimeKind.Local).AddTicks(6767), null, false, new DateTime(2022, 6, 27, 22, 49, 57, 757, DateTimeKind.Local).AddTicks(8971), "Practical Steel Gloves", 57m, "07709722", true },
                    { 94, 10, new DateTime(2022, 9, 22, 17, 39, 25, 983, DateTimeKind.Local).AddTicks(1115), null, false, new DateTime(2023, 3, 16, 20, 7, 59, 245, DateTimeKind.Local).AddTicks(1704), "Tasty Cotton Pizza", 53m, "01653663", true },
                    { 95, 3, new DateTime(2022, 6, 25, 10, 31, 38, 785, DateTimeKind.Local).AddTicks(6912), null, false, new DateTime(2022, 11, 10, 18, 42, 41, 827, DateTimeKind.Local).AddTicks(2239), "Fantastic Cotton Bacon", 54m, "62765718", true },
                    { 96, 4, new DateTime(2022, 10, 12, 6, 43, 57, 952, DateTimeKind.Local).AddTicks(32), null, false, new DateTime(2022, 5, 15, 13, 4, 42, 762, DateTimeKind.Local).AddTicks(7235), "Incredible Granite Bacon", 57m, "60575418", true },
                    { 97, 5, new DateTime(2023, 3, 24, 2, 13, 42, 419, DateTimeKind.Local).AddTicks(7158), null, false, new DateTime(2022, 12, 15, 9, 5, 2, 90, DateTimeKind.Local).AddTicks(4504), "Handmade Metal Pants", 49m, "16658509", true },
                    { 98, 6, new DateTime(2022, 10, 14, 16, 1, 38, 810, DateTimeKind.Local).AddTicks(6049), null, true, new DateTime(2022, 9, 4, 5, 49, 2, 821, DateTimeKind.Local).AddTicks(8636), "Refined Steel Table", 56m, "22187628", true },
                    { 99, 3, new DateTime(2022, 7, 5, 1, 24, 43, 585, DateTimeKind.Local).AddTicks(2897), null, true, new DateTime(2022, 6, 18, 19, 8, 31, 324, DateTimeKind.Local).AddTicks(3692), "Refined Cotton Table", 51m, "78884908", true },
                    { 100, 3, new DateTime(2022, 7, 16, 0, 45, 5, 242, DateTimeKind.Local).AddTicks(4489), null, false, new DateTime(2022, 5, 14, 13, 35, 9, 821, DateTimeKind.Local).AddTicks(1045), "Generic Concrete Sausages", 50m, "92850309", true }
                });

            migrationBuilder.InsertData(
                table: "BasketItems",
                columns: new[] { "Id", "BasketId", "CreateDate", "ModifiedDate", "ProductId", "QTY", "Total" },
                values: new object[,]
                {
                    { 1, 17, new DateTime(2022, 10, 30, 22, 49, 17, 184, DateTimeKind.Local).AddTicks(2241), new DateTime(2022, 7, 11, 18, 34, 58, 392, DateTimeKind.Local).AddTicks(5953), 25, 644636219, null },
                    { 2, 65, new DateTime(2022, 12, 11, 4, 3, 40, 415, DateTimeKind.Local).AddTicks(7839), new DateTime(2022, 5, 9, 21, 36, 5, 244, DateTimeKind.Local).AddTicks(7875), 66, 417798499, null },
                    { 3, 97, new DateTime(2023, 4, 8, 22, 58, 35, 459, DateTimeKind.Local).AddTicks(188), new DateTime(2023, 1, 18, 21, 5, 58, 851, DateTimeKind.Local).AddTicks(3270), 11, -2005791709, null },
                    { 4, 149, new DateTime(2022, 8, 13, 10, 26, 11, 308, DateTimeKind.Local).AddTicks(2085), new DateTime(2022, 8, 23, 9, 1, 1, 579, DateTimeKind.Local).AddTicks(5347), 33, -2074246612, null },
                    { 5, 93, new DateTime(2022, 8, 5, 8, 35, 29, 559, DateTimeKind.Local).AddTicks(1182), new DateTime(2022, 8, 6, 6, 5, 46, 28, DateTimeKind.Local).AddTicks(4006), 29, -388238167, null },
                    { 6, 15, new DateTime(2023, 2, 19, 16, 17, 16, 976, DateTimeKind.Local).AddTicks(957), new DateTime(2022, 11, 30, 23, 46, 6, 78, DateTimeKind.Local).AddTicks(1628), 95, 874851869, null },
                    { 7, 26, new DateTime(2022, 7, 3, 16, 17, 25, 659, DateTimeKind.Local).AddTicks(2927), new DateTime(2022, 12, 28, 6, 30, 56, 138, DateTimeKind.Local).AddTicks(9815), 80, 1709217468, null },
                    { 8, 133, new DateTime(2022, 9, 28, 8, 37, 36, 153, DateTimeKind.Local).AddTicks(1677), new DateTime(2022, 7, 31, 19, 14, 42, 329, DateTimeKind.Local).AddTicks(3897), 83, -1373401113, null },
                    { 9, 3, new DateTime(2022, 4, 22, 9, 0, 1, 406, DateTimeKind.Local).AddTicks(7058), new DateTime(2022, 6, 29, 2, 37, 58, 573, DateTimeKind.Local).AddTicks(6371), 70, 1943226053, null },
                    { 10, 10, new DateTime(2022, 10, 13, 15, 44, 44, 570, DateTimeKind.Local).AddTicks(8006), new DateTime(2022, 10, 9, 16, 34, 21, 993, DateTimeKind.Local).AddTicks(7191), 86, -1000183512, null },
                    { 11, 150, new DateTime(2022, 8, 10, 3, 45, 36, 750, DateTimeKind.Local).AddTicks(6233), new DateTime(2022, 11, 29, 7, 5, 0, 74, DateTimeKind.Local).AddTicks(9167), 28, 524456002, null },
                    { 12, 102, new DateTime(2022, 8, 15, 3, 58, 17, 523, DateTimeKind.Local).AddTicks(6056), new DateTime(2022, 10, 28, 19, 27, 9, 993, DateTimeKind.Local).AddTicks(6956), 44, 1999013951, null },
                    { 13, 54, new DateTime(2022, 10, 9, 7, 51, 42, 532, DateTimeKind.Local).AddTicks(7428), new DateTime(2023, 2, 16, 13, 39, 7, 64, DateTimeKind.Local).AddTicks(6316), 25, -946511884, null },
                    { 14, 104, new DateTime(2022, 11, 26, 4, 22, 53, 190, DateTimeKind.Local).AddTicks(763), new DateTime(2023, 2, 21, 17, 34, 52, 640, DateTimeKind.Local).AddTicks(2969), 35, 822106988, null },
                    { 15, 13, new DateTime(2022, 4, 29, 0, 36, 16, 973, DateTimeKind.Local).AddTicks(111), new DateTime(2022, 10, 23, 6, 30, 6, 290, DateTimeKind.Local).AddTicks(6223), 95, -1157967740, null },
                    { 16, 8, new DateTime(2023, 3, 6, 7, 19, 49, 821, DateTimeKind.Local).AddTicks(4946), new DateTime(2023, 1, 31, 0, 12, 50, 537, DateTimeKind.Local).AddTicks(7114), 64, 834492576, null },
                    { 17, 47, new DateTime(2022, 10, 1, 2, 55, 52, 214, DateTimeKind.Local).AddTicks(6546), new DateTime(2022, 12, 28, 12, 55, 56, 673, DateTimeKind.Local).AddTicks(5355), 9, -1009544703, null },
                    { 18, 132, new DateTime(2022, 7, 2, 19, 36, 39, 720, DateTimeKind.Local).AddTicks(2847), new DateTime(2023, 1, 29, 0, 39, 22, 30, DateTimeKind.Local).AddTicks(1485), 100, 210515352, null },
                    { 19, 27, new DateTime(2022, 11, 13, 20, 2, 40, 221, DateTimeKind.Local).AddTicks(4580), new DateTime(2022, 5, 5, 11, 25, 54, 575, DateTimeKind.Local).AddTicks(6592), 11, -1810813505, null },
                    { 20, 117, new DateTime(2022, 5, 8, 12, 32, 0, 821, DateTimeKind.Local).AddTicks(569), new DateTime(2023, 3, 5, 16, 21, 56, 201, DateTimeKind.Local).AddTicks(7989), 41, 1395967450, null },
                    { 21, 49, new DateTime(2023, 3, 27, 12, 29, 59, 424, DateTimeKind.Local).AddTicks(1705), new DateTime(2022, 10, 30, 0, 37, 36, 320, DateTimeKind.Local).AddTicks(833), 50, -2041764393, null },
                    { 22, 59, new DateTime(2022, 12, 5, 7, 21, 15, 575, DateTimeKind.Local).AddTicks(6933), new DateTime(2023, 4, 16, 15, 15, 5, 22, DateTimeKind.Local).AddTicks(2282), 37, 1935322504, null },
                    { 23, 126, new DateTime(2022, 6, 10, 19, 12, 11, 629, DateTimeKind.Local).AddTicks(4392), new DateTime(2022, 7, 11, 0, 11, 16, 737, DateTimeKind.Local).AddTicks(9062), 62, 815609146, null },
                    { 24, 4, new DateTime(2022, 5, 30, 22, 12, 13, 782, DateTimeKind.Local).AddTicks(9640), new DateTime(2023, 1, 26, 22, 20, 27, 514, DateTimeKind.Local).AddTicks(8670), 9, 1147372735, null },
                    { 25, 72, new DateTime(2022, 12, 30, 17, 47, 8, 636, DateTimeKind.Local).AddTicks(3577), new DateTime(2023, 3, 5, 17, 20, 18, 112, DateTimeKind.Local).AddTicks(2019), 88, -2072818963, null },
                    { 26, 56, new DateTime(2022, 10, 28, 0, 58, 42, 185, DateTimeKind.Local).AddTicks(2409), new DateTime(2022, 12, 5, 20, 2, 49, 964, DateTimeKind.Local).AddTicks(9659), 13, -2015185804, null },
                    { 27, 46, new DateTime(2023, 3, 25, 9, 59, 49, 981, DateTimeKind.Local).AddTicks(9524), new DateTime(2023, 2, 17, 5, 42, 25, 173, DateTimeKind.Local).AddTicks(212), 56, -202395888, null },
                    { 28, 66, new DateTime(2022, 7, 18, 13, 35, 22, 531, DateTimeKind.Local).AddTicks(8087), new DateTime(2023, 2, 14, 8, 3, 36, 27, DateTimeKind.Local).AddTicks(7437), 27, -886744128, null },
                    { 29, 128, new DateTime(2022, 4, 20, 21, 10, 13, 969, DateTimeKind.Local).AddTicks(9117), new DateTime(2022, 12, 24, 7, 21, 58, 529, DateTimeKind.Local).AddTicks(8841), 14, -743807823, null },
                    { 30, 98, new DateTime(2022, 6, 11, 11, 42, 50, 518, DateTimeKind.Local).AddTicks(989), new DateTime(2022, 8, 7, 4, 9, 28, 334, DateTimeKind.Local).AddTicks(7533), 99, -140516136, null },
                    { 31, 82, new DateTime(2022, 8, 11, 6, 44, 27, 680, DateTimeKind.Local).AddTicks(938), new DateTime(2023, 2, 19, 12, 53, 25, 26, DateTimeKind.Local).AddTicks(7775), 95, -300312536, null },
                    { 32, 4, new DateTime(2023, 3, 2, 10, 57, 17, 870, DateTimeKind.Local).AddTicks(9623), new DateTime(2023, 3, 23, 4, 14, 44, 787, DateTimeKind.Local).AddTicks(2335), 2, -2135602793, null },
                    { 33, 31, new DateTime(2023, 3, 20, 2, 35, 0, 104, DateTimeKind.Local).AddTicks(9875), new DateTime(2022, 5, 16, 10, 16, 49, 880, DateTimeKind.Local).AddTicks(3099), 30, 504028062, null },
                    { 34, 124, new DateTime(2022, 4, 20, 22, 0, 51, 229, DateTimeKind.Local).AddTicks(2437), new DateTime(2023, 3, 6, 4, 7, 37, 455, DateTimeKind.Local).AddTicks(3751), 48, 1170615998, null },
                    { 35, 105, new DateTime(2022, 5, 21, 10, 55, 24, 967, DateTimeKind.Local).AddTicks(7355), new DateTime(2023, 3, 30, 15, 7, 45, 501, DateTimeKind.Local).AddTicks(7534), 85, 6439367, null },
                    { 36, 31, new DateTime(2022, 7, 21, 12, 42, 31, 659, DateTimeKind.Local).AddTicks(8170), new DateTime(2023, 2, 12, 23, 4, 36, 363, DateTimeKind.Local).AddTicks(7604), 32, 676302874, null },
                    { 37, 103, new DateTime(2022, 8, 30, 3, 50, 0, 468, DateTimeKind.Local).AddTicks(1916), new DateTime(2023, 1, 22, 15, 17, 49, 372, DateTimeKind.Local).AddTicks(7108), 9, -656512081, null },
                    { 38, 86, new DateTime(2023, 1, 21, 3, 27, 36, 677, DateTimeKind.Local).AddTicks(5327), new DateTime(2023, 1, 28, 11, 58, 46, 953, DateTimeKind.Local).AddTicks(9984), 4, 1395309720, null },
                    { 39, 91, new DateTime(2023, 2, 12, 11, 7, 34, 573, DateTimeKind.Local).AddTicks(5593), new DateTime(2022, 9, 17, 16, 30, 23, 764, DateTimeKind.Local).AddTicks(8680), 63, -1975041180, null },
                    { 40, 48, new DateTime(2022, 12, 12, 21, 36, 42, 875, DateTimeKind.Local).AddTicks(1258), new DateTime(2022, 10, 6, 4, 6, 54, 354, DateTimeKind.Local).AddTicks(7098), 69, -1704039727, null },
                    { 41, 150, new DateTime(2022, 6, 4, 2, 3, 25, 405, DateTimeKind.Local).AddTicks(8774), new DateTime(2023, 3, 28, 14, 40, 26, 640, DateTimeKind.Local).AddTicks(5616), 18, 997842694, null },
                    { 42, 125, new DateTime(2022, 8, 6, 6, 48, 21, 778, DateTimeKind.Local).AddTicks(2122), new DateTime(2022, 12, 26, 10, 59, 39, 545, DateTimeKind.Local).AddTicks(6020), 36, -1015305652, null },
                    { 43, 132, new DateTime(2022, 10, 29, 1, 40, 19, 64, DateTimeKind.Local).AddTicks(8167), new DateTime(2023, 1, 3, 12, 15, 47, 362, DateTimeKind.Local).AddTicks(8779), 86, -1619420866, null },
                    { 44, 121, new DateTime(2022, 12, 1, 9, 20, 43, 243, DateTimeKind.Local).AddTicks(4658), new DateTime(2022, 7, 23, 14, 23, 59, 120, DateTimeKind.Local).AddTicks(7197), 74, 1744150631, null },
                    { 45, 77, new DateTime(2023, 3, 22, 1, 13, 32, 807, DateTimeKind.Local).AddTicks(4725), new DateTime(2022, 12, 16, 21, 7, 37, 472, DateTimeKind.Local).AddTicks(8948), 80, 689275248, null },
                    { 46, 135, new DateTime(2023, 4, 3, 6, 20, 14, 492, DateTimeKind.Local).AddTicks(2611), new DateTime(2022, 7, 28, 22, 38, 50, 498, DateTimeKind.Local).AddTicks(8150), 39, -1050884354, null },
                    { 47, 130, new DateTime(2022, 12, 29, 8, 36, 48, 200, DateTimeKind.Local).AddTicks(7902), new DateTime(2022, 6, 4, 21, 27, 39, 932, DateTimeKind.Local).AddTicks(6800), 97, 1002254423, null },
                    { 48, 62, new DateTime(2022, 11, 10, 9, 59, 38, 300, DateTimeKind.Local).AddTicks(6912), new DateTime(2022, 10, 7, 3, 26, 28, 291, DateTimeKind.Local).AddTicks(3577), 65, 1134079808, null },
                    { 49, 57, new DateTime(2022, 6, 2, 9, 2, 36, 885, DateTimeKind.Local).AddTicks(4123), new DateTime(2022, 12, 21, 22, 53, 45, 881, DateTimeKind.Local).AddTicks(3288), 35, -1892421983, null },
                    { 50, 103, new DateTime(2022, 6, 22, 22, 52, 31, 869, DateTimeKind.Local).AddTicks(6207), new DateTime(2023, 1, 15, 18, 11, 25, 552, DateTimeKind.Local).AddTicks(5674), 33, 106160421, null },
                    { 51, 49, new DateTime(2022, 11, 30, 19, 14, 13, 846, DateTimeKind.Local).AddTicks(311), new DateTime(2023, 2, 21, 14, 41, 59, 765, DateTimeKind.Local).AddTicks(1980), 98, 8991959, null },
                    { 52, 143, new DateTime(2022, 10, 25, 6, 21, 52, 435, DateTimeKind.Local).AddTicks(6106), new DateTime(2022, 6, 23, 14, 55, 2, 647, DateTimeKind.Local).AddTicks(9376), 10, 1927520712, null },
                    { 53, 67, new DateTime(2022, 7, 5, 7, 42, 2, 247, DateTimeKind.Local).AddTicks(5458), new DateTime(2023, 2, 14, 20, 18, 13, 823, DateTimeKind.Local).AddTicks(1149), 23, 532402375, null },
                    { 54, 2, new DateTime(2023, 2, 24, 2, 41, 25, 855, DateTimeKind.Local).AddTicks(8093), new DateTime(2023, 1, 6, 20, 15, 46, 102, DateTimeKind.Local).AddTicks(8549), 24, -744215287, null },
                    { 55, 23, new DateTime(2023, 3, 14, 10, 35, 44, 626, DateTimeKind.Local).AddTicks(7886), new DateTime(2022, 10, 20, 19, 25, 57, 327, DateTimeKind.Local).AddTicks(9171), 95, -397962080, null },
                    { 56, 125, new DateTime(2022, 8, 18, 17, 5, 25, 425, DateTimeKind.Local).AddTicks(5903), new DateTime(2022, 11, 8, 0, 23, 14, 47, DateTimeKind.Local).AddTicks(714), 53, -868460439, null },
                    { 57, 141, new DateTime(2022, 5, 9, 7, 35, 14, 794, DateTimeKind.Local).AddTicks(770), new DateTime(2022, 12, 8, 8, 38, 29, 890, DateTimeKind.Local).AddTicks(1307), 44, 265814218, null },
                    { 58, 9, new DateTime(2022, 11, 20, 4, 58, 28, 139, DateTimeKind.Local).AddTicks(2016), new DateTime(2023, 3, 9, 20, 36, 22, 482, DateTimeKind.Local).AddTicks(8365), 93, 1609227792, null },
                    { 59, 124, new DateTime(2022, 12, 9, 6, 57, 17, 664, DateTimeKind.Local).AddTicks(6871), new DateTime(2023, 3, 27, 18, 25, 13, 561, DateTimeKind.Local).AddTicks(814), 69, 1551550066, null },
                    { 60, 134, new DateTime(2022, 9, 1, 23, 38, 48, 325, DateTimeKind.Local).AddTicks(8261), new DateTime(2023, 4, 15, 22, 42, 58, 683, DateTimeKind.Local).AddTicks(8848), 52, -1540649266, null },
                    { 61, 73, new DateTime(2022, 8, 24, 7, 20, 36, 889, DateTimeKind.Local).AddTicks(8101), new DateTime(2023, 2, 4, 7, 0, 44, 651, DateTimeKind.Local).AddTicks(9394), 38, 1207503615, null },
                    { 62, 40, new DateTime(2023, 1, 1, 6, 44, 37, 955, DateTimeKind.Local).AddTicks(6342), new DateTime(2022, 12, 18, 14, 1, 33, 151, DateTimeKind.Local).AddTicks(3338), 63, -148697901, null },
                    { 63, 90, new DateTime(2022, 12, 3, 13, 38, 49, 194, DateTimeKind.Local).AddTicks(1375), new DateTime(2023, 2, 13, 15, 51, 2, 59, DateTimeKind.Local).AddTicks(2231), 23, -963961377, null },
                    { 64, 50, new DateTime(2022, 7, 25, 13, 39, 35, 117, DateTimeKind.Local).AddTicks(1274), new DateTime(2023, 2, 23, 14, 39, 43, 947, DateTimeKind.Local).AddTicks(4441), 59, 1663770847, null },
                    { 65, 141, new DateTime(2022, 7, 30, 21, 48, 55, 566, DateTimeKind.Local).AddTicks(6201), new DateTime(2023, 2, 21, 10, 36, 17, 384, DateTimeKind.Local).AddTicks(2994), 66, -601053186, null },
                    { 66, 19, new DateTime(2022, 5, 25, 17, 32, 28, 532, DateTimeKind.Local).AddTicks(2708), new DateTime(2023, 2, 18, 13, 30, 11, 665, DateTimeKind.Local).AddTicks(5085), 1, -1644775201, null },
                    { 67, 102, new DateTime(2022, 10, 23, 1, 40, 48, 391, DateTimeKind.Local).AddTicks(6677), new DateTime(2022, 11, 18, 23, 29, 49, 65, DateTimeKind.Local).AddTicks(5953), 3, -651143424, null },
                    { 68, 14, new DateTime(2022, 7, 12, 10, 0, 25, 465, DateTimeKind.Local).AddTicks(8990), new DateTime(2023, 3, 28, 3, 26, 47, 944, DateTimeKind.Local).AddTicks(9062), 66, -1649722617, null },
                    { 69, 14, new DateTime(2023, 3, 8, 1, 21, 30, 627, DateTimeKind.Local).AddTicks(8021), new DateTime(2023, 4, 4, 20, 40, 10, 867, DateTimeKind.Local).AddTicks(3697), 53, 1860791225, null },
                    { 70, 70, new DateTime(2022, 6, 22, 16, 44, 42, 845, DateTimeKind.Local).AddTicks(5038), new DateTime(2023, 2, 15, 13, 1, 45, 705, DateTimeKind.Local).AddTicks(7850), 18, -229401953, null },
                    { 71, 92, new DateTime(2023, 3, 1, 18, 41, 19, 148, DateTimeKind.Local).AddTicks(1753), new DateTime(2022, 12, 22, 18, 25, 49, 317, DateTimeKind.Local).AddTicks(8936), 65, 1663713027, null },
                    { 72, 36, new DateTime(2022, 10, 9, 23, 19, 56, 105, DateTimeKind.Local).AddTicks(6295), new DateTime(2022, 12, 10, 1, 0, 56, 874, DateTimeKind.Local).AddTicks(5289), 69, 654430360, null },
                    { 73, 32, new DateTime(2022, 11, 22, 8, 50, 12, 79, DateTimeKind.Local).AddTicks(3411), new DateTime(2022, 9, 22, 1, 14, 26, 822, DateTimeKind.Local).AddTicks(7824), 9, -1897066882, null },
                    { 74, 71, new DateTime(2023, 4, 18, 5, 16, 18, 178, DateTimeKind.Local).AddTicks(5596), new DateTime(2023, 1, 15, 6, 11, 10, 139, DateTimeKind.Local).AddTicks(4222), 17, 936532757, null },
                    { 75, 74, new DateTime(2023, 2, 15, 5, 25, 31, 353, DateTimeKind.Local).AddTicks(5529), new DateTime(2022, 5, 10, 6, 22, 57, 421, DateTimeKind.Local).AddTicks(6464), 59, 99077370, null },
                    { 76, 133, new DateTime(2022, 8, 13, 10, 39, 39, 429, DateTimeKind.Local).AddTicks(405), new DateTime(2023, 2, 26, 15, 31, 4, 432, DateTimeKind.Local).AddTicks(166), 78, 1759718621, null },
                    { 77, 48, new DateTime(2022, 8, 23, 2, 15, 9, 493, DateTimeKind.Local).AddTicks(2332), new DateTime(2022, 10, 19, 19, 13, 46, 419, DateTimeKind.Local).AddTicks(931), 83, 1340099347, null },
                    { 78, 105, new DateTime(2022, 4, 29, 2, 49, 33, 6, DateTimeKind.Local).AddTicks(9672), new DateTime(2023, 2, 8, 9, 20, 26, 692, DateTimeKind.Local).AddTicks(8804), 22, 1458880470, null },
                    { 79, 83, new DateTime(2022, 10, 14, 9, 16, 58, 581, DateTimeKind.Local).AddTicks(7216), new DateTime(2022, 11, 26, 9, 43, 4, 847, DateTimeKind.Local).AddTicks(3771), 12, -1651258103, null },
                    { 80, 87, new DateTime(2022, 10, 25, 6, 51, 57, 512, DateTimeKind.Local).AddTicks(7600), new DateTime(2022, 7, 2, 22, 17, 53, 203, DateTimeKind.Local).AddTicks(2013), 99, 1283806098, null },
                    { 81, 20, new DateTime(2022, 12, 20, 20, 17, 10, 943, DateTimeKind.Local).AddTicks(646), new DateTime(2022, 11, 8, 20, 54, 25, 989, DateTimeKind.Local).AddTicks(8444), 16, -282057835, null },
                    { 82, 30, new DateTime(2022, 5, 28, 23, 47, 22, 799, DateTimeKind.Local).AddTicks(7093), new DateTime(2023, 4, 1, 10, 23, 27, 609, DateTimeKind.Local).AddTicks(2554), 69, -774012183, null },
                    { 83, 129, new DateTime(2022, 11, 3, 10, 40, 47, 862, DateTimeKind.Local).AddTicks(330), new DateTime(2022, 8, 11, 3, 49, 51, 700, DateTimeKind.Local).AddTicks(9684), 9, 1146041398, null },
                    { 84, 133, new DateTime(2022, 11, 25, 15, 11, 3, 635, DateTimeKind.Local).AddTicks(1205), new DateTime(2022, 7, 15, 3, 54, 35, 897, DateTimeKind.Local).AddTicks(3359), 30, -316580199, null },
                    { 85, 149, new DateTime(2022, 10, 21, 5, 49, 18, 16, DateTimeKind.Local).AddTicks(4784), new DateTime(2022, 12, 6, 6, 16, 18, 888, DateTimeKind.Local).AddTicks(3153), 93, 40074253, null },
                    { 86, 5, new DateTime(2023, 2, 25, 13, 5, 46, 975, DateTimeKind.Local).AddTicks(8696), new DateTime(2022, 11, 26, 20, 3, 19, 857, DateTimeKind.Local).AddTicks(5754), 58, -1520558119, null },
                    { 87, 33, new DateTime(2022, 11, 2, 13, 18, 3, 884, DateTimeKind.Local).AddTicks(5676), new DateTime(2022, 9, 4, 4, 42, 21, 269, DateTimeKind.Local).AddTicks(1651), 24, 333214979, null },
                    { 88, 92, new DateTime(2023, 1, 10, 17, 19, 0, 757, DateTimeKind.Local).AddTicks(3575), new DateTime(2023, 4, 17, 20, 42, 49, 775, DateTimeKind.Local).AddTicks(7640), 97, -343975088, null },
                    { 89, 57, new DateTime(2022, 7, 5, 8, 47, 7, 777, DateTimeKind.Local).AddTicks(8054), new DateTime(2022, 8, 27, 7, 0, 56, 538, DateTimeKind.Local).AddTicks(3312), 1, 269048478, null },
                    { 90, 36, new DateTime(2022, 11, 2, 6, 14, 58, 231, DateTimeKind.Local).AddTicks(8677), new DateTime(2022, 8, 31, 13, 40, 38, 643, DateTimeKind.Local).AddTicks(1053), 56, -974327064, null },
                    { 91, 91, new DateTime(2022, 11, 20, 2, 47, 12, 669, DateTimeKind.Local).AddTicks(9857), new DateTime(2022, 12, 11, 2, 34, 55, 395, DateTimeKind.Local).AddTicks(870), 43, 1376214180, null },
                    { 92, 43, new DateTime(2022, 5, 25, 18, 51, 11, 288, DateTimeKind.Local).AddTicks(180), new DateTime(2023, 1, 24, 11, 24, 43, 499, DateTimeKind.Local).AddTicks(1660), 24, 1933694000, null },
                    { 93, 113, new DateTime(2022, 10, 31, 16, 58, 56, 648, DateTimeKind.Local).AddTicks(9062), new DateTime(2022, 4, 20, 19, 32, 0, 650, DateTimeKind.Local).AddTicks(7156), 16, 1114013805, null },
                    { 94, 18, new DateTime(2023, 1, 30, 1, 35, 30, 631, DateTimeKind.Local).AddTicks(6838), new DateTime(2023, 3, 4, 3, 19, 45, 942, DateTimeKind.Local).AddTicks(1150), 9, 2124366463, null },
                    { 95, 141, new DateTime(2023, 2, 2, 21, 36, 19, 294, DateTimeKind.Local).AddTicks(7951), new DateTime(2022, 10, 30, 19, 36, 26, 798, DateTimeKind.Local).AddTicks(4997), 99, -1211685224, null },
                    { 96, 41, new DateTime(2023, 3, 17, 20, 47, 49, 264, DateTimeKind.Local).AddTicks(6726), new DateTime(2022, 10, 27, 6, 43, 26, 402, DateTimeKind.Local).AddTicks(7343), 74, 1466791435, null },
                    { 97, 68, new DateTime(2022, 8, 13, 7, 1, 18, 4, DateTimeKind.Local).AddTicks(6481), new DateTime(2022, 5, 20, 17, 11, 43, 239, DateTimeKind.Local).AddTicks(3214), 59, -2143071845, null },
                    { 98, 113, new DateTime(2023, 2, 2, 7, 6, 51, 965, DateTimeKind.Local).AddTicks(5817), new DateTime(2022, 8, 10, 12, 49, 0, 744, DateTimeKind.Local).AddTicks(834), 10, 104497640, null },
                    { 99, 130, new DateTime(2022, 5, 9, 10, 1, 34, 454, DateTimeKind.Local).AddTicks(127), new DateTime(2022, 4, 29, 14, 40, 46, 672, DateTimeKind.Local).AddTicks(3491), 54, 335315917, null },
                    { 100, 119, new DateTime(2023, 2, 21, 3, 54, 37, 485, DateTimeKind.Local).AddTicks(723), new DateTime(2022, 5, 7, 10, 8, 31, 373, DateTimeKind.Local).AddTicks(8610), 62, 784745183, null },
                    { 101, 35, new DateTime(2022, 10, 29, 1, 16, 9, 58, DateTimeKind.Local).AddTicks(6708), new DateTime(2023, 2, 1, 18, 3, 21, 645, DateTimeKind.Local).AddTicks(115), 32, 594114942, null },
                    { 102, 42, new DateTime(2022, 5, 18, 17, 35, 22, 593, DateTimeKind.Local).AddTicks(847), new DateTime(2022, 5, 29, 6, 3, 1, 56, DateTimeKind.Local).AddTicks(6913), 15, 2050482371, null },
                    { 103, 100, new DateTime(2022, 8, 22, 9, 36, 46, 12, DateTimeKind.Local).AddTicks(2807), new DateTime(2022, 9, 5, 6, 23, 58, 831, DateTimeKind.Local).AddTicks(817), 16, 1497423212, null },
                    { 104, 149, new DateTime(2022, 5, 27, 8, 22, 37, 899, DateTimeKind.Local).AddTicks(7739), new DateTime(2023, 2, 22, 10, 59, 48, 888, DateTimeKind.Local).AddTicks(5761), 4, -1746664994, null },
                    { 105, 141, new DateTime(2022, 7, 13, 14, 53, 29, 679, DateTimeKind.Local).AddTicks(2810), new DateTime(2022, 7, 7, 12, 0, 50, 271, DateTimeKind.Local).AddTicks(528), 52, 128048896, null },
                    { 106, 148, new DateTime(2023, 2, 26, 23, 59, 59, 868, DateTimeKind.Local).AddTicks(3295), new DateTime(2022, 11, 25, 5, 6, 11, 98, DateTimeKind.Local).AddTicks(5249), 61, -141934601, null },
                    { 107, 117, new DateTime(2022, 10, 31, 12, 46, 38, 181, DateTimeKind.Local).AddTicks(6388), new DateTime(2023, 1, 27, 20, 48, 53, 794, DateTimeKind.Local).AddTicks(1269), 55, 605980744, null },
                    { 108, 37, new DateTime(2022, 10, 14, 16, 10, 42, 940, DateTimeKind.Local).AddTicks(7775), new DateTime(2023, 2, 6, 20, 43, 24, 930, DateTimeKind.Local).AddTicks(897), 17, 2074987890, null },
                    { 109, 39, new DateTime(2023, 2, 22, 5, 7, 46, 715, DateTimeKind.Local).AddTicks(2692), new DateTime(2022, 10, 15, 13, 14, 46, 342, DateTimeKind.Local).AddTicks(7528), 78, 1691124643, null },
                    { 110, 132, new DateTime(2022, 12, 18, 18, 19, 3, 735, DateTimeKind.Local).AddTicks(6661), new DateTime(2022, 12, 25, 23, 44, 31, 593, DateTimeKind.Local).AddTicks(9879), 80, 486756808, null },
                    { 111, 119, new DateTime(2022, 7, 18, 1, 49, 29, 735, DateTimeKind.Local).AddTicks(8606), new DateTime(2022, 11, 13, 15, 47, 27, 779, DateTimeKind.Local).AddTicks(9709), 54, 1629079115, null },
                    { 112, 89, new DateTime(2022, 8, 22, 10, 50, 0, 614, DateTimeKind.Local).AddTicks(8884), new DateTime(2022, 10, 5, 5, 56, 57, 20, DateTimeKind.Local).AddTicks(5344), 10, 1256379010, null },
                    { 113, 119, new DateTime(2022, 11, 4, 9, 46, 48, 68, DateTimeKind.Local).AddTicks(2489), new DateTime(2022, 8, 14, 0, 55, 22, 718, DateTimeKind.Local).AddTicks(9129), 97, -2000747249, null },
                    { 114, 57, new DateTime(2022, 12, 13, 8, 20, 2, 87, DateTimeKind.Local).AddTicks(7168), new DateTime(2022, 12, 20, 22, 39, 18, 19, DateTimeKind.Local).AddTicks(3644), 3, -1031500285, null },
                    { 115, 12, new DateTime(2022, 8, 18, 9, 57, 44, 941, DateTimeKind.Local).AddTicks(4162), new DateTime(2022, 12, 5, 18, 4, 32, 747, DateTimeKind.Local).AddTicks(769), 9, -207824016, null },
                    { 116, 105, new DateTime(2022, 7, 30, 5, 38, 50, 901, DateTimeKind.Local).AddTicks(4670), new DateTime(2022, 5, 20, 14, 17, 35, 528, DateTimeKind.Local).AddTicks(9587), 81, 1218010952, null },
                    { 117, 70, new DateTime(2022, 6, 16, 0, 14, 39, 245, DateTimeKind.Local).AddTicks(8714), new DateTime(2022, 7, 10, 0, 21, 18, 193, DateTimeKind.Local).AddTicks(943), 16, 1750746121, null },
                    { 118, 59, new DateTime(2022, 12, 10, 7, 20, 50, 431, DateTimeKind.Local).AddTicks(9083), new DateTime(2022, 8, 29, 11, 59, 36, 969, DateTimeKind.Local).AddTicks(2735), 84, -1398268579, null },
                    { 119, 68, new DateTime(2023, 1, 18, 5, 48, 8, 793, DateTimeKind.Local).AddTicks(731), new DateTime(2022, 6, 27, 10, 40, 18, 323, DateTimeKind.Local).AddTicks(255), 61, -262978600, null },
                    { 120, 107, new DateTime(2022, 12, 29, 20, 42, 44, 29, DateTimeKind.Local).AddTicks(2199), new DateTime(2022, 5, 6, 17, 12, 49, 553, DateTimeKind.Local).AddTicks(9345), 24, -1230311996, null },
                    { 121, 140, new DateTime(2023, 1, 15, 3, 12, 46, 335, DateTimeKind.Local).AddTicks(7304), new DateTime(2022, 12, 2, 11, 12, 30, 574, DateTimeKind.Local).AddTicks(6279), 12, -729958488, null },
                    { 122, 125, new DateTime(2023, 2, 15, 15, 15, 57, 43, DateTimeKind.Local).AddTicks(7898), new DateTime(2022, 11, 23, 0, 5, 38, 356, DateTimeKind.Local).AddTicks(321), 80, -646591649, null },
                    { 123, 124, new DateTime(2022, 11, 16, 1, 31, 19, 840, DateTimeKind.Local).AddTicks(8814), new DateTime(2022, 7, 29, 17, 19, 6, 481, DateTimeKind.Local).AddTicks(3642), 91, -1632805628, null },
                    { 124, 145, new DateTime(2022, 10, 17, 4, 54, 3, 684, DateTimeKind.Local).AddTicks(1847), new DateTime(2022, 6, 17, 19, 16, 18, 663, DateTimeKind.Local).AddTicks(8653), 22, 575234982, null },
                    { 125, 126, new DateTime(2023, 1, 7, 16, 40, 42, 900, DateTimeKind.Local).AddTicks(2568), new DateTime(2022, 8, 31, 5, 20, 11, 971, DateTimeKind.Local).AddTicks(9585), 8, 1158714813, null },
                    { 126, 133, new DateTime(2022, 8, 7, 14, 36, 6, 317, DateTimeKind.Local).AddTicks(6333), new DateTime(2022, 9, 20, 8, 18, 21, 886, DateTimeKind.Local).AddTicks(2210), 75, 54741030, null },
                    { 127, 123, new DateTime(2023, 3, 21, 13, 20, 34, 202, DateTimeKind.Local).AddTicks(5245), new DateTime(2022, 9, 23, 0, 8, 35, 785, DateTimeKind.Local).AddTicks(8535), 44, 189697329, null },
                    { 128, 81, new DateTime(2023, 3, 15, 12, 59, 13, 721, DateTimeKind.Local).AddTicks(7214), new DateTime(2022, 12, 3, 13, 21, 0, 398, DateTimeKind.Local).AddTicks(3603), 13, -1957177933, null },
                    { 129, 108, new DateTime(2023, 1, 17, 14, 54, 31, 472, DateTimeKind.Local).AddTicks(3345), new DateTime(2022, 6, 1, 21, 50, 52, 733, DateTimeKind.Local).AddTicks(5475), 78, -951522776, null },
                    { 130, 52, new DateTime(2023, 3, 5, 3, 19, 33, 653, DateTimeKind.Local).AddTicks(638), new DateTime(2022, 12, 23, 17, 41, 30, 642, DateTimeKind.Local).AddTicks(6992), 44, 1061124294, null },
                    { 131, 66, new DateTime(2022, 6, 6, 11, 23, 26, 375, DateTimeKind.Local).AddTicks(642), new DateTime(2023, 4, 14, 18, 42, 27, 991, DateTimeKind.Local).AddTicks(8443), 29, 205437111, null },
                    { 132, 96, new DateTime(2022, 11, 14, 9, 22, 48, 306, DateTimeKind.Local).AddTicks(2147), new DateTime(2022, 8, 29, 21, 10, 23, 512, DateTimeKind.Local).AddTicks(6483), 97, -646899149, null },
                    { 133, 62, new DateTime(2022, 7, 23, 5, 30, 46, 291, DateTimeKind.Local).AddTicks(7210), new DateTime(2022, 11, 27, 7, 58, 16, 75, DateTimeKind.Local).AddTicks(5884), 95, -170337471, null },
                    { 134, 101, new DateTime(2023, 2, 3, 6, 54, 29, 680, DateTimeKind.Local).AddTicks(4901), new DateTime(2023, 1, 23, 2, 31, 24, 837, DateTimeKind.Local).AddTicks(7966), 44, -677518829, null },
                    { 135, 103, new DateTime(2022, 5, 10, 9, 41, 29, 456, DateTimeKind.Local).AddTicks(2826), new DateTime(2022, 4, 28, 23, 0, 56, 761, DateTimeKind.Local).AddTicks(7688), 23, -1214021940, null },
                    { 136, 91, new DateTime(2023, 1, 7, 4, 9, 53, 950, DateTimeKind.Local).AddTicks(2680), new DateTime(2022, 12, 5, 1, 8, 14, 38, DateTimeKind.Local).AddTicks(1919), 76, 840522668, null },
                    { 137, 8, new DateTime(2022, 5, 7, 8, 1, 46, 565, DateTimeKind.Local).AddTicks(6194), new DateTime(2022, 10, 20, 19, 41, 59, 260, DateTimeKind.Local).AddTicks(4316), 74, 853010040, null },
                    { 138, 94, new DateTime(2022, 11, 24, 15, 52, 30, 215, DateTimeKind.Local).AddTicks(8181), new DateTime(2022, 7, 27, 20, 33, 17, 689, DateTimeKind.Local).AddTicks(3210), 72, 1545481053, null },
                    { 139, 144, new DateTime(2022, 12, 14, 21, 52, 41, 948, DateTimeKind.Local).AddTicks(7368), new DateTime(2022, 12, 27, 19, 59, 24, 968, DateTimeKind.Local).AddTicks(4617), 72, 2031180282, null },
                    { 140, 103, new DateTime(2022, 9, 7, 4, 51, 44, 185, DateTimeKind.Local).AddTicks(2594), new DateTime(2022, 6, 30, 21, 19, 23, 152, DateTimeKind.Local).AddTicks(6585), 2, 1756724437, null },
                    { 141, 67, new DateTime(2022, 9, 4, 4, 3, 35, 399, DateTimeKind.Local).AddTicks(9222), new DateTime(2022, 8, 2, 19, 14, 0, 261, DateTimeKind.Local).AddTicks(4147), 39, 1453429899, null },
                    { 142, 106, new DateTime(2022, 5, 10, 11, 59, 5, 225, DateTimeKind.Local).AddTicks(4345), new DateTime(2023, 3, 13, 3, 44, 53, 843, DateTimeKind.Local).AddTicks(3427), 80, -1797947547, null },
                    { 143, 3, new DateTime(2022, 8, 24, 19, 47, 11, 905, DateTimeKind.Local).AddTicks(2514), new DateTime(2022, 7, 16, 18, 19, 29, 983, DateTimeKind.Local).AddTicks(3978), 52, 545275134, null },
                    { 144, 23, new DateTime(2022, 9, 24, 5, 56, 38, 638, DateTimeKind.Local).AddTicks(5329), new DateTime(2022, 8, 11, 2, 10, 14, 750, DateTimeKind.Local).AddTicks(1465), 41, -158289744, null },
                    { 145, 75, new DateTime(2023, 1, 6, 15, 23, 7, 32, DateTimeKind.Local).AddTicks(8310), new DateTime(2022, 5, 20, 1, 6, 24, 243, DateTimeKind.Local).AddTicks(3024), 16, -1806484552, null },
                    { 146, 140, new DateTime(2022, 5, 17, 2, 0, 18, 11, DateTimeKind.Local).AddTicks(5622), new DateTime(2022, 12, 21, 22, 51, 55, 420, DateTimeKind.Local).AddTicks(1573), 69, 2143284150, null },
                    { 147, 2, new DateTime(2022, 8, 15, 13, 55, 49, 536, DateTimeKind.Local).AddTicks(9179), new DateTime(2022, 10, 28, 12, 12, 48, 900, DateTimeKind.Local).AddTicks(2321), 2, -2130192547, null },
                    { 148, 135, new DateTime(2023, 1, 27, 17, 36, 2, 806, DateTimeKind.Local).AddTicks(2332), new DateTime(2022, 10, 2, 16, 0, 8, 487, DateTimeKind.Local).AddTicks(3721), 33, 1753553547, null },
                    { 149, 22, new DateTime(2022, 9, 18, 0, 46, 27, 984, DateTimeKind.Local).AddTicks(1764), new DateTime(2022, 12, 27, 5, 24, 47, 299, DateTimeKind.Local).AddTicks(1588), 7, 1172763813, null },
                    { 150, 86, new DateTime(2022, 9, 21, 23, 9, 10, 580, DateTimeKind.Local).AddTicks(3916), new DateTime(2023, 4, 9, 8, 8, 29, 297, DateTimeKind.Local).AddTicks(7501), 98, -418893246, null },
                    { 151, 128, new DateTime(2022, 4, 25, 0, 1, 27, 568, DateTimeKind.Local).AddTicks(6092), new DateTime(2022, 8, 7, 16, 37, 4, 851, DateTimeKind.Local).AddTicks(4186), 11, -1273642301, null },
                    { 152, 97, new DateTime(2022, 12, 21, 1, 58, 20, 833, DateTimeKind.Local).AddTicks(9326), new DateTime(2022, 9, 24, 23, 33, 55, 632, DateTimeKind.Local).AddTicks(2471), 98, 585266260, null },
                    { 153, 99, new DateTime(2023, 2, 23, 14, 10, 12, 44, DateTimeKind.Local).AddTicks(575), new DateTime(2022, 10, 13, 8, 30, 15, 679, DateTimeKind.Local).AddTicks(5636), 40, 719650174, null },
                    { 154, 105, new DateTime(2023, 3, 7, 5, 29, 19, 782, DateTimeKind.Local).AddTicks(9001), new DateTime(2022, 11, 3, 18, 23, 45, 716, DateTimeKind.Local).AddTicks(6860), 41, -984825137, null },
                    { 155, 45, new DateTime(2022, 8, 7, 14, 44, 34, 363, DateTimeKind.Local).AddTicks(1902), new DateTime(2022, 7, 7, 2, 51, 40, 840, DateTimeKind.Local).AddTicks(2780), 52, 722246546, null },
                    { 156, 71, new DateTime(2022, 7, 10, 0, 24, 57, 749, DateTimeKind.Local).AddTicks(9824), new DateTime(2022, 9, 7, 18, 35, 32, 964, DateTimeKind.Local).AddTicks(6727), 3, 1257130757, null },
                    { 157, 16, new DateTime(2022, 8, 9, 18, 26, 43, 734, DateTimeKind.Local).AddTicks(3111), new DateTime(2023, 1, 14, 16, 2, 56, 536, DateTimeKind.Local).AddTicks(6438), 80, -1683194425, null },
                    { 158, 39, new DateTime(2022, 8, 3, 5, 16, 22, 907, DateTimeKind.Local).AddTicks(2945), new DateTime(2022, 9, 16, 6, 43, 25, 220, DateTimeKind.Local).AddTicks(4316), 57, 1475405123, null },
                    { 159, 39, new DateTime(2022, 6, 27, 15, 5, 4, 41, DateTimeKind.Local).AddTicks(3771), new DateTime(2022, 6, 18, 21, 23, 16, 632, DateTimeKind.Local).AddTicks(3637), 93, -716024999, null },
                    { 160, 34, new DateTime(2022, 12, 12, 1, 45, 50, 389, DateTimeKind.Local).AddTicks(9323), new DateTime(2022, 12, 4, 16, 46, 31, 650, DateTimeKind.Local).AddTicks(6875), 95, 1597866335, null },
                    { 161, 17, new DateTime(2023, 3, 20, 9, 20, 9, 296, DateTimeKind.Local).AddTicks(3670), new DateTime(2022, 8, 17, 17, 27, 34, 879, DateTimeKind.Local).AddTicks(6543), 69, -706490234, null },
                    { 162, 107, new DateTime(2023, 2, 27, 1, 39, 31, 209, DateTimeKind.Local).AddTicks(5728), new DateTime(2022, 12, 6, 5, 57, 32, 292, DateTimeKind.Local).AddTicks(151), 75, 1931321930, null },
                    { 163, 20, new DateTime(2022, 7, 4, 5, 24, 48, 635, DateTimeKind.Local).AddTicks(9993), new DateTime(2022, 8, 14, 1, 32, 17, 847, DateTimeKind.Local).AddTicks(9734), 3, 540100915, null },
                    { 164, 119, new DateTime(2023, 4, 19, 7, 13, 15, 203, DateTimeKind.Local).AddTicks(6887), new DateTime(2022, 8, 29, 20, 5, 9, 861, DateTimeKind.Local).AddTicks(6102), 88, -565956557, null },
                    { 165, 56, new DateTime(2022, 5, 23, 11, 59, 55, 38, DateTimeKind.Local).AddTicks(2665), new DateTime(2022, 6, 7, 3, 9, 7, 597, DateTimeKind.Local).AddTicks(2342), 8, 434687082, null },
                    { 166, 11, new DateTime(2022, 4, 19, 10, 11, 40, 740, DateTimeKind.Local).AddTicks(2772), new DateTime(2023, 3, 1, 12, 10, 54, 249, DateTimeKind.Local).AddTicks(3776), 95, -1423531345, null },
                    { 167, 85, new DateTime(2022, 9, 15, 11, 34, 7, 938, DateTimeKind.Local).AddTicks(2304), new DateTime(2023, 2, 23, 16, 56, 5, 527, DateTimeKind.Local).AddTicks(6061), 95, -1291860490, null },
                    { 168, 43, new DateTime(2022, 10, 15, 18, 54, 18, 254, DateTimeKind.Local).AddTicks(6589), new DateTime(2023, 1, 3, 0, 26, 51, 487, DateTimeKind.Local).AddTicks(9015), 89, 1475416860, null },
                    { 169, 49, new DateTime(2023, 3, 14, 10, 2, 27, 86, DateTimeKind.Local).AddTicks(9563), new DateTime(2022, 5, 19, 20, 23, 26, 174, DateTimeKind.Local).AddTicks(2773), 95, -845907757, null },
                    { 170, 16, new DateTime(2022, 6, 7, 12, 0, 34, 311, DateTimeKind.Local).AddTicks(8464), new DateTime(2023, 3, 20, 5, 21, 28, 671, DateTimeKind.Local).AddTicks(3700), 39, 1238415981, null },
                    { 171, 49, new DateTime(2023, 1, 22, 23, 20, 4, 31, DateTimeKind.Local).AddTicks(633), new DateTime(2022, 11, 10, 16, 49, 38, 609, DateTimeKind.Local).AddTicks(3707), 97, -2067470002, null },
                    { 172, 5, new DateTime(2022, 7, 31, 2, 41, 59, 909, DateTimeKind.Local).AddTicks(9112), new DateTime(2023, 3, 1, 10, 28, 43, 986, DateTimeKind.Local).AddTicks(1118), 47, 937299191, null },
                    { 173, 26, new DateTime(2022, 7, 15, 7, 41, 15, 675, DateTimeKind.Local).AddTicks(2111), new DateTime(2022, 9, 21, 3, 53, 38, 842, DateTimeKind.Local).AddTicks(9838), 26, 13797417, null },
                    { 174, 73, new DateTime(2022, 11, 16, 3, 50, 9, 167, DateTimeKind.Local).AddTicks(7187), new DateTime(2022, 9, 5, 16, 43, 55, 440, DateTimeKind.Local).AddTicks(9270), 32, 1453564576, null },
                    { 175, 143, new DateTime(2022, 7, 28, 17, 11, 24, 603, DateTimeKind.Local).AddTicks(4982), new DateTime(2023, 2, 10, 8, 58, 17, 814, DateTimeKind.Local).AddTicks(957), 12, -1346962174, null },
                    { 176, 149, new DateTime(2022, 10, 26, 7, 27, 10, 406, DateTimeKind.Local).AddTicks(5738), new DateTime(2022, 7, 23, 18, 26, 55, 339, DateTimeKind.Local).AddTicks(9404), 12, 299746755, null },
                    { 177, 76, new DateTime(2022, 7, 25, 12, 16, 22, 273, DateTimeKind.Local).AddTicks(2781), new DateTime(2022, 10, 2, 15, 53, 28, 582, DateTimeKind.Local).AddTicks(9147), 62, -1169538448, null },
                    { 178, 13, new DateTime(2023, 1, 17, 19, 48, 56, 847, DateTimeKind.Local).AddTicks(9111), new DateTime(2022, 5, 1, 16, 34, 44, 71, DateTimeKind.Local).AddTicks(7226), 70, 56131823, null },
                    { 179, 124, new DateTime(2022, 5, 25, 15, 11, 29, 404, DateTimeKind.Local).AddTicks(629), new DateTime(2022, 9, 3, 10, 17, 17, 25, DateTimeKind.Local).AddTicks(5719), 51, 880167826, null },
                    { 180, 85, new DateTime(2022, 8, 18, 7, 13, 45, 561, DateTimeKind.Local).AddTicks(1341), new DateTime(2022, 5, 20, 6, 22, 11, 201, DateTimeKind.Local).AddTicks(7349), 84, 1558980548, null },
                    { 181, 69, new DateTime(2022, 5, 27, 7, 4, 37, 11, DateTimeKind.Local).AddTicks(3441), new DateTime(2022, 8, 1, 13, 20, 33, 690, DateTimeKind.Local).AddTicks(5754), 85, 35731429, null },
                    { 182, 140, new DateTime(2022, 4, 29, 17, 13, 27, 381, DateTimeKind.Local).AddTicks(1535), new DateTime(2022, 11, 2, 0, 29, 18, 766, DateTimeKind.Local).AddTicks(8994), 53, 573124682, null },
                    { 183, 73, new DateTime(2022, 6, 29, 6, 23, 7, 25, DateTimeKind.Local).AddTicks(117), new DateTime(2022, 11, 10, 12, 57, 3, 951, DateTimeKind.Local).AddTicks(6128), 91, 26439661, null },
                    { 184, 102, new DateTime(2022, 5, 1, 21, 59, 43, 498, DateTimeKind.Local).AddTicks(604), new DateTime(2022, 4, 28, 13, 4, 18, 496, DateTimeKind.Local).AddTicks(1116), 39, -1036639245, null },
                    { 185, 75, new DateTime(2022, 6, 24, 19, 31, 8, 611, DateTimeKind.Local).AddTicks(6707), new DateTime(2022, 5, 2, 9, 49, 17, 525, DateTimeKind.Local).AddTicks(536), 85, 1559602122, null },
                    { 186, 27, new DateTime(2022, 11, 8, 14, 23, 35, 348, DateTimeKind.Local).AddTicks(853), new DateTime(2023, 2, 16, 8, 51, 45, 471, DateTimeKind.Local).AddTicks(7594), 30, -980347333, null },
                    { 187, 120, new DateTime(2023, 3, 25, 0, 38, 12, 566, DateTimeKind.Local).AddTicks(236), new DateTime(2022, 10, 20, 10, 25, 3, 724, DateTimeKind.Local).AddTicks(7613), 93, 1850081438, null },
                    { 188, 120, new DateTime(2022, 7, 5, 20, 18, 29, 189, DateTimeKind.Local).AddTicks(8301), new DateTime(2022, 10, 1, 6, 28, 23, 3, DateTimeKind.Local).AddTicks(2698), 59, -63006082, null },
                    { 189, 122, new DateTime(2022, 12, 14, 18, 23, 24, 915, DateTimeKind.Local).AddTicks(5088), new DateTime(2022, 8, 21, 16, 6, 27, 206, DateTimeKind.Local).AddTicks(1054), 28, 969893193, null },
                    { 190, 115, new DateTime(2023, 1, 30, 8, 12, 1, 879, DateTimeKind.Local).AddTicks(7420), new DateTime(2022, 8, 11, 16, 7, 56, 570, DateTimeKind.Local).AddTicks(9407), 10, 1078522551, null },
                    { 191, 41, new DateTime(2022, 8, 28, 11, 55, 29, 53, DateTimeKind.Local).AddTicks(2562), new DateTime(2023, 2, 1, 12, 36, 42, 976, DateTimeKind.Local).AddTicks(9139), 53, -588729491, null },
                    { 192, 122, new DateTime(2022, 9, 17, 16, 58, 39, 820, DateTimeKind.Local).AddTicks(174), new DateTime(2022, 6, 21, 10, 3, 15, 764, DateTimeKind.Local).AddTicks(1272), 28, 1446456455, null },
                    { 193, 139, new DateTime(2022, 7, 8, 19, 25, 10, 4, DateTimeKind.Local).AddTicks(9733), new DateTime(2022, 12, 19, 1, 22, 23, 544, DateTimeKind.Local).AddTicks(8927), 86, 1710096915, null },
                    { 194, 106, new DateTime(2022, 9, 5, 5, 4, 22, 430, DateTimeKind.Local).AddTicks(8147), new DateTime(2022, 8, 18, 13, 36, 27, 556, DateTimeKind.Local).AddTicks(5101), 75, 495423107, null },
                    { 195, 109, new DateTime(2022, 7, 4, 4, 19, 30, 373, DateTimeKind.Local).AddTicks(8412), new DateTime(2022, 7, 28, 4, 58, 27, 841, DateTimeKind.Local).AddTicks(6306), 2, 178165960, null },
                    { 196, 72, new DateTime(2022, 6, 3, 7, 13, 59, 393, DateTimeKind.Local).AddTicks(3852), new DateTime(2023, 3, 11, 20, 15, 13, 372, DateTimeKind.Local).AddTicks(4333), 87, -1515045065, null },
                    { 197, 39, new DateTime(2023, 2, 20, 13, 11, 28, 480, DateTimeKind.Local).AddTicks(8773), new DateTime(2022, 9, 22, 22, 36, 56, 834, DateTimeKind.Local).AddTicks(8647), 70, 114959550, null },
                    { 198, 46, new DateTime(2022, 6, 2, 1, 35, 23, 840, DateTimeKind.Local).AddTicks(6051), new DateTime(2023, 3, 21, 6, 35, 36, 289, DateTimeKind.Local).AddTicks(5236), 34, -641210337, null },
                    { 199, 20, new DateTime(2022, 11, 11, 12, 14, 41, 773, DateTimeKind.Local).AddTicks(2243), new DateTime(2023, 4, 10, 23, 20, 51, 249, DateTimeKind.Local).AddTicks(4661), 29, -293054200, null },
                    { 200, 35, new DateTime(2022, 5, 28, 18, 34, 57, 482, DateTimeKind.Local).AddTicks(4736), new DateTime(2023, 3, 10, 11, 59, 16, 405, DateTimeKind.Local).AddTicks(3616), 54, 2085301686, null },
                    { 201, 37, new DateTime(2022, 8, 29, 15, 56, 14, 871, DateTimeKind.Local).AddTicks(355), new DateTime(2022, 8, 22, 0, 58, 14, 450, DateTimeKind.Local).AddTicks(4867), 22, 698309717, null },
                    { 202, 69, new DateTime(2022, 6, 29, 22, 47, 23, 499, DateTimeKind.Local).AddTicks(1431), new DateTime(2022, 9, 21, 12, 11, 13, 419, DateTimeKind.Local).AddTicks(5798), 2, -2120591690, null },
                    { 203, 102, new DateTime(2022, 8, 26, 19, 34, 32, 617, DateTimeKind.Local).AddTicks(1804), new DateTime(2022, 12, 5, 23, 6, 9, 100, DateTimeKind.Local).AddTicks(8448), 20, 317363549, null },
                    { 204, 74, new DateTime(2022, 6, 22, 15, 55, 23, 740, DateTimeKind.Local).AddTicks(3965), new DateTime(2023, 3, 31, 0, 36, 18, 80, DateTimeKind.Local).AddTicks(3610), 98, -1631157763, null },
                    { 205, 81, new DateTime(2022, 10, 12, 5, 46, 34, 535, DateTimeKind.Local).AddTicks(8212), new DateTime(2023, 4, 12, 0, 12, 9, 952, DateTimeKind.Local).AddTicks(4687), 40, -724646548, null },
                    { 206, 3, new DateTime(2022, 10, 21, 15, 34, 18, 196, DateTimeKind.Local).AddTicks(9907), new DateTime(2022, 9, 29, 22, 25, 38, 546, DateTimeKind.Local).AddTicks(6996), 66, -827925466, null },
                    { 207, 105, new DateTime(2023, 3, 31, 18, 51, 10, 748, DateTimeKind.Local).AddTicks(6163), new DateTime(2022, 9, 7, 14, 7, 53, 448, DateTimeKind.Local).AddTicks(3265), 5, 28243758, null },
                    { 208, 90, new DateTime(2023, 3, 1, 4, 53, 19, 297, DateTimeKind.Local).AddTicks(8732), new DateTime(2022, 7, 8, 4, 35, 8, 202, DateTimeKind.Local).AddTicks(6846), 27, -1466384536, null },
                    { 209, 103, new DateTime(2022, 10, 12, 21, 0, 30, 73, DateTimeKind.Local).AddTicks(2620), new DateTime(2022, 9, 4, 19, 27, 42, 13, DateTimeKind.Local).AddTicks(5797), 84, -1470396160, null },
                    { 210, 33, new DateTime(2023, 3, 18, 12, 17, 25, 250, DateTimeKind.Local).AddTicks(3612), new DateTime(2023, 1, 22, 21, 44, 8, 781, DateTimeKind.Local).AddTicks(881), 84, -1385597679, null },
                    { 211, 88, new DateTime(2022, 12, 1, 7, 1, 59, 879, DateTimeKind.Local).AddTicks(163), new DateTime(2022, 8, 21, 23, 32, 6, 193, DateTimeKind.Local).AddTicks(716), 46, -105864855, null },
                    { 212, 77, new DateTime(2023, 3, 11, 6, 58, 23, 962, DateTimeKind.Local).AddTicks(4656), new DateTime(2022, 7, 4, 13, 7, 44, 743, DateTimeKind.Local).AddTicks(996), 67, -269245655, null },
                    { 213, 58, new DateTime(2022, 9, 2, 8, 57, 41, 151, DateTimeKind.Local).AddTicks(5709), new DateTime(2022, 4, 20, 2, 52, 58, 562, DateTimeKind.Local).AddTicks(7497), 31, 678598874, null },
                    { 214, 131, new DateTime(2022, 11, 4, 8, 28, 46, 5, DateTimeKind.Local).AddTicks(381), new DateTime(2023, 2, 6, 23, 26, 20, 768, DateTimeKind.Local).AddTicks(1526), 72, 89503524, null },
                    { 215, 13, new DateTime(2022, 9, 7, 14, 36, 21, 398, DateTimeKind.Local).AddTicks(2341), new DateTime(2022, 12, 24, 4, 58, 20, 391, DateTimeKind.Local).AddTicks(5601), 75, -1650159966, null },
                    { 216, 29, new DateTime(2022, 12, 28, 17, 11, 21, 171, DateTimeKind.Local).AddTicks(8164), new DateTime(2022, 9, 14, 19, 41, 31, 759, DateTimeKind.Local).AddTicks(4386), 41, 99250317, null },
                    { 217, 130, new DateTime(2022, 10, 6, 9, 38, 9, 58, DateTimeKind.Local).AddTicks(8254), new DateTime(2023, 1, 3, 17, 7, 4, 343, DateTimeKind.Local).AddTicks(5183), 55, 1525219960, null },
                    { 218, 31, new DateTime(2023, 1, 30, 23, 54, 3, 310, DateTimeKind.Local).AddTicks(949), new DateTime(2023, 2, 13, 17, 57, 31, 139, DateTimeKind.Local).AddTicks(9377), 98, 2040839111, null },
                    { 219, 43, new DateTime(2022, 9, 24, 13, 14, 43, 444, DateTimeKind.Local).AddTicks(9595), new DateTime(2023, 3, 24, 12, 20, 21, 323, DateTimeKind.Local).AddTicks(9677), 45, 458379405, null },
                    { 220, 126, new DateTime(2022, 5, 29, 2, 16, 48, 887, DateTimeKind.Local).AddTicks(192), new DateTime(2022, 10, 6, 17, 42, 44, 297, DateTimeKind.Local).AddTicks(4379), 64, 833397630, null },
                    { 221, 39, new DateTime(2022, 12, 28, 16, 49, 59, 163, DateTimeKind.Local).AddTicks(863), new DateTime(2022, 5, 30, 17, 11, 34, 539, DateTimeKind.Local).AddTicks(8469), 60, -608312786, null },
                    { 222, 21, new DateTime(2023, 3, 25, 22, 44, 44, 382, DateTimeKind.Local).AddTicks(4268), new DateTime(2022, 5, 3, 4, 55, 18, 496, DateTimeKind.Local).AddTicks(9621), 97, -192294584, null },
                    { 223, 49, new DateTime(2022, 6, 5, 10, 36, 57, 423, DateTimeKind.Local).AddTicks(7654), new DateTime(2022, 7, 18, 17, 1, 44, 430, DateTimeKind.Local).AddTicks(8788), 23, -1656688602, null },
                    { 224, 116, new DateTime(2022, 6, 19, 11, 49, 7, 899, DateTimeKind.Local).AddTicks(8574), new DateTime(2023, 1, 13, 12, 8, 2, 441, DateTimeKind.Local).AddTicks(6423), 61, -1171203044, null },
                    { 225, 119, new DateTime(2023, 3, 7, 13, 48, 22, 147, DateTimeKind.Local).AddTicks(354), new DateTime(2022, 7, 2, 14, 59, 31, 230, DateTimeKind.Local).AddTicks(1381), 28, 672030125, null },
                    { 226, 123, new DateTime(2022, 6, 24, 21, 4, 34, 793, DateTimeKind.Local).AddTicks(3386), new DateTime(2023, 3, 12, 10, 40, 18, 543, DateTimeKind.Local).AddTicks(3780), 98, 826649331, null },
                    { 227, 68, new DateTime(2022, 9, 30, 13, 40, 2, 147, DateTimeKind.Local).AddTicks(3753), new DateTime(2022, 11, 12, 7, 38, 4, 50, DateTimeKind.Local).AddTicks(4804), 17, 1286947829, null },
                    { 228, 58, new DateTime(2022, 9, 26, 2, 16, 31, 677, DateTimeKind.Local).AddTicks(1025), new DateTime(2022, 5, 20, 2, 38, 38, 570, DateTimeKind.Local).AddTicks(8518), 31, 988488948, null },
                    { 229, 12, new DateTime(2022, 7, 28, 13, 17, 4, 653, DateTimeKind.Local).AddTicks(6614), new DateTime(2023, 2, 25, 14, 1, 40, 860, DateTimeKind.Local).AddTicks(6719), 20, -1749473708, null },
                    { 230, 63, new DateTime(2022, 9, 3, 13, 5, 35, 744, DateTimeKind.Local).AddTicks(7454), new DateTime(2022, 11, 22, 17, 33, 29, 295, DateTimeKind.Local).AddTicks(8715), 89, 853778894, null },
                    { 231, 86, new DateTime(2023, 3, 27, 23, 25, 30, 395, DateTimeKind.Local).AddTicks(1605), new DateTime(2022, 8, 24, 4, 19, 6, 629, DateTimeKind.Local).AddTicks(6115), 80, -1923485676, null },
                    { 232, 70, new DateTime(2022, 9, 22, 16, 28, 1, 610, DateTimeKind.Local).AddTicks(3559), new DateTime(2022, 8, 14, 15, 43, 57, 541, DateTimeKind.Local).AddTicks(5341), 34, -1151130485, null },
                    { 233, 46, new DateTime(2022, 7, 3, 18, 41, 21, 449, DateTimeKind.Local).AddTicks(5681), new DateTime(2022, 6, 14, 19, 39, 26, 956, DateTimeKind.Local).AddTicks(4339), 45, 2102922513, null },
                    { 234, 15, new DateTime(2022, 9, 28, 15, 1, 32, 631, DateTimeKind.Local).AddTicks(5805), new DateTime(2022, 7, 10, 11, 40, 2, 103, DateTimeKind.Local).AddTicks(9140), 72, -464451764, null },
                    { 235, 31, new DateTime(2022, 7, 30, 19, 37, 8, 172, DateTimeKind.Local).AddTicks(1551), new DateTime(2022, 10, 12, 1, 25, 51, 988, DateTimeKind.Local).AddTicks(234), 45, -855691132, null },
                    { 236, 96, new DateTime(2022, 8, 22, 13, 57, 8, 426, DateTimeKind.Local).AddTicks(9922), new DateTime(2022, 6, 15, 7, 23, 15, 252, DateTimeKind.Local).AddTicks(2520), 59, -2107825905, null },
                    { 237, 144, new DateTime(2022, 9, 27, 15, 57, 51, 8, DateTimeKind.Local).AddTicks(6338), new DateTime(2022, 10, 9, 14, 25, 58, 413, DateTimeKind.Local).AddTicks(7483), 76, -1324434966, null },
                    { 238, 104, new DateTime(2022, 12, 2, 10, 28, 25, 568, DateTimeKind.Local).AddTicks(9826), new DateTime(2022, 6, 10, 3, 29, 19, 227, DateTimeKind.Local).AddTicks(3939), 5, 144527603, null },
                    { 239, 107, new DateTime(2022, 4, 19, 12, 54, 45, 213, DateTimeKind.Local).AddTicks(1387), new DateTime(2022, 11, 22, 7, 48, 27, 88, DateTimeKind.Local).AddTicks(9559), 17, 818980134, null },
                    { 240, 25, new DateTime(2022, 7, 11, 14, 59, 28, 255, DateTimeKind.Local).AddTicks(3953), new DateTime(2022, 8, 5, 0, 32, 13, 473, DateTimeKind.Local).AddTicks(4384), 76, 859619578, null },
                    { 241, 131, new DateTime(2022, 4, 25, 1, 34, 40, 210, DateTimeKind.Local).AddTicks(6722), new DateTime(2023, 4, 18, 23, 41, 35, 51, DateTimeKind.Local).AddTicks(6164), 88, -120784016, null },
                    { 242, 108, new DateTime(2023, 2, 5, 14, 34, 42, 729, DateTimeKind.Local).AddTicks(344), new DateTime(2023, 3, 13, 23, 36, 41, 750, DateTimeKind.Local).AddTicks(3315), 60, 558708324, null },
                    { 243, 143, new DateTime(2022, 8, 5, 19, 32, 43, 663, DateTimeKind.Local).AddTicks(5594), new DateTime(2022, 8, 13, 5, 20, 2, 237, DateTimeKind.Local).AddTicks(9200), 53, -1107221265, null },
                    { 244, 16, new DateTime(2022, 6, 24, 19, 23, 4, 723, DateTimeKind.Local).AddTicks(1879), new DateTime(2023, 2, 18, 20, 48, 11, 670, DateTimeKind.Local).AddTicks(225), 70, 581853324, null },
                    { 245, 33, new DateTime(2022, 5, 27, 23, 11, 23, 16, DateTimeKind.Local).AddTicks(6682), new DateTime(2022, 12, 2, 21, 32, 37, 420, DateTimeKind.Local).AddTicks(395), 92, 1416621198, null },
                    { 246, 7, new DateTime(2022, 8, 30, 11, 51, 51, 351, DateTimeKind.Local).AddTicks(4571), new DateTime(2022, 7, 15, 18, 6, 2, 785, DateTimeKind.Local).AddTicks(5942), 91, -506509819, null },
                    { 247, 141, new DateTime(2022, 8, 13, 11, 34, 28, 596, DateTimeKind.Local).AddTicks(6628), new DateTime(2023, 4, 18, 1, 39, 8, 975, DateTimeKind.Local).AddTicks(6260), 93, 1600705187, null },
                    { 248, 23, new DateTime(2023, 4, 12, 11, 24, 6, 895, DateTimeKind.Local).AddTicks(1876), new DateTime(2023, 1, 8, 11, 33, 35, 18, DateTimeKind.Local).AddTicks(3589), 10, -722842495, null },
                    { 249, 3, new DateTime(2022, 8, 28, 17, 3, 37, 601, DateTimeKind.Local).AddTicks(8055), new DateTime(2022, 8, 1, 10, 4, 25, 951, DateTimeKind.Local).AddTicks(8167), 44, 771320306, null },
                    { 250, 99, new DateTime(2023, 1, 16, 20, 6, 6, 35, DateTimeKind.Local).AddTicks(8082), new DateTime(2023, 4, 4, 8, 20, 44, 877, DateTimeKind.Local).AddTicks(2500), 65, 1383662177, null },
                    { 251, 69, new DateTime(2023, 4, 18, 22, 43, 47, 959, DateTimeKind.Local).AddTicks(5872), new DateTime(2023, 3, 16, 12, 5, 9, 625, DateTimeKind.Local).AddTicks(3060), 76, 1471730771, null },
                    { 252, 105, new DateTime(2023, 2, 20, 13, 16, 34, 782, DateTimeKind.Local).AddTicks(6332), new DateTime(2023, 3, 29, 6, 15, 20, 588, DateTimeKind.Local).AddTicks(264), 99, 2078000179, null },
                    { 253, 126, new DateTime(2022, 10, 22, 7, 12, 38, 969, DateTimeKind.Local).AddTicks(1373), new DateTime(2022, 10, 4, 18, 3, 46, 50, DateTimeKind.Local).AddTicks(7965), 90, -1336001633, null },
                    { 254, 60, new DateTime(2022, 6, 30, 23, 47, 39, 617, DateTimeKind.Local).AddTicks(9075), new DateTime(2022, 6, 19, 16, 10, 17, 174, DateTimeKind.Local).AddTicks(5897), 28, -157082062, null },
                    { 255, 34, new DateTime(2023, 3, 22, 23, 13, 13, 632, DateTimeKind.Local).AddTicks(3351), new DateTime(2022, 8, 23, 5, 55, 12, 979, DateTimeKind.Local).AddTicks(2528), 24, 1161143576, null },
                    { 256, 30, new DateTime(2023, 4, 17, 15, 24, 3, 321, DateTimeKind.Local).AddTicks(6443), new DateTime(2022, 12, 3, 18, 19, 10, 896, DateTimeKind.Local).AddTicks(5205), 4, 1422050696, null },
                    { 257, 64, new DateTime(2023, 1, 17, 4, 19, 43, 888, DateTimeKind.Local).AddTicks(6612), new DateTime(2022, 8, 12, 4, 57, 55, 731, DateTimeKind.Local).AddTicks(293), 94, -1009622668, null },
                    { 258, 16, new DateTime(2022, 10, 13, 21, 26, 5, 563, DateTimeKind.Local).AddTicks(8016), new DateTime(2023, 1, 14, 20, 10, 20, 729, DateTimeKind.Local).AddTicks(4288), 47, -908971685, null },
                    { 259, 128, new DateTime(2022, 9, 4, 18, 18, 55, 311, DateTimeKind.Local).AddTicks(2126), new DateTime(2022, 11, 7, 18, 13, 30, 582, DateTimeKind.Local).AddTicks(2156), 97, -1219327028, null },
                    { 260, 82, new DateTime(2022, 7, 10, 6, 1, 13, 425, DateTimeKind.Local).AddTicks(195), new DateTime(2023, 1, 25, 5, 10, 4, 73, DateTimeKind.Local).AddTicks(2095), 5, -1144569453, null },
                    { 261, 94, new DateTime(2023, 3, 10, 14, 57, 14, 862, DateTimeKind.Local).AddTicks(7004), new DateTime(2023, 1, 15, 1, 56, 10, 870, DateTimeKind.Local).AddTicks(5629), 78, 1125013854, null },
                    { 262, 73, new DateTime(2023, 4, 17, 8, 9, 23, 886, DateTimeKind.Local).AddTicks(3491), new DateTime(2023, 4, 6, 17, 23, 33, 498, DateTimeKind.Local).AddTicks(8960), 66, 599665081, null },
                    { 263, 122, new DateTime(2022, 10, 26, 14, 10, 6, 712, DateTimeKind.Local).AddTicks(4807), new DateTime(2022, 11, 15, 1, 43, 34, 666, DateTimeKind.Local).AddTicks(1367), 22, 1512451128, null },
                    { 264, 90, new DateTime(2023, 4, 17, 3, 28, 2, 768, DateTimeKind.Local).AddTicks(2915), new DateTime(2022, 9, 27, 0, 8, 14, 340, DateTimeKind.Local).AddTicks(4132), 59, -1310075194, null },
                    { 265, 95, new DateTime(2023, 2, 19, 12, 2, 7, 985, DateTimeKind.Local).AddTicks(7926), new DateTime(2022, 9, 27, 13, 55, 46, 700, DateTimeKind.Local).AddTicks(3700), 46, 77309783, null },
                    { 266, 71, new DateTime(2022, 9, 15, 1, 49, 8, 448, DateTimeKind.Local).AddTicks(1554), new DateTime(2022, 7, 4, 11, 13, 21, 326, DateTimeKind.Local).AddTicks(5512), 45, -1454405130, null },
                    { 267, 35, new DateTime(2022, 9, 21, 12, 17, 30, 958, DateTimeKind.Local).AddTicks(7409), new DateTime(2022, 11, 17, 22, 23, 38, 977, DateTimeKind.Local).AddTicks(5894), 33, -1088212775, null },
                    { 268, 54, new DateTime(2022, 7, 6, 3, 1, 55, 952, DateTimeKind.Local).AddTicks(6131), new DateTime(2022, 8, 9, 5, 57, 43, 498, DateTimeKind.Local).AddTicks(1838), 78, 1370434476, null },
                    { 269, 127, new DateTime(2022, 6, 2, 18, 9, 39, 554, DateTimeKind.Local).AddTicks(7517), new DateTime(2022, 11, 20, 9, 23, 40, 85, DateTimeKind.Local).AddTicks(3220), 45, 2002087466, null },
                    { 270, 112, new DateTime(2022, 8, 1, 8, 28, 38, 338, DateTimeKind.Local).AddTicks(722), new DateTime(2022, 11, 5, 16, 32, 46, 780, DateTimeKind.Local).AddTicks(1233), 9, 66907268, null },
                    { 271, 33, new DateTime(2022, 10, 28, 23, 50, 34, 665, DateTimeKind.Local).AddTicks(2581), new DateTime(2022, 8, 22, 13, 22, 57, 697, DateTimeKind.Local).AddTicks(6574), 43, 2123954817, null },
                    { 272, 14, new DateTime(2022, 8, 14, 19, 17, 55, 1, DateTimeKind.Local).AddTicks(4222), new DateTime(2022, 12, 7, 1, 25, 28, 20, DateTimeKind.Local).AddTicks(5004), 63, -1408969364, null },
                    { 273, 10, new DateTime(2022, 4, 22, 7, 26, 18, 660, DateTimeKind.Local).AddTicks(5906), new DateTime(2022, 11, 17, 18, 33, 50, 143, DateTimeKind.Local).AddTicks(9113), 85, -117104629, null },
                    { 274, 33, new DateTime(2022, 7, 5, 18, 31, 18, 645, DateTimeKind.Local).AddTicks(8401), new DateTime(2022, 12, 29, 13, 17, 0, 357, DateTimeKind.Local).AddTicks(8966), 39, 1627531317, null },
                    { 275, 48, new DateTime(2022, 5, 12, 21, 25, 36, 906, DateTimeKind.Local).AddTicks(2793), new DateTime(2022, 11, 14, 8, 38, 20, 303, DateTimeKind.Local).AddTicks(7401), 4, -53143449, null },
                    { 276, 89, new DateTime(2023, 1, 14, 8, 25, 31, 989, DateTimeKind.Local).AddTicks(7829), new DateTime(2022, 6, 10, 9, 23, 18, 15, DateTimeKind.Local).AddTicks(806), 91, 1022453570, null },
                    { 277, 118, new DateTime(2022, 4, 27, 14, 26, 4, 681, DateTimeKind.Local).AddTicks(1072), new DateTime(2022, 7, 24, 16, 39, 22, 153, DateTimeKind.Local).AddTicks(8861), 3, -1606097257, null },
                    { 278, 90, new DateTime(2022, 10, 28, 16, 19, 49, 464, DateTimeKind.Local).AddTicks(7331), new DateTime(2022, 8, 4, 7, 9, 25, 455, DateTimeKind.Local).AddTicks(5498), 72, -941509774, null },
                    { 279, 107, new DateTime(2023, 2, 28, 4, 15, 55, 956, DateTimeKind.Local).AddTicks(5457), new DateTime(2023, 1, 27, 9, 32, 41, 22, DateTimeKind.Local).AddTicks(6113), 92, 536022439, null },
                    { 280, 141, new DateTime(2023, 2, 17, 6, 14, 43, 282, DateTimeKind.Local).AddTicks(6868), new DateTime(2023, 1, 23, 18, 38, 9, 51, DateTimeKind.Local).AddTicks(6267), 1, 1223054856, null },
                    { 281, 32, new DateTime(2022, 9, 23, 1, 10, 57, 621, DateTimeKind.Local).AddTicks(4879), new DateTime(2022, 8, 2, 0, 37, 26, 523, DateTimeKind.Local).AddTicks(3230), 56, 1460143259, null },
                    { 282, 56, new DateTime(2022, 12, 26, 8, 23, 3, 772, DateTimeKind.Local).AddTicks(8497), new DateTime(2023, 1, 25, 5, 2, 9, 245, DateTimeKind.Local).AddTicks(3902), 37, 1242360953, null },
                    { 283, 87, new DateTime(2022, 12, 1, 20, 3, 34, 539, DateTimeKind.Local).AddTicks(8641), new DateTime(2022, 7, 12, 13, 54, 37, 324, DateTimeKind.Local).AddTicks(5422), 6, -1880920703, null },
                    { 284, 44, new DateTime(2022, 10, 2, 1, 39, 50, 909, DateTimeKind.Local).AddTicks(4954), new DateTime(2022, 6, 19, 9, 44, 11, 820, DateTimeKind.Local).AddTicks(767), 82, 1408905424, null },
                    { 285, 93, new DateTime(2022, 8, 30, 5, 41, 27, 238, DateTimeKind.Local).AddTicks(761), new DateTime(2022, 6, 17, 6, 36, 20, 814, DateTimeKind.Local).AddTicks(5807), 96, -1692640910, null },
                    { 286, 142, new DateTime(2022, 8, 26, 19, 34, 8, 533, DateTimeKind.Local).AddTicks(7139), new DateTime(2023, 1, 17, 12, 58, 24, 658, DateTimeKind.Local).AddTicks(1459), 12, 1575933270, null },
                    { 287, 43, new DateTime(2022, 10, 16, 12, 47, 45, 433, DateTimeKind.Local).AddTicks(9330), new DateTime(2022, 8, 17, 11, 55, 24, 504, DateTimeKind.Local).AddTicks(6799), 59, 310867419, null },
                    { 288, 85, new DateTime(2022, 12, 29, 18, 58, 49, 986, DateTimeKind.Local).AddTicks(5660), new DateTime(2023, 3, 15, 10, 44, 0, 779, DateTimeKind.Local).AddTicks(9760), 8, 554481066, null },
                    { 289, 106, new DateTime(2022, 6, 4, 7, 3, 51, 80, DateTimeKind.Local).AddTicks(4680), new DateTime(2022, 8, 8, 13, 50, 58, 917, DateTimeKind.Local).AddTicks(4044), 15, -1528121115, null },
                    { 290, 83, new DateTime(2022, 10, 21, 1, 25, 21, 654, DateTimeKind.Local).AddTicks(9955), new DateTime(2022, 8, 24, 9, 3, 30, 635, DateTimeKind.Local).AddTicks(9009), 2, -252196006, null },
                    { 291, 113, new DateTime(2022, 8, 14, 7, 17, 25, 255, DateTimeKind.Local).AddTicks(6192), new DateTime(2023, 2, 25, 10, 48, 46, 274, DateTimeKind.Local).AddTicks(9538), 48, -1498289383, null },
                    { 292, 106, new DateTime(2022, 5, 27, 5, 17, 3, 925, DateTimeKind.Local).AddTicks(7653), new DateTime(2022, 9, 3, 15, 45, 52, 660, DateTimeKind.Local).AddTicks(6698), 22, 263820810, null },
                    { 293, 46, new DateTime(2023, 1, 11, 21, 11, 56, 637, DateTimeKind.Local).AddTicks(6455), new DateTime(2022, 11, 29, 13, 40, 59, 706, DateTimeKind.Local).AddTicks(1777), 17, -554072019, null },
                    { 294, 50, new DateTime(2023, 3, 5, 3, 31, 36, 850, DateTimeKind.Local).AddTicks(848), new DateTime(2022, 9, 8, 8, 46, 2, 360, DateTimeKind.Local).AddTicks(7616), 30, 71720128, null },
                    { 295, 48, new DateTime(2023, 3, 4, 12, 56, 29, 32, DateTimeKind.Local).AddTicks(2714), new DateTime(2023, 3, 21, 17, 31, 9, 140, DateTimeKind.Local).AddTicks(741), 57, -1894528877, null },
                    { 296, 97, new DateTime(2023, 2, 23, 7, 22, 32, 492, DateTimeKind.Local).AddTicks(3002), new DateTime(2022, 10, 21, 10, 13, 25, 260, DateTimeKind.Local).AddTicks(692), 87, 904683505, null },
                    { 297, 43, new DateTime(2022, 9, 5, 6, 35, 21, 86, DateTimeKind.Local).AddTicks(925), new DateTime(2023, 3, 10, 8, 54, 59, 660, DateTimeKind.Local).AddTicks(1640), 28, -334880285, null },
                    { 298, 128, new DateTime(2022, 6, 25, 15, 19, 18, 547, DateTimeKind.Local).AddTicks(8166), new DateTime(2022, 11, 20, 14, 22, 44, 903, DateTimeKind.Local).AddTicks(5390), 42, -2045278365, null },
                    { 299, 148, new DateTime(2022, 12, 6, 20, 56, 55, 388, DateTimeKind.Local).AddTicks(1439), new DateTime(2022, 12, 7, 15, 32, 42, 750, DateTimeKind.Local).AddTicks(8591), 13, 553782046, null },
                    { 300, 76, new DateTime(2023, 4, 6, 5, 7, 30, 530, DateTimeKind.Local).AddTicks(499), new DateTime(2022, 5, 31, 19, 5, 51, 335, DateTimeKind.Local).AddTicks(8956), 27, -1331236501, null },
                    { 301, 133, new DateTime(2022, 10, 16, 8, 15, 48, 223, DateTimeKind.Local).AddTicks(5143), new DateTime(2022, 7, 10, 12, 57, 58, 601, DateTimeKind.Local).AddTicks(6571), 39, -188077920, null },
                    { 302, 138, new DateTime(2022, 7, 2, 18, 9, 11, 282, DateTimeKind.Local).AddTicks(5616), new DateTime(2022, 6, 23, 17, 30, 59, 755, DateTimeKind.Local).AddTicks(3803), 30, 926435471, null },
                    { 303, 40, new DateTime(2023, 3, 2, 12, 42, 58, 527, DateTimeKind.Local).AddTicks(8843), new DateTime(2022, 8, 7, 16, 2, 26, 293, DateTimeKind.Local).AddTicks(9561), 58, 1340516497, null },
                    { 304, 63, new DateTime(2022, 7, 5, 3, 33, 4, 276, DateTimeKind.Local).AddTicks(1344), new DateTime(2022, 6, 19, 23, 1, 52, 143, DateTimeKind.Local).AddTicks(3057), 43, 633384617, null },
                    { 305, 28, new DateTime(2022, 6, 4, 15, 4, 51, 79, DateTimeKind.Local).AddTicks(6658), new DateTime(2022, 5, 14, 8, 21, 26, 353, DateTimeKind.Local).AddTicks(2478), 60, -1906157486, null },
                    { 306, 119, new DateTime(2023, 2, 1, 13, 9, 19, 721, DateTimeKind.Local).AddTicks(8060), new DateTime(2022, 12, 26, 1, 40, 50, 274, DateTimeKind.Local).AddTicks(1155), 9, 593662367, null },
                    { 307, 129, new DateTime(2023, 1, 12, 14, 48, 58, 725, DateTimeKind.Local).AddTicks(9917), new DateTime(2022, 12, 25, 5, 46, 58, 880, DateTimeKind.Local).AddTicks(2781), 49, 1548494215, null },
                    { 308, 115, new DateTime(2022, 12, 13, 3, 34, 48, 783, DateTimeKind.Local).AddTicks(8397), new DateTime(2023, 3, 27, 2, 12, 44, 115, DateTimeKind.Local).AddTicks(7997), 97, -1631830991, null },
                    { 309, 37, new DateTime(2022, 8, 10, 12, 41, 13, 875, DateTimeKind.Local).AddTicks(7925), new DateTime(2022, 4, 26, 18, 18, 39, 571, DateTimeKind.Local).AddTicks(5406), 29, -1351629366, null },
                    { 310, 57, new DateTime(2023, 2, 6, 12, 36, 38, 289, DateTimeKind.Local).AddTicks(4788), new DateTime(2022, 12, 11, 0, 16, 10, 899, DateTimeKind.Local).AddTicks(9380), 14, 1783216195, null },
                    { 311, 120, new DateTime(2022, 10, 6, 23, 49, 2, 670, DateTimeKind.Local).AddTicks(5882), new DateTime(2023, 2, 23, 14, 8, 50, 204, DateTimeKind.Local).AddTicks(1966), 49, 6104776, null },
                    { 312, 18, new DateTime(2022, 4, 23, 9, 41, 2, 484, DateTimeKind.Local).AddTicks(3414), new DateTime(2022, 8, 5, 0, 47, 54, 450, DateTimeKind.Local).AddTicks(3079), 72, 406368757, null },
                    { 313, 81, new DateTime(2022, 7, 13, 3, 41, 13, 822, DateTimeKind.Local).AddTicks(4322), new DateTime(2023, 3, 22, 17, 57, 19, 566, DateTimeKind.Local).AddTicks(4167), 20, 538170330, null },
                    { 314, 16, new DateTime(2022, 7, 1, 13, 25, 54, 296, DateTimeKind.Local).AddTicks(7860), new DateTime(2022, 9, 11, 18, 17, 56, 983, DateTimeKind.Local).AddTicks(7258), 63, 1373010681, null },
                    { 315, 30, new DateTime(2023, 1, 4, 23, 55, 27, 27, DateTimeKind.Local).AddTicks(9925), new DateTime(2022, 11, 10, 0, 37, 41, 221, DateTimeKind.Local).AddTicks(5305), 68, 1702404170, null },
                    { 316, 73, new DateTime(2022, 6, 10, 4, 59, 26, 690, DateTimeKind.Local).AddTicks(4049), new DateTime(2022, 6, 25, 6, 57, 8, 875, DateTimeKind.Local).AddTicks(3978), 66, -2035680261, null },
                    { 317, 11, new DateTime(2022, 11, 18, 23, 7, 17, 875, DateTimeKind.Local).AddTicks(6496), new DateTime(2023, 2, 12, 20, 41, 10, 707, DateTimeKind.Local).AddTicks(8704), 92, 892307353, null },
                    { 318, 122, new DateTime(2022, 8, 8, 0, 59, 55, 113, DateTimeKind.Local).AddTicks(6350), new DateTime(2023, 1, 29, 3, 17, 1, 22, DateTimeKind.Local).AddTicks(8335), 73, -256236407, null },
                    { 319, 78, new DateTime(2022, 11, 8, 7, 20, 57, 890, DateTimeKind.Local).AddTicks(9051), new DateTime(2023, 1, 5, 2, 25, 41, 693, DateTimeKind.Local).AddTicks(4482), 99, -1915528865, null },
                    { 320, 10, new DateTime(2022, 9, 14, 16, 44, 50, 824, DateTimeKind.Local).AddTicks(8917), new DateTime(2022, 12, 4, 23, 35, 45, 304, DateTimeKind.Local).AddTicks(8556), 26, 220486631, null },
                    { 321, 85, new DateTime(2023, 3, 6, 2, 52, 0, 569, DateTimeKind.Local).AddTicks(2159), new DateTime(2022, 11, 14, 0, 26, 35, 805, DateTimeKind.Local).AddTicks(1898), 87, -816954982, null },
                    { 322, 41, new DateTime(2022, 11, 10, 22, 42, 6, 951, DateTimeKind.Local).AddTicks(6827), new DateTime(2023, 2, 13, 5, 59, 10, 226, DateTimeKind.Local).AddTicks(5579), 100, 1806007870, null },
                    { 323, 14, new DateTime(2022, 12, 28, 0, 36, 0, 535, DateTimeKind.Local).AddTicks(597), new DateTime(2022, 5, 11, 1, 17, 5, 65, DateTimeKind.Local).AddTicks(3263), 45, 2049251589, null },
                    { 324, 114, new DateTime(2022, 8, 5, 23, 57, 13, 360, DateTimeKind.Local).AddTicks(5167), new DateTime(2023, 4, 16, 22, 28, 22, 45, DateTimeKind.Local).AddTicks(1147), 9, 329960153, null },
                    { 325, 108, new DateTime(2023, 1, 23, 9, 35, 44, 283, DateTimeKind.Local).AddTicks(3081), new DateTime(2022, 8, 24, 8, 15, 51, 22, DateTimeKind.Local).AddTicks(1998), 95, 902365130, null },
                    { 326, 122, new DateTime(2022, 4, 26, 19, 44, 49, 826, DateTimeKind.Local).AddTicks(1595), new DateTime(2022, 11, 30, 3, 30, 39, 591, DateTimeKind.Local).AddTicks(5301), 71, 1245250050, null },
                    { 327, 83, new DateTime(2023, 3, 18, 23, 39, 51, 875, DateTimeKind.Local).AddTicks(3255), new DateTime(2023, 3, 10, 22, 32, 2, 969, DateTimeKind.Local).AddTicks(4517), 84, -1057227380, null },
                    { 328, 78, new DateTime(2022, 12, 13, 11, 54, 49, 403, DateTimeKind.Local).AddTicks(6914), new DateTime(2022, 9, 8, 4, 32, 15, 503, DateTimeKind.Local).AddTicks(9351), 67, 238991639, null },
                    { 329, 138, new DateTime(2022, 9, 22, 17, 39, 25, 986, DateTimeKind.Local).AddTicks(7433), new DateTime(2023, 3, 16, 20, 7, 59, 248, DateTimeKind.Local).AddTicks(8021), 61, -689703800, null },
                    { 330, 65, new DateTime(2022, 6, 22, 12, 49, 22, 613, DateTimeKind.Local).AddTicks(5812), new DateTime(2022, 8, 28, 4, 45, 42, 688, DateTimeKind.Local).AddTicks(5353), 36, 313959142, null },
                    { 331, 36, new DateTime(2022, 7, 24, 6, 26, 21, 323, DateTimeKind.Local).AddTicks(2564), new DateTime(2022, 8, 29, 20, 29, 53, 717, DateTimeKind.Local).AddTicks(1526), 64, -2106943538, null },
                    { 332, 114, new DateTime(2023, 3, 2, 22, 57, 48, 175, DateTimeKind.Local).AddTicks(1576), new DateTime(2023, 1, 24, 16, 8, 36, 608, DateTimeKind.Local).AddTicks(2172), 51, -809248587, null },
                    { 333, 66, new DateTime(2022, 12, 14, 8, 30, 41, 68, DateTimeKind.Local).AddTicks(1172), new DateTime(2022, 10, 4, 23, 21, 19, 769, DateTimeKind.Local).AddTicks(9194), 82, 2004235084, null },
                    { 334, 142, new DateTime(2022, 8, 18, 13, 36, 4, 941, DateTimeKind.Local).AddTicks(6198), new DateTime(2023, 3, 29, 3, 48, 29, 443, DateTimeKind.Local).AddTicks(3925), 83, -624559471, null },
                    { 335, 111, new DateTime(2022, 9, 15, 17, 41, 21, 688, DateTimeKind.Local).AddTicks(9607), new DateTime(2022, 11, 8, 3, 33, 39, 447, DateTimeKind.Local).AddTicks(2951), 59, -1774801558, null },
                    { 336, 50, new DateTime(2022, 10, 12, 6, 43, 57, 955, DateTimeKind.Local).AddTicks(6341), new DateTime(2022, 5, 15, 13, 4, 42, 766, DateTimeKind.Local).AddTicks(3544), 19, 444965650, null },
                    { 337, 105, new DateTime(2022, 12, 16, 1, 36, 51, 955, DateTimeKind.Local).AddTicks(7914), new DateTime(2023, 2, 14, 13, 49, 37, 109, DateTimeKind.Local).AddTicks(6180), 75, -1512283779, null },
                    { 338, 92, new DateTime(2022, 8, 26, 3, 8, 4, 227, DateTimeKind.Local).AddTicks(184), new DateTime(2022, 10, 14, 23, 12, 15, 725, DateTimeKind.Local).AddTicks(1987), 19, 991318424, null },
                    { 339, 90, new DateTime(2023, 4, 11, 10, 37, 37, 576, DateTimeKind.Local).AddTicks(7641), new DateTime(2022, 10, 31, 2, 41, 38, 699, DateTimeKind.Local).AddTicks(2278), 90, 1205798993, null },
                    { 340, 52, new DateTime(2022, 6, 1, 9, 2, 9, 436, DateTimeKind.Local).AddTicks(9611), new DateTime(2023, 3, 20, 16, 52, 30, 53, DateTimeKind.Local).AddTicks(52), 8, -1679788621, null },
                    { 341, 129, new DateTime(2023, 1, 2, 21, 50, 30, 165, DateTimeKind.Local).AddTicks(2048), new DateTime(2023, 1, 28, 0, 12, 42, 410, DateTimeKind.Local).AddTicks(2192), 42, -1010139200, null },
                    { 342, 122, new DateTime(2022, 7, 6, 5, 17, 24, 284, DateTimeKind.Local).AddTicks(5930), new DateTime(2022, 8, 22, 1, 1, 19, 291, DateTimeKind.Local).AddTicks(9259), 17, 1628514238, null },
                    { 343, 78, new DateTime(2022, 10, 14, 16, 1, 38, 814, DateTimeKind.Local).AddTicks(2358), new DateTime(2022, 9, 4, 5, 49, 2, 825, DateTimeKind.Local).AddTicks(4944), 25, -1986030177, null },
                    { 344, 57, new DateTime(2022, 11, 4, 8, 57, 59, 361, DateTimeKind.Local).AddTicks(3952), new DateTime(2022, 12, 30, 7, 18, 15, 448, DateTimeKind.Local).AddTicks(2855), 84, -1234432773, null },
                    { 345, 122, new DateTime(2022, 5, 27, 4, 11, 20, 243, DateTimeKind.Local).AddTicks(7337), new DateTime(2022, 6, 29, 8, 14, 51, 108, DateTimeKind.Local).AddTicks(5261), 72, 776699361, null },
                    { 346, 144, new DateTime(2023, 4, 2, 11, 58, 59, 541, DateTimeKind.Local).AddTicks(9650), new DateTime(2023, 2, 3, 6, 42, 24, 677, DateTimeKind.Local).AddTicks(6149), 42, -455540412, null },
                    { 347, 126, new DateTime(2022, 8, 26, 9, 28, 42, 603, DateTimeKind.Local).AddTicks(2620), new DateTime(2023, 1, 25, 4, 14, 55, 609, DateTimeKind.Local).AddTicks(6570), 80, -779990774, null },
                    { 348, 31, new DateTime(2022, 4, 24, 11, 24, 53, 5, DateTimeKind.Local).AddTicks(1286), new DateTime(2023, 1, 22, 14, 41, 30, 310, DateTimeKind.Local).AddTicks(6482), 92, -861680024, null },
                    { 349, 77, new DateTime(2023, 4, 9, 16, 17, 8, 837, DateTimeKind.Local).AddTicks(8036), new DateTime(2022, 12, 18, 22, 6, 34, 45, DateTimeKind.Local).AddTicks(1192), 86, -1539399534, null },
                    { 350, 45, new DateTime(2022, 7, 16, 0, 45, 5, 246, DateTimeKind.Local).AddTicks(798), new DateTime(2022, 5, 14, 13, 35, 9, 824, DateTimeKind.Local).AddTicks(7352), 4, 854534590, null },
                    { 351, 103, new DateTime(2022, 5, 15, 17, 15, 54, 343, DateTimeKind.Local).AddTicks(460), new DateTime(2022, 8, 17, 0, 8, 46, 507, DateTimeKind.Local).AddTicks(9882), 91, -689746412, null },
                    { 352, 4, new DateTime(2022, 8, 17, 2, 30, 40, 543, DateTimeKind.Local).AddTicks(8885), new DateTime(2022, 10, 14, 14, 26, 59, 985, DateTimeKind.Local).AddTicks(4590), 10, -77521310, null },
                    { 353, 109, new DateTime(2022, 7, 20, 6, 27, 23, 20, DateTimeKind.Local).AddTicks(7133), new DateTime(2023, 1, 13, 8, 52, 3, 866, DateTimeKind.Local).AddTicks(4507), 14, 1771642264, null },
                    { 354, 12, new DateTime(2022, 8, 19, 8, 56, 25, 975, DateTimeKind.Local).AddTicks(4302), new DateTime(2022, 11, 1, 11, 58, 25, 529, DateTimeKind.Local).AddTicks(417), 45, -1678243422, null },
                    { 355, 13, new DateTime(2022, 11, 12, 8, 38, 4, 806, DateTimeKind.Local).AddTicks(3884), new DateTime(2022, 12, 18, 12, 51, 18, 162, DateTimeKind.Local).AddTicks(4492), 81, 2003828849, null },
                    { 356, 84, new DateTime(2022, 7, 23, 17, 19, 51, 80, DateTimeKind.Local).AddTicks(9342), new DateTime(2023, 4, 2, 19, 29, 22, 509, DateTimeKind.Local).AddTicks(2743), 17, -1842720778, null },
                    { 357, 42, new DateTime(2022, 7, 13, 5, 39, 45, 299, DateTimeKind.Local).AddTicks(7047), new DateTime(2022, 12, 20, 5, 42, 49, 530, DateTimeKind.Local).AddTicks(4498), 53, -478730370, null },
                    { 358, 19, new DateTime(2023, 1, 12, 19, 8, 35, 646, DateTimeKind.Local).AddTicks(1934), new DateTime(2022, 11, 15, 23, 33, 6, 118, DateTimeKind.Local).AddTicks(1955), 36, 847692040, null },
                    { 359, 145, new DateTime(2022, 5, 27, 7, 38, 24, 376, DateTimeKind.Local).AddTicks(9276), new DateTime(2022, 7, 25, 17, 10, 37, 398, DateTimeKind.Local).AddTicks(8066), 5, -2050487456, null },
                    { 360, 57, new DateTime(2023, 3, 11, 9, 4, 43, 395, DateTimeKind.Local).AddTicks(707), new DateTime(2022, 7, 14, 4, 5, 42, 187, DateTimeKind.Local).AddTicks(4080), 3, 1409577594, null },
                    { 361, 21, new DateTime(2023, 3, 16, 22, 32, 47, 391, DateTimeKind.Local).AddTicks(2177), new DateTime(2023, 2, 5, 14, 12, 12, 67, DateTimeKind.Local).AddTicks(6153), 17, 29139879, null },
                    { 362, 109, new DateTime(2022, 7, 4, 9, 47, 48, 460, DateTimeKind.Local).AddTicks(3124), new DateTime(2022, 7, 9, 9, 12, 5, 182, DateTimeKind.Local).AddTicks(4580), 46, -414424138, null },
                    { 363, 85, new DateTime(2022, 10, 9, 16, 44, 12, 334, DateTimeKind.Local).AddTicks(9098), new DateTime(2022, 5, 7, 6, 51, 40, 299, DateTimeKind.Local).AddTicks(6064), 85, -1292760865, null },
                    { 364, 64, new DateTime(2022, 7, 13, 0, 40, 16, 809, DateTimeKind.Local).AddTicks(1581), new DateTime(2022, 12, 11, 9, 24, 4, 41, DateTimeKind.Local).AddTicks(7677), 87, -2000835588, null },
                    { 365, 133, new DateTime(2023, 2, 25, 11, 52, 36, 984, DateTimeKind.Local).AddTicks(6977), new DateTime(2022, 6, 22, 6, 7, 38, 764, DateTimeKind.Local).AddTicks(659), 95, -270615615, null },
                    { 366, 52, new DateTime(2023, 2, 20, 11, 38, 19, 671, DateTimeKind.Local).AddTicks(9073), new DateTime(2023, 4, 13, 4, 40, 48, 887, DateTimeKind.Local).AddTicks(2737), 26, -2071151355, null },
                    { 367, 49, new DateTime(2023, 1, 31, 6, 25, 24, 570, DateTimeKind.Local).AddTicks(5582), new DateTime(2022, 10, 26, 0, 7, 37, 416, DateTimeKind.Local).AddTicks(4488), 46, 1150255341, null },
                    { 368, 140, new DateTime(2022, 11, 11, 10, 16, 2, 821, DateTimeKind.Local).AddTicks(4768), new DateTime(2022, 11, 12, 3, 22, 14, 661, DateTimeKind.Local).AddTicks(3450), 19, -2078867667, null },
                    { 369, 101, new DateTime(2023, 2, 15, 20, 13, 27, 378, DateTimeKind.Local).AddTicks(3492), new DateTime(2023, 4, 9, 3, 43, 16, 382, DateTimeKind.Local).AddTicks(8875), 98, 1349498961, null },
                    { 370, 81, new DateTime(2022, 9, 15, 5, 12, 13, 302, DateTimeKind.Local).AddTicks(5248), new DateTime(2022, 6, 29, 19, 33, 26, 369, DateTimeKind.Local).AddTicks(7269), 47, 1390175888, null },
                    { 371, 149, new DateTime(2022, 10, 24, 4, 0, 17, 884, DateTimeKind.Local).AddTicks(8526), new DateTime(2022, 7, 5, 8, 20, 2, 989, DateTimeKind.Local).AddTicks(9052), 49, 2080813474, null },
                    { 372, 48, new DateTime(2022, 9, 26, 15, 49, 49, 394, DateTimeKind.Local).AddTicks(961), new DateTime(2022, 9, 4, 0, 22, 58, 197, DateTimeKind.Local).AddTicks(3781), 60, 1669724963, null },
                    { 373, 82, new DateTime(2022, 7, 5, 0, 4, 49, 830, DateTimeKind.Local).AddTicks(8013), new DateTime(2023, 2, 25, 13, 45, 56, 858, DateTimeKind.Local).AddTicks(9103), 20, 430209566, null },
                    { 374, 43, new DateTime(2022, 10, 16, 2, 36, 20, 100, DateTimeKind.Local).AddTicks(5107), new DateTime(2022, 6, 24, 5, 40, 5, 755, DateTimeKind.Local).AddTicks(7797), 23, 731898288, null },
                    { 375, 12, new DateTime(2022, 7, 21, 20, 11, 19, 600, DateTimeKind.Local).AddTicks(2511), new DateTime(2023, 3, 3, 17, 12, 58, 289, DateTimeKind.Local).AddTicks(3509), 98, -1301014388, null },
                    { 376, 47, new DateTime(2022, 9, 13, 6, 13, 5, 245, DateTimeKind.Local).AddTicks(8703), new DateTime(2022, 5, 21, 19, 46, 49, 54, DateTimeKind.Local).AddTicks(939), 51, -1964281363, null },
                    { 377, 14, new DateTime(2022, 4, 29, 14, 58, 12, 222, DateTimeKind.Local).AddTicks(32), new DateTime(2023, 2, 7, 13, 1, 0, 90, DateTimeKind.Local).AddTicks(2373), 13, 1592729617, null },
                    { 378, 112, new DateTime(2022, 5, 29, 21, 4, 16, 772, DateTimeKind.Local).AddTicks(9641), new DateTime(2022, 11, 22, 23, 48, 14, 539, DateTimeKind.Local).AddTicks(8054), 26, 661981338, null },
                    { 379, 52, new DateTime(2022, 12, 15, 4, 45, 12, 735, DateTimeKind.Local).AddTicks(7043), new DateTime(2023, 1, 11, 14, 51, 47, 954, DateTimeKind.Local).AddTicks(7674), 30, -1952991166, null },
                    { 380, 56, new DateTime(2022, 11, 17, 0, 43, 29, 920, DateTimeKind.Local).AddTicks(8201), new DateTime(2023, 2, 26, 15, 34, 3, 105, DateTimeKind.Local).AddTicks(8951), 86, -1350389969, null },
                    { 381, 89, new DateTime(2023, 1, 6, 0, 21, 37, 821, DateTimeKind.Local).AddTicks(5202), new DateTime(2022, 8, 29, 14, 34, 45, 586, DateTimeKind.Local).AddTicks(5466), 77, -1664291786, null },
                    { 382, 44, new DateTime(2023, 2, 3, 17, 34, 32, 626, DateTimeKind.Local).AddTicks(9767), new DateTime(2022, 8, 7, 22, 46, 29, 431, DateTimeKind.Local).AddTicks(7209), 15, 1033796094, null },
                    { 383, 53, new DateTime(2023, 3, 31, 10, 29, 47, 451, DateTimeKind.Local).AddTicks(9016), new DateTime(2022, 11, 28, 4, 17, 54, 749, DateTimeKind.Local).AddTicks(9836), 17, -114122435, null },
                    { 384, 70, new DateTime(2023, 1, 1, 13, 35, 55, 816, DateTimeKind.Local).AddTicks(5161), new DateTime(2023, 2, 16, 1, 32, 20, 969, DateTimeKind.Local).AddTicks(6228), 80, 1580850800, null },
                    { 385, 87, new DateTime(2022, 8, 21, 4, 27, 16, 517, DateTimeKind.Local).AddTicks(5281), new DateTime(2022, 10, 17, 0, 25, 27, 278, DateTimeKind.Local).AddTicks(148), 40, -1323114060, null },
                    { 386, 56, new DateTime(2022, 12, 5, 22, 52, 32, 507, DateTimeKind.Local).AddTicks(36), new DateTime(2022, 11, 3, 12, 39, 5, 153, DateTimeKind.Local).AddTicks(7852), 35, 170031381, null },
                    { 387, 58, new DateTime(2022, 6, 11, 11, 21, 32, 342, DateTimeKind.Local).AddTicks(5695), new DateTime(2022, 5, 30, 3, 18, 37, 404, DateTimeKind.Local).AddTicks(5256), 66, 1716546516, null },
                    { 388, 36, new DateTime(2022, 5, 3, 3, 2, 26, 642, DateTimeKind.Local).AddTicks(988), new DateTime(2022, 9, 9, 23, 45, 18, 234, DateTimeKind.Local).AddTicks(1130), 94, -40968807, null },
                    { 389, 91, new DateTime(2022, 12, 7, 16, 18, 24, 795, DateTimeKind.Local).AddTicks(8332), new DateTime(2022, 5, 19, 9, 45, 10, 165, DateTimeKind.Local).AddTicks(1609), 66, 341801946, null },
                    { 390, 144, new DateTime(2022, 7, 12, 18, 15, 44, 323, DateTimeKind.Local).AddTicks(1748), new DateTime(2022, 6, 17, 17, 12, 46, 494, DateTimeKind.Local).AddTicks(9418), 3, -1607163857, null },
                    { 391, 42, new DateTime(2023, 4, 7, 1, 14, 51, 586, DateTimeKind.Local).AddTicks(6667), new DateTime(2022, 5, 24, 20, 47, 10, 52, DateTimeKind.Local).AddTicks(9372), 89, -865704737, null },
                    { 392, 75, new DateTime(2022, 9, 9, 7, 1, 49, 141, DateTimeKind.Local).AddTicks(6356), new DateTime(2022, 6, 22, 0, 15, 15, 488, DateTimeKind.Local).AddTicks(3002), 69, 1900807590, null },
                    { 393, 26, new DateTime(2022, 6, 3, 14, 47, 7, 98, DateTimeKind.Local).AddTicks(2879), new DateTime(2023, 1, 6, 4, 14, 16, 268, DateTimeKind.Local).AddTicks(564), 5, -2018494401, null },
                    { 394, 138, new DateTime(2022, 7, 1, 8, 25, 13, 996, DateTimeKind.Local).AddTicks(2072), new DateTime(2022, 11, 25, 7, 55, 50, 174, DateTimeKind.Local).AddTicks(7941), 71, -1058348359, null },
                    { 395, 124, new DateTime(2022, 4, 25, 3, 34, 36, 39, DateTimeKind.Local).AddTicks(2456), new DateTime(2022, 7, 17, 11, 4, 35, 425, DateTimeKind.Local).AddTicks(594), 23, -734666403, null },
                    { 396, 48, new DateTime(2022, 7, 16, 14, 44, 31, 551, DateTimeKind.Local).AddTicks(3202), new DateTime(2022, 5, 18, 9, 51, 42, 342, DateTimeKind.Local).AddTicks(9674), 44, -393344251, null },
                    { 397, 67, new DateTime(2022, 7, 25, 1, 19, 20, 181, DateTimeKind.Local).AddTicks(7589), new DateTime(2023, 2, 7, 21, 59, 14, 888, DateTimeKind.Local).AddTicks(9550), 39, -950617832, null },
                    { 398, 57, new DateTime(2023, 2, 26, 6, 23, 41, 762, DateTimeKind.Local).AddTicks(1775), new DateTime(2022, 11, 12, 18, 16, 27, 182, DateTimeKind.Local).AddTicks(2978), 11, 961695442, null },
                    { 399, 124, new DateTime(2022, 9, 5, 18, 47, 56, 246, DateTimeKind.Local).AddTicks(3238), new DateTime(2023, 3, 26, 0, 47, 12, 304, DateTimeKind.Local).AddTicks(5486), 81, 715482153, null },
                    { 400, 70, new DateTime(2022, 7, 12, 16, 21, 46, 194, DateTimeKind.Local).AddTicks(3124), new DateTime(2023, 2, 22, 4, 3, 53, 509, DateTimeKind.Local).AddTicks(4645), 34, -2141938413, null },
                    { 401, 5, new DateTime(2022, 6, 15, 14, 45, 16, 620, DateTimeKind.Local).AddTicks(9661), new DateTime(2022, 7, 13, 14, 39, 12, 99, DateTimeKind.Local).AddTicks(4671), 78, -2031101093, null },
                    { 402, 102, new DateTime(2022, 5, 26, 15, 4, 12, 84, DateTimeKind.Local).AddTicks(5332), new DateTime(2022, 7, 23, 12, 30, 37, 910, DateTimeKind.Local).AddTicks(5684), 37, -2136119007, null },
                    { 403, 145, new DateTime(2022, 8, 8, 16, 45, 10, 313, DateTimeKind.Local).AddTicks(8775), new DateTime(2023, 2, 4, 17, 16, 12, 524, DateTimeKind.Local).AddTicks(8602), 81, 761159345, null },
                    { 404, 2, new DateTime(2022, 11, 23, 22, 14, 6, 889, DateTimeKind.Local).AddTicks(8369), new DateTime(2022, 9, 23, 1, 11, 41, 794, DateTimeKind.Local).AddTicks(3910), 98, 1203092511, null },
                    { 405, 17, new DateTime(2022, 10, 13, 23, 26, 9, 87, DateTimeKind.Local).AddTicks(3577), new DateTime(2023, 1, 20, 19, 22, 55, 726, DateTimeKind.Local).AddTicks(8361), 52, -1168792355, null },
                    { 406, 63, new DateTime(2022, 7, 28, 18, 44, 19, 285, DateTimeKind.Local).AddTicks(8498), new DateTime(2022, 8, 18, 18, 32, 41, 117, DateTimeKind.Local).AddTicks(3573), 77, 165576631, null },
                    { 407, 67, new DateTime(2022, 10, 27, 4, 26, 25, 775, DateTimeKind.Local).AddTicks(3618), new DateTime(2022, 5, 31, 7, 16, 42, 112, DateTimeKind.Local).AddTicks(1475), 3, -812152765, null },
                    { 408, 111, new DateTime(2023, 3, 26, 20, 31, 46, 472, DateTimeKind.Local).AddTicks(4902), new DateTime(2022, 7, 17, 0, 44, 43, 382, DateTimeKind.Local).AddTicks(3718), 30, 47112922, null },
                    { 409, 125, new DateTime(2022, 4, 27, 7, 59, 43, 290, DateTimeKind.Local).AddTicks(5861), new DateTime(2022, 11, 21, 17, 42, 28, 735, DateTimeKind.Local).AddTicks(9915), 6, 335714392, null },
                    { 410, 149, new DateTime(2022, 9, 28, 3, 4, 11, 310, DateTimeKind.Local).AddTicks(3951), new DateTime(2022, 8, 3, 8, 22, 56, 576, DateTimeKind.Local).AddTicks(6939), 48, -2045467805, null },
                    { 411, 150, new DateTime(2022, 11, 27, 15, 57, 6, 405, DateTimeKind.Local).AddTicks(6883), new DateTime(2023, 3, 1, 6, 58, 27, 566, DateTimeKind.Local).AddTicks(5691), 55, 1616836337, null },
                    { 412, 142, new DateTime(2022, 11, 3, 20, 22, 37, 577, DateTimeKind.Local).AddTicks(1005), new DateTime(2022, 7, 4, 2, 26, 47, 579, DateTimeKind.Local).AddTicks(7380), 69, -310012531, null },
                    { 413, 8, new DateTime(2022, 9, 30, 13, 29, 55, 80, DateTimeKind.Local).AddTicks(4636), new DateTime(2023, 1, 29, 5, 51, 0, 443, DateTimeKind.Local).AddTicks(7613), 43, -1812199561, null },
                    { 414, 79, new DateTime(2022, 11, 28, 2, 46, 45, 683, DateTimeKind.Local).AddTicks(1190), new DateTime(2022, 12, 8, 3, 52, 23, 866, DateTimeKind.Local).AddTicks(9503), 96, -190525026, null },
                    { 415, 27, new DateTime(2022, 7, 24, 7, 59, 56, 110, DateTimeKind.Local).AddTicks(4381), new DateTime(2022, 5, 18, 20, 6, 57, 101, DateTimeKind.Local).AddTicks(7378), 31, -1971553626, null },
                    { 416, 2, new DateTime(2022, 11, 8, 21, 10, 25, 528, DateTimeKind.Local).AddTicks(9609), new DateTime(2023, 3, 25, 8, 14, 12, 776, DateTimeKind.Local).AddTicks(7647), 21, -1489487154, null },
                    { 417, 141, new DateTime(2023, 2, 25, 12, 5, 20, 66, DateTimeKind.Local).AddTicks(3106), new DateTime(2023, 2, 25, 8, 13, 13, 60, DateTimeKind.Local).AddTicks(5738), 91, -608148254, null },
                    { 418, 150, new DateTime(2023, 3, 14, 15, 50, 57, 207, DateTimeKind.Local).AddTicks(7781), new DateTime(2022, 10, 9, 21, 2, 3, 757, DateTimeKind.Local).AddTicks(3936), 4, 425460727, null },
                    { 419, 121, new DateTime(2022, 8, 8, 13, 52, 32, 608, DateTimeKind.Local).AddTicks(4519), new DateTime(2022, 7, 12, 22, 18, 31, 540, DateTimeKind.Local).AddTicks(3177), 56, 1361165155, null },
                    { 420, 89, new DateTime(2022, 4, 24, 21, 36, 59, 794, DateTimeKind.Local).AddTicks(7500), new DateTime(2023, 3, 18, 3, 21, 52, 736, DateTimeKind.Local).AddTicks(8756), 3, 1646631131, null },
                    { 421, 103, new DateTime(2022, 11, 1, 8, 26, 12, 994, DateTimeKind.Local).AddTicks(2675), new DateTime(2023, 1, 18, 7, 34, 3, 914, DateTimeKind.Local).AddTicks(8395), 99, 1682186580, null },
                    { 422, 127, new DateTime(2022, 6, 29, 12, 15, 24, 30, DateTimeKind.Local).AddTicks(5314), new DateTime(2022, 10, 7, 18, 2, 7, 976, DateTimeKind.Local).AddTicks(2392), 19, -251431688, null },
                    { 423, 93, new DateTime(2023, 3, 12, 15, 30, 25, 182, DateTimeKind.Local).AddTicks(4394), new DateTime(2022, 12, 31, 22, 58, 15, 68, DateTimeKind.Local).AddTicks(1709), 45, -639167605, null },
                    { 424, 96, new DateTime(2022, 10, 16, 4, 11, 5, 992, DateTimeKind.Local).AddTicks(8798), new DateTime(2022, 10, 6, 7, 32, 59, 131, DateTimeKind.Local).AddTicks(1664), 26, -1928545403, null },
                    { 425, 49, new DateTime(2023, 1, 24, 9, 17, 33, 432, DateTimeKind.Local).AddTicks(8853), new DateTime(2022, 7, 21, 14, 45, 20, 376, DateTimeKind.Local).AddTicks(2704), 56, 1044659312, null },
                    { 426, 47, new DateTime(2022, 7, 16, 17, 25, 15, 987, DateTimeKind.Local).AddTicks(731), new DateTime(2022, 11, 14, 4, 8, 56, 949, DateTimeKind.Local).AddTicks(2044), 80, -2034603189, null },
                    { 427, 4, new DateTime(2022, 8, 20, 7, 41, 56, 525, DateTimeKind.Local).AddTicks(3176), new DateTime(2023, 2, 24, 7, 16, 12, 826, DateTimeKind.Local).AddTicks(3476), 95, 921564217, null },
                    { 428, 94, new DateTime(2022, 12, 17, 0, 56, 50, 34, DateTimeKind.Local).AddTicks(8174), new DateTime(2022, 8, 2, 0, 16, 17, 819, DateTimeKind.Local).AddTicks(4433), 84, -1955219273, null },
                    { 429, 98, new DateTime(2022, 5, 14, 10, 8, 48, 777, DateTimeKind.Local).AddTicks(7066), new DateTime(2022, 10, 12, 12, 2, 18, 373, DateTimeKind.Local).AddTicks(3634), 20, -2101689165, null },
                    { 430, 29, new DateTime(2022, 5, 31, 4, 16, 0, 180, DateTimeKind.Local).AddTicks(4272), new DateTime(2023, 3, 29, 16, 50, 14, 90, DateTimeKind.Local).AddTicks(1287), 55, 2046918665, null },
                    { 431, 93, new DateTime(2022, 8, 5, 1, 39, 10, 228, DateTimeKind.Local).AddTicks(7713), new DateTime(2022, 11, 17, 14, 44, 18, 154, DateTimeKind.Local).AddTicks(2070), 14, 1563280938, null },
                    { 432, 121, new DateTime(2023, 1, 10, 19, 6, 34, 430, DateTimeKind.Local).AddTicks(8403), new DateTime(2022, 5, 19, 1, 1, 55, 694, DateTimeKind.Local).AddTicks(9654), 90, 1739850913, null },
                    { 433, 25, new DateTime(2023, 1, 30, 20, 50, 8, 812, DateTimeKind.Local).AddTicks(9487), new DateTime(2022, 8, 6, 5, 2, 46, 188, DateTimeKind.Local).AddTicks(3893), 30, 1806456386, null },
                    { 434, 37, new DateTime(2023, 1, 2, 16, 29, 37, 580, DateTimeKind.Local).AddTicks(7285), new DateTime(2022, 8, 15, 7, 38, 49, 792, DateTimeKind.Local).AddTicks(6854), 36, -1214430959, null },
                    { 435, 6, new DateTime(2022, 12, 30, 19, 58, 40, 685, DateTimeKind.Local).AddTicks(5432), new DateTime(2023, 2, 20, 21, 20, 27, 258, DateTimeKind.Local).AddTicks(4495), 93, -17608709, null },
                    { 436, 99, new DateTime(2022, 8, 7, 1, 5, 44, 132, DateTimeKind.Local).AddTicks(725), new DateTime(2022, 6, 24, 11, 55, 54, 674, DateTimeKind.Local).AddTicks(1871), 19, 580288630, null },
                    { 437, 59, new DateTime(2023, 3, 11, 14, 32, 33, 374, DateTimeKind.Local).AddTicks(1687), new DateTime(2022, 9, 10, 7, 7, 31, 938, DateTimeKind.Local).AddTicks(1778), 28, -198839870, null },
                    { 438, 149, new DateTime(2022, 4, 24, 22, 21, 36, 167, DateTimeKind.Local).AddTicks(9038), new DateTime(2022, 12, 8, 21, 42, 7, 98, DateTimeKind.Local).AddTicks(4354), 71, 897863347, null },
                    { 439, 27, new DateTime(2022, 9, 8, 1, 10, 11, 490, DateTimeKind.Local).AddTicks(1507), new DateTime(2023, 2, 12, 2, 39, 9, 51, DateTimeKind.Local).AddTicks(2645), 44, -328595255, null },
                    { 440, 51, new DateTime(2022, 10, 5, 5, 17, 37, 992, DateTimeKind.Local).AddTicks(6519), new DateTime(2023, 2, 24, 4, 32, 47, 74, DateTimeKind.Local).AddTicks(8788), 61, 187895886, null },
                    { 441, 112, new DateTime(2022, 6, 12, 10, 34, 0, 323, DateTimeKind.Local).AddTicks(4161), new DateTime(2022, 8, 17, 20, 26, 56, 352, DateTimeKind.Local).AddTicks(720), 76, 1714798588, null },
                    { 442, 96, new DateTime(2022, 12, 10, 11, 57, 53, 547, DateTimeKind.Local).AddTicks(8994), new DateTime(2022, 5, 7, 11, 24, 8, 260, DateTimeKind.Local).AddTicks(7145), 41, -875438822, null },
                    { 443, 39, new DateTime(2022, 9, 15, 17, 37, 50, 179, DateTimeKind.Local).AddTicks(6633), new DateTime(2022, 10, 13, 14, 44, 12, 903, DateTimeKind.Local).AddTicks(3925), 36, 1182885743, null },
                    { 444, 110, new DateTime(2022, 6, 4, 0, 1, 18, 601, DateTimeKind.Local).AddTicks(5670), new DateTime(2022, 10, 27, 18, 26, 3, 667, DateTimeKind.Local).AddTicks(1298), 90, 478797119, null },
                    { 445, 133, new DateTime(2023, 2, 27, 1, 43, 42, 780, DateTimeKind.Local).AddTicks(2340), new DateTime(2022, 10, 18, 17, 27, 17, 578, DateTimeKind.Local).AddTicks(7513), 92, 158677908, null },
                    { 446, 100, new DateTime(2023, 1, 31, 18, 23, 24, 278, DateTimeKind.Local).AddTicks(8590), new DateTime(2022, 12, 28, 14, 23, 30, 868, DateTimeKind.Local).AddTicks(6109), 70, -1058712640, null },
                    { 447, 129, new DateTime(2023, 1, 12, 15, 45, 46, 754, DateTimeKind.Local).AddTicks(7363), new DateTime(2023, 2, 12, 5, 41, 10, 913, DateTimeKind.Local).AddTicks(9842), 18, 1944801066, null },
                    { 448, 17, new DateTime(2023, 3, 24, 11, 18, 29, 519, DateTimeKind.Local).AddTicks(7693), new DateTime(2022, 9, 17, 1, 33, 36, 346, DateTimeKind.Local).AddTicks(288), 63, 1872655326, null },
                    { 449, 23, new DateTime(2022, 11, 23, 14, 9, 4, 381, DateTimeKind.Local).AddTicks(581), new DateTime(2022, 11, 10, 19, 59, 0, 643, DateTimeKind.Local).AddTicks(4054), 50, 645934607, null },
                    { 450, 5, new DateTime(2022, 11, 19, 18, 27, 43, 359, DateTimeKind.Local).AddTicks(1717), new DateTime(2022, 8, 28, 2, 56, 37, 512, DateTimeKind.Local).AddTicks(7386), 81, 920209631, null },
                    { 451, 24, new DateTime(2023, 1, 18, 9, 9, 0, 160, DateTimeKind.Local).AddTicks(1801), new DateTime(2022, 11, 5, 13, 58, 38, 416, DateTimeKind.Local).AddTicks(2799), 4, 1431838651, null },
                    { 452, 71, new DateTime(2022, 10, 30, 18, 14, 20, 184, DateTimeKind.Local).AddTicks(6926), new DateTime(2022, 8, 3, 16, 11, 32, 496, DateTimeKind.Local).AddTicks(8710), 40, 1890548790, null },
                    { 453, 21, new DateTime(2023, 1, 11, 23, 51, 35, 108, DateTimeKind.Local).AddTicks(1000), new DateTime(2022, 7, 30, 16, 27, 10, 703, DateTimeKind.Local).AddTicks(5317), 31, -1874349704, null },
                    { 454, 6, new DateTime(2022, 11, 4, 16, 22, 32, 324, DateTimeKind.Local).AddTicks(2738), new DateTime(2023, 3, 17, 5, 2, 26, 369, DateTimeKind.Local).AddTicks(9299), 20, 751516294, null },
                    { 455, 82, new DateTime(2022, 10, 21, 2, 38, 53, 57, DateTimeKind.Local).AddTicks(5227), new DateTime(2022, 9, 30, 4, 10, 15, 585, DateTimeKind.Local).AddTicks(7039), 54, -44727109, null },
                    { 456, 27, new DateTime(2022, 12, 22, 19, 52, 34, 347, DateTimeKind.Local).AddTicks(2171), new DateTime(2023, 1, 19, 17, 58, 9, 233, DateTimeKind.Local).AddTicks(7368), 38, -806478200, null },
                    { 457, 1, new DateTime(2023, 4, 13, 5, 54, 28, 865, DateTimeKind.Local).AddTicks(8118), new DateTime(2022, 7, 22, 21, 51, 59, 288, DateTimeKind.Local).AddTicks(2822), 19, 1823302888, null },
                    { 458, 66, new DateTime(2022, 8, 17, 14, 10, 46, 801, DateTimeKind.Local).AddTicks(1915), new DateTime(2022, 5, 31, 7, 58, 52, 148, DateTimeKind.Local).AddTicks(3688), 33, -1045353974, null },
                    { 459, 75, new DateTime(2022, 10, 31, 4, 20, 57, 778, DateTimeKind.Local).AddTicks(4830), new DateTime(2022, 10, 4, 18, 51, 55, 622, DateTimeKind.Local).AddTicks(3565), 48, -1902954551, null },
                    { 460, 115, new DateTime(2022, 5, 23, 6, 2, 27, 443, DateTimeKind.Local).AddTicks(5853), new DateTime(2022, 8, 4, 20, 0, 46, 15, DateTimeKind.Local).AddTicks(2447), 42, 358402996, null },
                    { 461, 84, new DateTime(2022, 6, 2, 3, 25, 4, 187, DateTimeKind.Local).AddTicks(6209), new DateTime(2022, 10, 21, 18, 37, 32, 75, DateTimeKind.Local).AddTicks(6842), 39, -19562718, null },
                    { 462, 53, new DateTime(2022, 11, 28, 14, 46, 15, 308, DateTimeKind.Local).AddTicks(2190), new DateTime(2022, 11, 2, 6, 49, 29, 608, DateTimeKind.Local).AddTicks(8887), 85, -856063842, null },
                    { 463, 47, new DateTime(2022, 5, 23, 21, 52, 18, 106, DateTimeKind.Local).AddTicks(7334), new DateTime(2023, 1, 14, 17, 54, 53, 396, DateTimeKind.Local).AddTicks(3427), 70, 1853797823, null },
                    { 464, 130, new DateTime(2023, 1, 10, 12, 58, 14, 435, DateTimeKind.Local).AddTicks(8670), new DateTime(2022, 6, 9, 16, 39, 43, 151, DateTimeKind.Local).AddTicks(5637), 54, -545587664, null },
                    { 465, 1, new DateTime(2023, 1, 11, 12, 57, 2, 965, DateTimeKind.Local).AddTicks(8472), new DateTime(2022, 11, 26, 2, 6, 55, 576, DateTimeKind.Local).AddTicks(6027), 84, -1994527613, null },
                    { 466, 109, new DateTime(2022, 11, 30, 13, 34, 57, 970, DateTimeKind.Local).AddTicks(7723), new DateTime(2022, 6, 8, 8, 3, 54, 753, DateTimeKind.Local).AddTicks(4169), 46, 1072823055, null },
                    { 467, 58, new DateTime(2023, 1, 19, 11, 21, 32, 522, DateTimeKind.Local).AddTicks(9423), new DateTime(2022, 8, 6, 21, 50, 21, 755, DateTimeKind.Local).AddTicks(5307), 47, 1751482380, null },
                    { 468, 138, new DateTime(2022, 8, 15, 16, 22, 18, 52, DateTimeKind.Local).AddTicks(2696), new DateTime(2022, 7, 12, 3, 32, 2, 659, DateTimeKind.Local).AddTicks(3101), 58, 1033604254, null },
                    { 469, 119, new DateTime(2023, 2, 18, 13, 26, 28, 70, DateTimeKind.Local).AddTicks(7045), new DateTime(2022, 6, 26, 0, 14, 14, 804, DateTimeKind.Local).AddTicks(2246), 64, 2073859414, null },
                    { 470, 125, new DateTime(2022, 11, 23, 18, 9, 9, 827, DateTimeKind.Local).AddTicks(1931), new DateTime(2022, 6, 19, 16, 0, 22, 619, DateTimeKind.Local).AddTicks(4143), 30, -1266137389, null },
                    { 471, 84, new DateTime(2023, 4, 3, 12, 58, 32, 16, DateTimeKind.Local).AddTicks(7108), new DateTime(2023, 4, 14, 3, 20, 2, 500, DateTimeKind.Local).AddTicks(1934), 62, 2040976870, null },
                    { 472, 62, new DateTime(2022, 12, 12, 20, 8, 51, 440, DateTimeKind.Local).AddTicks(7093), new DateTime(2022, 9, 8, 0, 38, 16, 392, DateTimeKind.Local).AddTicks(3455), 54, -782753338, null },
                    { 473, 92, new DateTime(2022, 8, 5, 1, 45, 58, 870, DateTimeKind.Local).AddTicks(9367), new DateTime(2022, 11, 20, 7, 19, 23, 376, DateTimeKind.Local).AddTicks(4419), 23, 1326913413, null },
                    { 474, 77, new DateTime(2023, 1, 17, 8, 27, 45, 631, DateTimeKind.Local).AddTicks(3614), new DateTime(2022, 8, 21, 4, 11, 32, 603, DateTimeKind.Local).AddTicks(8153), 50, 2014417597, null },
                    { 475, 3, new DateTime(2023, 4, 9, 16, 14, 5, 68, DateTimeKind.Local).AddTicks(6700), new DateTime(2022, 11, 1, 17, 46, 22, 432, DateTimeKind.Local).AddTicks(397), 18, 1170816140, null },
                    { 476, 104, new DateTime(2022, 5, 29, 13, 30, 0, 988, DateTimeKind.Local).AddTicks(2853), new DateTime(2022, 7, 7, 21, 12, 56, 554, DateTimeKind.Local).AddTicks(8823), 11, -1308995039, null },
                    { 477, 21, new DateTime(2022, 9, 4, 17, 56, 45, 399, DateTimeKind.Local).AddTicks(9360), new DateTime(2022, 7, 20, 15, 1, 59, 650, DateTimeKind.Local).AddTicks(6108), 64, 888949217, null },
                    { 478, 69, new DateTime(2022, 9, 25, 3, 57, 58, 720, DateTimeKind.Local).AddTicks(819), new DateTime(2023, 4, 18, 1, 41, 0, 465, DateTimeKind.Local).AddTicks(1173), 70, -1171014992, null },
                    { 479, 66, new DateTime(2022, 7, 8, 14, 58, 51, 65, DateTimeKind.Local).AddTicks(9987), new DateTime(2022, 5, 26, 22, 18, 7, 112, DateTimeKind.Local).AddTicks(1916), 61, 1426911949, null },
                    { 480, 56, new DateTime(2022, 12, 19, 16, 3, 48, 916, DateTimeKind.Local).AddTicks(7966), new DateTime(2023, 3, 30, 15, 57, 39, 587, DateTimeKind.Local).AddTicks(3978), 69, 445613984, null },
                    { 481, 96, new DateTime(2022, 10, 29, 2, 11, 24, 938, DateTimeKind.Local).AddTicks(7091), new DateTime(2022, 5, 2, 15, 28, 19, 978, DateTimeKind.Local).AddTicks(9176), 4, 43608280, null },
                    { 482, 40, new DateTime(2023, 1, 8, 2, 14, 13, 777, DateTimeKind.Local).AddTicks(3840), new DateTime(2023, 3, 4, 5, 52, 42, 114, DateTimeKind.Local).AddTicks(6585), 22, 290447443, null },
                    { 483, 76, new DateTime(2022, 8, 28, 4, 24, 52, 531, DateTimeKind.Local).AddTicks(9338), new DateTime(2023, 1, 8, 3, 10, 40, 982, DateTimeKind.Local).AddTicks(5107), 54, 169075120, null },
                    { 484, 141, new DateTime(2022, 7, 27, 22, 40, 30, 340, DateTimeKind.Local).AddTicks(9200), new DateTime(2022, 5, 16, 4, 2, 16, 943, DateTimeKind.Local).AddTicks(1495), 81, 1788722721, null },
                    { 485, 40, new DateTime(2022, 12, 2, 0, 45, 36, 556, DateTimeKind.Local).AddTicks(1349), new DateTime(2022, 11, 25, 7, 29, 56, 374, DateTimeKind.Local).AddTicks(4291), 67, 2061848812, null },
                    { 486, 91, new DateTime(2022, 5, 20, 13, 57, 10, 704, DateTimeKind.Local).AddTicks(3811), new DateTime(2022, 7, 11, 16, 45, 3, 170, DateTimeKind.Local).AddTicks(4122), 80, 513139152, null },
                    { 487, 106, new DateTime(2022, 6, 28, 0, 27, 36, 291, DateTimeKind.Local).AddTicks(9896), new DateTime(2023, 3, 29, 14, 11, 14, 520, DateTimeKind.Local).AddTicks(7271), 5, 419012115, null },
                    { 488, 54, new DateTime(2022, 4, 27, 10, 57, 37, 738, DateTimeKind.Local).AddTicks(9125), new DateTime(2022, 6, 29, 19, 24, 32, 786, DateTimeKind.Local).AddTicks(9495), 74, -1091734587, null },
                    { 489, 146, new DateTime(2022, 11, 13, 12, 12, 24, 927, DateTimeKind.Local).AddTicks(8136), new DateTime(2022, 10, 29, 16, 26, 42, 133, DateTimeKind.Local).AddTicks(1358), 69, 312572871, null },
                    { 490, 139, new DateTime(2022, 9, 22, 15, 38, 12, 738, DateTimeKind.Local).AddTicks(6966), new DateTime(2022, 12, 5, 3, 21, 37, 253, DateTimeKind.Local).AddTicks(4704), 22, -1324344762, null },
                    { 491, 75, new DateTime(2023, 2, 1, 7, 1, 32, 254, DateTimeKind.Local).AddTicks(4878), new DateTime(2023, 2, 7, 11, 16, 16, 206, DateTimeKind.Local).AddTicks(3156), 86, -1414163749, null },
                    { 492, 44, new DateTime(2023, 2, 5, 6, 49, 57, 277, DateTimeKind.Local).AddTicks(471), new DateTime(2022, 8, 20, 16, 19, 5, 674, DateTimeKind.Local).AddTicks(5403), 82, -223471900, null },
                    { 493, 129, new DateTime(2023, 1, 25, 2, 53, 2, 858, DateTimeKind.Local).AddTicks(3456), new DateTime(2022, 11, 16, 11, 18, 25, 388, DateTimeKind.Local).AddTicks(3167), 71, -881411300, null },
                    { 494, 140, new DateTime(2023, 1, 13, 3, 48, 25, 597, DateTimeKind.Local).AddTicks(2757), new DateTime(2022, 11, 13, 10, 17, 11, 699, DateTimeKind.Local).AddTicks(3707), 99, -1030134677, null },
                    { 495, 106, new DateTime(2022, 5, 17, 21, 54, 58, 86, DateTimeKind.Local).AddTicks(8700), new DateTime(2022, 10, 15, 15, 19, 51, 395, DateTimeKind.Local).AddTicks(6105), 72, 486858268, null },
                    { 496, 34, new DateTime(2022, 11, 26, 7, 5, 55, 328, DateTimeKind.Local).AddTicks(4632), new DateTime(2023, 2, 12, 7, 40, 54, 862, DateTimeKind.Local).AddTicks(1982), 46, -1338114744, null },
                    { 497, 126, new DateTime(2022, 9, 15, 14, 3, 14, 479, DateTimeKind.Local).AddTicks(8881), new DateTime(2022, 6, 20, 4, 24, 43, 692, DateTimeKind.Local).AddTicks(439), 53, -1870223331, null },
                    { 498, 39, new DateTime(2022, 8, 3, 3, 27, 42, 343, DateTimeKind.Local).AddTicks(9541), new DateTime(2022, 7, 23, 7, 13, 29, 229, DateTimeKind.Local).AddTicks(7252), 51, -1716821782, null },
                    { 499, 2, new DateTime(2022, 10, 4, 5, 33, 48, 719, DateTimeKind.Local).AddTicks(1725), new DateTime(2023, 1, 1, 9, 55, 16, 690, DateTimeKind.Local).AddTicks(925), 69, -29764571, null },
                    { 500, 109, new DateTime(2022, 5, 4, 22, 35, 50, 85, DateTimeKind.Local).AddTicks(4853), new DateTime(2022, 7, 18, 2, 36, 10, 139, DateTimeKind.Local).AddTicks(7253), 40, 1781707848, null }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CreateDate", "Filename", "ModifiedDate", "Name", "ProductId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 18, 15, 29, 53, 516, DateTimeKind.Local).AddTicks(6939), "Gorgeous_Wooden_Shoes.jpg", new DateTime(2023, 3, 9, 23, 43, 3, 922, DateTimeKind.Local).AddTicks(2970), "Gorgeous_Wooden_Shoes", 1 },
                    { 2, new DateTime(2023, 1, 18, 15, 29, 53, 518, DateTimeKind.Local).AddTicks(1288), "Gorgeous_Wooden_Shoes2.jpg", new DateTime(2023, 3, 9, 23, 43, 3, 923, DateTimeKind.Local).AddTicks(7310), "Gorgeous_Wooden_Shoes2", 1 },
                    { 3, new DateTime(2023, 1, 18, 15, 29, 53, 519, DateTimeKind.Local).AddTicks(5496), "Gorgeous_Wooden_Shoes3.jpg", new DateTime(2023, 3, 9, 23, 43, 3, 925, DateTimeKind.Local).AddTicks(1521), "Gorgeous_Wooden_Shoes3", 1 },
                    { 4, new DateTime(2023, 1, 18, 15, 29, 53, 521, DateTimeKind.Local).AddTicks(600), "Handcrafted_Plastic_Soap.jpg", new DateTime(2023, 3, 9, 23, 43, 3, 926, DateTimeKind.Local).AddTicks(6625), "Handcrafted_Plastic_Soap", 2 },
                    { 5, new DateTime(2023, 1, 18, 15, 29, 53, 522, DateTimeKind.Local).AddTicks(4917), "Handcrafted_Plastic_Soap2.jpg", new DateTime(2023, 3, 9, 23, 43, 3, 928, DateTimeKind.Local).AddTicks(942), "Handcrafted_Plastic_Soap2", 2 },
                    { 6, new DateTime(2023, 1, 18, 15, 29, 53, 523, DateTimeKind.Local).AddTicks(8780), "Metal_Chicken.jpg", new DateTime(2023, 3, 9, 23, 43, 3, 929, DateTimeKind.Local).AddTicks(4803), "Metal_Chicken", 3 },
                    { 7, new DateTime(2023, 1, 18, 15, 29, 53, 525, DateTimeKind.Local).AddTicks(2173), "Metal_Shoes.jpg", new DateTime(2023, 3, 9, 23, 43, 3, 930, DateTimeKind.Local).AddTicks(8196), "Metal_Shoes", 4 },
                    { 8, new DateTime(2023, 1, 18, 15, 29, 53, 526, DateTimeKind.Local).AddTicks(5585), "Metal_Shoes2.jpg", new DateTime(2023, 3, 9, 23, 43, 3, 932, DateTimeKind.Local).AddTicks(1609), "Metal_Shoes2", 4 },
                    { 9, new DateTime(2023, 1, 18, 15, 29, 53, 539, DateTimeKind.Local).AddTicks(4019), "Steel_Computer.jpg", new DateTime(2023, 3, 9, 23, 43, 3, 945, DateTimeKind.Local).AddTicks(116), "Steel_Computer", 5 },
                    { 10, new DateTime(2023, 1, 18, 15, 29, 53, 540, DateTimeKind.Local).AddTicks(4684), "Cotton_Cheese.jpg", new DateTime(2023, 3, 9, 23, 43, 3, 946, DateTimeKind.Local).AddTicks(707), "Cotton_Cheese", 6 },
                    { 11, new DateTime(2023, 1, 18, 15, 29, 53, 541, DateTimeKind.Local).AddTicks(5011), "Refined_Soft_Computer.jpg", new DateTime(2023, 3, 9, 23, 43, 3, 947, DateTimeKind.Local).AddTicks(1032), "Refined_Soft_Computer", 7 },
                    { 12, new DateTime(2023, 1, 18, 15, 29, 53, 542, DateTimeKind.Local).AddTicks(5078), "Incredible_Steel_Mouse.jpg", new DateTime(2023, 3, 9, 23, 43, 3, 948, DateTimeKind.Local).AddTicks(1098), "Incredible_Steel_Mouse", 8 },
                    { 13, new DateTime(2023, 1, 18, 15, 29, 53, 543, DateTimeKind.Local).AddTicks(5170), "Tasty_Granite_Chicken.jpg", new DateTime(2023, 3, 9, 23, 43, 3, 949, DateTimeKind.Local).AddTicks(1190), "Tasty_Granite_Chicken", 9 }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreateDate", "Description", "ImageId", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 9, 23, 43, 3, 915, DateTimeKind.Local).AddTicks(279), null, 1, new DateTime(2022, 10, 30, 22, 49, 17, 178, DateTimeKind.Local).AddTicks(9665), "Computers" },
                    { 2, new DateTime(2022, 8, 22, 9, 58, 10, 144, DateTimeKind.Local).AddTicks(9750), null, 2, new DateTime(2022, 11, 12, 10, 39, 33, 864, DateTimeKind.Local).AddTicks(7980), "Shoes" },
                    { 3, new DateTime(2022, 5, 9, 21, 36, 5, 239, DateTimeKind.Local).AddTicks(5293), null, 3, new DateTime(2023, 3, 13, 10, 44, 27, 100, DateTimeKind.Local).AddTicks(1031), "Garden" },
                    { 4, new DateTime(2023, 4, 8, 22, 58, 35, 453, DateTimeKind.Local).AddTicks(7639), null, 4, new DateTime(2023, 1, 18, 21, 5, 58, 846, DateTimeKind.Local).AddTicks(721), "Baby" },
                    { 5, new DateTime(2022, 4, 23, 3, 28, 29, 209, DateTimeKind.Local).AddTicks(9121), null, 5, new DateTime(2022, 8, 13, 10, 26, 11, 302, DateTimeKind.Local).AddTicks(9539), "Garden" },
                    { 6, new DateTime(2023, 1, 6, 5, 7, 37, 172, DateTimeKind.Local).AddTicks(3834), null, 6, new DateTime(2022, 9, 6, 19, 24, 1, 648, DateTimeKind.Local).AddTicks(2317), "Baby" },
                    { 7, new DateTime(2022, 8, 6, 6, 5, 46, 23, DateTimeKind.Local).AddTicks(1466), null, 7, new DateTime(2022, 5, 7, 17, 46, 32, 877, DateTimeKind.Local).AddTicks(8621), "Clothing" },
                    { 8, new DateTime(2023, 2, 19, 16, 17, 16, 970, DateTimeKind.Local).AddTicks(8420), null, 8, new DateTime(2022, 11, 30, 23, 46, 6, 72, DateTimeKind.Local).AddTicks(9090), "Music" },
                    { 9, new DateTime(2023, 2, 16, 13, 18, 9, 839, DateTimeKind.Local).AddTicks(688), null, 9, new DateTime(2022, 7, 3, 16, 17, 25, 654, DateTimeKind.Local).AddTicks(391), "Jewelery" }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[,]
                {
                    { 8, 1 },
                    { 5, 2 },
                    { 2, 3 },
                    { 3, 4 },
                    { 9, 5 },
                    { 7, 6 },
                    { 3, 7 },
                    { 6, 8 },
                    { 7, 9 },
                    { 3, 10 },
                    { 6, 11 },
                    { 4, 12 },
                    { 9, 13 },
                    { 6, 14 },
                    { 5, 15 },
                    { 7, 16 },
                    { 1, 17 },
                    { 1, 18 },
                    { 4, 19 },
                    { 4, 20 },
                    { 2, 21 },
                    { 3, 22 },
                    { 1, 23 },
                    { 5, 24 },
                    { 6, 25 },
                    { 3, 26 },
                    { 1, 27 },
                    { 8, 28 },
                    { 4, 29 },
                    { 5, 30 },
                    { 4, 31 },
                    { 3, 32 },
                    { 7, 33 },
                    { 3, 34 },
                    { 2, 35 },
                    { 2, 36 },
                    { 9, 37 },
                    { 1, 38 },
                    { 2, 39 },
                    { 5, 40 },
                    { 1, 41 },
                    { 2, 42 },
                    { 4, 43 },
                    { 4, 44 },
                    { 4, 45 },
                    { 5, 46 },
                    { 5, 47 },
                    { 8, 48 },
                    { 3, 49 },
                    { 6, 50 },
                    { 9, 51 },
                    { 9, 52 },
                    { 8, 53 },
                    { 5, 54 },
                    { 8, 55 },
                    { 9, 56 },
                    { 2, 57 },
                    { 5, 58 },
                    { 3, 59 },
                    { 4, 60 },
                    { 7, 61 },
                    { 4, 62 },
                    { 6, 63 },
                    { 5, 64 },
                    { 5, 65 },
                    { 2, 66 },
                    { 1, 67 },
                    { 1, 68 },
                    { 4, 69 },
                    { 2, 70 },
                    { 3, 71 },
                    { 5, 72 },
                    { 3, 73 },
                    { 4, 74 },
                    { 1, 75 },
                    { 4, 76 },
                    { 4, 77 },
                    { 5, 78 },
                    { 4, 79 },
                    { 1, 80 },
                    { 3, 81 },
                    { 8, 82 },
                    { 4, 83 },
                    { 9, 84 },
                    { 1, 85 },
                    { 2, 86 },
                    { 7, 87 },
                    { 9, 88 },
                    { 5, 89 },
                    { 9, 90 },
                    { 1, 91 },
                    { 3, 92 },
                    { 4, 93 },
                    { 6, 94 },
                    { 2, 95 },
                    { 7, 96 },
                    { 9, 97 },
                    { 9, 98 },
                    { 6, 99 },
                    { 7, 100 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_CountryId",
                table: "Address",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_BillingAddressId",
                table: "AspNetUsers",
                column: "BillingAddressId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_BasketId",
                table: "BasketItems",
                column: "BasketId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_ProductId",
                table: "BasketItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_BillingAddressId",
                table: "Baskets",
                column: "BillingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_PaymentProviderId",
                table: "Baskets",
                column: "PaymentProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_ShippingAddressId",
                table: "Baskets",
                column: "ShippingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_UserId",
                table: "Baskets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ImageId",
                table: "Categories",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ProductId",
                table: "Images",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_CategoryId",
                table: "ProductCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BasketItems");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Baskets");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "PaymentProvider");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
