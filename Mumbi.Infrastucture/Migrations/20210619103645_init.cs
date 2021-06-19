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
                name: "Dad");

            migrationBuilder.DropTable(
                name: "Diary");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "GuidebookMom");

            migrationBuilder.DropTable(
                name: "InjectionSchedule");

            migrationBuilder.DropTable(
                name: "NewsMom");

            migrationBuilder.DropTable(
                name: "PregnancyActivity");

            migrationBuilder.DropTable(
                name: "PregnancyInformation");

            migrationBuilder.DropTable(
                name: "Reminder");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "StandardIndex");

            migrationBuilder.DropTable(
                name: "SymptomVaccine");

            migrationBuilder.DropTable(
                name: "Token");

            migrationBuilder.DropTable(
                name: "ToothChild");

            migrationBuilder.DropTable(
                name: "Action");

            migrationBuilder.DropTable(
                name: "Guidebook");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "PregnancyActivityType");

            migrationBuilder.DropTable(
                name: "Symptom");

            migrationBuilder.DropTable(
                name: "Vaccine");

            migrationBuilder.DropTable(
                name: "Child");

            migrationBuilder.DropTable(
                name: "Tooth");

            migrationBuilder.DropTable(
                name: "GuidebookType");

            migrationBuilder.DropTable(
                name: "NewsType");

            migrationBuilder.DropTable(
                name: "Mom");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
