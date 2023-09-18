using TapChef_Backend.Utility;

namespace TapChef_Backend.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<Response<TEntity>> GetByIdAsync(int id);
        Task<Response<IEnumerable<TEntity>>> GetAllAsync();
        Task<Response<TEntity>> AddAsync(TEntity entity);
        Task<Response<TEntity>> UpdateAsync(TEntity entity);
        Task<Response<TEntity>> DeleteAsync(int id);
    }
}
