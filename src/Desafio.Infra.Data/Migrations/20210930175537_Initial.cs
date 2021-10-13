using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Desafio.Infra.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PublicPlace = table.Column<string>(type: "varchar(200)", nullable: false),
                    Number = table.Column<string>(type: "varchar(50)", nullable: false),
                    Complement = table.Column<string>(type: "varchar(250)", nullable: true),
                    ZipCode = table.Column<string>(type: "varchar(8)", nullable: false),
                    District = table.Column<string>(type: "varchar(100)", nullable: false),
                    City = table.Column<string>(type: "varchar(100)", nullable: false),
                    State = table.Column<string>(type: "varchar(50)", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    Profit = table.Column<double>(type: "float", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", nullable: false),
                    Document = table.Column<string>(type: "varchar(14)", nullable: false),
                    TypeSupplier = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Supplier_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SupplierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "varchar(1000)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SalePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", nullable: false),
                    Image = table.Column<string>(type: "varchar(100)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Supplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "DateCreate", "Name", "Profit" },
                values: new object[,]
                {
                    { new Guid("76c8b704-bbff-4534-b71e-e58d1ffdd54f"), new DateTime(2021, 9, 30, 14, 55, 35, 958, DateTimeKind.Local).AddTicks(1786), "Bebida", 2.5 },
                    { new Guid("c5c1ffdd-922b-4151-9151-20a7cbd7d537"), new DateTime(2021, 9, 30, 14, 55, 35, 961, DateTimeKind.Local).AddTicks(8059), "Alimento", 1.5 },
                    { new Guid("9b503da9-eec2-4be4-8085-99d651d0496c"), new DateTime(2021, 9, 30, 14, 55, 35, 961, DateTimeKind.Local).AddTicks(8218), "Brinquedo", 1.0 },
                    { new Guid("3185fbee-3c97-4aec-8e19-ef4df3cb4060"), new DateTime(2021, 9, 30, 14, 55, 35, 961, DateTimeKind.Local).AddTicks(8252), "Limpeza", 3.5 },
                    { new Guid("eb153cfb-2b72-4a07-a4da-ec47a1cfb8e2"), new DateTime(2021, 9, 30, 14, 55, 35, 961, DateTimeKind.Local).AddTicks(8260), "Papelaria", 0.5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_SupplierId",
                table: "Product",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_AddressId",
                table: "Supplier",
                column: "AddressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
