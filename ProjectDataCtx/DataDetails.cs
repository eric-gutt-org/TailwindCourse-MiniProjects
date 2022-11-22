namespace ProjectDataCtx
{
    public record DataDetails
    {
        public int DataDetailsId { get; init; }
        public string? Data { get; init; }
        public int ProjectDataId { get; init; }
    }
}