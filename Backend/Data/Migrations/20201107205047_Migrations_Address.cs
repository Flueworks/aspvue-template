using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Migrations_Address : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address_Lines",
                table: "Teachers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_PostalCode",
                table: "Teachers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_PostalPlace",
                table: "Teachers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Lines",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_PostalCode",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_PostalPlace",
                table: "Students",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address_Lines",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Address_PostalCode",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Address_PostalPlace",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Address_Lines",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Address_PostalCode",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Address_PostalPlace",
                table: "Students");
        }
    }
}
