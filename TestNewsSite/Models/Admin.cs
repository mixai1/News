using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestNewsSite.Models
{
    public class Admin
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }




        public New news { get; set; }
      

        public List<Comment> comments { get; set; }
        public List<UserCategory> userCategories { get; set; }
        

    }
}
