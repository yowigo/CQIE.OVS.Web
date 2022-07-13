#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (c) 2022 Genshin  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：GS2-20220506KRQ
 * 唯一标识：ca52b8d3-ea7e-413b-8a83-862e29e7c405
 * 文件名：Theme
 * 创建者：Administrator
 * 电子邮箱：307886418@qq.com
 * 创建时间：2022/7/4 11:51:56
 * 版本：V1.0.0
 *----------------------------------------------------------------*/
#endregion << 版 本 注 释 >>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace CQIE.OVS.Models
{
    [Table("OVS_Theme")]
    public class Theme
    {
        public int Id { get; set; }

        [Display(Name ="主题名称")]
        [StringLength(20, ErrorMessage = "主题名称不超过20字"), Required]
        public string Name { get; set; }

        [Display(Name="主题类别")]
        [StringLength(20, ErrorMessage = "主题类别不超过20字"), Required]
        public string Categroy { get; set; }

        [Display(Name="项目简介")]
        public string Description { get; set; }

        [Display(Name = "开始时间")]
        [DataType(DataType.Date)]
        public DateTime StartTime { get; set; }

        [Display(Name = "结束时间")]
        [DataType(DataType.Date)]
        public DateTime EndTime { get; set; }
        
        /// <summary>
        /// 导航属性
        /// Theme与Singer一对多；与User多对多
        /// </summary>
        public List<Theme_Singer> Theme_Singers { get; set; }
        public List<Theme_User> Theme_Users { get; set; }
    }
}
