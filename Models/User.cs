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
        
        public UserModel(string Id, string Email, bool IsAdmin)
        {
            this.Id = Id;
            this.Email = Email;
            this.IsAdmin = IsAdmin;
        }
    }
}
