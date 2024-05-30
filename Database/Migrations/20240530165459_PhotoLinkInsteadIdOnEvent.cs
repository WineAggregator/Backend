using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Database.Migrations
{
    /// <inheritdoc />
    public partial class PhotoLinkInsteadIdOnEvent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Photos_PreviewPhotoId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_PreviewPhotoId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "PreviewPhotoId",
                table: "Events");

            migrationBuilder.AddColumn<string>(
                name: "PreviewPhotoLink",
                table: "Events",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PreviewPhotoLink",
                table: "Events");

            migrationBuilder.AddColumn<int>(
                name: "PreviewPhotoId",
                table: "Events",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Events_PreviewPhotoId",
                table: "Events",
                column: "PreviewPhotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Photos_PreviewPhotoId",
                table: "Events",
                column: "PreviewPhotoId",
                principalTable: "Photos",
                principalColumn: "Id");
        }
    }
}
