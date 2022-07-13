#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (c) 2022 Genshin  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：GS2-20220506KRQ
 * 唯一标识：aac26c50-f788-438c-b9c0-8fd07d1c98c8
 * 文件名：Theme_Singer
 * 创建者：Administrator
 * 电子邮箱：307886418@qq.com
 * 创建时间：2022/7/9 11:43:14
 * 版本：V1.0.0
 *----------------------------------------------------------------*/
#endregion << 版 本 注 释 >>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace CQIE.OVS.Models
{
    public class Theme_Singer
    {
        public int Id { get; set; }
        public int ThemeId { get; set; }
        public int SingerId { get; set; }
        /// <summary>
        /// 获得票数
        /// </summary>
        [Display(Name = "票数")]
        public int VoteNum { get; set; }

        /// <summary>
        /// 导航属性
        /// </summary>
        public Theme Theme { get; set; }
        public Singer Singer { get; set; }
    }
}
