using TapChef_Backend.DTOs.Identity;
using TapChef_Backend.DTOs.Reviews;
using TapChef_Backend.Utility;

namespace TapChef_Backend.Interfaces
{
    public interface IClientRepository : IGenericRepository<Client>
    {
        Task<Response<IEnumerable<Client>>> GetByUserNameOrDisplayNameAsync(string searchTerm);
        Task<Response<IEnumerable<Client>>> GetByRatingAsync(double minRating);
        Task<Response<IEnumerable<Client>>> GetByLocationAsync(string location);
        Task<Response<IEnumerable<Client>>> GetByEmailAsync(string email);
        Task<Response<IEnumerable<Review>>> GetReviewsByClientAsync(int clientId);
        Task<Response<IEnumerable<Review>>> GetReviewsForClientAsync(int clientId);
        
    }
}
