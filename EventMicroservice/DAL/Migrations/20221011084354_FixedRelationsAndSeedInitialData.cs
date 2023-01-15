using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EventMicroservice.Migrations
{
    /// <inheritdoc />
    public partial class FixedRelationsAndSeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventUser_Events_EventsId",
                table: "EventUser");

            migrationBuilder.DropForeignKey(
                name: "FK_EventUser_Users_Usersid",
                table: "EventUser");

            migrationBuilder.DropTable(
                name: "CategoryEvent");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "GalleryId",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Roles",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Usersid",
                table: "EventUser",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "EventsId",
                table: "EventUser",
                newName: "EventId");

            migrationBuilder.RenameIndex(
                name: "IX_EventUser_Usersid",
                table: "EventUser",
                newName: "IX_EventUser_UserId");

            migrationBuilder.CreateTable(
                name: "EventCategory",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    EventId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventCategory", x => new { x.CategoryId, x.EventId });
                    table.ForeignKey(
                        name: "FK_EventCategory_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventCategory_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Family" },
                    { 2, "Game industry" },
                    { 3, "Stand up" },
                    { 4, "Nature" },
                    { 5, "Health" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Ukraine" },
                    { 2, "Spain" },
                    { 3, "Italy" },
                    { 4, "Poland" },
                    { 5, "Germany" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "ADMIN" },
                    { 2, "MODERATOR" },
                    { 3, "USER" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 1, 4, "Lodz" },
                    { 2, 4, "Poznan" },
                    { 3, 4, "Warszawa" },
                    { 4, 4, "Lublin" },
                    { 5, 4, "Krakow" },
                    { 6, 5, "Berlin" },
                    { 7, 5, "Hannover" },
                    { 8, 5, "Amsterdam" },
                    { 9, 5, "Hamburg" },
                    { 10, 5, "Shuttgart" },
                    { 11, 3, "Roma" },
                    { 12, 3, "Firenze" },
                    { 13, 3, "Bologna" },
                    { 14, 3, "Genova" },
                    { 15, 3, "Milano" },
                    { 16, 2, "Madrid" },
                    { 17, 2, "Sevilla" },
                    { 18, 2, "Valencia" },
                    { 19, 2, "Zaragoza" },
                    { 20, 2, "Barcelona" },
                    { 21, 1, "Krimea" },
                    { 22, 1, "Chernihiv" },
                    { 23, 1, "Chornobaivka" },
                    { 24, 1, "Chernivtsi" },
                    { 25, 1, "Vinnytsia" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "CityId", "CountryId", "Name" },
                values: new object[,]
                {
                    { 1, 24, 1, "Domestic Violence" },
                    { 2, 24, 1, "Love is the basis of life" },
                    { 3, 23, 1, "Global Gaming Expo 2022" },
                    { 4, 23, 1, "Sweden Game Conference 2022" },
                    { 5, 22, 1, "SBC Summit CIS 2022" },
                    { 6, 16, 2, "International Stand Up Comedy" },
                    { 7, 16, 2, "Cancel Culture Comedy" },
                    { 8, 16, 2, "Failing in Love" },
                    { 9, 15, 3, "Earth Day 2022" },
                    { 10, 15, 3, "Sounds at Sunset Concert Series" },
                    { 11, 15, 3, "Playscape Mondays" },
                    { 12, 15, 3, "Folk & Roots" },
                    { 13, 15, 3, "Annual Migration Festival" },
                    { 14, 2, 4, "Chronic Disease and Self-Help Program Lay Leader Training" },
                    { 15, 10, 5, "AI & Medical Imaging" },
                    { 16, 10, 5, "Duitslanddag" },
                    { 17, 6, 5, "Emerging Technologies in Health" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "CountryId", "Email", "FirstName", "Password", "Phone", "RoleId", "SecondName" },
                values: new object[,]
                {
                    { 1, 24, 1, "qwer@gmail.com", "Esmaralda", "qwert", "+380991231212", 1, "Voigt" },
                    { 2, 24, 1, "qwerr@gmail.com", "Ostap", "qwert", "+380991231212", 2, "Bleier" },
                    { 3, 24, 1, "qwerrr@gmail.com", "Sophia", "qwert", "+380991231212", 2, "Beringer" },
                    { 4, 23, 1, "qwerrrr@gmail.com", "Marlyn", "qwert", "+380991231212", 3, "Hendry" },
                    { 5, 16, 2, "qwerq@gmail.com", "Vlasi", "qwert", "+380991231212", 3, "Arterberry" },
                    { 6, 15, 3, "qwerqq@gmail.com", "Chasity", "qwert", "+380991231212", 3, "Ilbert" },
                    { 7, 15, 3, "qwerqqq@gmail.com", "Seraphina", "qwert", "+380991231212", 3, "Salmon" },
                    { 8, 2, 4, "qwerw@gmail.com", "Chas", "qwert", "+380991231212", 3, "Hope" },
                    { 9, 6, 5, "qwerww@gmail.com", "Nadezhda", "qwert", "+380991231212", 3, "Haynes" },
                    { 10, 10, 5, "qwerwww@gmail.com", "Sonny", "qwert", "+380991231212", 3, "Gibb" },
                    { 11, 8, 5, "qwere@gmail.com", "Eric", "qwert", "+380991231212", 3, "Lincoln" }
                });

            migrationBuilder.InsertData(
                table: "EventCategory",
                columns: new[] { "CategoryId", "EventId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 3 },
                    { 2, 4 },
                    { 2, 5 },
                    { 3, 6 },
                    { 3, 7 },
                    { 4, 2 },
                    { 4, 8 },
                    { 4, 9 },
                    { 4, 10 },
                    { 4, 11 },
                    { 4, 12 },
                    { 4, 13 },
                    { 5, 2 },
                    { 5, 14 },
                    { 5, 15 },
                    { 5, 16 },
                    { 5, 17 }
                });

            migrationBuilder.InsertData(
                table: "EventUser",
                columns: new[] { "EventId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 1, 5 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 3, 1 },
                    { 4, 1 },
                    { 5, 2 },
                    { 6, 3 },
                    { 7, 4 },
                    { 8, 5 },
                    { 9, 2 },
                    { 10, 3 },
                    { 11, 4 },
                    { 12, 5 },
                    { 13, 3 },
                    { 13, 4 },
                    { 13, 5 },
                    { 14, 5 },
                    { 15, 5 },
                    { 16, 5 },
                    { 17, 5 }
                });

            migrationBuilder.InsertData(
                table: "Galleries",
                columns: new[] { "Id", "EventId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "gallery1" },
                    { 2, 2, "gallery2" },
                    { 3, 3, "gallery3" },
                    { 4, 4, "gallery4" },
                    { 5, 5, "gallery5" },
                    { 6, 6, "gallery6" },
                    { 7, 7, "gallery7" },
                    { 8, 8, "gallery8" },
                    { 9, 9, "gallery9" },
                    { 10, 10, "gallery10" }
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
                name: "IX_EventCategory_EventId",
                table: "EventCategory",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventUser_Events_EventId",
                table: "EventUser",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventUser_Users_UserId",
                table: "EventUser",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventUser_Events_EventId",
                table: "EventUser");

            migrationBuilder.DropForeignKey(
                name: "FK_EventUser_Users_UserId",
                table: "EventUser");

            migrationBuilder.DropTable(
                name: "EventCategory");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "EventUser",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "EventUser",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "EventUser",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "EventUser",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "EventUser",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "EventUser",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "EventUser",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "EventUser",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "EventUser",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "EventUser",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "EventUser",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "EventUser",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 6, 3 });

            migrationBuilder.DeleteData(
                table: "EventUser",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 7, 4 });

            migrationBuilder.DeleteData(
                table: "EventUser",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 8, 5 });

            migrationBuilder.DeleteData(
                table: "EventUser",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 9, 2 });

            migrationBuilder.DeleteData(
                table: "EventUser",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 10, 3 });

            migrationBuilder.DeleteData(
                table: "EventUser",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 11, 4 });

            migrationBuilder.DeleteData(
                table: "EventUser",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 12, 5 });

            migrationBuilder.DeleteData(
                table: "EventUser",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 13, 3 });

            migrationBuilder.DeleteData(
                table: "EventUser",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 13, 4 });

            migrationBuilder.DeleteData(
                table: "EventUser",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 13, 5 });

            migrationBuilder.DeleteData(
                table: "EventUser",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 14, 5 });

            migrationBuilder.DeleteData(
                table: "EventUser",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 15, 5 });

            migrationBuilder.DeleteData(
                table: "EventUser",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 16, 5 });

            migrationBuilder.DeleteData(
                table: "EventUser",
                keyColumns: new[] { "EventId", "UserId" },
                keyValues: new object[] { 17, 5 });

            migrationBuilder.DeleteData(
                table: "Galleries",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Galleries",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Galleries",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Galleries",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Galleries",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Galleries",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Galleries",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Galleries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Galleries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Galleries",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Roles",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "EventUser",
                newName: "Usersid");

            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "EventUser",
                newName: "EventsId");

            migrationBuilder.RenameIndex(
                name: "IX_EventUser_UserId",
                table: "EventUser",
                newName: "IX_EventUser_Usersid");

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Images",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GalleryId",
                table: "Events",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CategoryEvent",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "integer", nullable: false),
                    EventsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryEvent", x => new { x.CategoriesId, x.EventsId });
                    table.ForeignKey(
                        name: "FK_CategoryEvent_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryEvent_Events_EventsId",
                        column: x => x.EventsId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryEvent_EventsId",
                table: "CategoryEvent",
                column: "EventsId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventUser_Events_EventsId",
                table: "EventUser",
                column: "EventsId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventUser_Users_Usersid",
                table: "EventUser",
                column: "Usersid",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
