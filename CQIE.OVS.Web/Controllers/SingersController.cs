#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (c) 2022 Genshin  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：GS2-20220506KRQ
 * 唯一标识：4647bfff-33b7-4beb-95ff-5a680a91b316
 * 文件名：SingersController
 * 创建者：Administrator
 * 电子邮箱：307886418@qq.com
 * 创建时间：2022/7/5 9:13:57
 * 版本：V1.0.0
 *----------------------------------------------------------------*/
#endregion << 版 本 注 释 >>
using CQIE.OVS.Models;
using CQIE.OVS.Services.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CQIE.OVS.Web.Controllers
{
    public class SingersController : Controller
    {
        private readonly ISingerService _singerService;
        public SingersController(ISingerService singerService)
        {
            _singerService = singerService;
        }

        public async Task<IActionResult> Index()
        {
            var value = await _singerService.GetListAsync();
            return View(value);
        }
    }
}
