#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (c) 2022 Genshin  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：GS2-20220506KRQ
 * 唯一标识：35ba7f7b-ceb4-444d-a687-a8b73eca28e1
 * 文件名：ISingerService
 * 创建者：Administrator
 * 电子邮箱：307886418@qq.com
 * 创建时间：2022/7/5 8:51:16
 * 版本：V1.0.0
 *----------------------------------------------------------------*/
#endregion << 版 本 注 释 >>
using CQIE.OVS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CQIE.OVS.Services.IService
{
    public interface ISingerService : IBaseService<Singer>
    {
        // extend-here

        //获取所有歌手
        IEnumerable<Singer> GetListSinger();
    }
}
