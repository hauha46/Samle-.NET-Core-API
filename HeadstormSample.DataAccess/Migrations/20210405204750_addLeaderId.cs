using Microsoft.EntityFrameworkCore.Migrations;

namespace HeadstormSample.DataAccess.Migrations
{
    public partial class addLeaderId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LeaderId",
                table: "SIGs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LeaderId",
                table: "SIGs");
        }
    }
}
