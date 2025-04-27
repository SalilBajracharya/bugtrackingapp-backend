using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BugTracking.Api.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedBugProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bugs_AspNetUsers_CreatedById",
                table: "Bugs");

            migrationBuilder.DropColumn(
                name: "AssignedToId",
                table: "Bugs");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                table: "Bugs",
                newName: "ReporterId");

            migrationBuilder.RenameIndex(
                name: "IX_Bugs_CreatedById",
                table: "Bugs",
                newName: "IX_Bugs_ReporterId");

            migrationBuilder.AddColumn<string>(
                name: "DeveloperId",
                table: "Bugs",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bugs_DeveloperId",
                table: "Bugs",
                column: "DeveloperId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bugs_AspNetUsers_DeveloperId",
                table: "Bugs",
                column: "DeveloperId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bugs_AspNetUsers_ReporterId",
                table: "Bugs",
                column: "ReporterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bugs_AspNetUsers_DeveloperId",
                table: "Bugs");

            migrationBuilder.DropForeignKey(
                name: "FK_Bugs_AspNetUsers_ReporterId",
                table: "Bugs");

            migrationBuilder.DropIndex(
                name: "IX_Bugs_DeveloperId",
                table: "Bugs");

            migrationBuilder.DropColumn(
                name: "DeveloperId",
                table: "Bugs");

            migrationBuilder.RenameColumn(
                name: "ReporterId",
                table: "Bugs",
                newName: "CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_Bugs_ReporterId",
                table: "Bugs",
                newName: "IX_Bugs_CreatedById");

            migrationBuilder.AddColumn<string>(
                name: "AssignedToId",
                table: "Bugs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bugs_AspNetUsers_CreatedById",
                table: "Bugs",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
