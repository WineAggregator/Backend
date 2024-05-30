using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Backend.Database.Migrations
{
    /// <inheritdoc />
    public partial class ForgottenTablesMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Organizer_OrganizerId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Photo_PreviewPhotoIdId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Organizer_User_UserId",
                table: "Organizer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Photo",
                table: "Photo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Organizer",
                table: "Organizer");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Photo",
                newName: "Photos");

            migrationBuilder.RenameTable(
                name: "Organizer",
                newName: "Organizers");

            migrationBuilder.RenameIndex(
                name: "IX_Organizer_UserId",
                table: "Organizers",
                newName: "IX_Organizers_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Photos",
                table: "Photos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Organizers",
                table: "Organizers",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "EventsPhoto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EventId = table.Column<int>(type: "integer", nullable: false),
                    PhotoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventsPhoto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventsPhoto_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventsPhoto_Photos_PhotoId",
                        column: x => x.PhotoId,
                        principalTable: "Photos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventsPhoto_EventId",
                table: "EventsPhoto",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventsPhoto_PhotoId",
                table: "EventsPhoto",
                column: "PhotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Organizers_OrganizerId",
                table: "Events",
                column: "OrganizerId",
                principalTable: "Organizers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Photos_PreviewPhotoIdId",
                table: "Events",
                column: "PreviewPhotoIdId",
                principalTable: "Photos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Organizers_Users_UserId",
                table: "Organizers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Organizers_OrganizerId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Photos_PreviewPhotoIdId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Organizers_Users_UserId",
                table: "Organizers");

            migrationBuilder.DropTable(
                name: "EventsPhoto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Photos",
                table: "Photos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Organizers",
                table: "Organizers");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "Photos",
                newName: "Photo");

            migrationBuilder.RenameTable(
                name: "Organizers",
                newName: "Organizer");

            migrationBuilder.RenameIndex(
                name: "IX_Organizers_UserId",
                table: "Organizer",
                newName: "IX_Organizer_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Photo",
                table: "Photo",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Organizer",
                table: "Organizer",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Organizer_OrganizerId",
                table: "Events",
                column: "OrganizerId",
                principalTable: "Organizer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Photo_PreviewPhotoIdId",
                table: "Events",
                column: "PreviewPhotoIdId",
                principalTable: "Photo",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Organizer_User_UserId",
                table: "Organizer",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
