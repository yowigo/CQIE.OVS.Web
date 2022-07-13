#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (c) 2022 Genshin  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：GS2-20220506KRQ
 * 唯一标识：527a5d53-b109-4711-8ffc-373158ef2e98
 * 文件名：Sys_UserClaim
 * 创建者：Administrator
 * 电子邮箱：307886418@qq.com
 * 创建时间：2022/7/4 17:07:42
 * 版本：V1.0.0
 *----------------------------------------------------------------*/
#endregion << 版 本 注 释 >>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.AspNetCore.Identity;


namespace CQIE.OVS.Models.IdentityModel
{
    [Table("OVS_SysUserClaim")]
    public class SysUserClaim : IdentityUserClaim<int>
    {
    }
}
