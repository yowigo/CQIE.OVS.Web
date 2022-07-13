#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (c) 2022 Genshin  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：GS2-20220506KRQ
 * 唯一标识：f0a7048c-f152-482e-bb53-d457b402ed11
 * 文件名：SingerViewModel
 * 创建者：Administrator
 * 电子邮箱：307886418@qq.com
 * 创建时间：2022/7/8 14:20:17
 * 版本：V1.0.0
 *----------------------------------------------------------------*/
#endregion << 版 本 注 释 >>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Http;


namespace CQIE.OVS.Models.ViewModel
{
    public class SingerViewModel
    {
        [Display(Name = "姓名")]
        [StringLength(20, ErrorMessage = "歌手姓名不超过20字"), Required]
        public string Name { get; set; }
        [Display(Name = "年龄")]
        public int Age { get; set; }

        /// <summary>
        /// 性别，女=0，男=1
        /// </summary>
        [Display(Name = "性别")]
        public int Gender { get; set; }

        [Display(Name = "电话号码")]
        [StringLength(11, ErrorMessage = "电话号码不超过11位"), Required]
        public string Phone { get; set; }
        /// <summary>
        /// 国籍
        /// </summary>
        [Display(Name = "国籍")]
        [StringLength(20), Required]
        public string National { get; set; }
        /// <summary>
        /// 座右铭
        /// </summary>
        [Display(Name = "座右铭")]
        [StringLength(50, ErrorMessage = "座右铭不超过50字")]
        public string Motto { get; set; }
        /// <summary>
        /// 个人简介
        /// </summary>
        [Display(Name = "个人简介")]
        [StringLength(500, ErrorMessage = "个人简介不超过500字"), Required]
        public string Profile { get; set; }

        [Display(Name = "头像")]
        public List<IFormFile> Photo { get; set; }
        /// <summary>
        /// 票数
        /// </summary>
        [Display(Name = "票数")]
        public int VoteNum { get; set; }
    }
}
