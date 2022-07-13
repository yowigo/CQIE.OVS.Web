using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CQIE.OVS.DataAccess.Migrations
{
    public partial class update_cloumn_name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Categroy",
                table: "OVS_Theme",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "OVS_Singer",
                keyColumn: "Id",
                keyValue: 1,
                column: "PhotoPath",
                value: "/images/avatars/zhangjie.jpg");

            migrationBuilder.UpdateData(
                table: "OVS_Theme",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Categroy", "EndTime", "StartTime" },
                values: new object[] { "音乐节", new DateTime(2022, 7, 10, 13, 35, 10, 90, DateTimeKind.Local).AddTicks(4131), new DateTime(2022, 7, 10, 13, 35, 10, 89, DateTimeKind.Local).AddTicks(7489) });

            migrationBuilder.UpdateData(
                table: "OVS_Theme",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Categroy", "EndTime", "StartTime" },
                values: new object[] { "音乐节", new DateTime(2022, 7, 10, 13, 35, 10, 90, DateTimeKind.Local).AddTicks(4486), new DateTime(2022, 7, 10, 13, 35, 10, 90, DateTimeKind.Local).AddTicks(4475) });

            migrationBuilder.InsertData(
                table: "Theme_Singers",
                columns: new[] { "Id", "SingerId", "ThemeId" },
                values: new object[] { 3, 1, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Theme_Singers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Categroy",
                table: "OVS_Theme");

            migrationBuilder.UpdateData(
                table: "OVS_Singer",
                keyColumn: "Id",
                keyValue: 1,
                column: "PhotoPath",
                value: "");

            migrationBuilder.UpdateData(
                table: "OVS_Theme",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2022, 7, 9, 11, 53, 12, 418, DateTimeKind.Local).AddTicks(9039), new DateTime(2022, 7, 9, 11, 53, 12, 418, DateTimeKind.Local).AddTicks(2035) });

            migrationBuilder.UpdateData(
                table: "OVS_Theme",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2022, 7, 9, 11, 53, 12, 418, DateTimeKind.Local).AddTicks(9400), new DateTime(2022, 7, 9, 11, 53, 12, 418, DateTimeKind.Local).AddTicks(9390) });
        }
    }
}
