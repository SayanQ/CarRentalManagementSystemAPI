using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentalManagementSystemAPI.Migrations
{
    /// <inheritdoc />
    public partial class driver : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adhaar_no = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    Pan_No = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Date_Of_Birth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Driving_Licence_No = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Driving_Licence_Valid_Till = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Km_Driven = table.Column<int>(type: "int", nullable: false),
                    Charges_Per_Hour = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drivers");
        }
    }
}
