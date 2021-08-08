using CourseProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProject.Models
{
    public class Collection
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Topic Topic { get; set; }

        public List<Item> Items { get; set; }

        public List<Field> Fields { get; set; }

        public MyIdentity Creator { get; set; }
    }
}
