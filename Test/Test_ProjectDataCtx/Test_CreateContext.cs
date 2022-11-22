using FluentAssertions;
using ProjectDataCtx;
using TestStack.BDDfy;
using TestStack.BDDfy.Xunit;
using TestSupport.EfHelpers;

namespace Test_ProjectDataCtx
{
    public class Test_CreateContext
    {
        private DbContextOptionsDisposable<EfDataCtx> _options;

        public Test_CreateContext()
        {
            _options = SqliteInMemory.CreateOptions<EfDataCtx>();
        }

        [BddfyFact]
        public void CreateContext()
        {
            string
                GIVN = "Given a context",
                WHEN = "When a context is refd",
                THEN = "Then the context is used";

            var testData = new ProjectData
            {
                ProjectDataId = 1,
                Name = "Name",
                Description = "Description",
                Size = 100,
                Details =
                new DataDetails[]
                {
                    new DataDetails
                    { DataDetailsId = 1,
                        Data= "Data1",
                        ProjectDataId = 1
                    },
                    new DataDetails
                    { DataDetailsId =2,
                         Data ="Data2",
                         ProjectDataId = 1
                    }
                }
            };

            using var ctx = new EfDataCtx(_options);

            IQueryable<ProjectData>? qry = default;
            _ = this.Given(() =>
                {
                    ctx.Database.EnsureCreated().Should().BeTrue();
                    ctx.SeedDatabase(testData).Should().BeTrue();
                },
                GIVN)
                .When(() =>
                {
                    qry = from i in ctx.ProjectData
                          select i;
                },
                WHEN)
                .Then(() =>
                {
                    qry!.First().Should().BeSameAs(testData);
                }, THEN)
                .BDDfy();
        }
    }
}