using TapChef_Backend.DTOs.Identity;

namespace TapChef_Backend.DTOs.Reviews
{
    public class ReviewableEntity
    {
        public int Id { get; set; }
        public string EntityType { get; set; } = default!;
        public List<Review> TargetedReviews { get; set; } = new List<Review>();

        // Navigation properties
        public int? ClientId { get; set; }
        public Client? Client { get; set; }

        public int? VendorId { get; set; }
        public Vendor? Vendor { get; set; }
    }
}
