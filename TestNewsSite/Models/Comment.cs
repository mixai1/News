using System;

namespace TestNewsSite.Models
{
    public class Comment : DatabaseEntity
    {
        public DateTime DateTime { get; set; }
        public string Content { get; set; }





        public User users { get; set; }
        

        public New news { get; set; }
        
       
        public Admin admins { get; set; }
       
    }
}
