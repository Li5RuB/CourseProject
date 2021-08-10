using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProject.Models
{
    public class MyIdentity : IdentityUser
    {
        public List<Collection> Collections { get; set; } 

        public List<Item> WhatLiked { get; set; }
    }
}
