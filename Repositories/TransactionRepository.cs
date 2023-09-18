using Microsoft.EntityFrameworkCore;
using TapChef_Backend.Data;
using TapChef_Backend.DTOs.Orders;
using TapChef_Backend.Interfaces;

namespace TapChef_Backend.Repositories
{
    public class TransactionRepository : GenericRepository<Transaction>, ITransactionRepository
    {
        private readonly DataContext _context;

        public TransactionRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Transaction>> GetByStatusAsync(TransactionStatus status)
        {
            return await _context.Transactions
                .Where(t => t.Status == status)
                .ToListAsync();
        }
    }

}
