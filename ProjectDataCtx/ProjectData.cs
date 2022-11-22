namespace ProjectDataCtx
{
    public record ProjectData
    {
        public int ProjectDataId { get; init; }
        public string? Name { get; init; }
        public string? Description { get; init; }
        public int Size { get; init; }
        public ICollection<DataDetails>? Details { get; init; }
    }
}