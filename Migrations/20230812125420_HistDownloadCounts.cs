using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModStats.API.Migrations
{
    /// <inheritdoc />
    public partial class HistDownloadCounts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "DownloadCount",
                table: "mods_supported_platforms",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "hist_download_count",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ModId = table.Column<Guid>(type: "uuid", nullable: false),
                    PlatformId = table.Column<Guid>(type: "uuid", nullable: false),
                    Data = table.Column<double>(type: "double precision", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hist_download_count", x => x.Id);
                    table.ForeignKey(
                        name: "FK_hist_download_count_mods_ModId",
                        column: x => x.ModId,
                        principalTable: "mods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_hist_download_count_platforms_PlatformId",
                        column: x => x.PlatformId,
                        principalTable: "platforms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "mod_loaders",
                keyColumn: "Id",
                keyValue: new Guid("091297f2-1ecd-45c2-8015-c1a4090d487b"),
                column: "CreatedAt",
                value: new DateTime(2023, 8, 12, 12, 54, 20, 72, DateTimeKind.Utc).AddTicks(7680));

            migrationBuilder.UpdateData(
                table: "mod_loaders",
                keyColumn: "Id",
                keyValue: new Guid("e437a393-d4b4-4d87-861b-2a47227c12df"),
                column: "CreatedAt",
                value: new DateTime(2023, 8, 12, 12, 54, 20, 72, DateTimeKind.Utc).AddTicks(7688));

            migrationBuilder.UpdateData(
                table: "mod_loaders",
                keyColumn: "Id",
                keyValue: new Guid("ea89d266-b6de-493a-b076-8e5e86142375"),
                column: "CreatedAt",
                value: new DateTime(2023, 8, 12, 12, 54, 20, 72, DateTimeKind.Utc).AddTicks(7657));

            migrationBuilder.UpdateData(
                table: "mod_loaders",
                keyColumn: "Id",
                keyValue: new Guid("f92fbda0-a69b-427c-8352-89eeb1772d7d"),
                column: "CreatedAt",
                value: new DateTime(2023, 8, 12, 12, 54, 20, 72, DateTimeKind.Utc).AddTicks(7685));

            migrationBuilder.UpdateData(
                table: "platforms",
                keyColumn: "Id",
                keyValue: new Guid("b6912369-4d45-422a-a238-b13983e9c435"),
                column: "CreatedAt",
                value: new DateTime(2023, 8, 12, 12, 54, 20, 72, DateTimeKind.Utc).AddTicks(8229));

            migrationBuilder.UpdateData(
                table: "platforms",
                keyColumn: "Id",
                keyValue: new Guid("ca1af69d-0961-491f-9fc0-f633313c8eab"),
                column: "CreatedAt",
                value: new DateTime(2023, 8, 12, 12, 54, 20, 72, DateTimeKind.Utc).AddTicks(8203));

            migrationBuilder.CreateIndex(
                name: "IX_hist_download_count_ModId",
                table: "hist_download_count",
                column: "ModId");

            migrationBuilder.CreateIndex(
                name: "IX_hist_download_count_PlatformId",
                table: "hist_download_count",
                column: "PlatformId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "hist_download_count");

            migrationBuilder.DropColumn(
                name: "DownloadCount",
                table: "mods_supported_platforms");

            migrationBuilder.UpdateData(
                table: "mod_loaders",
                keyColumn: "Id",
                keyValue: new Guid("091297f2-1ecd-45c2-8015-c1a4090d487b"),
                column: "CreatedAt",
                value: new DateTime(2023, 8, 12, 12, 1, 31, 287, DateTimeKind.Utc).AddTicks(8757));

            migrationBuilder.UpdateData(
                table: "mod_loaders",
                keyColumn: "Id",
                keyValue: new Guid("e437a393-d4b4-4d87-861b-2a47227c12df"),
                column: "CreatedAt",
                value: new DateTime(2023, 8, 12, 12, 1, 31, 287, DateTimeKind.Utc).AddTicks(8764));

            migrationBuilder.UpdateData(
                table: "mod_loaders",
                keyColumn: "Id",
                keyValue: new Guid("ea89d266-b6de-493a-b076-8e5e86142375"),
                column: "CreatedAt",
                value: new DateTime(2023, 8, 12, 12, 1, 31, 287, DateTimeKind.Utc).AddTicks(8716));

            migrationBuilder.UpdateData(
                table: "mod_loaders",
                keyColumn: "Id",
                keyValue: new Guid("f92fbda0-a69b-427c-8352-89eeb1772d7d"),
                column: "CreatedAt",
                value: new DateTime(2023, 8, 12, 12, 1, 31, 287, DateTimeKind.Utc).AddTicks(8761));

            migrationBuilder.UpdateData(
                table: "platforms",
                keyColumn: "Id",
                keyValue: new Guid("b6912369-4d45-422a-a238-b13983e9c435"),
                column: "CreatedAt",
                value: new DateTime(2023, 8, 12, 12, 1, 31, 288, DateTimeKind.Utc).AddTicks(173));

            migrationBuilder.UpdateData(
                table: "platforms",
                keyColumn: "Id",
                keyValue: new Guid("ca1af69d-0961-491f-9fc0-f633313c8eab"),
                column: "CreatedAt",
                value: new DateTime(2023, 8, 12, 12, 1, 31, 288, DateTimeKind.Utc).AddTicks(161));
        }
    }
}
