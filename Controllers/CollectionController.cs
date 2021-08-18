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

        public async Task<IActionResult> IndexAsync(string id = "0")
        {
            //ViewData["Role"] = "Autor";
            int iid = int.Parse(id);
            var collection = await context.Collections.Include(i => i.Topic).Include(i => i.Items).FirstOrDefaultAsync(i => i.Id == iid);
            return View(collection);
        }

        public async Task<JsonResult> GetItemsAsync(string Id)
        {
            var Collection = await context.Collections.Include(i=>i.Items).ThenInclude(i=>i.Tags).FirstOrDefaultAsync(i=> i.Id==int.Parse(Id));
            var Items = Collection.Items;
            return Json(Items);
        }

        [Authorize]
        public IActionResult ItemCreatorEditor(string collectionid, string id = "0")
        {            
            int iid = int.Parse(id);
            if (iid>0){
                var item = context.Items.Include(i=>i.Tags).Include(i=>i.Collection).FirstOrDefault(i=>i.Id==iid);
                ViewData["func"] = "Edit";
                return View(item);
            }
            ViewData["func"] = "Create";
            return View(new Item() { Collection = context.Collections.Find(int.Parse(collectionid)), CollectionId = int.Parse(collectionid)});
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ItemCreatorEditorAsync(Item item, string tags)
        {
            var i = await context.Items.Include(i => i.Tags).FirstOrDefaultAsync(i=>i.Id == item.Id);
            var t = tags.Split(',');
            item = await GetItemWithTags(item, t);
            if (i != null){
                await RemoveOldTags(i);
                context.ChangeTracker.Clear();
                await EditItemAsync(item);
            }
            else
                await CreateItemAsync(item);
            return RedirectToAction("Index", "Collection", new {id = item.CollectionId.ToString()});
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
            foreach (var tag in t){
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
        [HttpDelete]
        public async Task<OkObjectResult> Delete(string id)
        {
            var collection = await context.Collections.FindAsync(int.Parse(id));
            context.Collections.Remove(collection);
            await context.SaveChangesAsync();
            return Ok($"#{id}");
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CollectionsCreatorEditorAsync(Collection collection)
        {
            var coll = await context.Collections.AsNoTracking().FirstOrDefaultAsync(i=>i.Id == collection.Id);
            if (coll != null)
                EditCollection(collection);
            else
                await CreateCollectionAsync(collection);
            return RedirectToAction("Index", "Profile");
        }

        private async Task CreateCollectionAsync(Collection collection)
        {
            var curuser = await userManager.GetUserAsync(User);
            var user = await userManager.Users.Include(i => i.Collections).SingleAsync(i => i.Email == curuser.Email);
            user.Collections.Add(collection);
            var result = await userManager.UpdateAsync(user);
        }

        private void EditCollection(Collection editcoll)
        {
            context.Collections.Update(editcoll);
            context.SaveChanges();
        }
    }
}
