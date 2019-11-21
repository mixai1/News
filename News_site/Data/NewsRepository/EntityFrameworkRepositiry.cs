using Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Entity.NewsModels;
using Entity;

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



        public async Task AddAsync(T obj)
        {
            await _table.AddAsync(obj);

        }

        public async Task AddRangeAsync(IEnumerable<T> rangeObjs)
        {
            await _table.AddRangeAsync(rangeObjs);
        }

        public IQueryable<T> AsQueryble()
        {
            return _table.AsQueryable();
        }

        public async Task DeleteId(object id)
        {
            var findresult = await _table.FindAsync(id);
            _table.Remove(findresult);

        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _table.ToListAsync();
        }

        public async Task<T> GetIdAsync(object id)
        {
            return await _table.FindAsync(id);
        }

        public void Update(T obj)
        {

            _table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;

        }

        public IEnumerable<T> Where(Func<T, bool> predicate)
        {
            return _table.Where(predicate);
        }

       
    }
}
