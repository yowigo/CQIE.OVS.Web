using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CQIE.OVS.DataAccess.Migrations
{
    public partial class update_cloumn_name2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "OVS_Singer");

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthday",
                table: "OVS_Singer",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "OVS_Singer");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "OVS_Singer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "OVS_Singer",
                keyColumn: "Id",
                keyValue: 1,
                column: "Age",
                value: 39);

            migrationBuilder.UpdateData(
                table: "OVS_Singer",
                keyColumn: "Id",
                keyValue: 2,
                column: "Age",
                value: 41);

            migrationBuilder.UpdateData(
                table: "OVS_Theme",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2022, 7, 10, 13, 35, 10, 90, DateTimeKind.Local).AddTicks(4131), new DateTime(2022, 7, 10, 13, 35, 10, 89, DateTimeKind.Local).AddTicks(7489) });

            migrationBuilder.UpdateData(
                table: "OVS_Theme",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2022, 7, 10, 13, 35, 10, 90, DateTimeKind.Local).AddTicks(4486), new DateTime(2022, 7, 10, 13, 35, 10, 90, DateTimeKind.Local).AddTicks(4475) });
        }
    }
}
