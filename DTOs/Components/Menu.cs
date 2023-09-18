using TapChef_Backend.DTOs.Identity;
using TapChef_Backend.DTOs.Media;
using TapChef_Backend.DTOs.Utility;

namespace TapChef_Backend.DTOs.Components
{
    public class Menu
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; } = default!;
        public ImageMetadata? DisplayPicture { get; set; }
        public List<Note>? Notes { get; set; } = new List<Note>();
        public List<Tag>? Tags { get; set; } = new List<Tag>();
        public List<MenuItem>? MenuDishes { get; set; } = new List<MenuItem>();
        public int? VendorId { get; set; }
        public Vendor? Vendor { get; set; }

    }
}
