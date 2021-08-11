using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseProject.Data.Migrations
{
    public partial class UrlImg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UrlImg",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UrlImg",
                table: "Collections");
        }
    }
}
