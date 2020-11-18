using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuarterlySalesApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    DateOfHire = table.Column<DateTime>(nullable: false),
                    ManagerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeID);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    SalesID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quarter = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    SalesAmount = table.Column<double>(nullable: false),
                    EmployeeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.SalesID);
                    table.ForeignKey(
                        name: "FK_Sales_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "DateOfBirth", "DateOfHire", "FirstName", "LastName", "ManagerID" },
                values: new object[] { 1, new DateTime(1956, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1995, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ada", "Lovelace", 0 });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "DateOfBirth", "DateOfHire", "FirstName", "LastName", "ManagerID" },
                values: new object[] { 2, new DateTime(1977, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Luigi", "Verminelli", 1 });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "DateOfBirth", "DateOfHire", "FirstName", "LastName", "ManagerID" },
                values: new object[] { 3, new DateTime(1966, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1995, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Carl", "Wheezer", 1 });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "SalesID", "EmployeeID", "Quarter", "SalesAmount", "Year" },
                values: new object[] { 1, 2, 4, 20100.0, 2019 });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "SalesID", "EmployeeID", "Quarter", "SalesAmount", "Year" },
                values: new object[] { 2, 2, 1, 31211.0, 2020 });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "SalesID", "EmployeeID", "Quarter", "SalesAmount", "Year" },
                values: new object[] { 3, 3, 2, 42322.0, 202020 });

            migrationBuilder.CreateIndex(
                name: "IX_Sales_EmployeeID",
                table: "Sales",
                column: "EmployeeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
