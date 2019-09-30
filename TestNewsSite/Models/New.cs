using System;
using System.Collections.Generic;

namespace TestNewsSite.Models
{
    public class New : DatabaseEntity
    {
       
        public string Heading { get; set; }
        public DateTime DateTime { get; set; }  
        public string Source { get; set; }
        public string Content { get; set; }
        public string Img { get; set; }
        public decimal  Positive { get; set; }




        public List<Comment> comments { get; set; }
        public List<User> users { get; set; }
        public List<Admin> admins { get; set; }
    }
}
