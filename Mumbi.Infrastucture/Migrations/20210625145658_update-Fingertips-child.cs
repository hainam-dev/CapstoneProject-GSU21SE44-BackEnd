using Microsoft.EntityFrameworkCore.Migrations;

namespace Mumbi.Infrastucture.Migrations
{
    public partial class updateFingertipschild : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Fingertips",
                table: "Child",
                type: "int",
                unicode: false,
                maxLength: 10,
                nullable: true,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldUnicode: false,
                oldMaxLength: 10,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Fingertips",
                table: "Child",
                type: "varchar(10)",
                unicode: false,
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldUnicode: false,
                oldMaxLength: 10);
        }
    }
}
