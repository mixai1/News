using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestNewsSite.DataBase;
using TestNewsSite.Interfaces;
using TestNewsSite.Models;

//namespace TestNewsSite.Mocks
//{
//    public class llNewsRepository //: IGenericNewsRepository<T> where T : DatabaseEntity 
//    {
//        private readonly DBContext dbContext;
//        public NewsRepository(DBContext context)
//        {
//            this.dbContext = context;
//        }

//        public async Task<New> AddNewAsync(New news)
//        {

//            var result = dbContext.News.Add(news).Entity;
//            await dbContext.SaveChangesAsync();


//            return result;
//        }

//        public async Task DeleteNewsIdAsync(Guid id)
//        {
//            var result = await dbContext.News.FirstOrDefaultAsync(i => i.Id == id);
//            dbContext.Entry(result).State = EntityState.Deleted;
//            await dbContext.SaveChangesAsync();

//        }

//        public async Task<IEnumerable<New>> GetAllNewsAsync()
//        {
//            //var result = new List<New>();

//            var result = await dbContext.News.ToListAsync();

//            return result;
//        }

//        public async Task<New> GetNewsIdAsync(Guid id)
//        {

//            var result = await Task.Run(() => dbContext.News.FirstOrDefault(i => i.Id == id));

//            return result;
//        }

//        public async Task<New> UpdateNewsAsunc(New news)
//        {

//            dbContext.Entry(news).State = EntityState.Modified;
//            await dbContext.SaveChangesAsync();

//            return news;
//        }
//    }
//}
