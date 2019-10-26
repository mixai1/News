using System;

namespace News_site.Areas.IdentityViewModel
{
    public class ChangePasswordModel
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
