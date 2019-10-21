using Core;
using Data.Models;
using System;

namespace Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericNewsRepository<Comment> Comments { get; }

        IGenericNewsRepository<News> News { get; }



        void Save();
    }
}
