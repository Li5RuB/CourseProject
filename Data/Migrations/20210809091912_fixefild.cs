using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseProject.Data.Migrations
{
    public partial class fixefild : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fields");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<bool>(
                name: "Boolean1",
                table: "Items",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Boolean2",
                table: "Items",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Boolean3",
                table: "Items",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date1",
                table: "Items",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Date2",
                table: "Items",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Date3",
                table: "Items",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Integer1",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Integer2",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Integer3",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Line1",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Line2",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Line3",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text1",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text2",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text3",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Boolean1Name",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Boolean2Name",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Boolean3Name",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Date1Name",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Date2Name",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Date3Name",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Integer1Name",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Integer2Name",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Integer3Name",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Line1Name",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Line2Name",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Line3Name",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text1Name",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text2Name",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text3Name",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Boolean1",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Boolean2",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Boolean3",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Date1",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Date2",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Date3",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Integer1",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Integer2",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Integer3",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Line1",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Line2",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Line3",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Text1",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Text2",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Text3",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Boolean1Name",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "Boolean2Name",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "Boolean3Name",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "Date1Name",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "Date2Name",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "Date3Name",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "Integer1Name",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "Integer2Name",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "Integer3Name",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "Line1Name",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "Line2Name",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "Line3Name",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "Text1Name",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "Text2Name",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "Text3Name",
                table: "Collections");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Fields",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CollectionId = table.Column<int>(type: "int", nullable: true),
                    FieldType = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fields_Collections_CollectionId",
                        column: x => x.CollectionId,
                        principalTable: "Collections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Fields_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fields_CollectionId",
                table: "Fields",
                column: "CollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Fields_ItemId",
                table: "Fields",
                column: "ItemId");
        }
    }
}
