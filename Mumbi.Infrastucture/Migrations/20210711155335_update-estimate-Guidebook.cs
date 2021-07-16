using Microsoft.EntityFrameworkCore.Migrations;

namespace Mumbi.Infrastucture.Migrations
{
    public partial class updateestimateGuidebook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EstimatedFinishTime",
                table: "Guidebook",
                newName: "EstimateFinishTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EstimateFinishTime",
                table: "Guidebook",
                newName: "EstimatedFinishTime");
        }
    }
}
