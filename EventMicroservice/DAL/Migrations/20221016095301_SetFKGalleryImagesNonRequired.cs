using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventMicroservice.Migrations
{
    /// <inheritdoc />
    public partial class SetFKGalleryImagesNonRequired : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Galleries_GalleryId",
                table: "Images");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Galleries_GalleryId",
                table: "Images",
                column: "GalleryId",
                principalTable: "Galleries",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Galleries_GalleryId",
                table: "Images");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Galleries_GalleryId",
                table: "Images",
                column: "GalleryId",
                principalTable: "Galleries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
