using Core;
using Data.Models;
using System;
using System.Threading.Tasks;

namespace Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericNewsRepository<Comment> Comments { get; }

        IGenericNewsRepository<News> News { get; }



        Task SaveAsync();
    }
}
