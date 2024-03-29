﻿#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (c) 2022 Genshin  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：GS2-20220506KRQ
 * 唯一标识：86b3057d-deda-4465-8630-3b9ca1279d34
 * 文件名：AdminController
 * 创建者：Administrator
 * 电子邮箱：307886418@qq.com
 * 创建时间：2022/7/11 16:22:59
 * 版本：V1.0.0
 *----------------------------------------------------------------*/
#endregion << 版 本 注 释 >>
using CQIE.OVS.Models.IdentityModel;
using CQIE.OVS.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQIE.OVS.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SystemsController : Controller
    {
        private readonly RoleManager<SysRole> _roleManager;
        private readonly UserManager<SysUser> _userManager;
        private readonly ILogger<SystemsController> _logger;
        public SystemsController(RoleManager<SysRole> roleManager, UserManager<SysUser> userManager, ILogger<SystemsController> logger)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _logger = logger;
        }

        #region 角色管理
        //其他代码
        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                //我们只需要指定一个不重复的角色名称来创建新角色

                SysRole sysRole = new SysRole
                {
                    Name = model.RoleName
                };

                //将角色保存在AspNetRoles表中

                var result = await _roleManager.CreateAsync(sysRole);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles","Systems");
                }

                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }


        [HttpGet]
        public IActionResult ListRoles()
        {
            var roles = _roleManager.Roles;
            return View(roles);
        }

        //角色ID从URL传递给操作方法
        [HttpGet]
        public async Task<IActionResult> EditRole(string id)
        {
            //通过角色ID查找角色
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                ViewBag.ErrorMessage = $"角色Id={id}的信息不存在，请重试。";
                return View("NotFound");
            }
            var model = new EditRoleViewModel
            {
                Id = role.Id.ToString(),
                RoleName = role.Name
            };
            var users = _userManager.Users.ToList();

            //查询所有的用户
            foreach (var user in users)
            {
                //如果用户拥有此角色，请将用户名添加到
                //EditRoleViewModel模型中的Users属性中
                //然后将对象传递给视图显示到客户端
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    model.Users.Add(user.Email);
                }
            }

            return View(model);
        }

        //此操作方法用于响应HttpPost的请求并接收EditRoleViewModel模型数据
        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleViewModel model)
        {
            var role = await _roleManager.FindByIdAsync(model.Id);
            if (role == null)
            {
                ViewBag.ErrorMessage = $"角色Id={model.Id}的信息不存在，请重试。";
                return View("NotFound");
            }
            else
            {
                role.Name = model.RoleName;

                //使用UpdateAsync更新角色
                var result = await _roleManager.UpdateAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                ViewBag.ErrorMessage = $"无法找到ID为{id}的角色信息";
                return View("NotFound");
            }
            else
            {
                try
                {
                    var result = await _roleManager.DeleteAsync(role);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("ListRoles","Systems");
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                    return View("删除失败");

                }
                ///如果触发的异常是DbUpdateException，我们知道我们无法删除角色，
                ///因为该角色中已存在用户信息
                catch (DbUpdateException ex)
                {
                    //将异常记录到文件中。我们之前已经学习了使用Nlog配置我们的日志信息
                    _logger.LogError($"发生异常 : {ex}");
                    //我们使用ViewBag.ErrorTitle和 ViewBag.ErrorMessage来传递错误标题和详情信息到我们的Error视图。
                    //Error视图会将这些数据显示给用户                    
                    ViewBag.ErrorTitle = $"角色：{role.Name} 正在被使用中...";
                    ViewBag.ErrorMessage = $" 无法删除{role.Name}角色，因为此角色中已经存在用户。如果您想删除此角色，需要先从该角色中删除用户，然后尝试删除该角色本身。";
                    return View("Error");
                }
            }
        }

        #endregion

        #region 用户管理
        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                //我们只需要指定一个不重复的用户来创建新角色
                SysUser sysUser = new SysUser
                {
                    Email = model.Email
                };

                //将用户保存在AspNetUsers表中
                var result = await _userManager.CreateAsync(sysUser);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListUsers","Systems");
                }

                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult ListUsers()
        {
            var users = _userManager.Users.ToList();
            return View(users);
        }
        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"无法找到ID为{id}的用户";
                return View("NotFound");
            }
            // GetClaimsAsync返回用户声明列表
            var userClaims = await _userManager.GetClaimsAsync(user);
            // GetRolesAsync返回用户角色列表
            var userRoles = await _userManager.GetRolesAsync(user);

            var model = new EditUserViewModel
            {
                Id = user.Id.ToString(),
                Email = user.Email,
                BirthDay = user.BirthDay,
                Address = user.Address,
                Claims = userClaims.Select(c => c.Value).ToList(),
                Roles = userRoles
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditUser(EditUserViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.Id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"无法找到ID为{model.Id}的用户";
                return View("NotFound");
            }
            else
            {
                user.Email = model.Email;
                user.Address = model.Address;
                user.BirthDay = model.BirthDay;
                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListUsers");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(model);
            }
        }


        [HttpPost]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"无法找到ID为{id}的用户";
                return View("NotFound");
            }
            else
            {
                var result = await _userManager.DeleteAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListUsers");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View("ListUsers");
            }
        }

        #endregion

        #region 角色中的用户

        [HttpGet]
        public async Task<IActionResult> EditUsersInRole(string roleId)
        {
            ViewBag.roleId = roleId;
            //通过id查询角色实体信息
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                ViewBag.ErrorMessage = $"角色Id={roleId}的信息不存在，请重试。";
                return View("NotFound");
            }
            var model = new List<UserRoleViewModel>();
            //将所有的用户数据查询到内容中
            var users = _userManager.Users.ToList();
            foreach (var user in users)
            {
                var userRoleViewModel = new UserRoleViewModel
                {
                    UserId = user.Id.ToString(),
                    Email = user.Email
                };
                //判断当前用户是否已经存在于角色中
                var isInRole = await _userManager.IsInRoleAsync(user, role.Name);

                if (isInRole)
                {//存在则设置为选中状态，值为true
                    userRoleViewModel.IsSelected = true;
                }
                else
                {//不存在则设置为选中状态，值为false
                    userRoleViewModel.IsSelected = false;
                }
                model.Add(userRoleViewModel);
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditUsersInRole(List<UserRoleViewModel> model, string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            //检查当前角色是否存在
            if (role == null)
            {
                ViewBag.ErrorMessage = $"角色Id={roleId}的信息不存在，请重试。";
                return View("NotFound");
            }

            for (int i = 0; i < model.Count; i++)
            {
                var user = await _userManager.FindByIdAsync(model[i].UserId);

                IdentityResult result = null;
                //检查当前的userid，是否被选中，如果被选中了则添加到角色中。

                if (model[i].IsSelected && !(await _userManager.IsInRoleAsync(user, role.Name)))
                {
                    result = await _userManager.AddToRoleAsync(user, role.Name);
                }//对于没有选中的则从userroles表中移除。
                else if (!model[i].IsSelected && await _userManager.IsInRoleAsync(user, role.Name))
                {
                    result = await _userManager.RemoveFromRoleAsync(user, role.Name);
                }
                else
                { //对于其他情况不做处理，继续新的循环。
                    continue;
                }

                if (result.Succeeded)
                {   //判断当前用户是否为最后一个用户，如果是则跳转回EditRole视图，如果不是则进入下一个循环
                    if (i < (model.Count - 1))
                        continue;
                    else
                        return RedirectToAction("EditRole", new { Id = roleId });
                }
            }

            return RedirectToAction("EditRole", new { Id = roleId });
        }

        #endregion

        #region 管理用户中的角色
        [HttpGet]
        public async Task<IActionResult> ManageUserRoles(string userId)
        {
            ViewBag.userId = userId;
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"无法找到ID为{userId}的用户";
                return View("NotFound");
            }

            var model = new List<RolesInUserViewModel>();

            var roles = await _roleManager.Roles.ToListAsync();
            foreach (var role in roles)
            {
                var rolesInUserViewModel = new RolesInUserViewModel
                {
                    RoleId = role.Id.ToString(),
                    RoleName = role.Name
                };
                //判断当前用户是否已经拥有该角色信息
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    //将已拥有的角色信息设置为选中
                    rolesInUserViewModel.IsSelected = true;
                }
                else
                {
                    rolesInUserViewModel.IsSelected = false;
                }
                //添加已经角色新到视图模型列表
                model.Add(rolesInUserViewModel);
            }

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> ManageUserRoles(List<RolesInUserViewModel> model, string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"无法找到ID为{userId}的用户";
                return View("NotFound");
            }

            var roles = await _userManager.GetRolesAsync(user);
            //移除当前用户中的所有角色信息
            var result = await _userManager.RemoveFromRolesAsync(user, roles);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "无法删除用户中的现有角色");
                return View(model);
            }
            //查询出模型列表中被选中的rolename添加到用户中。
            result = await _userManager.AddToRolesAsync(user,
                model.Where(x => x.IsSelected).Select(y => y.RoleName));

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "无法向用户添加选定的角色");
                return View(model);
            }

            return RedirectToAction("EditUser", new { Id = userId });
        }

        #endregion
    }
}
