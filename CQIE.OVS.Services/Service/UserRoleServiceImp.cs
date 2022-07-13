using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using CQIE.OVS.DataAccess.Database;

namespace CQIE.OVS.Services
{
    /// <summary>
    /// 用户角色服务实现
    /// </summary>
    public class UserRoleServiceImp : IUserRoleService
    {
        private readonly OVSDbContext _context;

        public UserRoleServiceImp(OVSDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 获取用户的角色
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<int> GetUserRoles(int userId)
        {
            var query = from o in _context.UserRoles
                        where o.UserId == userId
                        select o.RoleId;

            return query.ToList();
        }
    }
}
