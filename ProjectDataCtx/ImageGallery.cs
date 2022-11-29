namespace ProjectDataCtx
{
    public record ImageGallery
    {
        public int ImageGalleryId { get; init; }
        public string? ImageGalleryName { get; init; }
        public string? ImageGalleryTitle { get; init; }
        public string? ImageGalleryDescription { get; init; }
        public string? ImageGalleryPath { get; init; }
    }
}