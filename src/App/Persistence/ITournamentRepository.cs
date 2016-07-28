using Fixture.Domain;
using System.Collections.Generic;

namespace Fixture.Persistence
{
    public interface ITournamentRepository
    {
        IEnumerable<Tournament> Get();
    }
}
