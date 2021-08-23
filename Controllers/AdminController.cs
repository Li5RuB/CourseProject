using CourseProject.Data;
using CourseProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProject.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private UserManager<MyIdentity> userManager;
        private ApplicationDbContext context;
        public AdminController(UserManager<MyIdentity> userManager, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> GetUsersAsync()
        {
            List<UserModel> users = new List<UserModel>();
            foreach (var item in userManager.Users)
            {
                users.Add(new UserModel(item.Id, item.Email, await userManager.IsInRoleAsync(item, "admin"), await userManager.IsLockedOutAsync(item)));
            }
            return Json(users);
        }

        [HttpPost]
        public async Task DeleteUserAsync(string id)
        {
            await userManager.DeleteAsync(await userManager.FindByIdAsync(id));
        }

        [HttpPost]
        public async Task SetBlockAsync(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user.LockoutEnd>DateTime.Now)
            {
                user.LockoutEnd = DateTime.Now;
            }
            else { user.LockoutEnd = DateTime.MaxValue; }
            var result = await userManager.UpdateAsync(user);
        }

        [HttpPost]
        public async Task SetAdminAsync(string id)
        {
            if (await userManager.IsInRoleAsync(await userManager.FindByIdAsync(id),"admin"))
            {
                await userManager.RemoveFromRoleAsync(await userManager.FindByIdAsync(id), "admin");
            }
            else { await userManager.AddToRoleAsync(await userManager.FindByIdAsync(id), "admin"); }
        }
    }
}
