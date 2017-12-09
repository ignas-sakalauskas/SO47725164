using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DbContextUnitTest
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<RallyDbContext>();
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS01;Initial Catalog=RallyDb;Integrated Security=SSPI;");

            using (var context = new RallyDbContext(optionsBuilder.Options))
            {
                // Create DB and seed test data
                await SeedTestData(context);

                var service = new RallyService(context);
                var rallies = service.GetAllRallies();

                Console.WriteLine("Rallies found:");
                foreach (var rally in rallies)
                {
                    Console.WriteLine(rally.Name);
                }
            }

            Console.WriteLine("Exiting...");
        }

        private static async Task SeedTestData(RallyDbContext context)
        {
            await context.Database.EnsureCreatedAsync();
            if (await context.Rallies.AnyAsync())
            {
                return;
            }

            await context.AddRangeAsync(
                new Rally { Name = "name1" },
                new Rally { Name = "name2" },
                new Rally { Name = "name3" });
                
            await context.SaveChangesAsync();
        }
    }
}
