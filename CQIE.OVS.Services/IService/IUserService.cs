using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using CQIE.OVS.Models.IdentityModel;
using System.Linq.Expressions;

namespace CQIE.OVS.Services
{
    /// <summary>
    /// 用户服务
    /// </summary>
    public interface IUserService
    {
        Task<bool> AddAsync(SysUser user);
        Task<bool> DeleteAsync(SysUser user);
        Task<bool> EditAsync(SysUser user);
        Task<SysUser> GetById(int id);
        IQueryable<SysUser> GetList();
    }
}
