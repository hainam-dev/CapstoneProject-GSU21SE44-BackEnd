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
                name: "Action_Child");

            migrationBuilder.DropTable(
                name: "Child_History");

            migrationBuilder.DropTable(
                name: "Dad_Info");

            migrationBuilder.DropTable(
                name: "Diary");

            migrationBuilder.DropTable(
                name: "Guidebook_Mom");

            migrationBuilder.DropTable(
                name: "InjectionSchedule");

            migrationBuilder.DropTable(
                name: "News_Mom");

            migrationBuilder.DropTable(
                name: "Pregnancy_Info");

            migrationBuilder.DropTable(
                name: "PregnancyActivity");

            migrationBuilder.DropTable(
                name: "Reminder");

            migrationBuilder.DropTable(
                name: "StandardIndex");

            migrationBuilder.DropTable(
                name: "Token");

            migrationBuilder.DropTable(
                name: "Tooth");

            migrationBuilder.DropTable(
                name: "User_Info");

            migrationBuilder.DropTable(
                name: "UsersNotification");

            migrationBuilder.DropTable(
                name: "Action");

            migrationBuilder.DropTable(
                name: "Guidebook");

            migrationBuilder.DropTable(
                name: "Vaccine");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "PregnancyActivity_Type");

            migrationBuilder.DropTable(
                name: "Child_Info");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "Guidebook_Type");

            migrationBuilder.DropTable(
                name: "News_Type");

            migrationBuilder.DropTable(
                name: "Mom_Info");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
