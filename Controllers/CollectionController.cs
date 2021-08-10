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
    [Authorize]
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

        public IActionResult CollectionsCreatorEditor()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CollectionsCreatorEditorAsync(Collection collection)
        {
            var user = await userManager.GetUserAsync(User);
            user.Collections.Add(collection);
            var result = await userManager.UpdateAsync(user);
            return View();
        }
    }
}
