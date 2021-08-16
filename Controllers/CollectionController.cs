﻿using CourseProject.Data;
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
