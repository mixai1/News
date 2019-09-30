using System;

namespace TestNewsSite.Models
{
    public class UserCategory : DatabaseEntity
    {
        
        public User user { get; set; }
        public Guid userId { get; set; }


        public Admin admin { get; set; }
        public Guid adminId { get; set; }
       
    }
}
