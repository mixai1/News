using System;
using Core;
using Data.Models;

namespace Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        private readonly IGenericNewsRepository<News> _newsRepository;
        private readonly IGenericNewsRepository<Comment> _commentRepository;

        public UnitOfWork(
            AppDbContext dbcontext,
            IGenericNewsRepository<News> newsRepository,
            IGenericNewsRepository<Comment> commentRepositorytory)
        {

            _newsRepository = newsRepository;
            _commentRepository = commentRepositorytory;
            _context = dbcontext;
        }

        public IGenericNewsRepository<Comment> Comments => _commentRepository;

        public IGenericNewsRepository<News> News => _newsRepository;



        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }



        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
