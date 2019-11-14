using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TLCN.Models.Migrations
{
    public partial class InitDatabase_version1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MetadataTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTimeOffset>(nullable: false),
                    Modified = table.Column<DateTimeOffset>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 255, nullable: true),
                    AppService = table.Column<string>(maxLength: 255, nullable: true),
                    IsActivated = table.Column<bool>(nullable: false),
                    Code = table.Column<string>(maxLength: 50, nullable: true),
                    Name = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetadataTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MetadataValues",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTimeOffset>(nullable: false),
                    Modified = table.Column<DateTimeOffset>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 255, nullable: true),
                    AppService = table.Column<string>(maxLength: 255, nullable: true),
                    IsActivated = table.Column<bool>(nullable: false),
                    Code = table.Column<string>(maxLength: 50, nullable: true),
                    Name = table.Column<string>(maxLength: 255, nullable: true),
                    TypeId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetadataValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MetadataValues_MetadataTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "MetadataTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AuthUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTimeOffset>(nullable: false),
                    Modified = table.Column<DateTimeOffset>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 255, nullable: true),
                    AppService = table.Column<string>(maxLength: 255, nullable: true),
                    IsActivated = table.Column<bool>(nullable: false),
                    Code = table.Column<string>(maxLength: 50, nullable: true),
                    Fullname = table.Column<string>(maxLength: 255, nullable: true),
                    Email = table.Column<string>(maxLength: 255, nullable: true),
                    BirthDate = table.Column<DateTimeOffset>(nullable: false),
                    GenderId = table.Column<Guid>(nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 255, nullable: true),
                    Address = table.Column<string>(maxLength: 255, nullable: true),
                    AvatarId = table.Column<Guid>(nullable: true),
                    Username = table.Column<string>(maxLength: 50, nullable: true),
                    Password = table.Column<string>(maxLength: 255, nullable: true),
                    Role = table.Column<int>(nullable: false),
                    DistrictId = table.Column<Guid>(nullable: true),
                    ProvinceId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuthUsers_MetadataValues_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "MetadataValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AuthUsers_MetadataValues_GenderId",
                        column: x => x.GenderId,
                        principalTable: "MetadataValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AuthUsers_MetadataValues_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "MetadataValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTimeOffset>(nullable: false),
                    Modified = table.Column<DateTimeOffset>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 255, nullable: true),
                    AppService = table.Column<string>(maxLength: 255, nullable: true),
                    IsActivated = table.Column<bool>(nullable: false),
                    Code = table.Column<string>(maxLength: 50, nullable: true),
                    Name = table.Column<string>(maxLength: 255, nullable: true),
                    Address = table.Column<string>(maxLength: 255, nullable: true),
                    DistrictId = table.Column<Guid>(nullable: true),
                    ProvinceId = table.Column<Guid>(nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 10, nullable: true),
                    IsPointOfSale = table.Column<bool>(nullable: false),
                    ParentId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Branches_MetadataValues_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "MetadataValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Branches_MetadataValues_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "MetadataValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTimeOffset>(nullable: false),
                    Modified = table.Column<DateTimeOffset>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 255, nullable: true),
                    AppService = table.Column<string>(maxLength: 255, nullable: true),
                    IsActivated = table.Column<bool>(nullable: false),
                    Code = table.Column<string>(maxLength: 50, nullable: true),
                    ProducerId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(maxLength: 255, nullable: true),
                    Price = table.Column<double>(nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    IsSell = table.Column<bool>(nullable: false),
                    Logo = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_MetadataValues_ProducerId",
                        column: x => x.ProducerId,
                        principalTable: "MetadataValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTimeOffset>(nullable: false),
                    Modified = table.Column<DateTimeOffset>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 255, nullable: true),
                    AppService = table.Column<string>(maxLength: 255, nullable: true),
                    IsActivated = table.Column<bool>(nullable: false),
                    Code = table.Column<string>(maxLength: 50, nullable: true),
                    AuthUserId = table.Column<Guid>(nullable: false),
                    Total = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bills_AuthUsers_AuthUserId",
                        column: x => x.AuthUserId,
                        principalTable: "AuthUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTimeOffset>(nullable: false),
                    Modified = table.Column<DateTimeOffset>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 255, nullable: true),
                    AppService = table.Column<string>(maxLength: 255, nullable: true),
                    IsActivated = table.Column<bool>(nullable: false),
                    Code = table.Column<string>(maxLength: 50, nullable: true),
                    AuthUserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_AuthUsers_AuthUserId",
                        column: x => x.AuthUserId,
                        principalTable: "AuthUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReviewProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTimeOffset>(nullable: false),
                    Modified = table.Column<DateTimeOffset>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 255, nullable: true),
                    AppService = table.Column<string>(maxLength: 255, nullable: true),
                    IsActivated = table.Column<bool>(nullable: false),
                    Code = table.Column<string>(maxLength: 50, nullable: true),
                    ProductId = table.Column<Guid>(nullable: false),
                    AuthUserId = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Rating = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReviewProducts_AuthUsers_AuthUserId",
                        column: x => x.AuthUserId,
                        principalTable: "AuthUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReviewProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetailBills",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTimeOffset>(nullable: false),
                    Modified = table.Column<DateTimeOffset>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 255, nullable: true),
                    AppService = table.Column<string>(maxLength: 255, nullable: true),
                    IsActivated = table.Column<bool>(nullable: false),
                    Code = table.Column<string>(maxLength: 50, nullable: true),
                    ProductId = table.Column<Guid>(nullable: false),
                    BillId = table.Column<Guid>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    PriceTotal = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailBills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetailBills_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailBills_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Promotions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTimeOffset>(nullable: false),
                    Modified = table.Column<DateTimeOffset>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 255, nullable: true),
                    AppService = table.Column<string>(maxLength: 255, nullable: true),
                    IsActivated = table.Column<bool>(nullable: false),
                    Code = table.Column<string>(maxLength: 50, nullable: true),
                    Name = table.Column<string>(maxLength: 255, nullable: true),
                    DisCount = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    BillId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Promotions_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CartDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTimeOffset>(nullable: false),
                    Modified = table.Column<DateTimeOffset>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 255, nullable: true),
                    AppService = table.Column<string>(maxLength: 255, nullable: true),
                    IsActivated = table.Column<bool>(nullable: false),
                    Code = table.Column<string>(maxLength: 50, nullable: true),
                    CartId = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false),
                    Amount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartDetails_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthUsers_DistrictId",
                table: "AuthUsers",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthUsers_GenderId",
                table: "AuthUsers",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthUsers_ProvinceId",
                table: "AuthUsers",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_AuthUserId",
                table: "Bills",
                column: "AuthUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_DistrictId",
                table: "Branches",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_ProvinceId",
                table: "Branches",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_CartDetails_CartId",
                table: "CartDetails",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartDetails_ProductId",
                table: "CartDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_AuthUserId",
                table: "Carts",
                column: "AuthUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailBills_BillId",
                table: "DetailBills",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailBills_ProductId",
                table: "DetailBills",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_MetadataValues_TypeId",
                table: "MetadataValues",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProducerId",
                table: "Products",
                column: "ProducerId");

            migrationBuilder.CreateIndex(
                name: "IX_Promotions_BillId",
                table: "Promotions",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewProducts_AuthUserId",
                table: "ReviewProducts",
                column: "AuthUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewProducts_ProductId",
                table: "ReviewProducts",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "CartDetails");

            migrationBuilder.DropTable(
                name: "DetailBills");

            migrationBuilder.DropTable(
                name: "Promotions");

            migrationBuilder.DropTable(
                name: "ReviewProducts");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AuthUsers");

            migrationBuilder.DropTable(
                name: "MetadataValues");

            migrationBuilder.DropTable(
                name: "MetadataTypes");
        }
    }
}
