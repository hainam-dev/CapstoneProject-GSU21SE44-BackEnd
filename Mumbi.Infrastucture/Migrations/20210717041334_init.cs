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
                name: "Activity");

            migrationBuilder.DropTable(
                name: "ChildHistory");

            migrationBuilder.DropTable(
                name: "DadInfo");

            migrationBuilder.DropTable(
                name: "Diary");

            migrationBuilder.DropTable(
                name: "GuidebookMom");

            migrationBuilder.DropTable(
                name: "InjectionSchedule");

            migrationBuilder.DropTable(
                name: "NewsMom");

            migrationBuilder.DropTable(
                name: "PregnancyHistory");

            migrationBuilder.DropTable(
                name: "Reminder");

            migrationBuilder.DropTable(
                name: "StandardIndex");

            migrationBuilder.DropTable(
                name: "Token");

            migrationBuilder.DropTable(
                name: "Tooth");

            migrationBuilder.DropTable(
                name: "UserInfo");

            migrationBuilder.DropTable(
                name: "UserNotification");

            migrationBuilder.DropTable(
                name: "Vaccine");

            migrationBuilder.DropTable(
                name: "Action");

            migrationBuilder.DropTable(
                name: "ActivityType");

            migrationBuilder.DropTable(
                name: "Guidebook");

            migrationBuilder.DropTable(
                name: "InjectedPerson");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "ChildInfo");

            migrationBuilder.DropTable(
                name: "ToothInfo");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "GuidebookType");

            migrationBuilder.DropTable(
                name: "NewsType");

            migrationBuilder.DropTable(
                name: "MomInfo");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
