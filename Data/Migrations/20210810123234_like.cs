using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseProject.Data.Migrations
{
    public partial class like : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemMyIdentity",
                columns: table => new
                {
                    WhatLikedId = table.Column<int>(type: "int", nullable: false),
                    WhoLikedId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemMyIdentity", x => new { x.WhatLikedId, x.WhoLikedId });
                    table.ForeignKey(
                        name: "FK_ItemMyIdentity_AspNetUsers_WhoLikedId",
                        column: x => x.WhoLikedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemMyIdentity_Items_WhatLikedId",
                        column: x => x.WhatLikedId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemMyIdentity_WhoLikedId",
                table: "ItemMyIdentity",
                column: "WhoLikedId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemMyIdentity");
        }
    }
}
