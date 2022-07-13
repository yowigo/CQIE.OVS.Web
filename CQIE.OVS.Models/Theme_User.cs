#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (c) 2022 Genshin  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：GS2-20220506KRQ
 * 唯一标识：d6828a73-3c92-405b-b60c-9f5effcd57bb
 * 文件名：Theme_User
 * 创建者：Administrator
 * 电子邮箱：307886418@qq.com
 * 创建时间：2022/7/4 12:05:47
 * 版本：V1.0.0
 *----------------------------------------------------------------*/
#endregion << 版 本 注 释 >>
using CQIE.OVS.Models.IdentityModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CQIE.OVS.Models
{
    [Table("OVS_Theme_User")]
    public class Theme_User
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ThemeId { get; set; }

        /// <summary>
        /// 导航属性
        /// </summary>
        public Theme Theme { get; set; }
        public SysUser User { get; set; }
    }
}
