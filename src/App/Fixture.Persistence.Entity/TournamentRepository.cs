using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Common.Persistence.Entity;
using Fixture.Domain;

namespace Fixture.Persistence.Entity
{
    public class TournamentRepository : RepositoryBase<Tournament, int>, ITournamentRepository
    {
        public TournamentRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Tournament> Get(bool extended)
        {
            if (extended)
                return set.ToList();

            return set.Select(x => new { Id = x.Id, Name = x.Name })
                        .ToList()
                        .Select(x => new Tournament { Id = x.Id, Name = x.Name });
        }
    }
}
