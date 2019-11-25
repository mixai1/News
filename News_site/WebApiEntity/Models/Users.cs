using System;
using System.ComponentModel.DataAnnotations;

namespace WebApiEntity.Models
{
    public class IdentityUsers
    {
        public Guid Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Compare("Password")]
        public string PasswordConfirm { get; set; }
        public string Role { get; set; }
    }
}
