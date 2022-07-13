#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (c) 2022 Genshin  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：GS2-20220506KRQ
 * 唯一标识：b04f607b-8c7b-4d8c-9b21-a70cc20f1f5d
 * 文件名：OVSDbContext
 * 创建者：Administrator
 * 电子邮箱：307886418@qq.com
 * 创建时间：2022/7/4 11:32:47
 * 版本：V1.0.0
 *----------------------------------------------------------------*/
#endregion << 版 本 注 释 >>
using System;
using System.Collections.Generic;
using System.Text;
using CQIE.OVS.Models;
using CQIE.OVS.Models.IdentityModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CQIE.OVS.DataAccess.Database
{
    public class OVSDbContext : IdentityDbContext<SysUser, SysRole, int, SysUserClaim, SysUserRole, SysUserLogin, SysRoleClaim, SysUserToken>
    {
        public OVSDbContext(DbContextOptions<OVSDbContext> options) : base(options)
        {

        }

        public DbSet<Singer> Singers { get; set; }
        public DbSet<Theme> Themes { get; set; }
        public DbSet<Theme_User> Theme_Users { get; set; }
        public DbSet<Theme_Singer> Theme_Singers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<SysUserLogin>(config =>
            {
                config.HasKey(x => x.Id);
            });

            builder.Entity<Singer>(config =>
            {
                config.HasKey(x => x.Id);
            });

            builder.Entity<Theme>(config =>
            {
                config.HasKey(x => x.Id);
            });
            builder.Entity<Theme_Singer>(config =>
            {
                config.HasKey(x => x.Id);
                config.HasOne(x => x.Singer).WithMany(x => x.Theme_Singers).HasForeignKey(x => x.SingerId);
                config.HasOne(x => x.Theme).WithMany(x => x.Theme_Singers).HasForeignKey(x => x.ThemeId);
            });
            builder.Entity<Theme_User>(config =>
            {
                config.HasKey(x => x.Id);
                config.HasOne(x => x.Theme).WithMany(x => x.Theme_Users).HasForeignKey(x => x.ThemeId);
                config.HasOne(x => x.User).WithMany(x => x.Theme_Users).HasForeignKey(x => x.UserId);
            });

            #region 数据
            builder.Entity<Singer>().HasData(
                new Singer
                {
                    Id = 1,
                    Name = "张杰",
                    Birthday=DateTime.Now,
                    Gender = 1,
                    National = "中国",
                    Phone = "1xxxxxxxx88",
                    Motto = "不跟别人比,就跟自己比",
                    Profile = "张杰，1982年12月20日出生于四川省成都市，是一位中国内地男歌手。2004年，他参加第一届“我型我秀”冠军出道：凭借成名曲《北斗星的爱》获得全球华语榜中榜”年度传媒推荐大奖”等奖项；凭借专辑《明天过后》获得最受欢迎男歌手奖，获得北京流行音乐典礼11项提名；凭借发行的MX - POP专辑《未·LVE》销量打破FP三白金认证。张杰的其他代表作品有《天下》、《勿忘心安》、《一路之下》、《这，就是爱》、《最美的太阳》、《他不懂》等。",
                    PhotoPath = "/images/background.jpg"
                },
                new Singer
                {
                    Id = 2,
                    Name = "林俊杰",
                    Birthday = DateTime.Now,
                    Gender = 1,
                    National = "中国",
                    Phone = "1xxxxxxx666",
                    Motto = "认真对待每一个人，你们都是林俊杰的人",
                    Profile = "林俊杰（JJ Lin），著名男歌手，1981年出生于新加坡。2003年首发第一张个人创作专辑《乐行者》，取得不俗成绩；其杰出的创作才能又在之后推出的《江南》、《曹操》、《JJ陆》等多部畅销唱片专辑中得以充分展现；于此同时，林俊杰还斩获了无数音乐大奖，成为当今华语歌坛最耀眼的男歌手之一。",
                    PhotoPath = ""
                });

            builder.Entity<Theme>().HasData(
                new Theme
                {
                    Id = 1,
                    Name = "2021CCTV新年音乐会",
                    Categroy = "音乐节",
                    Description = "今年是第二十届，与以往不同的是，中国爱乐乐团将携手上海交响乐团、广州交响乐团两支兄弟乐团，由余隆指挥，共同演出一场以红色经典为主线的新年音乐会，迎接2021年中国共产党成立一百周年华诞。据了解，2019年10月1日，中国爱乐乐团也曾携手上海交响乐团、广州交响乐团等十六支交响乐团共同组建成规模庞大的“千人交响乐团”，共同奏响献礼中华人民共和国成立七十周年的华章。",
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now
                },
                new Theme
                {
                    Id = 2,
                    Name = "2022CCTV新年音乐会",
                    Categroy = "音乐节",
                    Description = "本场音乐会以交响音乐会的形式，回顾2021年，展望2022年，在新年起始之际，中央广播电台文艺中心音乐频道与中国爱乐乐团携手为广大音乐爱好者带来一场新年音乐会。",
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now
                });

            builder.Entity<Theme_Singer>().HasData(
                new Theme_Singer
                {
                    Id = 1,
                    ThemeId = 1,
                    SingerId = 1,
                    VoteNum = 0
                },
                new Theme_Singer
                {
                    Id = 2,
                    ThemeId = 1,
                    SingerId = 2,
                    VoteNum = 0
                }, //第一场比赛有Id=1,2的两个选手参与
                new Theme_Singer
                {
                    Id = 3,
                    ThemeId = 2,
                    SingerId = 1,
                    VoteNum = 0
                });
            #endregion

            IdentityModelCreating(builder);
        }

        private static void IdentityModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<SysUser>(b =>
                {
                    b.HasKey(u => u.Id);
                    b.HasIndex(u => u.NormalizedUserName).HasName("UserNameIndex").IsUnique();
                    //SQL Server下正常，MySQL下报错，如果使用索引，MYSQL下字段长度最大可设置为191
                    b.HasIndex(u => u.NormalizedEmail).HasName("EmailIndex");
                    b.Property(u => u.ConcurrencyStamp).IsConcurrencyToken();

                    b.Property(u => u.UserName).HasMaxLength(256);
                    b.Property(u => u.NormalizedUserName).HasMaxLength(128);
                    b.Property(u => u.Email).HasMaxLength(256);
                    b.Property(u => u.NormalizedEmail).HasMaxLength(128);
                    b.Ignore(u => u.LockoutEnd);

                    b.HasMany<SysUserClaim>().WithOne().HasForeignKey(uc => uc.UserId).IsRequired();
                    b.HasMany<SysUserLogin>().WithOne().HasForeignKey(ul => ul.UserId).IsRequired();
                    b.HasMany<SysUserToken>().WithOne().HasForeignKey(ut => ut.UserId).IsRequired();
                });

                modelBuilder.Entity<SysRole>(b =>
                {
                    b.HasKey(r => r.Id);
                    b.HasIndex(r => r.NormalizedName).HasName("RoleNameIndex").IsUnique();
                    b.Property(r => r.ConcurrencyStamp).IsConcurrencyToken();

                    b.Property(u => u.Name).HasMaxLength(256);
                    b.Property(u => u.NormalizedName).HasMaxLength(128);

                    b.HasMany<SysRoleClaim>().WithOne().HasForeignKey(rc => rc.RoleId).IsRequired();
                });


                modelBuilder.Entity<SysUserClaim>(b =>
                {
                    b.HasKey(uc => uc.Id);
                });

                modelBuilder.Entity<SysUserRole>(b =>
                {
                    b.HasKey(uc => uc.Id);
                    b.HasOne(c => c.Role).WithMany(c => c.SysUserRoles).HasForeignKey(c => c.RoleId);
                    b.HasOne(c => c.User).WithMany(c => c.SysUserRoles).HasForeignKey(c => c.UserId);
                });

                modelBuilder.Entity<SysUserLogin>(b =>
                {
                    b.HasKey(c => c.Id);
                });

                modelBuilder.Entity<SysUserToken>(b =>
                {
                    b.HasKey(c => c.Id);
                });

                modelBuilder.Entity<SysRoleClaim>(b =>
                {
                    b.HasKey(rc => rc.Id);
                });
            }
    }
}
