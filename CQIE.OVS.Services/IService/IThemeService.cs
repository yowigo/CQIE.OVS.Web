#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (c) 2022 Genshin  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：GS2-20220506KRQ
 * 唯一标识：a3b9c8e9-005d-4053-af59-39f1c28428a7
 * 文件名：IThemeService
 * 创建者：Administrator
 * 电子邮箱：307886418@qq.com
 * 创建时间：2022/7/5 0:03:27
 * 版本：V1.0.0
 *----------------------------------------------------------------*/
#endregion << 版 本 注 释 >>
using CQIE.OVS.Models;
using CQIE.OVS.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CQIE.OVS.Services.IService
{
    public interface IThemeService : IBaseService<Theme>
    {
        //extend-here
        Task<Theme> GetThemeSinger(int id);
        //通过ThemeId找到歌手
        Task<List<Theme>> GetListSingerByTheme();

        Task<bool> AddThemeSinger(Theme_Singer theme_Singer);

        IEnumerable<SingerNumberView> GetVoteNumByTheme(int GameId);
    }
}
