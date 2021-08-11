using CourseProject.Data;
using CourseProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProject.Controllers
{
    
    public class CollectionController : Controller
    {
        private UserManager<MyIdentity> userManager;
        private ApplicationDbContext context;
        public CollectionController(UserManager<MyIdentity> userManager,ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.context = context;
        }

        public IActionResult Index()
        {

            return View();
        }
        [Authorize]
        public IActionResult CollectionsCreatorEditor()
        {
            var topics = context.Topics;
            ViewBag.Topics = new SelectList(topics, "Id", "Name");
            return View();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CollectionsCreatorEditorAsync(Collection collection)
        {
            var curuser = await userManager.GetUserAsync(User);
            var user = await userManager.Users.Include(i=>i.Collections).SingleAsync(i=>i.Email == curuser.Email);
            user.Collections.Add(collection);
            var result = await userManager.UpdateAsync(user);
            return View();
        }
    }
}
