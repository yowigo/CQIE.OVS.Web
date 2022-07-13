#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (c) 2022 Genshin  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：GS2-20220506KRQ
 * 唯一标识：97bcf3cf-4536-4215-a139-4b4093e8e8bc
 * 文件名：ThemeController
 * 创建者：Administrator
 * 电子邮箱：307886418@qq.com
 * 创建时间：2022/7/5 10:49:24
 * 版本：V1.0.0
 *----------------------------------------------------------------*/
#endregion << 版 本 注 释 >>
using CQIE.OVS.DataAccess.Database;
using CQIE.OVS.Models;
using CQIE.OVS.Models.IdentityModel;
using CQIE.OVS.Services.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace CQIE.OVS.Web.Controllers
{
    public class ThemesController : Controller
    {
        private readonly IThemeService _themeService;
        private readonly ISingerService _singerService;
        private readonly OVSDbContext _context;
        public ThemesController(IThemeService themeService, OVSDbContext context, ISingerService singerService)
        {
            _themeService = themeService;
            _singerService = singerService;
            _context = context;
        }

        /// <summary>
        /// 主题 √√√
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var value = await _themeService.GetListAsync();
            return View(value);
        }

        /// <summary>
        /// 主题-比赛详情 √√√
        /// </summary>
        /// <param name="model"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(int id,int themeId)
        {
            //var theme = await _themeService.FindByIdAsync(id);
            var value = await _themeService.GetThemeSinger(id); //级联查询-单条数据
            //await _themeService.GetListSingerByTheme(); //级联查询-多条数据

            ViewBag.themesId = id;
            return View(value);
        }

        /// <summary>
        /// 查看活动详情，并投票
        /// </summary>
        /// <param name="themeId"></param>
        /// <param name="singerId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> VoteAdd(int themeId, int singerId)
        {
            var value = HttpContext.Session.GetString("UserSession");
            var user = JsonSerializer.Deserialize<SysUser>(value);

            Theme_User theme_User = new Theme_User()
            {

                ThemeId = themeId,
                UserId = user.Id
            };

            //查询主题和用户--userId和themeId
            var result = _context.Theme_Users.Where(c => c.ThemeId == themeId && c.UserId == user.Id).FirstOrDefault();
            //获取比赛信息
            var themeInfo = _context.Themes.Find(themeId);
            if (result == null)
            {
                //新增关系记录
                await _context.AddAsync(theme_User);

                //票数+1
                var vote = await _context.Theme_Singers.FindAsync(singerId);

                //将票数存进数据库
                var theme_Singer = _context.Theme_Singers.Where(c => c.ThemeId == themeId && c.SingerId == singerId).FirstOrDefault();
                theme_Singer.VoteNum++;

                _context.Theme_Singers.Update(theme_Singer);  //Id没有值时
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index", "Themes");
        }

        /// <summary>
        /// ajax获取剩余时间倒计时方法
        /// </summary>
        /// <param name="themeId"></param>
        /// <returns></returns>
        [HttpGet]
        public string CountDownTime(int themeId)
        {
            //获取比赛信息
            var result = _context.Themes.Find(themeId);
            //获取当前时间
            if (DateTime.Now > result.EndTime)
            {
                //超时过期，时间为0
                var time1 = new
                {
                    hour = 00,
                    minute = 00,
                    second = 00
                };
                return JsonSerializer.Serialize(time1);
            }
            //未过期，未开始
            var time = new
            {
                //获取剩余时间
                hour = (result.EndTime.Hour - DateTime.Now.Hour).ToString(),
                minute = (result.EndTime.Minute - DateTime.Now.Minute).ToString(),
                second = (60 - DateTime.Now.Second).ToString()
            };

            return JsonSerializer.Serialize(time);
        }

        /// <summary>
        /// 获取当前比赛的投票情况
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string Jsonlist(int themeId)
        {
            //一次只有一场比赛
            //通过比赛Id来确定歌手信息与投票结果
            var result = _themeService.GetVoteNumByTheme(themeId);
            //数据处理为接送格式
            //var list = singerService.GetSingers();
            //返回字符串，data
            return JsonSerializer.Serialize(result);
        }
    }
}
