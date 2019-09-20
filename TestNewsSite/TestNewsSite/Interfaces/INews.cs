using System.Collections.Generic;
using System.Threading.Tasks;
using TestNewsSite.Models;

namespace TestNewsSite.Interfaces
{
   public interface INewsRepository
    {

        Task<New> AddNewAsync(New news);

        Task<IEnumerable<New>> GetAllNewsAsync();

        Task<New> GetNewIdAsync(int id);

        Task DeleteNewIdAsync(int id);

        Task<New> UpdateNewsAsunc(New news);


    }
}
