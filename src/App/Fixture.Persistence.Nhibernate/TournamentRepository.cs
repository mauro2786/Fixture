using System.Collections.Generic;
using Fixture.Domain;
using Common.Persistence.NHibernate;
using NHibernate;
using NHibernate.Linq;

namespace Fixture.Persistence.NHibernate
{
    public class TournamentRepository : RepositoryBase<Tournament, int>, ITournamentRepository
    {
        public TournamentRepository(ISession session) : base(session)
        {
        }

        public IEnumerable<Tournament> Get()
        {
            return session.Query<Tournament>();
        }
    }
}
