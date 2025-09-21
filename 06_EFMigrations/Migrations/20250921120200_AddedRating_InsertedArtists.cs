using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _06_EFMigrations.Migrations
{
    /// <inheritdoc />
    public partial class AddedRating_InsertedArtists : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Artists_ArtistId",
                table: "Albums");

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "Songs",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<int>(
                name: "ArtistId",
                table: "Albums",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "Albums",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ArtistId", "Rating" },
                values: new object[] { 1, 6.2000000000000002 });

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ArtistId", "Rating" },
                values: new object[] { 2, 8.9000000000000004 });

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ArtistId", "Rating" },
                values: new object[] { 3, 7.7999999999999998 });

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ArtistId", "Rating" },
                values: new object[] { 4, 10.0 });

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ArtistId", "Rating" },
                values: new object[] { 5, 9.8000000000000007 });

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ArtistId", "Rating" },
                values: new object[] { 6, 10.0 });

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ArtistId", "Rating" },
                values: new object[] { 7, 9.4000000000000004 });

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ArtistId", "Rating" },
                values: new object[] { 8, 9.6999999999999993 });

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ArtistId", "Rating" },
                values: new object[] { 9, 9.0999999999999996 });

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ArtistId", "Rating" },
                values: new object[] { 10, 8.3000000000000007 });

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ArtistId", "Rating" },
                values: new object[] { 2, 9.0 });

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ArtistId", "Rating" },
                values: new object[] { 2, 7.5 });

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ArtistId", "GenreId", "Rating" },
                values: new object[] { 2, 4, 7.2000000000000002 });

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ArtistId", "Rating" },
                values: new object[] { 1, 9.9000000000000004 });

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "ArtistId", "Rating" },
                values: new object[] { 1, 9.5 });

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "ArtistId", "Rating" },
                values: new object[] { 3, 8.6999999999999993 });

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 1,
                column: "Rating",
                value: 8.9000000000000004);

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 2,
                column: "Rating",
                value: 10.0);

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 3,
                column: "Rating",
                value: 4.7999999999999998);

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 4,
                column: "Rating",
                value: 3.6000000000000001);

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 5,
                column: "Rating",
                value: 7.0999999999999996);

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 6,
                column: "Rating",
                value: 4.4000000000000004);

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 7,
                column: "Rating",
                value: 6.7999999999999998);

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 8,
                column: "Rating",
                value: 9.1999999999999993);

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 9,
                column: "Rating",
                value: 2.5);

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 10,
                column: "Rating",
                value: 7.2999999999999998);

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Artists_ArtistId",
                table: "Albums",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Artists_ArtistId",
                table: "Albums");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Albums");

            migrationBuilder.AlterColumn<int>(
                name: "ArtistId",
                table: "Albums",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 1,
                column: "ArtistId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 2,
                column: "ArtistId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 3,
                column: "ArtistId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 4,
                column: "ArtistId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 5,
                column: "ArtistId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 6,
                column: "ArtistId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 7,
                column: "ArtistId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 8,
                column: "ArtistId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 9,
                column: "ArtistId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 10,
                column: "ArtistId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 11,
                column: "ArtistId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 12,
                column: "ArtistId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ArtistId", "GenreId" },
                values: new object[] { null, 2 });

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 14,
                column: "ArtistId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 15,
                column: "ArtistId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 16,
                column: "ArtistId",
                value: null);

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Artists_ArtistId",
                table: "Albums",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id");
        }
    }
}
