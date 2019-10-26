using Data.IdentityModel;
using System;
using System.Collections.Generic;

namespace News_site.Areas.IdentityViewModel
{
    public class ChangeRoleModel
    {
        public Guid UserId { get; set; }
        public string UserEmail { get; set; }
        public List<MyRole> AllRole { get; set; }
        public IList<string> UserRole { get; set; }

        public ChangeRoleModel()
        {
            AllRole = new List<MyRole>();
            UserRole = new List<string>();
        }

    }
}
