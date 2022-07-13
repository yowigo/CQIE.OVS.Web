#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (c) 2022 Genshin  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：GS2-20220506KRQ
 * 唯一标识：c631cb0e-040f-4747-805f-1c8f27da9d41
 * 文件名：SingerNumberView
 * 创建者：Administrator
 * 电子邮箱：307886418@qq.com
 * 创建时间：2022/7/13 1:22:57
 * 版本：V1.0.0
 *----------------------------------------------------------------*/
#endregion << 版 本 注 释 >>
using System;
using System.Collections.Generic;
using System.Text;


namespace CQIE.OVS.Models.ViewModel
{
    public class SingerNumberView
    {
        /// <summary>
        /// 歌手姓名
        /// </summary>
        public string SingerName { get; set; }
        /// <summary>
        /// 歌手票数
        /// </summary>
        public int SingerVoteNum { get; set; }
    }
}
