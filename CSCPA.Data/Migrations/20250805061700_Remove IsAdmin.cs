using Microsoft.EntityFrameworkCore.Migrations;

namespace CSCPA.Data.Migrations
{
    public partial class RemoveIsAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "BDGReport");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "BDGReport",
                type: "bit",
                nullable: true,
                defaultValueSql: "((0))");
        }
    }
}
