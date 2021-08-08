using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProject.Models
{
    public class Item
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Tag> Tags { get; set; }

        public List<Field> Fields { get; set; }

        public Collection Collection { get; set; }
    }
}
