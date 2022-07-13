#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (c) 2022 Genshin  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：GS2-20220506KRQ
 * 唯一标识：0f95946d-5c91-4d05-8f06-5c697315dc59
 * 文件名：ThemesController
 * 创建者：Administrator
 * 电子邮箱：307886418@qq.com
 * 创建时间：2022/7/6 12:11:59
 * 版本：V1.0.0
 *----------------------------------------------------------------*/
#endregion << 版 本 注 释 >>
using CQIE.OVS.DataAccess.Database;
using CQIE.OVS.Models;
using CQIE.OVS.Services.IService;
using CQIE.OVS.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQIE.OVS.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ThemesController : Controller
    {
        private readonly OVSDbContext _context;
        private readonly IThemeService _themeService;
        private readonly ISingerService _singerService;
        public ThemesController(IThemeService themeService, OVSDbContext context, ISingerService singerService)
        {
            _context = context;
            _themeService = themeService;
            _singerService = singerService;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            var value = await _themeService.GetListAsync();
            ViewBag.themeCount = value.Count();
            //模糊查询
            if (!String.IsNullOrEmpty(searchString))
            {
                var query = _context.Themes.Where(s => s.Name.Contains(searchString));
                ViewData["CurrentFilter"] = searchString;
                return View(query);
            }
            return View(value);
        }

        public IActionResult Create()
        {
            //歌手
            var singers = _singerService.GetListSinger();
            var selectListItem = new List<SelectListItem>()
            {
                new SelectListItem() { Value="0", Text="---请选择歌手---",Selected=true }
            };
            var singerList = new SelectList(singers, "Id", "Name");
            selectListItem.AddRange(singerList);

            var themeList = new ThemeSingerViewModel();
            themeList.SingerListItems = selectListItem;
            
            return View(themeList);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Theme theme,int Singer1Id,int Singer2Id)
        {
            await _themeService.CreateAsync(theme);
            var themeId = theme.Id;//获取ThemeId


            Theme_Singer theme_Singer = new Theme_Singer()
            {
                ThemeId = themeId,
                SingerId = Singer1Id
            };
            await _themeService.AddThemeSinger(theme_Singer); 
            Theme_Singer theme_Singer2 = new Theme_Singer()
            {
                ThemeId = themeId,
                SingerId = Singer2Id
            };
            await _themeService.AddThemeSinger(theme_Singer2);
            return RedirectToAction("Index","Themes");
        }

        public async Task<IActionResult> Edit(int id)
        {
            //歌手
            var singerList = _singerService.GetListSinger();
            var selectListItem = new List<SelectListItem>()
            {
                new SelectListItem() { Value="0", Text="---请选择歌手---",Selected=true }
            };
            var selectList = new SelectList(singerList, "Id", "Name");
            selectListItem.AddRange(selectList);
            ViewBag.singer1 = selectListItem;
            ViewBag.singer2 = selectListItem;
            //主题
            var value = await _themeService.FindByIdAsync(id);
            if (value == null)
                return View("没有找到该主题活动！");
            return View(value);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Theme model,int tsId/* int Singer1Id, int Singer2Id*/)
        {
            Theme theme = new Theme()
            {
                Id = model.Id,
                Name = model.Name,
                Categroy = model.Categroy,
                Description = model.Description,
                StartTime = model.StartTime,
                EndTime = model.EndTime,
            };
            var value = await _themeService.EditAsync(theme);

            //修改关系表
            //级联查询Theme/Singer
            var result = _context.Theme_Singers.FindAsync(tsId);
            
            var res = _themeService.GetThemeSinger(model.Id);
            //新增关系
            
            Theme_Singer theme_Singer = new Theme_Singer()
            {
                ThemeId = model.Id,
            };
            
            //var themeId = model.Id;//获取ThemeId
            //var singers = await _singerService.GetListAsync();
            //foreach (var item in singers)
            //{
            //    ViewBag.SingerId = item.Id;
            //    ViewBag.SingerName = item.Name;
            //    Theme_Singer theme_Singer = new Theme_Singer()
            //    {
            //        ThemeId = themeId,
            //        SingerId = ViewBag.SingerId
            //    };
            //    await _themeService.AddThemeSinger(theme_Singer);
            //}
            //var singerId = item.Id;//获取SingerId

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(Theme theme, int id)
        {
            await _themeService.DeleteAsync(theme, id);
            return RedirectToAction("Index");
        }
    }
}
