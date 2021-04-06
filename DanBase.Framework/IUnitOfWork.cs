using System.Threading.Tasks;

namespace DanBase.Framework
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}