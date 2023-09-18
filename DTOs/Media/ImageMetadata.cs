namespace TapChef_Backend.DTOs.Media
{
    public class ImageMetadata
    {
        public int Id { get; set; }
        public string? Url { get; set; }
        public string? PublicId { get; set; }
        public string? Description { get; set; }
        public string? AltText { get; set; }
        public string? Title { get; set; }
        public string? FileName { get; set; }
        public string? ContentType { get; set; }
        public long? Size { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
        public string? LastUpdatedBy { get; set; }
        public string? CreatedBy { get; set; }

    }
}
