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
    public class ItemController : Controller
    {
        private UserManager<MyIdentity> userManager;
        private ApplicationDbContext context;
        public ItemController(UserManager<MyIdentity> userManager, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.context = context;
        }

        public IActionResult Index(string id)
        {
            var item = context.Items.Include(i => i.Tags).Include(i => i.Comments).Include(i => i.WhoLiked).Include(i=>i.Collection).FirstOrDefault(i => i.Id == int.Parse(id));
            return View(item);
        }

        [Authorize]
        public IActionResult ItemCreatorEditor(string collectionid, string id = "0")
        {
            int iid = int.Parse(id);
            if (iid > 0)
            {
                var item = context.Items.Include(i => i.Tags).Include(i => i.Collection).FirstOrDefault(i => i.Id == iid);
                ViewData["func"] = "Edit";
                return View(item);
            }
            ViewData["func"] = "Create";
            return View(new Item() { Collection = context.Collections.Find(int.Parse(collectionid)), CollectionId = int.Parse(collectionid) });
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ItemCreatorEditorAsync(Item item, string tags)
        {
            var i = await context.Items.Include(i => i.Tags).FirstOrDefaultAsync(i => i.Id == item.Id);
            var t = tags.Split(',');
            item = await GetItemWithTags(item, t);
            if (i != null)
            {
                await RemoveOldTags(i);
                context.ChangeTracker.Clear();
                await EditItemAsync(item);
            }
            else
                await CreateItemAsync(item);
            return RedirectToAction("Index", "Collection", new { id = item.CollectionId.ToString() });
        }

        private async Task RemoveOldTags(Item i)
        {
            foreach (var it in i.Tags)
            {
                i.Tags.Remove(it);
                await context.SaveChangesAsync();
            }
        }
        private async Task<Item> GetItemWithTags(Item item, string[] t)
        {
            item.Tags.Clear();
            foreach (var tag in t)
            {
                var ta = await context.Tags.FirstOrDefaultAsync(i => i.Name == tag);
                if (ta == null)
                    context.Tags.Add(new Tag() { Name = tag });
                await context.SaveChangesAsync();
                item.Tags.Add(context.Tags.FirstOrDefault(i => i.Name == tag));
            }
            return item;
        }
        private async Task CreateItemAsync(Item item)
        {
            await context.Items.AddAsync(item);
            await context.SaveChangesAsync();
        }

        private async Task EditItemAsync(Item edititem)
        {
            context.Items.Update(edititem);
            await context.SaveChangesAsync();
        }

        [HttpPost]
        [Authorize]
        public void Delete(string id)
        {
            context.Items.Remove(context.Items.Find(int.Parse(id)));
            context.SaveChanges();  
        }
    }
}
