using Microsoft.EntityFrameworkCore;
using TapChef_Backend.Data;
using TapChef_Backend.DTOs.Components;
using TapChef_Backend.DTOs.Identity;
using TapChef_Backend.DTOs.Reviews;
using TapChef_Backend.Interfaces;
using TapChef_Backend.Utility;

namespace TapChef_Backend.Repositories
{
    public class VendorRepository : GenericRepository<Vendor>, IVendorRepository
    {
        private readonly DataContext _context;

        public VendorRepository(DataContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Response<IEnumerable<Vendor>>> GetByCertificatesAsync(IEnumerable<Certificate> certificates)
        {
            var vendors = await _context.Vendors.Include(v => v.Certificates)
                .Where(v => v.Certificates!.Any(c => certificates.Contains(c)))
                .ToListAsync();
            
            if(!vendors.Any())
            {
                return new Response<IEnumerable<Vendor>>
                {
                    Success = false,
                    Message = "No vendors found with the given certificates."
                };
            }

            return new Response<IEnumerable<Vendor>> { Data = vendors, Success = true };
        }

        public async Task<Response<IEnumerable<Vendor>>> GetByEmailAsync(string email)
        {
            var vendors = await _context.Vendors
                .Where(v => v.Email == email)
                .ToListAsync();
            
            if(!vendors.Any())
            {
                return new Response<IEnumerable<Vendor>>
                {
                    Success = false,
                    Message = "No vendors found with the given email."
                };
            }

            return new Response<IEnumerable<Vendor>> { Data = vendors, Success = true };
        }

        public async Task<Response<IEnumerable<Vendor>>> GetByFeeRangeAsync(decimal minFee, decimal maxFee)
        {
            var vendors = await _context.Vendors
                .Where(v => v.FeePerHour >= minFee && v.FeePerHour <= maxFee)
                .ToListAsync();

            if (!vendors.Any())
            {
                return new Response<IEnumerable<Vendor>>
                {
                    Success = false,
                    Message = "No vendors found within the given fee range."
                };
            }

            return new Response<IEnumerable<Vendor>> { Data = vendors, Success = true };
        }

        public async Task<Response<IEnumerable<Vendor>>> GetByLocationAsync(string location)
        {
            string search = location.ToLower();

            var vendors = await _context.Vendors
                .Include(v => v.Address)
                .Where(v => v.Address.Street.ToLower().Contains(search)
                         || v.Address.City.ToLower().Contains(search)
                         || v.Address.State.ToLower().Contains(search)
                         || v.Address.PostalCode.ToLower().Contains(search))
                .ToListAsync();

            if (!vendors.Any())
            {
                return new Response<IEnumerable<Vendor>>
                {
                    Success = false,
                    Message = "No vendors found for the given location."
                };
            }

            return new Response<IEnumerable<Vendor>> { Data = vendors, Success = true };
        }

        public async Task<Response<IEnumerable<Vendor>>> GetByRatingRangeAsync(double minRating, double maxRating)
        {
            var vendors = await _context.Vendors
                .Where(v => v.Rating >= minRating && v.Rating <= maxRating)
                .ToListAsync();

            if (!vendors.Any())
            {
                return new Response<IEnumerable<Vendor>>
                {
                    Success = false,
                    Message = "No vendors found within the given rating range."
                };
            }

            return new Response<IEnumerable<Vendor>> { Data = vendors, Success = true };
        }

        public async Task<Response<IEnumerable<Vendor>>> GetByUserNameOrDisplayNameAsync(string searchTerm)
        {
            var vendors =  await _context.Vendors
                .Where(v => v.UserName.Contains(searchTerm) || v.DisplayName.Contains(searchTerm))
                .ToListAsync();

            if (!vendors.Any())
            {
                return new Response<IEnumerable<Vendor>>
                {
                    Success = false,
                    Message = "No vendors found with the given name."
                };
            }

            return new Response<IEnumerable<Vendor>> { Data = vendors, Success = true };
        }

        public async Task<Response<IEnumerable<Menu>>> GetMenusByVendorAsync(int vendorId)
        {
            var menus = await _context.Menus
                .Where(m => m.VendorId == vendorId)
                .ToListAsync();

            if (!menus.Any())
            {
                return new Response<IEnumerable<Menu>>
                {
                    Success = false,
                    Message = $"No menus found for vendor with ID {vendorId}."
                };
            }

            return new Response<IEnumerable<Menu>> { Data = menus, Success = true };
        }

        public async Task<Response<IEnumerable<Review>>> GetReviewsByVendorAsync(int vendorId)
        {
            var reviews = await _context.Reviews
                .Where(r => r.OriginEntityId == vendorId)
                .ToListAsync();

            if (!reviews.Any())
            {
                return new Response<IEnumerable<Review>>
                {
                    Success = false,
                    Message = $"No reviews found from vendor with ID {vendorId}."
                };
            }

            return new Response<IEnumerable<Review>> { Data = reviews, Success = true };
        }

        public async Task<Response<IEnumerable<Review>>> GetReviewsForVendorAsync(int vendorId)
        {
            var reviews = await _context.Reviews
                .Where(r => r.TargetEntityId == vendorId)
                .ToListAsync();

            if (!reviews.Any())
            {
                return new Response<IEnumerable<Review>>
                {
                    Success = false,
                    Message = $"No reviews found for vendor with ID {vendorId}."
                };
            }

            return new Response<IEnumerable<Review>> { Data = reviews, Success = true };
        }
    }
}
