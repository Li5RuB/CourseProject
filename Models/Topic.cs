using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CourseProject.Models
{
    public class Topic
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public ICollection<Collection> Collections { get; set; }
    }
}
