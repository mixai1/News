using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiEntity.ModelsDto
{
    public class UserDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public IList< string>  Role{ get; set; }
        public  object Token { get; set; }
    }
}
