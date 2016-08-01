using Fixture.Domain;
using Common.Persistence;
using System.Collections.Generic;

namespace Fixture.Persistence
{
    public interface ITournamentRepository : IRepository<Tournament, int>
    {
        IEnumerable<Tournament> Get();
    }
}
