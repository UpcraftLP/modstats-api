using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModStats.API.Migrations
{
    /// <inheritdoc />
    public partial class HistSupportedVersions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SupportedVersionsSnapshotId",
                table: "mc_versions",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "hist_supported_versions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModId = table.Column<Guid>(type: "uuid", nullable: false),
                    PlatformId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hist_supported_versions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_hist_supported_versions_mods_ModId",
                        column: x => x.ModId,
                        principalTable: "mods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_hist_supported_versions_platforms_PlatformId",
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
                value: new DateTime(2023, 8, 12, 17, 36, 1, 859, DateTimeKind.Utc).AddTicks(5064));

            migrationBuilder.UpdateData(
                table: "mod_loaders",
                keyColumn: "Id",
                keyValue: new Guid("e437a393-d4b4-4d87-861b-2a47227c12df"),
                column: "CreatedAt",
                value: new DateTime(2023, 8, 12, 17, 36, 1, 859, DateTimeKind.Utc).AddTicks(5091));

            migrationBuilder.UpdateData(
                table: "mod_loaders",
                keyColumn: "Id",
                keyValue: new Guid("ea89d266-b6de-493a-b076-8e5e86142375"),
                column: "CreatedAt",
                value: new DateTime(2023, 8, 12, 17, 36, 1, 859, DateTimeKind.Utc).AddTicks(5017));

            migrationBuilder.UpdateData(
                table: "mod_loaders",
                keyColumn: "Id",
                keyValue: new Guid("f92fbda0-a69b-427c-8352-89eeb1772d7d"),
                column: "CreatedAt",
                value: new DateTime(2023, 8, 12, 17, 36, 1, 859, DateTimeKind.Utc).AddTicks(5069));

            migrationBuilder.UpdateData(
                table: "platforms",
                keyColumn: "Id",
                keyValue: new Guid("b6912369-4d45-422a-a238-b13983e9c435"),
                column: "CreatedAt",
                value: new DateTime(2023, 8, 12, 17, 36, 1, 859, DateTimeKind.Utc).AddTicks(6535));

            migrationBuilder.UpdateData(
                table: "platforms",
                keyColumn: "Id",
                keyValue: new Guid("ca1af69d-0961-491f-9fc0-f633313c8eab"),
                column: "CreatedAt",
                value: new DateTime(2023, 8, 12, 17, 36, 1, 859, DateTimeKind.Utc).AddTicks(6520));

            migrationBuilder.CreateIndex(
                name: "IX_mc_versions_SupportedVersionsSnapshotId",
                table: "mc_versions",
                column: "SupportedVersionsSnapshotId");

            migrationBuilder.CreateIndex(
                name: "IX_hist_supported_versions_ModId",
                table: "hist_supported_versions",
                column: "ModId");

            migrationBuilder.CreateIndex(
                name: "IX_hist_supported_versions_PlatformId",
                table: "hist_supported_versions",
                column: "PlatformId");

            migrationBuilder.AddForeignKey(
                name: "FK_mc_versions_hist_supported_versions_SupportedVersionsSnapsh~",
                table: "mc_versions",
                column: "SupportedVersionsSnapshotId",
                principalTable: "hist_supported_versions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mc_versions_hist_supported_versions_SupportedVersionsSnapsh~",
                table: "mc_versions");

            migrationBuilder.DropTable(
                name: "hist_supported_versions");

            migrationBuilder.DropIndex(
                name: "IX_mc_versions_SupportedVersionsSnapshotId",
                table: "mc_versions");

            migrationBuilder.DropColumn(
                name: "SupportedVersionsSnapshotId",
                table: "mc_versions");

            migrationBuilder.UpdateData(
                table: "mod_loaders",
                keyColumn: "Id",
                keyValue: new Guid("091297f2-1ecd-45c2-8015-c1a4090d487b"),
                column: "CreatedAt",
                value: new DateTime(2023, 8, 12, 14, 7, 3, 16, DateTimeKind.Utc).AddTicks(4976));

            migrationBuilder.UpdateData(
                table: "mod_loaders",
                keyColumn: "Id",
                keyValue: new Guid("e437a393-d4b4-4d87-861b-2a47227c12df"),
                column: "CreatedAt",
                value: new DateTime(2023, 8, 12, 14, 7, 3, 16, DateTimeKind.Utc).AddTicks(4984));

            migrationBuilder.UpdateData(
                table: "mod_loaders",
                keyColumn: "Id",
                keyValue: new Guid("ea89d266-b6de-493a-b076-8e5e86142375"),
                column: "CreatedAt",
                value: new DateTime(2023, 8, 12, 14, 7, 3, 16, DateTimeKind.Utc).AddTicks(4955));

            migrationBuilder.UpdateData(
                table: "mod_loaders",
                keyColumn: "Id",
                keyValue: new Guid("f92fbda0-a69b-427c-8352-89eeb1772d7d"),
                column: "CreatedAt",
                value: new DateTime(2023, 8, 12, 14, 7, 3, 16, DateTimeKind.Utc).AddTicks(4980));

            migrationBuilder.UpdateData(
                table: "platforms",
                keyColumn: "Id",
                keyValue: new Guid("b6912369-4d45-422a-a238-b13983e9c435"),
                column: "CreatedAt",
                value: new DateTime(2023, 8, 12, 14, 7, 3, 16, DateTimeKind.Utc).AddTicks(5553));

            migrationBuilder.UpdateData(
                table: "platforms",
                keyColumn: "Id",
                keyValue: new Guid("ca1af69d-0961-491f-9fc0-f633313c8eab"),
                column: "CreatedAt",
                value: new DateTime(2023, 8, 12, 14, 7, 3, 16, DateTimeKind.Utc).AddTicks(5547));
        }
    }
}
