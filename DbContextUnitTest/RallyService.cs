using System.Collections.Generic;

namespace DbContextUnitTest
{
    public class RallyService : IRallyService
    {
        private readonly RallyDbContext _context;

        public RallyService(RallyDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Rally> GetAllRallies()
        {
            return _context.Rallies;
        }
    }
}
