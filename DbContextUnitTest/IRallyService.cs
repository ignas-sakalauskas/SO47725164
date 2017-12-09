using System.Collections.Generic;

namespace DbContextUnitTest
{
    public interface IRallyService
    {
        IEnumerable<Rally> GetAllRallies();
    }
}