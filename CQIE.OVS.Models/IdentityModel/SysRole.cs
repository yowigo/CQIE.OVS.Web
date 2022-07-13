#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (c) 2022 Genshin  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：GS2-20220506KRQ
 * 唯一标识：76a046a0-de52-4d80-b89f-48a2cee1381e
 * 文件名：Role
 * 创建者：Administrator
 * 电子邮箱：307886418@qq.com
 * 创建时间：2022/7/4 15:35:04
 * 版本：V1.0.0
 *----------------------------------------------------------------*/
#endregion << 版 本 注 释 >>
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace CQIE.OVS.Models.IdentityModel
{
    [Table("OVS_SysRole")]
    public class SysRole : IdentityRole<int>
    {
        public ICollection<SysUserRole> SysUserRoles { get; set; } = new HashSet<SysUserRole>();
    }
}
