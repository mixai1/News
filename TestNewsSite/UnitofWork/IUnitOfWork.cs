using System;
using TestNewsSite.Interfaces;
using TestNewsSite.Models;

namespace TestNewsSite.UnitofWork
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericNewsRepository<User> Users { get; }

        IGenericNewsRepository<Comment> Comments { get; }

        IGenericNewsRepository<New>  News { get; }

        IGenericNewsRepository<Admin> Admins { get; }

        IGenericNewsRepository<UserCategory> UserCategotys { get; }

        void Save();

    }
}
