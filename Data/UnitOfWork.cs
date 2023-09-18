using TapChef_Backend.Exceptions;
using TapChef_Backend.Interfaces;
using TapChef_Backend.Repositories;

namespace TapChef_Backend.Data
{
    // Group Database queries with multiple steps/stages into a single transaction for a unified transaction-state.
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private readonly Dictionary<Type, object> _repositories;

        public UnitOfWork(DataContext context)
        {
            _context = context;
            _repositories = new Dictionary<Type, object>();
        }

        public IGenericRepository<T> Repository<T>() where T : class
        {
            if (_repositories.Keys.Contains(typeof(T)))
            {
                var repo = _repositories[typeof(T)] as IGenericRepository<T>;
                if(repo is null)
                {
                    throw new InvalidOperationException($"Repository for type {typeof(T).Name} is not of expected type.");
                }

                return repo;
            }

            var repository = new GenericRepository<T>(_context);
            _repositories.Add(typeof(T), repository);
            return repository;
        }

        public async Task<int> CompleteAsync()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new SaveFailedException(ex);
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}