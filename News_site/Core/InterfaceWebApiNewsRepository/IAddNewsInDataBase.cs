using System.Threading.Tasks;

namespace Core.InterfaceWebApiNewsRepository
{
    public interface IAddNewsInDataBase
    {
        Task AddNewsRangeDatabase();
    }
}
