using TapChef_Backend.DTOs.Communication;
using TapChef_Backend.DTOs.Media;
using TapChef_Backend.DTOs.Reviews;
using TapChef_Backend.DTOs.Utility;

namespace TapChef_Backend.DTOs.Identity
{
    public class Client
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string UserName { get; set; } = default!;
        public string DisplayName { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public string? Description { get; set; }
        public string? TimeZone { get; set; } = default!;
        public double Rating { get; set; } = 5;
        public int AddressId { get; set; }
        public Address Address { get; set; } = default!;
        public ImageMetadata? ProfilePicture { get; set; }
        public int? ReviewableEntityId { get; set; }
        public ReviewableEntity? ReviewableEntity { get; set; }

        public int? ReviewerEntityId { get; set; }
        public ReviewerEntity? ReviewerEntity { get; set; }
        public List<ImageMetadata>? UploadedImages { get; set; } = new List<ImageMetadata>();
        public List<VideoMetadata>? UploadedVideos { get; set; } = new List<VideoMetadata>();

        // Flags
        public bool IsTwoFactorEnabled { get; set; }
        public bool IsActive { get; set; }
        public bool IsEmailConfirmed { get; set; } = false;
        public bool IsOptInNewsletter { get; set; }
        public bool IsOptInPromotions { get; set; }
        public bool IsDataConsent { get; set; }
    }
}
