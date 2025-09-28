using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FinalWorkDataLibrary.Migrations
{
    /// <inheritdoc />
    public partial class InitialTestData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedalTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedalTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OlympiadTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OlympiadTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SportTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Medals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedalTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medals_MedalTypes_MedalTypeId",
                        column: x => x.MedalTypeId,
                        principalTable: "MedalTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    SportTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sports_SportTypes_SportTypeId",
                        column: x => x.SportTypeId,
                        principalTable: "SportTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Olympiads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    OlympiadTypeId = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Olympiads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Olympiads_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Olympiads_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Olympiads_OlympiadTypes_OlympiadTypeId",
                        column: x => x.OlympiadTypeId,
                        principalTable: "OlympiadTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Athletes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    SportId = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Athletes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Athletes_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Athletes_Sports_SportId",
                        column: x => x.SportId,
                        principalTable: "Sports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OlympiadSportType",
                columns: table => new
                {
                    OlympiadsId = table.Column<int>(type: "int", nullable: false),
                    SportTypesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OlympiadSportType", x => new { x.OlympiadsId, x.SportTypesId });
                    table.ForeignKey(
                        name: "FK_OlympiadSportType_Olympiads_OlympiadsId",
                        column: x => x.OlympiadsId,
                        principalTable: "Olympiads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OlympiadSportType_SportTypes_SportTypesId",
                        column: x => x.SportTypesId,
                        principalTable: "SportTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OlympiadId = table.Column<int>(type: "int", nullable: false),
                    MedalId = table.Column<int>(type: "int", nullable: true),
                    AthleteId = table.Column<int>(type: "int", nullable: false),
                    SportId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Results_Athletes_AthleteId",
                        column: x => x.AthleteId,
                        principalTable: "Athletes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Results_Medals_MedalId",
                        column: x => x.MedalId,
                        principalTable: "Medals",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Results_Olympiads_OlympiadId",
                        column: x => x.OlympiadId,
                        principalTable: "Olympiads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Results_Sports_SportId",
                        column: x => x.SportId,
                        principalTable: "Sports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "USA" },
                    { 2, "Germany" },
                    { 3, "Japan" },
                    { 4, "Ukraine" }
                });

            migrationBuilder.InsertData(
                table: "MedalTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Gold" },
                    { 2, "Silver" },
                    { 3, "Bronze" }
                });

            migrationBuilder.InsertData(
                table: "OlympiadTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Summer" },
                    { 2, "Winter" }
                });

            migrationBuilder.InsertData(
                table: "SportTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Athletics" },
                    { 2, "Swimming" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Los Angeles" },
                    { 2, 2, "Berlin" },
                    { 3, 3, "Tokyo" },
                    { 4, 4, "Kyiv" }
                });

            migrationBuilder.InsertData(
                table: "Medals",
                columns: new[] { "Id", "MedalTypeId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Sports",
                columns: new[] { "Id", "Name", "SportTypeId" },
                values: new object[,]
                {
                    { 1, "100m Sprint", 1 },
                    { 2, "Freestyle Swimming", 2 }
                });

            migrationBuilder.InsertData(
                table: "Athletes",
                columns: new[] { "Id", "CountryId", "DateOfBirth", "Name", "PhotoPath", "SportId", "Surname" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(1986, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Usain", "test", 1, "Bolt" },
                    { 2, 2, new DateTime(1985, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Michael", "test", 2, "Phelps" },
                    { 3, 1, new DateTime(1963, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Serhii", "test", 1, "Bubka" }
                });

            migrationBuilder.InsertData(
                table: "Olympiads",
                columns: new[] { "Id", "CityId", "CountryId", "Name", "OlympiadTypeId", "Year" },
                values: new object[,]
                {
                    { 1, 1, 1, "Los Angeles 2028", 1, 2028 },
                    { 2, 2, 2, "Berlin 1936", 1, 1936 },
                    { 3, 3, 3, "Tokyo 2020", 1, 2020 },
                    { 4, 4, 4, "Kyiv 2032", 2, 2032 }
                });

            migrationBuilder.InsertData(
                table: "Results",
                columns: new[] { "Id", "AthleteId", "MedalId", "OlympiadId", "SportId" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, 1 },
                    { 2, 2, 1, 2, 2 },
                    { 3, 3, 2, 1, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Athletes_CountryId",
                table: "Athletes",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Athletes_SportId",
                table: "Athletes",
                column: "SportId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Medals_MedalTypeId",
                table: "Medals",
                column: "MedalTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Olympiads_CityId",
                table: "Olympiads",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Olympiads_CountryId",
                table: "Olympiads",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Olympiads_OlympiadTypeId",
                table: "Olympiads",
                column: "OlympiadTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OlympiadSportType_SportTypesId",
                table: "OlympiadSportType",
                column: "SportTypesId");

            migrationBuilder.CreateIndex(
                name: "IX_Results_AthleteId",
                table: "Results",
                column: "AthleteId");

            migrationBuilder.CreateIndex(
                name: "IX_Results_MedalId",
                table: "Results",
                column: "MedalId");

            migrationBuilder.CreateIndex(
                name: "IX_Results_OlympiadId",
                table: "Results",
                column: "OlympiadId");

            migrationBuilder.CreateIndex(
                name: "IX_Results_SportId",
                table: "Results",
                column: "SportId");

            migrationBuilder.CreateIndex(
                name: "IX_Sports_SportTypeId",
                table: "Sports",
                column: "SportTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OlympiadSportType");

            migrationBuilder.DropTable(
                name: "Results");

            migrationBuilder.DropTable(
                name: "Athletes");

            migrationBuilder.DropTable(
                name: "Medals");

            migrationBuilder.DropTable(
                name: "Olympiads");

            migrationBuilder.DropTable(
                name: "Sports");

            migrationBuilder.DropTable(
                name: "MedalTypes");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "OlympiadTypes");

            migrationBuilder.DropTable(
                name: "SportTypes");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
