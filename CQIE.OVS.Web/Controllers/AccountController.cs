using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using CQIE.OVS.Models.IdentityModel;
using CQIE.OVS.Web.Models;
using CQIE.OVS.Services;
using CQIE.OVS.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using CQIE.OVS.DataAccess.Database;
using System.Linq;

namespace CQIE.OVS.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<SysUser> _userManager;
        private readonly SignInManager<SysUser> _signInManager;
        private readonly OVSDbContext _context;
        public AccountController(UserManager<SysUser> userManager, OVSDbContext context,
          SignInManager<SysUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(
                    model.Email, model.Password, model.RememberMe, false);
                //查询用户,将用户信息存进Session
                var user = await _userManager.FindByNameAsync(model.Email);
                var userString = System.Text.Json.JsonSerializer.Serialize(user);
                HttpContext.Session.SetString("UserSession", userString);

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        if (Url.IsLocalUrl(returnUrl))
                        {
                            return Redirect(returnUrl);
                        }
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }


                ModelState.AddModelError(string.Empty, "登录失败，请重试");
            }

            return View(model);
        }


        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                //将数据从RegisterViewModel复制到IdentityUser
                var user = new SysUser
                {
                    UserName = model.Email,
                    Email = model.Email
                };

                //将用户数据存储在AspNetUsers数据库表中
                var result = await _userManager.CreateAsync(user, model.Password);

                //如果成功创建用户，则使用登录服务登录用户信息
                //并重定向到home econtroller的索引操作
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("index", "home");
                }

                //如果有任何错误，将它们添加到ModelState对象中
                //将由验证摘要标记助手显示到视图中
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }

        /// <summary>
        /// 退出登录状态
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        public async Task<IActionResult> Logout([FromServices] SessionService session)
        {
            session.Clear();
            await _signInManager.SignOutAsync();
            return Redirect("~/Account/Login");
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }

    }
}
