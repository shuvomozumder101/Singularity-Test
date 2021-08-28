using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeOfficeManagement.Data.Migrations
{
    public partial class blockcoloumnadd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "BlockStutas",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BlockStutas",
                table: "AspNetUsers");
        }
    }
}
