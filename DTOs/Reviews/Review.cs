using TapChef_Backend.DTOs.Media;

namespace TapChef_Backend.DTOs.Reviews
{
    public class Review
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public double Rating { get; set; } = 5;
        public ImageMetadata? DisplayPicture { get; set; }
        public VideoMetadata? DisplayVideo { get; set; }

        // Origin and Target relationships
        public int OriginEntityId { get; set; }
        public ReviewerEntity OriginEntity { get; set; } = new ReviewerEntity();

        public int TargetEntityId { get; set; }
        public ReviewableEntity TargetEntity { get; set; } = new ReviewableEntity();
    }
}
