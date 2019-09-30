using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestNewsSite.DataBase;
using TestNewsSite.Interfaces;
using TestNewsSite.Models;

namespace TestNewsSite.Repository
{
    public class EntityFrameworkRepositiry<T> : IGenericNewsRepository<T> where T : DatabaseEntity
    {

        protected readonly DBContext _context;
        protected readonly DbSet<T> _table;

        public EntityFrameworkRepositiry(DBContext dbcontext)
        {
            _context = dbcontext;
            _table = dbcontext.Set<T>();

        }

        public async Task AddNewsAsync(T obj)
        {
            await _table.AddAsync(obj);
        
        }

        public async Task AddNewsRangeAsync(IEnumerable<T> rangeObjs)
        {
            await _table.AddRangeAsync(rangeObjs);
        }

        public IQueryable<T> AsQueryble()
        {
            return _table.AsQueryable();
        }

        public void DeleteNewsId(object id)
        {
            var findresult = _table.Find(id);
            _table.Remove(findresult);
            
        }

        public async Task<IEnumerable<T>> GetAllNewsAsync()
        {
            return await _table.ToListAsync();
        }

        public async Task<T> GetNewsIdAsync(object id)
        {
            return await _table.FindAsync(id);
        }

        public Task UpdateNewsAsunc(T obj)
        {
            //_table.Attach(obj);
            // _context.Entry(obj).State = EntityState.Modified;


            throw new Exception();
              
            
        }
    }
}
