using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebApiEntity.ModelsDto
{
    public class RegisterDto
    {
        [Required]
        public string Email { get; set; }
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
