using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProject.Models
{
    public class UserModel
    {
        public string Id{ get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsBlock { get; set; }
        
        public UserModel(string Id, string Email,bool IsAdmin, bool IsBlock)
        {
            this.Id = Id;
            this.Email = Email;
            this.IsBlock = IsBlock;
            this.IsAdmin = IsAdmin;
        }
    }
}
