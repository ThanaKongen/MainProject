using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class AddedSpecializationAndFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusinessCustomer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CVR = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    EAN = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    WWW = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    VatCode = table.Column<int>(type: "int", nullable: false),
                    DebitorNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessCustomer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessCustomer_Customer_Id",
                        column: x => x.Id,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerField",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Datatype = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerField", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrivateCustomer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CPR = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    CPRDelete = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrivateCustomer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrivateCustomer_Customer_Id",
                        column: x => x.Id,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompanyCustomerField",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerFieldId = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyCustomerField", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyCustomerField_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyCustomerField_CustomerField_CustomerFieldId",
                        column: x => x.CustomerFieldId,
                        principalTable: "CustomerField",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerFieldValue",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CistomerFieldId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerFieldValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerFieldValue_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerFieldValue_CustomerField_CistomerFieldId",
                        column: x => x.CistomerFieldId,
                        principalTable: "CustomerField",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyCustomerField_CompanyId",
                table: "CompanyCustomerField",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyCustomerField_CustomerFieldId",
                table: "CompanyCustomerField",
                column: "CustomerFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerFieldValue_CistomerFieldId",
                table: "CustomerFieldValue",
                column: "CistomerFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerFieldValue_CustomerId",
                table: "CustomerFieldValue",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessCustomer");

            migrationBuilder.DropTable(
                name: "CompanyCustomerField");

            migrationBuilder.DropTable(
                name: "CustomerFieldValue");

            migrationBuilder.DropTable(
                name: "PrivateCustomer");

            migrationBuilder.DropTable(
                name: "CustomerField");
        }
    }
}
