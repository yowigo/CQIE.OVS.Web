using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CQIE.OVS.Models
{
    [Table("OVS_Singer")]
    public class Singer
    {
        public int Id { get; set; }

        [Display(Name ="姓名")]
        [StringLength(20, ErrorMessage = "歌手姓名不超过20字"), Required]
        public string Name { get; set; }

        [Display(Name = "生日")]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

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
        [StringLength(50,ErrorMessage ="座右铭不超过50字")]
        public string Motto { get; set; }
        /// <summary>
        /// 个人简介
        /// </summary>
        [Display(Name = "个人简介")]
        [StringLength(500, ErrorMessage = "个人简介不超过500字"), Required]
        public string Profile { get; set; }

        [Display(Name = "照片存储路径")]
        public string PhotoPath { get; set; }


        /// <summary>
        /// 导航属性
        /// Singer与Theme一对多
        /// </summary>
        public List<Theme_Singer> Theme_Singers { get; set; }
    }
}
