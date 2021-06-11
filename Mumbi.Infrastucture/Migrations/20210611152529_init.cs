using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mumbi.Infrastucture.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActionChild");

            migrationBuilder.DropTable(
                name: "Diary");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "Guidebook");

            migrationBuilder.DropTable(
                name: "InjectionSchedule");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "PregnancyActivity");

            migrationBuilder.DropTable(
                name: "PregnancyInformation");

            migrationBuilder.DropTable(
                name: "Reminder");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "Teeth");

            migrationBuilder.DropTable(
                name: "Token");

            migrationBuilder.DropTable(
                name: "Action");

            migrationBuilder.DropTable(
                name: "GuildbookType");

            migrationBuilder.DropTable(
                name: "Vaccine");

            migrationBuilder.DropTable(
                name: "NewsType");

            migrationBuilder.DropTable(
                name: "PregnancyActivityType");

            migrationBuilder.DropTable(
                name: "Child");

            migrationBuilder.DropTable(
                name: "Dad");

            migrationBuilder.DropTable(
                name: "Mom");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
