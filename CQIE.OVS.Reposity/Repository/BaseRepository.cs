
using CQIE.OVS.DataAccess.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CQIE.OVS.Repository.IRepository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        //接收子类传入的数据库上下文
        private readonly OVSDbContext _context;
        private readonly DbSet<TEntity> _dbSet;
        public BaseRepository(OVSDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> CreateAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(TEntity entity,int id)
        {
            entity = await _dbSet.FindAsync(id);
            _dbSet.Remove(entity);
            await SaveChangesAsync();
            return true;
        }

        public async Task<bool> EditAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            await SaveChangesAsync();
            return true;
        }

        //导航查询
        public async Task<TEntity> FindAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<List<TEntity>> QueryAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public IQueryable<TEntity> QueryAsync(Expression<Func<TEntity, bool>> func)
        {
            var query = _dbSet.Where(func);
            return query;
        }
    }
}
