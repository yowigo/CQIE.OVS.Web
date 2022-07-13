#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (c) 2022 Genshin  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：GS2-20220506KRQ
 * 唯一标识：e7e6761a-2265-45eb-9bdc-0e2ce641dcc4
 * 文件名：BaseServiceImp
 * 创建者：Administrator
 * 电子邮箱：307886418@qq.com
 * 创建时间：2022/7/7 9:24:37
 * 版本：V1.0.0
 *----------------------------------------------------------------*/
#endregion << 版 本 注 释 >>
using CQIE.OVS.Repository.IRepository;
using CQIE.OVS.Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CQIE.OVS.Services.Service
{
    public class BaseServiceImp<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        //从子类的构造函数中传入
        private readonly IBaseRepository<TEntity> _iBaseRepository;
        public BaseServiceImp(IBaseRepository<TEntity> iBaseRepository)
        {
            _iBaseRepository = iBaseRepository;
        }

        public async Task<bool> CreateAsync(TEntity entity)
        {
            return await _iBaseRepository.CreateAsync(entity);
        }

        public async Task<bool> DeleteAsync(TEntity entity, int id)
        {
            return await _iBaseRepository.DeleteAsync(entity,id);
        }

        public async Task<bool> EditAsync(TEntity entity)
        {
            return await _iBaseRepository.EditAsync(entity);
        }

        public async Task<TEntity> FindByIdAsync(int id)
        {
            return await _iBaseRepository.FindAsync(id);
        }

        public async Task<List<TEntity>> GetListAsync()
        {
            return await _iBaseRepository.QueryAsync();
        }

        public IQueryable<TEntity> GetListAsync(Expression<Func<TEntity, bool>> func)
        {
            return _iBaseRepository.QueryAsync(func);
        }
    }
}
