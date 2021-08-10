using Microsoft.EntityFrameworkCore.Migrations;

namespace Square.Migrations
{
    public partial class DeleteCascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Points_Lists_ListId",
                table: "Points");

            migrationBuilder.AddForeignKey(
                name: "FK_Points_Lists_ListId",
                table: "Points",
                column: "ListId",
                principalTable: "Lists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Points_Lists_ListId",
                table: "Points");

            migrationBuilder.AddForeignKey(
                name: "FK_Points_Lists_ListId",
                table: "Points",
                column: "ListId",
                principalTable: "Lists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
