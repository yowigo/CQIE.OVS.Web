using CQIE.OVS.DataAccess.Database;
using CQIE.OVS.Models;
using CQIE.OVS.Services.IService;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQIE.OVS.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SingersController : Controller
    {
        private readonly ISingerService _singerService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly OVSDbContext _context;

        public SingersController(ISingerService singerService, OVSDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _singerService = singerService;
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        /// <summary>
        /// 歌手列表
        /// </summary>
        /// <param name="searchString">模糊查询条件：按姓名查找</param>
        /// <returns></returns>
        public async Task<IActionResult> Index(string searchString)
        {
            var singers = await _singerService.GetListAsync();
            //模糊查询
            if (!String.IsNullOrEmpty(searchString))
            {
                var query = _context.Singers.Where(s => s.Name.Contains(searchString));
                ViewData["CurrentFilter"] = searchString;
                return View(query);
            }
            return View(singers);
        }

        
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Singer singer)
        {
            var value = await _singerService.CreateAsync(singer);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Edit(int id)
        {
            var singer =await _singerService.FindByIdAsync(id);
            if (singer == null)
                return View("没有找到该歌手！！");
            return View(singer);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Singer model)
        {
            Singer newSinger = new Singer()
            {
                Id = model.Id,
                Name = model.Name,
                Birthday = model.Birthday,
                Gender = model.Gender,
                Phone = model.Phone,
                National = model.National,
                Motto = model.Motto,
                Profile = model.Profile,
                PhotoPath = model.PhotoPath
            };

            await _singerService.EditAsync(newSinger);
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Delete(Singer singer, int id)
        {
            _singerService.DeleteAsync(singer, id);
            return RedirectToAction("Index");
        }
    }
}
