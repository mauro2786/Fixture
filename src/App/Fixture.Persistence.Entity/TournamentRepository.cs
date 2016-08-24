using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fixture.Domain;
using System.Data.Entity;
using Common.Persistence.Entity;

namespace Fixture.Persistence.Entity
{
    public class TournamentRepository : RepositoryBase<Tournament, int>, ITournamentRepository
    {
        private DbContext context;

        public TournamentRepository(DbContext dbContext) : base(dbContext)
        {
            context = dbContext;
        }

        public IEnumerable<Tournament> Get() => set.ToList();
    }
}
