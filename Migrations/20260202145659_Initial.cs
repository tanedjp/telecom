using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace telecom.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "telecom");

            migrationBuilder.CreateTable(
                name: "customer",
                schema: "telecom",
                columns: table => new
                {
                    customer_uid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    customer_first_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    customer_last_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone_number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    main_addr_no = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    main_addr_building = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    main_addr_soi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    main_addr_moo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    main_addr_province = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    main_addr_district = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    main_addr_sub_district = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    main_addr_postcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_main_doc = table.Column<bool>(type: "bit", nullable: true),
                    doc_addr_no = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    doc_addr_building = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    doc_addr_soi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    doc_addr_moo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    doc_addr_province = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    doc_addr_district = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    doc_addr_sub_district = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    doc_addr_postcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    register_package_uid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer", x => x.customer_uid);
                });

            migrationBuilder.CreateTable(
                name: "package",
                schema: "telecom",
                columns: table => new
                {
                    package_uid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    package_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    phone_limit = table.Column<int>(type: "int", nullable: true),
                    internet_limit = table.Column<int>(type: "int", nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_package", x => x.package_uid);
                });

            migrationBuilder.CreateTable(
                name: "register_package",
                schema: "telecom",
                columns: table => new
                {
                    register_package_uid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    customer_uid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    package_uid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    register_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    expired_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_register_package", x => x.register_package_uid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customer",
                schema: "telecom");

            migrationBuilder.DropTable(
                name: "package",
                schema: "telecom");

            migrationBuilder.DropTable(
                name: "register_package",
                schema: "telecom");
        }
    }
}
