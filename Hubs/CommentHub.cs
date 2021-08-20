using CourseProject.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProject.Hubs
{

    public class CommentHub : Hub
    {
        private ApplicationDbContext context;
        public CommentHub(ApplicationDbContext context)
        {
            this.context = context;
        }
        [Authorize]
        public async Task AddComment(int Id,string text, string author)
        {
            var item = await context.Items.Include(i => i.Comments).FirstOrDefaultAsync(i => i.Id == Id);
            item.Comments.Add(new Models.Comments() { Text = text, Author = author });
            await context.SaveChangesAsync();
            await Clients.All.SendAsync("CreateComment", text, author);
        }
        public async Task InitComments(int Id)
        {
            var item = await context.Items.Include(i => i.Comments).FirstOrDefaultAsync(i => i.Id == Id);
            foreach (var i in item.Comments)
            {
                await Clients.Caller.SendAsync("CreateComment", i.Text, i.Author);
            }
        }
    }
}
