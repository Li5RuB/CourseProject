using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProject.Models
{
    public class MyIdentity : IdentityUser
    {
        public ICollection<Collection> Collections { get; set; } 

        public ICollection<Item> WhatLiked { get; set; }
    }
}
