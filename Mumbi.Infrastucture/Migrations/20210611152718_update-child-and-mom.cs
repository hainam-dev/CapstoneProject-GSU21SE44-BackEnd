using Microsoft.EntityFrameworkCore.Migrations;

namespace Mumbi.Infrastucture.Migrations
{
    public partial class updatechildandmom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSingleMom",
                table: "Mom");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Child",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Child");

            migrationBuilder.AddColumn<bool>(
                name: "IsSingleMom",
                table: "Mom",
                type: "bit",
                nullable: true);
        }
    }
}
