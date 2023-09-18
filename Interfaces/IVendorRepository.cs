using TapChef_Backend.DTOs.Components;
using TapChef_Backend.DTOs.Identity;
using TapChef_Backend.DTOs.Reviews;
using TapChef_Backend.Utility;

namespace TapChef_Backend.Interfaces
{
    public interface IVendorRepository : IGenericRepository<Vendor>
    {
        Task<Response<IEnumerable<Vendor>>> GetByUserNameOrDisplayNameAsync(string searchTerm);
        Task<Response<IEnumerable<Vendor>>> GetByLocationAsync(string location);
        Task<Response<IEnumerable<Vendor>>> GetByEmailAsync(string email);
        Task<Response<IEnumerable<Vendor>>> GetByRatingRangeAsync(double minRating, double maxRating);
        Task<Response<IEnumerable<Vendor>>> GetByFeeRangeAsync(decimal minFee, decimal maxFee);
        Task<Response<IEnumerable<Vendor>>> GetByCertificatesAsync(IEnumerable<Certificate> certificates);
        Task<Response<IEnumerable<Review>>> GetReviewsByVendorAsync(int vendorId);
        Task<Response<IEnumerable<Review>>> GetReviewsForVendorAsync(int vendorId);
        Task<Response<IEnumerable<Menu>>> GetMenusByVendorAsync(int vendorId);
    }
}
