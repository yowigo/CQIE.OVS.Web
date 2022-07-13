#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (c) 2022 Genshin  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：GS2-20220506KRQ
 * 唯一标识：9c7ba814-1286-44dc-be1b-1be261077f51
 * 文件名：SingerRepository
 * 创建者：Administrator
 * 电子邮箱：307886418@qq.com
 * 创建时间：2022/7/7 10:45:49
 * 版本：V1.0.0
 *----------------------------------------------------------------*/
#endregion << 版 本 注 释 >>
using CQIE.OVS.DataAccess.Database;
using CQIE.OVS.Models;
using CQIE.OVS.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;


namespace CQIE.OVS.Repository.Repository
{
    public class SingerRepository : BaseRepository<Singer>, ISingerRepository
    {
        public SingerRepository(OVSDbContext context) : base(context)
        {
        }
    }
}
