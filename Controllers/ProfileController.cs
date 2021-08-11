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
        public ProfileController(UserManager<MyIdentity> userManager, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.context = context;
        }
        public async Task<IActionResult> IndexAsync()
        {
            var curuser = await userManager.GetUserAsync(User);
            var user = await context.Users.Include(i => i.Collections).ThenInclude(t=>t.Topic   ).SingleAsync(u => u.Email == curuser.Email);
            var collection = user.Collections;
            return View(collection);
        }
    }
}
