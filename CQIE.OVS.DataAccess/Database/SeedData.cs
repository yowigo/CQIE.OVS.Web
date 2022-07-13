#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (c) 2022 Genshin  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：GS2-20220506KRQ
 * 唯一标识：a341834c-cd62-414b-b2de-710cc0d112c1
 * 文件名：SeedData
 * 创建者：Administrator
 * 电子邮箱：307886418@qq.com
 * 创建时间：2022/7/4 15:52:17
 * 版本：V1.0.0
 *----------------------------------------------------------------*/
#endregion << 版 本 注 释 >>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CQIE.OVS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace CQIE.OVS.DataAccess.Database
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new OVSDbContext(serviceProvider.GetRequiredService<DbContextOptions<OVSDbContext>>()))
            {
                #region Singer表
                if (context.Singers.Any())
                {
                    return;   // DB has been seeded
                }
                context.Singers.AddRange(
                    new Singer
                    {
                        Id = 1,
                        Name="张杰",
                        Birthday=DateTime.Now,
                        Gender=1,
                        National="中国",
                        Phone="1xxxxxxxx88",
                        Motto= "不跟别人比,就跟自己比",
                        Profile= "张杰，1982年12月20日出生于四川省成都市，是一位中国内地男歌手。2004年，他参加第一届“我型我秀”冠军出道：凭借成名曲《北斗星的爱》获得全球华语榜中榜”年度传媒推荐大奖”等奖项；凭借专辑《明天过后》获得最受欢迎男歌手奖，获得北京流行音乐典礼11项提名；凭借发行的MX - POP专辑《未·LVE》销量打破FP三白金认证。张杰的其他代表作品有《天下》、《勿忘心安》、《一路之下》、《这，就是爱》、《最美的太阳》、《他不懂》等。",
                        PhotoPath= "/images/background.jpg"
                    },
                    new Singer
                    {
                        Id=2,
                        Name = "林俊杰",
                        Birthday = DateTime.Now,
                        Gender = 1,
                        National = "中国",
                        Phone = "1xxxxxxx666",
                        Motto= "认真对待每一个人，你们都是林俊杰的人",
                        Profile= "林俊杰（JJ Lin），著名男歌手，1981年出生于新加坡。2003年首发第一张个人创作专辑《乐行者》，取得不俗成绩；其杰出的创作才能又在之后推出的《江南》、《曹操》、《JJ陆》等多部畅销唱片专辑中得以充分展现；于此同时，林俊杰还斩获了无数音乐大奖，成为当今华语歌坛最耀眼的男歌手之一。",
                        PhotoPath = "/images/background.jpg"
                    }
                );
                #endregion

                #region Theme表
                if (context.Themes.Any())
                {
                    return;   // DB has been seeded
                }
                context.Themes.AddRange(new Theme
                    {
                        Id = 1,
                        Name = "CCTV中国中央广播电视总台2022新年音乐会",
                        Categroy = "音乐节",
                        Description = "本场音乐会以交响音乐会的形式，回顾2021年，展望2022年，在新年起始之际，中央广播电台文艺中心音乐频道与中国爱乐乐团携手为广大音乐爱好者带来一场新年音乐会。",
                        StartTime = DateTime.Now,
                        EndTime = DateTime.Now
                    },
                    new Theme
                    {
                        Id = 2,
                        Name = "CCTV中国中央广播电视总台2021新年音乐会",
                        Categroy = "音乐节",
                        Description = "今年是第二十届，与以往不同的是，中国爱乐乐团将携手上海交响乐团、广州交响乐团两支兄弟乐团，由余隆指挥，共同演出一场以红色经典为主线的新年音乐会，迎接2021年中国共产党成立一百周年华诞。据了解，2019年10月1日，中国爱乐乐团也曾携手上海交响乐团、广州交响乐团等十六支交响乐团共同组建成规模庞大的“千人交响乐团”，共同奏响献礼中华人民共和国成立七十周年的华章。",
                        StartTime = DateTime.Now,
                        EndTime = DateTime.Now
                    });
                #endregion

                context.SaveChanges();
            }
        }
    }
}
