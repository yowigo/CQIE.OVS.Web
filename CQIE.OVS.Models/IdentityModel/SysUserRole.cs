#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (c) 2022 Genshin  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：GS2-20220506KRQ
 * 唯一标识：aa77a176-1e5b-46f1-b2d6-cd45f0dc6c3c
 * 文件名：SysUserRole
 * 创建者：Administrator
 * 电子邮箱：307886418@qq.com
 * 创建时间：2022/7/4 17:12:32
 * 版本：V1.0.0
 *----------------------------------------------------------------*/
#endregion << 版 本 注 释 >>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace CQIE.OVS.Models.IdentityModel
{
    [Table("OVS_SysUserRole")]
    public class SysUserRole : Microsoft.AspNetCore.Identity.IdentityUserRole<int>
    {
        public int Id { get; set; }
        public SysRole Role { get; set; }
        public SysUser User { get; set; }
    }
}
