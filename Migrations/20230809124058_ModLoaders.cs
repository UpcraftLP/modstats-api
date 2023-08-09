using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModStats.API.Migrations
{
    /// <inheritdoc />
    public partial class ModLoaders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ModLoaders",
                table: "ModLoaders");

            migrationBuilder.RenameTable(
                name: "ModLoaders",
                newName: "mod_loaders");

            migrationBuilder.RenameIndex(
                name: "IX_ModLoaders_Slug",
                table: "mod_loaders",
                newName: "IX_mod_loaders_Slug");

            migrationBuilder.AddPrimaryKey(
                name: "PK_mod_loaders",
                table: "mod_loaders",
                column: "Id");

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
                column: "CreatedAt",
                value: new DateTime(2023, 8, 9, 12, 40, 58, 96, DateTimeKind.Utc).AddTicks(8069));

            migrationBuilder.UpdateData(
                table: "platforms",
                keyColumn: "Id",
                keyValue: new Guid("ca1af69d-0961-491f-9fc0-f633313c8eab"),
                column: "CreatedAt",
                value: new DateTime(2023, 8, 9, 12, 40, 58, 96, DateTimeKind.Utc).AddTicks(8062));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_mod_loaders",
                table: "mod_loaders");

            migrationBuilder.RenameTable(
                name: "mod_loaders",
                newName: "ModLoaders");

            migrationBuilder.RenameIndex(
                name: "IX_mod_loaders_Slug",
                table: "ModLoaders",
                newName: "IX_ModLoaders_Slug");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ModLoaders",
                table: "ModLoaders",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "ModLoaders",
                keyColumn: "Id",
                keyValue: new Guid("091297f2-1ecd-45c2-8015-c1a4090d487b"),
                column: "CreatedAt",
                value: new DateTime(2023, 8, 7, 11, 12, 1, 922, DateTimeKind.Utc).AddTicks(4181));

            migrationBuilder.UpdateData(
                table: "ModLoaders",
                keyColumn: "Id",
                keyValue: new Guid("e437a393-d4b4-4d87-861b-2a47227c12df"),
                column: "CreatedAt",
                value: new DateTime(2023, 8, 7, 11, 12, 1, 922, DateTimeKind.Utc).AddTicks(4188));

            migrationBuilder.UpdateData(
                table: "ModLoaders",
                keyColumn: "Id",
                keyValue: new Guid("ea89d266-b6de-493a-b076-8e5e86142375"),
                column: "CreatedAt",
                value: new DateTime(2023, 8, 7, 11, 12, 1, 922, DateTimeKind.Utc).AddTicks(4163));

            migrationBuilder.UpdateData(
                table: "ModLoaders",
                keyColumn: "Id",
                keyValue: new Guid("f92fbda0-a69b-427c-8352-89eeb1772d7d"),
                column: "CreatedAt",
                value: new DateTime(2023, 8, 7, 11, 12, 1, 922, DateTimeKind.Utc).AddTicks(4184));

            migrationBuilder.UpdateData(
                table: "platforms",
                keyColumn: "Id",
                keyValue: new Guid("b6912369-4d45-422a-a238-b13983e9c435"),
                column: "CreatedAt",
                value: new DateTime(2023, 8, 7, 11, 12, 1, 922, DateTimeKind.Utc).AddTicks(4616));

            migrationBuilder.UpdateData(
                table: "platforms",
                keyColumn: "Id",
                keyValue: new Guid("ca1af69d-0961-491f-9fc0-f633313c8eab"),
                column: "CreatedAt",
                value: new DateTime(2023, 8, 7, 11, 12, 1, 922, DateTimeKind.Utc).AddTicks(4612));
        }
    }
}
