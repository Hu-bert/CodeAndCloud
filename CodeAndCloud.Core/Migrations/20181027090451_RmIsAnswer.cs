using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeAndCloud.Core.Migrations
{
    public partial class RmIsAnswer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAnswer",
                table: "Contacts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAnswer",
                table: "Contacts",
                nullable: false,
                defaultValue: false);
        }
    }
}
