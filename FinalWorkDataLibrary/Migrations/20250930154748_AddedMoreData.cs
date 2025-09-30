using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FinalWorkDataLibrary.Migrations
{
    /// <inheritdoc />
    public partial class AddedMoreData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Athletes",
                columns: new[] { "Id", "CountryId", "DateOfBirth", "Name", "PhotoPath", "SportId", "Surname" },
                values: new object[,]
                {
                    { 6, 1, new DateTime(1997, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Katie", "test", 2, "Ledecky" },
                    { 8, 4, new DateTime(1982, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yana", "test", 2, "Klochkova" },
                    { 11, 4, new DateTime(1976, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andriy", "test", 1, "Shevchenko" },
                    { 12, 1, new DateTime(1982, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Natalie", "test", 2, "Coughlin" },
                    { 13, 2, new DateTime(1981, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jan", "test", 1, "Frodeno" },
                    { 16, 4, new DateTime(1996, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mykhailo", "test", 2, "Romanchuk" },
                    { 20, 2, new DateTime(1969, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paul", "test", 1, "Tergat" }
                });

            migrationBuilder.InsertData(
                table: "SportTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 3, "Cycling" },
                    { 4, "Gymnastics" },
                    { 5, "Boxing" },
                    { 6, "Wrestling" },
                    { 7, "Rowing" }
                });

            migrationBuilder.InsertData(
                table: "Results",
                columns: new[] { "Id", "AthleteId", "MedalId", "OlympiadId", "SportId" },
                values: new object[,]
                {
                    { 6, 6, 1, 3, 2 },
                    { 8, 8, 3, 4, 2 },
                    { 11, 11, 3, 3, 1 },
                    { 12, 12, 2, 4, 2 },
                    { 13, 13, 2, 1, 1 },
                    { 16, 16, 1, 4, 2 },
                    { 20, 20, 2, 4, 1 }
                });

            migrationBuilder.InsertData(
                table: "Sports",
                columns: new[] { "Id", "Name", "SportTypeId" },
                values: new object[,]
                {
                    { 3, "Cycling BMX Racing", 3 },
                    { 4, "Artistic Gymnastics", 4 },
                    { 5, "Boxing Lightweight", 5 },
                    { 6, "Greco-Roman Wrestling", 6 },
                    { 7, "Rowing Single Sculls", 7 }
                });

            migrationBuilder.InsertData(
                table: "Athletes",
                columns: new[] { "Id", "CountryId", "DateOfBirth", "Name", "PhotoPath", "SportId", "Surname" },
                values: new object[,]
                {
                    { 4, 1, new DateTime(1997, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Simone", "test", 4, "Biles" },
                    { 5, 4, new DateTime(1987, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Oleksandr", "test", 5, "Usyk" },
                    { 7, 2, new DateTime(1976, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chris", "test", 3, "Hoy" },
                    { 9, 2, new DateTime(1967, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alexander", "test", 6, "Karelin" },
                    { 10, 2, new DateTime(1962, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Steve", "test", 7, "Redgrave" },
                    { 14, 3, new DateTime(1989, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kohei", "test", 4, "Uchimura" },
                    { 15, 1, new DateTime(1971, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rulon", "test", 6, "Gardner" },
                    { 17, 2, new DateTime(1993, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kristina", "test", 3, "Vilhauer" },
                    { 18, 3, new DateTime(1993, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Naoya", "test", 5, "Inoue" },
                    { 19, 4, new DateTime(1989, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Igor", "test", 7, "Tymoshenko" }
                });

            migrationBuilder.InsertData(
                table: "Results",
                columns: new[] { "Id", "AthleteId", "MedalId", "OlympiadId", "SportId" },
                values: new object[,]
                {
                    { 4, 4, 1, 3, 4 },
                    { 5, 5, 1, 4, 5 },
                    { 7, 7, 2, 2, 3 },
                    { 9, 9, 1, 1, 6 },
                    { 10, 10, 1, 2, 7 },
                    { 14, 14, 1, 2, 4 },
                    { 15, 15, 3, 3, 6 },
                    { 17, 17, 2, 1, 3 },
                    { 18, 18, 1, 2, 5 },
                    { 19, 19, 3, 3, 7 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Results",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Results",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Results",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Results",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Results",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Results",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Results",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Results",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Results",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Results",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Results",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Results",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Results",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Results",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Results",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Results",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Results",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Athletes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Athletes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Athletes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Athletes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Athletes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Athletes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Athletes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Athletes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Athletes",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Athletes",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Athletes",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Athletes",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Athletes",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Athletes",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Athletes",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Athletes",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Athletes",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "SportTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SportTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SportTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SportTypes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "SportTypes",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
