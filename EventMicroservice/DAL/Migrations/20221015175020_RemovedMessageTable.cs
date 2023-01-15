using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EventMicroservice.Migrations
{
    /// <inheritdoc />
    public partial class RemovedMessageTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EventId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Messages_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "CreatedAt", "EventId", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2018, 4, 10, 7, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 2, new DateTime(2018, 5, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 3, new DateTime(2019, 4, 26, 16, 0, 0, 0, DateTimeKind.Unspecified), 2, 1 },
                    { 4, new DateTime(2019, 5, 26, 16, 0, 0, 0, DateTimeKind.Unspecified), 3, 2 },
                    { 5, new DateTime(2022, 10, 9, 11, 0, 5, 0, DateTimeKind.Unspecified), 4, 2 },
                    { 6, new DateTime(2022, 10, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), 5, 3 },
                    { 7, new DateTime(2022, 10, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), 6, 4 },
                    { 8, new DateTime(2022, 10, 10, 10, 0, 0, 0, DateTimeKind.Unspecified), 7, 5 },
                    { 9, new DateTime(2022, 10, 10, 11, 0, 0, 0, DateTimeKind.Unspecified), 8, 6 },
                    { 10, new DateTime(2022, 10, 10, 12, 0, 0, 0, DateTimeKind.Unspecified), 9, 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_EventId",
                table: "Messages",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UserId",
                table: "Messages",
                column: "UserId");
        }
    }
}
