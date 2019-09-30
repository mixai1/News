using System.Collections.Generic;

namespace TestNewsSite.Models
{
    public class Admin : DatabaseEntity
    {
        
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }


        public New news { get; set; }
      

        public List<Comment> comments { get; set; }
        public List<UserCategory> userCategories { get; set; }
        

    }
}
