using CQIE.OVS.Models;
using CQIE.OVS.Services.IService;
using CQIE.OVS.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CQIE.OVS.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IThemeService _themeService;

        public HomeController(ILogger<HomeController> logger,IThemeService themeService)
        {
            _logger = logger;
            _themeService = themeService;
        }

        public async Task<IActionResult> Index()
        {
            var value = await _themeService.GetListAsync();
            return View(value);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
