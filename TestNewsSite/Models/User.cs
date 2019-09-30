using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestNewsSite.Models
{
    public class User : DatabaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required,EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; } 
        public bool IsAdmin { get; set; }




        public List<Comment> comments { get; set; }
        public List<UserCategory> userCategories { get; set; }

        public New news { get; set; }
       
    }
}
