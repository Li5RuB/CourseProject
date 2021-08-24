using CourseProject.Data;
using CourseProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MoreLinq;

namespace CourseProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private UserManager<MyIdentity> userManager;
        private ApplicationDbContext context;

        public HomeController(ILogger<HomeController> logger, UserManager<MyIdentity> userManager, ApplicationDbContext context)
        {
            _logger = logger;
            this.userManager = userManager;
            this.context = context;
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Search(string s="", string t="")
        {
            ViewData["s"] = s;
            ViewData["t"] = t;
            return View();
        }

        [HttpGet]
        public JsonResult GetSearchResult(string s)
        {
            var items = context.Items.Include(i => i.Tags).Include(i => i.WhoLiked).Where(i => EF.Functions.Contains(i.Name, s));
            var comments = context.Comments.Include(i => i.Item).ThenInclude(i => i.WhoLiked).Include(i => i.Item).ThenInclude(i => i.Tags).Where(i => EF.Functions.Contains(i.Text, s)).Select(i => i.Item);
            var description = context.Collections.Include(i => i.Topic).Include(i => i.Items).ThenInclude(i => i.WhoLiked).Include(i => i.Items).ThenInclude(i => i.Tags).Where(i => EF.Functions.Contains(i.Description, s) || EF.Functions.Contains(i.Name, s)).SelectMany(i => i.Items);
            var allitems = items.Concat(comments).Concat(description).DistinctBy(i => i.Id);
            return Json(allitems);
        }

        [HttpGet]
        public JsonResult GetResultByTags(string t)
        {
            var items = context.Tags.Include(i => i.Items).ThenInclude(i=>i.WhoLiked).Include(i=>i.Items).ThenInclude(i=>i.Tags).FirstOrDefault(i => i.Name == t).Items;
            return Json(items);
        }
    }
}
