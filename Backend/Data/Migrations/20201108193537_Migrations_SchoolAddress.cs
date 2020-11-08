using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Migrations_SchoolAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Schools");

            migrationBuilder.AddColumn<string>(
                name: "Address_Lines",
                table: "Schools",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_PostalCode",
                table: "Schools",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_PostalPlace",
                table: "Schools",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address_Lines",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "Address_PostalCode",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "Address_PostalPlace",
                table: "Schools");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Schools",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
