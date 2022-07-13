#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (c) 2022 Genshin  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：GS2-20220506KRQ
 * 唯一标识：e87aa342-9559-4a8a-97b3-b901bedcd18a
 * 文件名：HomeController
 * 创建者：Administrator
 * 电子邮箱：307886418@qq.com
 * 创建时间：2022/7/8 15:36:17
 * 版本：V1.0.0
 *----------------------------------------------------------------*/
#endregion << 版 本 注 释 >>
using CQIE.OVS.Models;
using CQIE.OVS.Services.IService;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CQIE.OVS.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IThemeService _themeService;
        public HomeController(IThemeService themeService)
        {
            _themeService = themeService;
        }

        public async Task<IActionResult> Index()
        {
            var value = await _themeService.GetListAsync();
            ViewBag.themeCount = value.Count;
            return View(value);
        }
    }
}
