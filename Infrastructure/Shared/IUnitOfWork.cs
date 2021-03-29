using System.Threading.Tasks;

namespace Infrastructure.Shared
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}