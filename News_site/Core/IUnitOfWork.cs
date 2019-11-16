using Entity.NewsModels;
using System;
using System.Threading.Tasks;

namespace Core
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericNewsRepository<Comment> Comments { get; }

        IGenericNewsRepository<News> News { get; }



        Task SaveAsync();
    }
}
