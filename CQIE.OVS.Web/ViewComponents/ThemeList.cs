#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (c) 2022 Genshin  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：GS2-20220506KRQ
 * 唯一标识：49fef3cd-c80f-4f4c-bd4b-9c9fb6ad2068
 * 文件名：ThemeList
 * 创建者：Administrator
 * 电子邮箱：307886418@qq.com
 * 创建时间：2022/7/5 17:39:27
 * 版本：V1.0.0
 *----------------------------------------------------------------*/
#endregion << 版 本 注 释 >>

using CQIE.OVS.Models;
using CQIE.OVS.Services.IService;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CQIE.OVS.Web.ViewComponents
{
    /// <summary>
    /// 主题活动-视图组件
    /// </summary>
    public class ThemeList : ViewComponent
    {
        private readonly IThemeService _themeService;
        public ThemeList(IThemeService themeService)
        {
            _themeService = themeService;
        }

        /// <summary>
        /// 获取主题列表
        /// </summary>
        /// <returns></returns>
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _themeService.GetListAsync();
            return View(value);
        }
    }
}
