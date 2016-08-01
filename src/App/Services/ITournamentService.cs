using Fixture.Domain;
using System.Collections.Generic;

namespace Fixture.Services
{
    public interface ITournamentService
    {
        IEnumerable<Tournament> Get();

        Tournament Get(int id);

        Tournament Create(Tournament tournament);

        Tournament Update(Tournament tournament);

        void Delete(int id);
    }
}
