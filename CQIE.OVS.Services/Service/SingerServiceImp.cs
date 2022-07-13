#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (c) 2022 Genshin  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：GS2-20220506KRQ
 * 唯一标识：a541770b-10db-4cef-928d-3755693a236b
 * 文件名：SingerServiceImp
 * 创建者：Administrator
 * 电子邮箱：307886418@qq.com
 * 创建时间：2022/7/5 8:54:52
 * 版本：V1.0.0
 *----------------------------------------------------------------*/
#endregion << 版 本 注 释 >>
using CQIE.OVS.DataAccess.Database;
using CQIE.OVS.Models;
using CQIE.OVS.Repository.IRepository;
using CQIE.OVS.Services.IService;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQIE.OVS.Services.Service
{
    public class SingerServiceImp : BaseServiceImp<Singer>, ISingerService
    {
        private readonly OVSDbContext _context;
        public SingerServiceImp(IBaseRepository<Singer> iBaseRepository, OVSDbContext context)
            : base(iBaseRepository)
        {
            _context = context;
        }

        public IEnumerable<Singer> GetListSinger()
        {
            var value = _context.Singers;
            return value;
        }

    }
}
