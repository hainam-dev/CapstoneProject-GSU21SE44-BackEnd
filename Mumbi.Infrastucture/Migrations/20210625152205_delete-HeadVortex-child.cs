using Microsoft.EntityFrameworkCore.Migrations;

namespace Mumbi.Infrastucture.Migrations
{
    public partial class deleteHeadVortexchild : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HeadVortex",
                table: "Child");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HeadVortex",
                table: "Child",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
