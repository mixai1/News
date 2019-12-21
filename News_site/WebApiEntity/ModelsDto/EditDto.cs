using System;

namespace WebApiEntity.ModelsDto
{
    public class EditDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
    }
}
