using TapChef_Backend.DTOs.Orders;

namespace TapChef_Backend.Interfaces
{
    public interface ITransactionRepository : IGenericRepository<Transaction>
    {
        Task<IEnumerable<Transaction>> GetByStatusAsync(TransactionStatus status);
    }
}
