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
        public IActionResult CollectionsCreatorEditor(string id = "0")
        {
            int iid = int.Parse(id);
            var topics = context.Topics;
            ViewBag.Topics = new SelectList(topics, "Id", "Name");
            if (iid > 0){
                var coll = context.Collections.Find(iid);
                return View(coll);
            }
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CollectionsCreatorEditorAsync(Collection collection)
        {
            var coll = await context.Collections.FindAsync(collection.Id);
            if (coll != null)
                EditCollection(collection,coll);
            else
                CreateCollectionAsync(collection);
            ViewData["msg"] = "success";
            return View();
        }

        private async Task CreateCollectionAsync(Collection collection)
        {
            var curuser = await userManager.GetUserAsync(User);
            var user = await userManager.Users.Include(i => i.Collections).SingleAsync(i => i.Email == curuser.Email);
            user.Collections.Add(collection);
            var result = await userManager.UpdateAsync(user);
        }

        private void EditCollection(Collection editcoll, Collection coll)
        {
            coll.Name = editcoll.Name;
            coll.Description = editcoll.Description;
            coll.TopicId = editcoll.TopicId;
            coll.UrlImg = editcoll.UrlImg;
            coll.Boolean1Name = editcoll.Boolean1Name;
            coll.Boolean2Name = editcoll.Boolean2Name;
            coll.Boolean3Name = editcoll.Boolean3Name;
            coll.Date1Name = editcoll.Date1Name;
            coll.Date2Name = editcoll.Date2Name;
            coll.Date3Name = editcoll.Date3Name;
            coll.Integer1Name = editcoll.Integer1Name;
            coll.Integer2Name = editcoll.Integer2Name;
            coll.Integer3Name = editcoll.Integer3Name;
            coll.Line1Name = editcoll.Line1Name;
            coll.Line2Name = editcoll.Line2Name;
            coll.Line3Name = editcoll.Line3Name;
            coll.Text1Name = editcoll.Text1Name;
            coll.Text2Name = editcoll.Text2Name;
            coll.Text3Name = editcoll.Text3Name;
            context.SaveChanges();
        }
    }
}
