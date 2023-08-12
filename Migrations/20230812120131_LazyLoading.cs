using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModStats.API.Migrations
{
    /// <inheritdoc />
    public partial class LazyLoading : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_platforms_mods_ModId",
                table: "platforms");

            migrationBuilder.DropTable(
                name: "mod_display_info");

            migrationBuilder.DropIndex(
                name: "IX_platforms_ModId",
                table: "platforms");

            migrationBuilder.DropColumn(
                name: "ModId",
                table: "platforms");

            migrationBuilder.CreateTable(
                name: "mods_metadata",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ModId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Summary = table.Column<string>(type: "text", nullable: false),
                    Owner = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mods_metadata", x => x.Id);
                    table.ForeignKey(
                        name: "FK_mods_metadata_mods_ModId",
                        column: x => x.ModId,
                        principalTable: "mods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mods_supported_platforms",
                columns: table => new
                {
                    PlatformId = table.Column<Guid>(type: "uuid", nullable: false),
                    PlatformKey = table.Column<string>(type: "text", nullable: false),
                    ModId = table.Column<Guid>(type: "uuid", nullable: false),
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mods_supported_platforms", x => new { x.PlatformId, x.PlatformKey });
                    table.ForeignKey(
                        name: "FK_mods_supported_platforms_mods_ModId",
                        column: x => x.ModId,
                        principalTable: "mods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mods_supported_platforms_platforms_PlatformId",
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

            migrationBuilder.CreateIndex(
                name: "IX_mods_metadata_ModId",
                table: "mods_metadata",
                column: "ModId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_mods_supported_platforms_ModId",
                table: "mods_supported_platforms",
                column: "ModId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mods_metadata");

            migrationBuilder.DropTable(
                name: "mods_supported_platforms");

            migrationBuilder.AddColumn<Guid>(
                name: "ModId",
                table: "platforms",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "mod_display_info",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ModId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Owner = table.Column<string>(type: "text", nullable: false),
                    Summary = table.Column<string>(type: "text", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mod_display_info", x => x.Id);
                    table.ForeignKey(
                        name: "FK_mod_display_info_mods_ModId",
                        column: x => x.ModId,
                        principalTable: "mods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "mod_loaders",
                keyColumn: "Id",
                keyValue: new Guid("091297f2-1ecd-45c2-8015-c1a4090d487b"),
                column: "CreatedAt",
                value: new DateTime(2023, 8, 9, 12, 40, 58, 96, DateTimeKind.Utc).AddTicks(7516));

            migrationBuilder.UpdateData(
                table: "mod_loaders",
                keyColumn: "Id",
                keyValue: new Guid("e437a393-d4b4-4d87-861b-2a47227c12df"),
                column: "CreatedAt",
                value: new DateTime(2023, 8, 9, 12, 40, 58, 96, DateTimeKind.Utc).AddTicks(7537));

            migrationBuilder.UpdateData(
                table: "mod_loaders",
                keyColumn: "Id",
                keyValue: new Guid("ea89d266-b6de-493a-b076-8e5e86142375"),
                column: "CreatedAt",
                value: new DateTime(2023, 8, 9, 12, 40, 58, 96, DateTimeKind.Utc).AddTicks(7493));

            migrationBuilder.UpdateData(
                table: "mod_loaders",
                keyColumn: "Id",
                keyValue: new Guid("f92fbda0-a69b-427c-8352-89eeb1772d7d"),
                column: "CreatedAt",
                value: new DateTime(2023, 8, 9, 12, 40, 58, 96, DateTimeKind.Utc).AddTicks(7534));

            migrationBuilder.UpdateData(
                table: "platforms",
                keyColumn: "Id",
                keyValue: new Guid("b6912369-4d45-422a-a238-b13983e9c435"),
                columns: new[] { "CreatedAt", "ModId" },
                values: new object[] { new DateTime(2023, 8, 9, 12, 40, 58, 96, DateTimeKind.Utc).AddTicks(8069), null });

            migrationBuilder.UpdateData(
                table: "platforms",
                keyColumn: "Id",
                keyValue: new Guid("ca1af69d-0961-491f-9fc0-f633313c8eab"),
                columns: new[] { "CreatedAt", "ModId" },
                values: new object[] { new DateTime(2023, 8, 9, 12, 40, 58, 96, DateTimeKind.Utc).AddTicks(8062), null });

            migrationBuilder.CreateIndex(
                name: "IX_platforms_ModId",
                table: "platforms",
                column: "ModId");

            migrationBuilder.CreateIndex(
                name: "IX_mod_display_info_ModId",
                table: "mod_display_info",
                column: "ModId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_platforms_mods_ModId",
                table: "platforms",
                column: "ModId",
                principalTable: "mods",
                principalColumn: "Id");
        }
    }
}
