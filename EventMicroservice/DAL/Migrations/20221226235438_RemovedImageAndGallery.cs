using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EventMicroservice.Migrations
{
    /// <inheritdoc />
    public partial class RemovedImageAndGallery : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Galleries");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Galleries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EventId = table.Column<int>(type: "integer", nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Galleries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Galleries_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Galleries_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GalleryId = table.Column<int>(type: "integer", nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Galleries_GalleryId",
                        column: x => x.GalleryId,
                        principalTable: "Galleries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Images_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Galleries",
                columns: new[] { "Id", "EventId", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "gallery1", 1 },
                    { 2, 2, "gallery2", 1 },
                    { 3, 3, "gallery3", 1 },
                    { 4, 4, "gallery4", 1 },
                    { 5, 5, "gallery5", 2 },
                    { 6, 6, "gallery6", 2 },
                    { 7, 7, "gallery7", 2 },
                    { 8, 8, "gallery8", 3 },
                    { 9, 9, "gallery9", 3 },
                    { 10, 10, "gallery10", 3 }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "GalleryId", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "https://i.pinimg.com/originals/9b/e8/2e/9be82e85e85622adb810430a9a7aa9fe.jpg", 1 },
                    { 2, 1, "https://i.pinimg.com/originals/ab/c7/c5/abc7c5db1d161b0f5fbf6188e5ad47d1.jpg", 1 },
                    { 3, 1, "https://i.pinimg.com/564x/a8/7e/28/a87e28a37a1d992bc9e8f0ffeed70710.jpg", 2 },
                    { 4, 1, "https://i.pinimg.com/originals/cf/d8/f9/cfd8f9ba699d12fb9fbef34e6a941170.jpg", 2 },
                    { 5, 1, "https://i.pinimg.com/564x/42/70/b9/4270b97ec5499a420ff280beae4acd30.jpg", 3 },
                    { 6, 2, "https://i.pinimg.com/originals/2b/ae/f6/2baef6acf1db6d5f95ae43e9aa6ce4a3.jpg", 1 },
                    { 7, 2, "https://img.thesitebase.net/10224/10224026/products/0x900@16509464296105fa6630.jpeg", 1 },
                    { 8, 2, "http://www.lemky.com/uploads/posts/2009-06/1245182997_8.jpg", 3 },
                    { 9, 1, "https://i.pinimg.com/564x/dc/10/8e/dc108e35b06672104ac2e9b0996b8241.jpg", 3 },
                    { 10, 3, "https://i.pinimg.com/originals/7c/a8/59/7ca85929f1c6a7a56b9ae3633967260c.jpg", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Galleries_EventId",
                table: "Galleries",
                column: "EventId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Galleries_Name",
                table: "Galleries",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Galleries_UserId",
                table: "Galleries",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_GalleryId",
                table: "Images",
                column: "GalleryId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_Name",
                table: "Images",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_UserId",
                table: "Images",
                column: "UserId");
        }
    }
}
