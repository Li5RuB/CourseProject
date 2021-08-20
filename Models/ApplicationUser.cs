using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CourseProject.Models
{
    public class MyIdentity : IdentityUser
    {

        [JsonIgnore]
        [IgnoreDataMember]
        public ICollection<Collection> Collections { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public ICollection<Item> WhatLiked { get; set; }
    }
}
