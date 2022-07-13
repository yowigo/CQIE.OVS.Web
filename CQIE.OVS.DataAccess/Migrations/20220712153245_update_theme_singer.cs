using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CQIE.OVS.DataAccess.Migrations
{
    public partial class update_theme_singer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VoteNum",
                table: "OVS_Singer");

            migrationBuilder.AddColumn<int>(
                name: "VoteNum",
                table: "Theme_Singers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "OVS_Singer",
                keyColumn: "Id",
                keyValue: 1,
                column: "Birthday",
                value: new DateTime(2022, 7, 12, 23, 32, 44, 636, DateTimeKind.Local).AddTicks(6400));

            migrationBuilder.UpdateData(
                table: "OVS_Singer",
                keyColumn: "Id",
                keyValue: 2,
                column: "Birthday",
                value: new DateTime(2022, 7, 12, 23, 32, 44, 637, DateTimeKind.Local).AddTicks(4892));

            migrationBuilder.UpdateData(
                table: "OVS_Theme",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2022, 7, 12, 23, 32, 44, 638, DateTimeKind.Local).AddTicks(4911), new DateTime(2022, 7, 12, 23, 32, 44, 638, DateTimeKind.Local).AddTicks(4655) });

            migrationBuilder.UpdateData(
                table: "OVS_Theme",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2022, 7, 12, 23, 32, 44, 638, DateTimeKind.Local).AddTicks(5192), new DateTime(2022, 7, 12, 23, 32, 44, 638, DateTimeKind.Local).AddTicks(5182) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VoteNum",
                table: "Theme_Singers");

            migrationBuilder.AddColumn<int>(
                name: "VoteNum",
                table: "OVS_Singer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "OVS_Singer",
                keyColumn: "Id",
                keyValue: 1,
                column: "Birthday",
                value: new DateTime(2022, 7, 10, 13, 54, 21, 393, DateTimeKind.Local).AddTicks(6529));

            migrationBuilder.UpdateData(
                table: "OVS_Singer",
                keyColumn: "Id",
                keyValue: 2,
                column: "Birthday",
                value: new DateTime(2022, 7, 10, 13, 54, 21, 394, DateTimeKind.Local).AddTicks(4464));

            migrationBuilder.UpdateData(
                table: "OVS_Theme",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2022, 7, 10, 13, 54, 21, 395, DateTimeKind.Local).AddTicks(4287), new DateTime(2022, 7, 10, 13, 54, 21, 395, DateTimeKind.Local).AddTicks(4034) });

            migrationBuilder.UpdateData(
                table: "OVS_Theme",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2022, 7, 10, 13, 54, 21, 395, DateTimeKind.Local).AddTicks(4567), new DateTime(2022, 7, 10, 13, 54, 21, 395, DateTimeKind.Local).AddTicks(4556) });
        }
    }
}
