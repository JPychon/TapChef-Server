using TapChef_Backend.DTOs.Utility;

namespace TapChef_Backend.DTOs.Components
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public string? Quantity { get; set; } = default!;
        public List<Note>? Notes { get; set; } = new List<Note>();
    }
}
