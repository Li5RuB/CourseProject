using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseProject.Data.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Collections_TopicId",
                table: "Collections");

            migrationBuilder.CreateIndex(
                name: "IX_Collections_TopicId",
                table: "Collections",
                column: "TopicId",
                unique: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Collections_TopicId",
                table: "Collections");

            migrationBuilder.CreateIndex(
                name: "IX_Collections_TopicId",
                table: "Collections",
                column: "TopicId");
        }
    }
}
