namespace ProjectDataCtx
{
    public record ProductModal
    {
        public int ProductModalId { get; init; }
        public string? ProductName { get; init; }
        public string? ProductDescription { get; init; }
        public decimal ProductPrice { get; init; }
        public decimal ProductPreviousPrice { get; init; }

        public string? ProductDetails { get; init; }
    }
}