using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CQIE.OVS.DataAccess.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OVS_Singer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Age = table.Column<int>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    Phone = table.Column<string>(maxLength: 11, nullable: false),
                    National = table.Column<string>(maxLength: 20, nullable: false),
                    Motto = table.Column<string>(maxLength: 50, nullable: true),
                    Profile = table.Column<string>(maxLength: 500, nullable: false),
                    PhotoPath = table.Column<string>(nullable: true),
                    VoteNum = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OVS_Singer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OVS_SysRole",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 128, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OVS_SysRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OVS_SysUser",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 128, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 128, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    BirthDay = table.Column<DateTime>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    LoginPassword = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OVS_SysUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OVS_Theme",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OVS_Theme", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OVS_SysRoleClaim",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OVS_SysRoleClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OVS_SysRoleClaim_OVS_SysRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "OVS_SysRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OVS_SysUserClaim",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OVS_SysUserClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OVS_SysUserClaim_OVS_SysUser_UserId",
                        column: x => x.UserId,
                        principalTable: "OVS_SysUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OVS_SysUserLogin",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoginProvider = table.Column<string>(nullable: true),
                    ProviderKey = table.Column<string>(nullable: true),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OVS_SysUserLogin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OVS_SysUserLogin_OVS_SysUser_UserId",
                        column: x => x.UserId,
                        principalTable: "OVS_SysUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OVS_SysUserRole",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OVS_SysUserRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OVS_SysUserRole_OVS_SysRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "OVS_SysRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OVS_SysUserRole_OVS_SysUser_UserId",
                        column: x => x.UserId,
                        principalTable: "OVS_SysUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OVS_SysUserToken",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OVS_SysUserToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OVS_SysUserToken_OVS_SysUser_UserId",
                        column: x => x.UserId,
                        principalTable: "OVS_SysUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OVS_Theme_User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    ThemeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OVS_Theme_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OVS_Theme_User_OVS_Theme_ThemeId",
                        column: x => x.ThemeId,
                        principalTable: "OVS_Theme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OVS_Theme_User_OVS_SysUser_UserId",
                        column: x => x.UserId,
                        principalTable: "OVS_SysUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Theme_Singers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThemeId = table.Column<int>(nullable: false),
                    SingerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Theme_Singers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Theme_Singers_OVS_Singer_SingerId",
                        column: x => x.SingerId,
                        principalTable: "OVS_Singer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Theme_Singers_OVS_Theme_ThemeId",
                        column: x => x.ThemeId,
                        principalTable: "OVS_Theme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "OVS_Singer",
                columns: new[] { "Id", "Age", "Gender", "Motto", "Name", "National", "Phone", "PhotoPath", "Profile", "VoteNum" },
                values: new object[,]
                {
                    { 1, 39, 1, "不跟别人比,就跟自己比", "张杰", "中国", "1xxxxxxxx88", "", "张杰，1982年12月20日出生于四川省成都市，是一位中国内地男歌手。2004年，他参加第一届“我型我秀”冠军出道：凭借成名曲《北斗星的爱》获得全球华语榜中榜”年度传媒推荐大奖”等奖项；凭借专辑《明天过后》获得最受欢迎男歌手奖，获得北京流行音乐典礼11项提名；凭借发行的MX - POP专辑《未·LVE》销量打破FP三白金认证。张杰的其他代表作品有《天下》、《勿忘心安》、《一路之下》、《这，就是爱》、《最美的太阳》、《他不懂》等。", 0 },
                    { 2, 41, 1, "认真对待每一个人，你们都是林俊杰的人", "林俊杰", "中国", "1xxxxxxx666", "", "林俊杰（JJ Lin），著名男歌手，1981年出生于新加坡。2003年首发第一张个人创作专辑《乐行者》，取得不俗成绩；其杰出的创作才能又在之后推出的《江南》、《曹操》、《JJ陆》等多部畅销唱片专辑中得以充分展现；于此同时，林俊杰还斩获了无数音乐大奖，成为当今华语歌坛最耀眼的男歌手之一。", 0 }
                });

            migrationBuilder.InsertData(
                table: "OVS_Theme",
                columns: new[] { "Id", "Description", "EndTime", "Name", "StartTime" },
                values: new object[,]
                {
                    { 1, "今年是第二十届，与以往不同的是，中国爱乐乐团将携手上海交响乐团、广州交响乐团两支兄弟乐团，由余隆指挥，共同演出一场以红色经典为主线的新年音乐会，迎接2021年中国共产党成立一百周年华诞。据了解，2019年10月1日，中国爱乐乐团也曾携手上海交响乐团、广州交响乐团等十六支交响乐团共同组建成规模庞大的“千人交响乐团”，共同奏响献礼中华人民共和国成立七十周年的华章。", new DateTime(2022, 7, 9, 11, 53, 12, 418, DateTimeKind.Local).AddTicks(9039), "2021CCTV新年音乐会", new DateTime(2022, 7, 9, 11, 53, 12, 418, DateTimeKind.Local).AddTicks(2035) },
                    { 2, "本场音乐会以交响音乐会的形式，回顾2021年，展望2022年，在新年起始之际，中央广播电台文艺中心音乐频道与中国爱乐乐团携手为广大音乐爱好者带来一场新年音乐会。", new DateTime(2022, 7, 9, 11, 53, 12, 418, DateTimeKind.Local).AddTicks(9400), "2022CCTV新年音乐会", new DateTime(2022, 7, 9, 11, 53, 12, 418, DateTimeKind.Local).AddTicks(9390) }
                });

            migrationBuilder.InsertData(
                table: "Theme_Singers",
                columns: new[] { "Id", "SingerId", "ThemeId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "Theme_Singers",
                columns: new[] { "Id", "SingerId", "ThemeId" },
                values: new object[] { 2, 2, 1 });

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "OVS_SysRole",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OVS_SysRoleClaim_RoleId",
                table: "OVS_SysRoleClaim",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "OVS_SysUser",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "OVS_SysUser",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OVS_SysUserClaim_UserId",
                table: "OVS_SysUserClaim",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OVS_SysUserLogin_UserId",
                table: "OVS_SysUserLogin",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OVS_SysUserRole_RoleId",
                table: "OVS_SysUserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_OVS_SysUserRole_UserId",
                table: "OVS_SysUserRole",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OVS_SysUserToken_UserId",
                table: "OVS_SysUserToken",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OVS_Theme_User_ThemeId",
                table: "OVS_Theme_User",
                column: "ThemeId");

            migrationBuilder.CreateIndex(
                name: "IX_OVS_Theme_User_UserId",
                table: "OVS_Theme_User",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Theme_Singers_SingerId",
                table: "Theme_Singers",
                column: "SingerId");

            migrationBuilder.CreateIndex(
                name: "IX_Theme_Singers_ThemeId",
                table: "Theme_Singers",
                column: "ThemeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OVS_SysRoleClaim");

            migrationBuilder.DropTable(
                name: "OVS_SysUserClaim");

            migrationBuilder.DropTable(
                name: "OVS_SysUserLogin");

            migrationBuilder.DropTable(
                name: "OVS_SysUserRole");

            migrationBuilder.DropTable(
                name: "OVS_SysUserToken");

            migrationBuilder.DropTable(
                name: "OVS_Theme_User");

            migrationBuilder.DropTable(
                name: "Theme_Singers");

            migrationBuilder.DropTable(
                name: "OVS_SysRole");

            migrationBuilder.DropTable(
                name: "OVS_SysUser");

            migrationBuilder.DropTable(
                name: "OVS_Singer");

            migrationBuilder.DropTable(
                name: "OVS_Theme");
        }
    }
}
