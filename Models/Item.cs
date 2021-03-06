using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CourseProject.Models
{
    public class Item
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Tag> Tags { get; set; }

        public ICollection<Comments> Comments { get; set; }

        public ICollection<MyIdentity> WhoLiked { get; set; }

        public int CollectionId { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public Collection Collection { get; set; }

        public int Integer1 { get; set; }

        public int Integer2 { get; set; }

        public int Integer3 { get; set; }

        public string Line1 { get; set; }

        public string Line2 { get; set; }

        public string Line3 { get; set; }

        public string Text1 { get; set; }

        public string Text2 { get; set; }

        public string Text3 { get; set; }

        public DateTime Date1 { get; set; }

        public DateTime Date2 { get; set; }

        public DateTime Date3 { get; set; }

        public bool Boolean1 { get; set; }

        public bool Boolean2 { get; set; }

        public bool Boolean3 { get; set; }
    }
}
