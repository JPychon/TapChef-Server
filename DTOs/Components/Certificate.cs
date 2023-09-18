namespace TapChef_Backend.DTOs.Components
{
    public class Certificate
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string? Description { get; set; }
    }
}
