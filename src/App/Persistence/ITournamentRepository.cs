using System.Collections.Generic;
using Common.Persistence;
using Fixture.Domain;

namespace Fixture.Persistence
{
    public interface ITournamentRepository : IRepository<Tournament, int>
    {
        IEnumerable<Tournament> Get(bool extended);
    }
}
