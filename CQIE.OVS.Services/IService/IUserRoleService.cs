using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CQIE.OVS.Services
{
    /// <summary>
    /// 用户角色服务
    /// </summary>
    public interface IUserRoleService
    {
        /// <summary>
        /// 获取用户的角色
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        List<int> GetUserRoles(int userId);

    }
}
