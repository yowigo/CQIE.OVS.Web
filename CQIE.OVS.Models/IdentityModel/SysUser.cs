#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (c) 2022 Genshin  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：GS2-20220506KRQ
 * 唯一标识：6eb3ee9f-671e-43eb-ad26-d3816516e4db
 * 文件名：User
 * 创建者：Administrator
 * 电子邮箱：307886418@qq.com
 * 创建时间：2022/7/4 12:00:10
 * 版本：V1.0.0
 *----------------------------------------------------------------*/
#endregion << 版 本 注 释 >>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using IdentityModel;
using Microsoft.AspNetCore.Identity;


namespace CQIE.OVS.Models.IdentityModel
{
    [Table("OVS_SysUser")]
    public class SysUser : IdentityUser<int>
    {
        [Display(Name = "生日")]
        [DataType(DataType.Date)]
        public DateTime BirthDay { get; set; }

        [Display(Name = "地址")]
        public string Address { get; set; }

        /// <summary>
        /// 导航属性
        /// User与Theme多对多
        /// </summary>
        //public int UserId { get; set; }
        public List<Theme_User> Theme_Users { get; set; }

        public ICollection<SysUserRole> SysUserRoles { get; set; } = new HashSet<SysUserRole>();
        public string LoginPassword { get; set; }
    }
}
