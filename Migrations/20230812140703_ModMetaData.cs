using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModStats.API.Migrations
{
    /// <inheritdoc />
    public partial class ModMetaData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
