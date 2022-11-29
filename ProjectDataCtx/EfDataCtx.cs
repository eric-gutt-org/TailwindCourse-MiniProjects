using Microsoft.EntityFrameworkCore;

namespace ProjectDataCtx
{
    public class EfDataCtx : DbContext
    {
        public EfDataCtx(DbContextOptions<EfDataCtx> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) return;

            _ = string.IsNullOrEmpty(ConnectionString) ?
                throw new ArgumentNullException(nameof(ConnectionString)) : true;

            optionsBuilder.UseSqlServer(ConnectionString);

            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<ProjectData> ProjectData { get; set; }
        public DbSet<DataDetails> DataDetails { get; set; }

        public DbSet<ProductModal> ProductModals { get; set; }

        public string? ConnectionString { get; set; }
    }

    public static class EfDataCtxExtensions
    {
        public static bool SeedDatabase(this
            EfDataCtx context,
            ProjectData data
            )
        {
            context.Add(data);
            var count = context.SaveChanges();
            return count > 0;
        }
    }
}