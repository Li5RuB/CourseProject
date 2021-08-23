using CourseProject.Data;
using CourseProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProject.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private UserManager<MyIdentity> userManager;
        private ApplicationDbContext context;
        private RoleManager<IdentityRole> roleManager;
        public ProfileController(UserManager<MyIdentity> userManager, ApplicationDbContext context, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.context = context;
            this.roleManager = roleManager;
        }
        public async Task<IActionResult> IndexAsync(string userid)
        {
            var curuser = await userManager.GetUserAsync(User);
            if (curuser.Id==userid||await userManager.IsInRoleAsync(curuser,"admin"))
            {
                var user = await context.Users.Include(i => i.Collections).ThenInclude(t => t.Topic).SingleAsync(u => u.Email == curuser.Email);
                var collection = user.Collections;
                return View(collection);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
