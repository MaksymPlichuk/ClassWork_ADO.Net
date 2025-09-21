using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _06_EFMigrations.Migrations
{
    /// <inheritdoc />
    public partial class AddedNumberOfListenings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NumberOfListenings",
                table: "Songs",
                type: "nvarchar(150)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 1,
                column: "NumberOfListenings",
                value: "879 702 634");

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 2,
                column: "NumberOfListenings",
                value: "1 523 409 871");

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 3,
                column: "NumberOfListenings",
                value: "985 430 212");

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 4,
                column: "NumberOfListenings",
                value: "213 459 876");

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 5,
                column: "NumberOfListenings",
                value: "54 321 876");

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 6,
                column: "NumberOfListenings",
                value: "632 540 921");

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 7,
                column: "NumberOfListenings",
                value: "784 320 654");

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 8,
                column: "NumberOfListenings",
                value: "456 213 987");

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 9,
                column: "NumberOfListenings",
                value: "19 876 543");

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 10,
                column: "NumberOfListenings",
                value: "3 645 098 123");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfListenings",
                table: "Songs");
        }
    }
}
