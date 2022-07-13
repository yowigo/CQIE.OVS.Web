#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (c) 2022 Genshin  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：GS2-20220506KRQ
 * 唯一标识：444858de-c04c-430f-be2e-d15316957c91
 * 文件名：ThemeSingerViewModel
 * 创建者：Administrator
 * 电子邮箱：307886418@qq.com
 * 创建时间：2022/7/12 20:27:13
 * 版本：V1.0.0
 *----------------------------------------------------------------*/
#endregion << 版 本 注 释 >>

using CQIE.OVS.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace CQIE.OVS.Web.Areas.Admin.Models
{
    public class ThemeSingerViewModel
    {
        public int Singer1Id { get; set; }
        public int Singer2Id { get; set; }
        public Theme Theme { get; set; }
        public Singer Singer { get; set; }
        public IEnumerable<SelectListItem> SingerListItems { get; set; }
    }
}
