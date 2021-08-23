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
                users.Add(new UserModel(item.Id, item.Email, await userManager.IsInRoleAsync(item, "admin")));
            }
            return Json(users);
        }
    }
}
