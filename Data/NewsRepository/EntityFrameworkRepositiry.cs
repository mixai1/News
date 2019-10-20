using Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.NewsRepository
{
    public class EntityFrameworkRepositiry<T> : IGenericNewsRepository<T> where T : DataBaseEntity
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<T> _table;

        public EntityFrameworkRepositiry(AppDbContext dbcontext)
        {
            _context = dbcontext;
            _table = dbcontext.Set<T>();

        }



        public Task AddNewsAsync(T obj)
        {
            throw new NotImplementedException();
        }

        public Task AddNewsRangeAsync(IEnumerable<T> rangeObjs)
        {
            throw new NotImplementedException();
        }

        public System.Linq.IQueryable<T> AsQueryble()
        {
            throw new NotImplementedException();
        }

        public void DeleteNewsId(object id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAllNewsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetNewsIdAsync(object id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateNewsAsunc(T obj)
        {
            throw new NotImplementedException();
        }
    }
}
