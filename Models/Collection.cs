using CourseProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CourseProject.Models
{
    public class Collection
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public int TopicId { get; set; }

        [Required]
        public Topic Topic { get; set; }

        public ICollection<Item> Items { get; set; }

        public string CreatorId { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public MyIdentity Creator { get; set; }

        public string UrlImg { get; set; }

        public string Integer1Name { get; set; }

        public string Integer2Name { get; set; }

        public string Integer3Name { get; set; }

        public string Line1Name { get; set; }

        public string Line2Name { get; set; }

        public string Line3Name { get; set; }

        public string Text1Name { get; set; }

        public string Text2Name { get; set; }

        public string Text3Name { get; set; }

        public string Date1Name { get; set; }

        public string Date2Name { get; set; }

        public string Date3Name { get; set; }

        public string Boolean1Name { get; set; }

        public string Boolean2Name { get; set; }

        public string Boolean3Name { get; set; }
    }
}
