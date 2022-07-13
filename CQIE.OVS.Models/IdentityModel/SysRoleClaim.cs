#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (c) 2022 Genshin  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：GS2-20220506KRQ
 * 唯一标识：1fcdf7d3-569a-4e1a-b340-73bc062a4af5
 * 文件名：SysRoleClaim
 * 创建者：Administrator
 * 电子邮箱：307886418@qq.com
 * 创建时间：2022/7/4 17:10:12
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
    [Table("OVS_SysRoleClaim")]
    public class SysRoleClaim : IdentityRoleClaim<int>
    {
    }
}
