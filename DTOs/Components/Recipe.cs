using TapChef_Backend.DTOs.Media;
using TapChef_Backend.DTOs.Utility;

namespace TapChef_Backend.DTOs.Components
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public ImageMetadata? DisplayPicture { get; set; }
        public VideoMetadata? DisplayVideo { get; set; }
        public List<Note>? Notes { get; set; } = new List<Note>();
        public List<Tag>? Tags { get; set; } = new List<Tag>();
        public List<Instruction>? Instructions { get; set; } = new List<Instruction>();
        public List<Ingredient>? Ingredients { get; set; } = new List<Ingredient>();
    }
}
