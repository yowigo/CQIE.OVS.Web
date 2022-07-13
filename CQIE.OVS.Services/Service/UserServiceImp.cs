using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using CQIE.OVS.DataAccess.Database;
using Microsoft.AspNetCore.Identity;
using CQIE.OVS.Models.IdentityModel;

namespace CQIE.OVS.Services
{
    /// <summary>
    /// 用户服务实现
    /// </summary>
    public class UserServiceImp : IUserService
    {
        private readonly OVSDbContext _context;
        private readonly UserManager<SysUser> m_UserManager;

        public UserServiceImp(OVSDbContext context, UserManager<SysUser> userManager)
        {
            _context = context;
            m_UserManager = userManager;
        }

        public async Task<bool> AddAsync(SysUser user)
        {
            await m_UserManager.CreateAsync(user, user.LoginPassword);
            return true;
        }

        public async Task<bool> DeleteAsync(SysUser user)
        {
            await m_UserManager.DeleteAsync(user);
            return true;
        }

        public async Task<bool> EditAsync(SysUser user)
        {
            await m_UserManager.UpdateAsync(user);
            return true;
        }

        public async Task<SysUser> GetById(int id)
        {
            var query = from o in _context.Users
                        where o.Id == id
                        select o;
            return await query.FirstOrDefaultAsync();
        }

        public IQueryable<SysUser> GetList()
        {
            var query = from o in _context.Users
                        select o;
            return query;
        }



        public IQueryable<SysUser> GetUsers()
        {
            var query = from o in _context.Users
                        select o;

            return query;
        }
        public SysUser GetUserByID(int id)
        {
            var query = from o in _context.Users
                        where o.Id == id
                        select o;

            return query.FirstOrDefault();
        }
        public async Task<bool> SaveUser(SysUser user)
        {
            await m_UserManager.CreateAsync(user, user.LoginPassword);

            return true;
        }
        public bool RemoveUser(int userId)
        {
            var item = (from o in _context.Users.Include(c => c.SysUserRoles) // 删除用户时联带其角色关系表的数据一起删除
                        where o.Id == userId
                        select o).FirstOrDefault();

            if (item != null)
            {
                _context.Users.Remove(item);
                _context.SaveChanges();

                return true;
            }

            return false;
        }
    }
}
