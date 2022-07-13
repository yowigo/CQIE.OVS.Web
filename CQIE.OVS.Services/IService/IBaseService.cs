#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (c) 2022 Genshin  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：GS2-20220506KRQ
 * 唯一标识：0e91d91c-f1d5-4b3d-a17f-b24804a15fdd
 * 文件名：IBaseService
 * 创建者：Administrator
 * 电子邮箱：307886418@qq.com
 * 创建时间：2022/7/7 9:22:48
 * 版本：V1.0.0
 *----------------------------------------------------------------*/
#endregion << 版 本 注 释 >>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CQIE.OVS.Services.IService
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        Task<bool> CreateAsync(TEntity entity);
        Task<bool> DeleteAsync(TEntity entity, int id);
        Task<bool> EditAsync(TEntity entity);
        Task<TEntity> FindByIdAsync(int id);
        Task<List<TEntity>> GetListAsync();
        IQueryable<TEntity> GetListAsync(Expression<Func<TEntity, bool>> func); // 自定义条件查询
    }
}
