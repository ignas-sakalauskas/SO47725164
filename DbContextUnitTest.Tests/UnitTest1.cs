using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace DbContextUnitTest.Tests
{
    public class UnitTest1
    {
        private readonly DbContextOptions<RallyDbContext> _options;

        public UnitTest1()
        {
            // Use GUID for in-memory DB names to prevent any possible name conflicts
            _options = new DbContextOptionsBuilder<RallyDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
        }

        [Fact]
        public async Task Test1()
        {
            using (var context = new RallyDbContext(_options))
            {
                //Given 2 records in database
                await context.AddRangeAsync(new Rally { Name = "rally1" }, new Rally { Name = "rally2" });
                await context.SaveChangesAsync();
            }

            using (var context = new RallyDbContext(_options))
            {
                //When retrieve all rally records from the database
                var service = new RallyService(context);
                var rallies = service.GetAllRallies();

                //Then records count should be 2
                Assert.Equal(2, rallies.Count());
            }
        }
    }
}
