using CourseProject.Data;
using CourseProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CourseProject
{
    public static class AccessValidation
    {
        public static async Task<bool> CheckAccessAsync(UserManager<MyIdentity> userManager, ApplicationDbContext context, ClaimsPrincipal User, int collid)
        {
            var curuser = await userManager.GetUserAsync(User);
            var collection = await context.Collections.Include(i=>i.Creator).FirstOrDefaultAsync(i=>i.Id == collid);
            if (collection.Creator.Id == curuser.Id || await userManager.IsInRoleAsync(curuser,"admin"))
            {
                return true;
            }
            else return false;
        }
    }
}
