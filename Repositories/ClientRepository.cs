using Microsoft.EntityFrameworkCore;
using TapChef_Backend.Data;
using TapChef_Backend.DTOs.Identity;
using TapChef_Backend.DTOs.Reviews;
using TapChef_Backend.Interfaces;
using TapChef_Backend.Utility;

namespace TapChef_Backend.Repositories
{
    public class ClientRepository : GenericRepository<Client>, IClientRepository
    {
        private readonly DataContext _context;

        public ClientRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Response<IEnumerable<Client>>> GetByUserNameOrDisplayNameAsync(string searchTerm)
        {
            var clients = await _context.Clients
                .Where(c => c.UserName.Contains(searchTerm) || c.DisplayName.Contains(searchTerm))
                .ToListAsync();
            
            if(!clients.Any())
            {
                return new Response<IEnumerable<Client>>
                {
                    Success = false,
                    Message = "No clients found with the given name."
                };
            }

            return new Response<IEnumerable<Client>> { Success = true, Data = clients };
        }

        public async Task<Response<IEnumerable<Client>>> GetByRatingAsync(double minRating)
        {
            var clients = await _context.Clients
                .Where(c => c.Rating >= minRating)
                .ToListAsync();

            if(!clients.Any())
            {
                return new Response<IEnumerable<Client>>
                {
                    Success = false,
                    Message = "No clients found with the given rating."
                };
            }

            return new Response<IEnumerable<Client>> { Success = true, Data = clients };
        }

        public async Task<Response<IEnumerable<Client>>> GetByLocationAsync(string location)
        {
            string search = location.ToLower();

            var clients = await _context.Clients
                .Include(c => c.Address)
                .Where(c => c.Address.Street.ToLower().Contains(search)
                         || c.Address.City.ToLower().Contains(search)
                         || c.Address.State.ToLower().Contains(search)
                         || c.Address.PostalCode.ToLower().Contains(search))
                .ToListAsync();

            if (!clients.Any())
            {
                return new Response<IEnumerable<Client>>
                {
                    Success = false,
                    Message = "No clients found for the given location."
                };
            }

            return new Response<IEnumerable<Client>> { Success = true, Data = clients };
        }

        public async Task<Response<IEnumerable<Client>>> GetByEmailAsync(string email)
        {
            var clients = await _context.Clients
                .Where(c => c.Email == email)
                .ToListAsync();

            if (!clients.Any())
            {
                return new Response<IEnumerable<Client>>
                {
                    Success = false,
                    Message = "No clients found with the given email."
                };
            }
            
            return new Response<IEnumerable<Client>> { Data = clients, Success = true };
        }

        public async Task<Response<IEnumerable<Review>>> GetReviewsByClientAsync(int clientId)
        {
            var reviews = await _context.Reviews
                .Where(r => r.OriginEntityId == clientId)
                .ToListAsync();

            if (!reviews.Any())
            {
                return new Response<IEnumerable<Review>>
                {
                    Success = false,
                    Message = $"No reviews found from client with ID {clientId}."
                };
            }

            return new Response<IEnumerable<Review>> { Data = reviews, Success = true };
        }

        public async Task<Response<IEnumerable<Review>>> GetReviewsForClientAsync(int clientId)
        {
            var reviews = await _context.Reviews
                .Where(r => r.TargetEntityId == clientId)
                .ToListAsync();

            if (!reviews.Any())
            {
                return new Response<IEnumerable<Review>>
                {
                    Success = false,
                    Message = $"No reviews found for client with ID {clientId}."
                };
            }

            return new Response<IEnumerable<Review>> { Data = reviews, Success = true };
        }
    }
}
