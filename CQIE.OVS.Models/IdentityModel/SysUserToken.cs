#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (c) 2022 Genshin  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：GS2-20220506KRQ
 * 唯一标识：6bfdf50c-2764-4902-8766-999c2d550c48
 * 文件名：SysUserToken
 * 创建者：Administrator
 * 电子邮箱：307886418@qq.com
 * 创建时间：2022/7/4 17:13:23
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
    [Table("OVS_SysUserToken")]
    public class SysUserToken : IdentityUserToken<int>
    {
        public int Id { get; set; }
    }
}
