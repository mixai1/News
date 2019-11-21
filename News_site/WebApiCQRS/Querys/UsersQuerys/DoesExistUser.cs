using MediatR;
using WebApiEntity.Models;

namespace WebApiCQRS.Querys.UsersQuerys
{
    public class DoesExistUser : IRequest<Users>
    {
        public DoesExistUser(string email)
        {

            Email = email;
        }

        public string Email { get; }

    }
}
