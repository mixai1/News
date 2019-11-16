using MediatR;
using WebApiEntity.Models;

namespace WebApiCQRS.Querys.UsersQuerys
{
    public class DoesExistUser : IRequest<Users>
    {
        public DoesExistUser(string email, string password)
        {

            Email = email;
            Password = password;
        }

        public string Email { get; }
        public string Password { get; }
    }
}
