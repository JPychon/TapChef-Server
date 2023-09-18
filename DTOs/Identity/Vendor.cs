using TapChef_Backend.DTOs.Communication;
using TapChef_Backend.DTOs.Media;
using TapChef_Backend.DTOs.Utility;
using TapChef_Backend.DTOs.Components;
using TapChef_Backend.DTOs.Reviews;

namespace TapChef_Backend.DTOs.Identity
{
    public class Vendor
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string UserName { get; set; } = default!;
        public string DisplayName { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public string? Description { get; set; }
        public string? TimeZone { get; set; }
        public double Rating { get; set; } = 5;
        public decimal? FeePerHour { get; set; }
        public decimal? FeePerEvent { get; set; }
        public string? Education { get; set; }
        public ImageMetadata? ProfilePicture { get; set; }
        public VendorStatus Status { get; set; } = VendorStatus.Available;
        public int AddressId { get; set; }
        public Address Address { get; set; } = default!;
        public List<Dish>? PreferredDishes { get; set; } = new List<Dish>();
        public List<Degree> Degrees { get; set; } = new List<Degree>();
        public List<Certificate>? Certificates { get; set; } = new List<Certificate>();
        public List<ImageMetadata>? UploadedImages { get; set; } = new List<ImageMetadata>();
        public List<VideoMetadata>? UploadedVideos { get; set; } = new List<VideoMetadata>();
        public List<Dish>? Dishes { get; set; } = new List<Dish>();
        public List<Menu>? Menus { get; set; } = new List<Menu>();
        public List<Recipe>? Recipes { get; set; } = new List<Recipe>();
        public int? ReviewableEntityId { get; set; }
        public ReviewableEntity? ReviewableEntity { get; set; }

        public int? ReviewerEntityId { get; set; }
        public ReviewerEntity? ReviewerEntity { get; set; }

        // Flags
        public bool IsActive { get; set; } = true;
        public bool IsTwoFactorEnabled { get; set; }
        public bool IsEmailConfirmed { get; set; } = false;
        public bool IsDataConsent { get; set; } = false;
        public bool IsOptInNewsletter { get; set; }
        public bool IsOptInPromotions { get; set; }
        public bool IsChargedPerHour { get; set; } = true;
        public bool IsChargedPerEvent { get; set; } = false;

    }

    public enum VendorStatus
    {
        Available,
        Unavailable,
        Vacation
    }
}
