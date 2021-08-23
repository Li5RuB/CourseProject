using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CourseProject.Models
{
    public class Comments
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }
        public int ItemId { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public Item Item { get; set; }
    }
}
