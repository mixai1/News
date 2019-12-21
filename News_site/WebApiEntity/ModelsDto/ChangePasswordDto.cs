using System;

namespace WebApiEntity.ModelsDto
{
    public class ChangePasswordDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
