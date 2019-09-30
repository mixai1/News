using System;
using TestNewsSite.DataBase;
using TestNewsSite.Interfaces;
using TestNewsSite.Models;

namespace TestNewsSite.UnitofWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DBContext _context;

        private readonly IGenericNewsRepository<New> _newsRepository;
        private readonly IGenericNewsRepository<Admin> _adminRepository;
        private readonly IGenericNewsRepository<User> _userRepository;
        private readonly IGenericNewsRepository<UserCategory> _userCategoryRepository;
        private readonly IGenericNewsRepository<Comment> _commentRepository;

        public UnitOfWork(
            DBContext dbcontext, 
            IGenericNewsRepository<New> newsRepository, 
            IGenericNewsRepository<Admin> adminRepository, 
            IGenericNewsRepository<User> userRepository, 
            IGenericNewsRepository<UserCategory> userCategoryRepositoryitory,
            IGenericNewsRepository<Comment> commentRepositorytory)
        {

            _newsRepository = newsRepository;
            _adminRepository = adminRepository;
            _userRepository = userRepository;
            _userCategoryRepository = userCategoryRepositoryitory;
            _commentRepository = commentRepositorytory;
            _context = dbcontext;
        }
        public IGenericNewsRepository<User> Users => _userRepository;

        public IGenericNewsRepository<Comment> Comments => _commentRepository;

        public IGenericNewsRepository<New> News => _newsRepository;

        public IGenericNewsRepository<Admin> Admins => _adminRepository;

        public IGenericNewsRepository<UserCategory> UserCategotys => _userCategoryRepository;

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
