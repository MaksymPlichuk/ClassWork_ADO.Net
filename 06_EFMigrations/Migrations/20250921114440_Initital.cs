using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace _06_EFMigrations.Migrations
{
    /// <inheritdoc />
    public partial class Initital : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlayLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayLists_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Artists_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Year = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false),
                    ArtistId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Albums_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Albums_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AlbumId = table.Column<int>(type: "int", nullable: false),
                    Length = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Songs_Albums_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Albums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayListSong",
                columns: table => new
                {
                    PlayListsId = table.Column<int>(type: "int", nullable: false),
                    SongsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayListSong", x => new { x.PlayListsId, x.SongsId });
                    table.ForeignKey(
                        name: "FK_PlayListSong_PlayLists_PlayListsId",
                        column: x => x.PlayListsId,
                        principalTable: "PlayLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayListSong_Songs_SongsId",
                        column: x => x.SongsId,
                        principalTable: "Songs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Workout" },
                    { 2, "Chill" },
                    { 3, "Party" },
                    { 4, "Focus" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "USA" },
                    { 2, "UK" },
                    { 3, "Canada" },
                    { 4, "Germany" },
                    { 5, "France" },
                    { 6, "Italy" },
                    { 7, "Spain" },
                    { 8, "Jamaica" },
                    { 9, "Japan" },
                    { 10, "Australia" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Rock" },
                    { 2, "Pop" },
                    { 3, "Jazz" },
                    { 4, "Hip-Hop" },
                    { 5, "Classical" },
                    { 6, "Electronic" },
                    { 7, "Reggae" },
                    { 8, "Metal" },
                    { 9, "Blues" },
                    { 10, "Folk" }
                });

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "Id", "ArtistId", "GenreId", "Name", "Year" },
                values: new object[,]
                {
                    { 1, null, 1, "Abbey Road", new DateTime(1969, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, null, 4, "The Marshall Mathers LP", new DateTime(2000, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, null, 2, "1989", new DateTime(2014, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, null, 3, "Kind of Blue", new DateTime(1959, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, null, 5, "Requiem", new DateTime(1791, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, null, 6, "Discovery", new DateTime(2001, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, null, 7, "Legend", new DateTime(1984, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, null, 8, "Master of Puppets", new DateTime(1986, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, null, 9, "Live at the Regal", new DateTime(1965, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, null, 2, "Divide", new DateTime(2017, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, null, 4, "The Eminem Show", new DateTime(2002, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, null, 4, "Encore", new DateTime(2004, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, null, 2, "Relapse", new DateTime(2009, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, null, 1, "Sgt. Pepper's Lonely Hearts Club Band", new DateTime(1967, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, null, 1, "Revolver", new DateTime(1966, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, null, 2, "Fearless", new DateTime(2008, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "Id", "CountryId", "Name", "Surname" },
                values: new object[,]
                {
                    { 1, 2, "The Beatles", "" },
                    { 2, 1, "Eminem", "Mathers" },
                    { 3, 1, "Taylor", "Swift" },
                    { 4, 1, "Miles", "Davis" },
                    { 5, 9, "Wolfgnag", "Mozart" },
                    { 6, 5, "Daft", "Punk" },
                    { 7, 8, "Bob", "Marley" },
                    { 8, 1, "Metallica", "" },
                    { 9, 1, "B.B. King", "" },
                    { 10, 2, "Ed", "Sheeran" }
                });

            migrationBuilder.InsertData(
                table: "PlayLists",
                columns: new[] { "Id", "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Morning Energy" },
                    { 2, 2, "Evening Relax" },
                    { 3, 3, "Friday Night" },
                    { 4, 4, "Study Beats" }
                });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "AlbumId", "Length", "Name" },
                values: new object[,]
                {
                    { 1, 1, 259, "Come Together" },
                    { 2, 2, 326, "Lose Yourself" },
                    { 3, 3, 231, "Blank Space" },
                    { 4, 4, 545, "So What" },
                    { 5, 5, 720, "Lacrimosa" },
                    { 6, 6, 224, "Harder Better Faster Stronger" },
                    { 7, 7, 270, "No Woman No Cry" },
                    { 8, 8, 515, "Master of Puppets" },
                    { 9, 9, 220, "Sweet Little Angel" },
                    { 10, 10, 240, "Shape of You" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Albums_ArtistId",
                table: "Albums",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Albums_GenreId",
                table: "Albums",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Artists_CountryId",
                table: "Artists",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayLists_CategoryId",
                table: "PlayLists",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayListSong_SongsId",
                table: "PlayListSong",
                column: "SongsId");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_AlbumId",
                table: "Songs",
                column: "AlbumId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayListSong");

            migrationBuilder.DropTable(
                name: "PlayLists");

            migrationBuilder.DropTable(
                name: "Songs");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
