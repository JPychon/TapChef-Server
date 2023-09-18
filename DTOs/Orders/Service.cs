using TapChef_Backend.DTOs.Media;
using TapChef_Backend.DTOs.Utility;
using TapChef_Backend.DTOs.Identity;

namespace TapChef_Backend.DTOs.Orders
{
    public class Service
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
        public ServiceStatus Status { get; set; } = ServiceStatus.Open;
        public DateTime PostedOn { get; set; } = DateTime.UtcNow;
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public int MinHours { get; set; }
        public int MaxHours { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; } = default!;

        public int VendorId { get; set; }
        public Vendor Vendor { get; set; } = default!;

        public int? ClientId { get; set; }
        public Client? Client { get; set; }

        public ImageMetadata? DisplayImage { get; set; }
        public VideoMetadata? DisplayVideo { get; set; }
        public List<Tag>? Tags { get; set; } = new List<Tag>();
        public List<Note>? Notes { get; set; } = new List<Note>();
    }

    public enum ServiceStatus
    {
        Open,
        InNegotiation,
        Booked,
        Completed,
        Cancelled
    }
}