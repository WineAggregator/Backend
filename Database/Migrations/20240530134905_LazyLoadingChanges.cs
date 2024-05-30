using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Database.Migrations
{
    /// <inheritdoc />
    public partial class LazyLoadingChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Photos_PreviewPhotoIdId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_EventsPhoto_Events_EventId",
                table: "EventsPhoto");

            migrationBuilder.DropForeignKey(
                name: "FK_EventsPhoto_Photos_PhotoId",
                table: "EventsPhoto");

            migrationBuilder.RenameColumn(
                name: "PreviewPhotoIdId",
                table: "Events",
                newName: "PreviewPhotoId");

            migrationBuilder.RenameIndex(
                name: "IX_Events_PreviewPhotoIdId",
                table: "Events",
                newName: "IX_Events_PreviewPhotoId");

            migrationBuilder.AlterColumn<int>(
                name: "PhotoId",
                table: "EventsPhoto",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "EventsPhoto",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Photos_PreviewPhotoId",
                table: "Events",
                column: "PreviewPhotoId",
                principalTable: "Photos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EventsPhoto_Events_EventId",
                table: "EventsPhoto",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EventsPhoto_Photos_PhotoId",
                table: "EventsPhoto",
                column: "PhotoId",
                principalTable: "Photos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Photos_PreviewPhotoId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_EventsPhoto_Events_EventId",
                table: "EventsPhoto");

            migrationBuilder.DropForeignKey(
                name: "FK_EventsPhoto_Photos_PhotoId",
                table: "EventsPhoto");

            migrationBuilder.RenameColumn(
                name: "PreviewPhotoId",
                table: "Events",
                newName: "PreviewPhotoIdId");

            migrationBuilder.RenameIndex(
                name: "IX_Events_PreviewPhotoId",
                table: "Events",
                newName: "IX_Events_PreviewPhotoIdId");

            migrationBuilder.AlterColumn<int>(
                name: "PhotoId",
                table: "EventsPhoto",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "EventsPhoto",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Photos_PreviewPhotoIdId",
                table: "Events",
                column: "PreviewPhotoIdId",
                principalTable: "Photos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EventsPhoto_Events_EventId",
                table: "EventsPhoto",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventsPhoto_Photos_PhotoId",
                table: "EventsPhoto",
                column: "PhotoId",
                principalTable: "Photos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
