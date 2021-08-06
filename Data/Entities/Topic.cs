using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProject.Data.Entities
{
    public class Topic
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Collection> Collections { get; set; }
    }
}
