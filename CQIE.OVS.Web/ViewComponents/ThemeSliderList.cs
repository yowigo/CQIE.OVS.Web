#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (c) 2022 Genshin  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：GS2-20220506KRQ
 * 唯一标识：0b5b46d0-51fa-4665-b145-cf7c7ec916be
 * 文件名：ThemeSliderList
 * 创建者：Administrator
 * 电子邮箱：307886418@qq.com
 * 创建时间：2022/7/6 9:16:10
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
    /// 主题活动轮播-视图组件
    /// </summary>
    public class ThemeSliderList : ViewComponent
    {
        private readonly IThemeService _themeService;
        public ThemeSliderList(IThemeService themeService)
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
