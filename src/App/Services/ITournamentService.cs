using System.Collections.Generic;
using Fixture.Domain;

namespace Fixture.Services
{
    public interface ITournamentService
    {
        IEnumerable<Tournament> Get(bool extended);
        Tournament Get(int id);
        Tournament Create(Tournament tournament);
        Tournament Update(Tournament tournament);
        void Delete(int id);
    }
}
