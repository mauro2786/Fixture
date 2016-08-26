using System.Collections.Generic;
using System.Linq;
using Fixture.Domain;
using System.Data.Entity;
using Common.Persistence.Entity;

namespace Fixture.Persistence.Entity
{
    public class TournamentRepository : RepositoryBase<Tournament, int>, ITournamentRepository
    {
        public TournamentRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Tournament> Get() => set.ToList();
    }
}
