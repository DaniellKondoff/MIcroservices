using System.Threading.Tasks;

namespace CarRentalSystem.Common.Services
{
    public interface IDataService<in TEntity>
        where TEntity : class
    {
        Task Save(TEntity entity);
    }
}
