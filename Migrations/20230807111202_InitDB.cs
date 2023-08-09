using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ModStats.API.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ModLoaders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModLoaders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "mods",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "mc_versions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: false),
                    Time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ReleaseTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Sha1 = table.Column<string>(type: "text", nullable: false),
                    ComplianceLevel = table.Column<int>(type: "integer", nullable: false),
                    ModId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mc_versions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_mc_versions_mods_ModId",
                        column: x => x.ModId,
                        principalTable: "mods",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "mod_display_info",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ModId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Summary = table.Column<string>(type: "text", nullable: false),
                    Owner = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "platforms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ModId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_platforms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_platforms_mods_ModId",
                        column: x => x.ModId,
                        principalTable: "mods",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "ModLoaders",
                columns: new[] { "Id", "CreatedAt", "Name", "Slug" },
                values: new object[,]
                {
                    { new Guid("091297f2-1ecd-45c2-8015-c1a4090d487b"), new DateTime(2023, 8, 7, 11, 12, 1, 922, DateTimeKind.Utc).AddTicks(4181), "Fabric", "fabric" },
                    { new Guid("e437a393-d4b4-4d87-861b-2a47227c12df"), new DateTime(2023, 8, 7, 11, 12, 1, 922, DateTimeKind.Utc).AddTicks(4188), "NeoForge", "neoforge" },
                    { new Guid("ea89d266-b6de-493a-b076-8e5e86142375"), new DateTime(2023, 8, 7, 11, 12, 1, 922, DateTimeKind.Utc).AddTicks(4163), "Forge", "forge" },
                    { new Guid("f92fbda0-a69b-427c-8352-89eeb1772d7d"), new DateTime(2023, 8, 7, 11, 12, 1, 922, DateTimeKind.Utc).AddTicks(4184), "Quilt", "quilt" }
                });

            migrationBuilder.InsertData(
                table: "platforms",
                columns: new[] { "Id", "CreatedAt", "ModId", "Name", "Slug" },
                values: new object[,]
                {
                    { new Guid("b6912369-4d45-422a-a238-b13983e9c435"), new DateTime(2023, 8, 7, 11, 12, 1, 922, DateTimeKind.Utc).AddTicks(4616), null, "Modrinth", "modrinth" },
                    { new Guid("ca1af69d-0961-491f-9fc0-f633313c8eab"), new DateTime(2023, 8, 7, 11, 12, 1, 922, DateTimeKind.Utc).AddTicks(4612), null, "CurseForge", "curseforge" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_mc_versions_ModId",
                table: "mc_versions",
                column: "ModId");

            migrationBuilder.CreateIndex(
                name: "IX_mod_display_info_ModId",
                table: "mod_display_info",
                column: "ModId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ModLoaders_Slug",
                table: "ModLoaders",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_mods_Slug",
                table: "mods",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_platforms_ModId",
                table: "platforms",
                column: "ModId");

            migrationBuilder.CreateIndex(
                name: "IX_platforms_Slug",
                table: "platforms",
                column: "Slug",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mc_versions");

            migrationBuilder.DropTable(
                name: "mod_display_info");

            migrationBuilder.DropTable(
                name: "ModLoaders");

            migrationBuilder.DropTable(
                name: "platforms");

            migrationBuilder.DropTable(
                name: "mods");
        }
    }
}
