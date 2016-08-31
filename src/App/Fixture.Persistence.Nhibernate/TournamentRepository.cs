using System.Collections.Generic;
using System.Linq;
using Common.Persistence.NHibernate;
using Fixture.Domain;
using NHibernate;
using NHibernate.Linq;

namespace Fixture.Persistence.NHibernate
{
    public class TournamentRepository : RepositoryBase<Tournament, int>, ITournamentRepository
    {
        public TournamentRepository(ISession session) : base(session)
        {
        }

        public IEnumerable<Tournament> Get(bool extended)
        {
            if (extended)
                return session.Query<Tournament>().ToList();

            return session.Query<Tournament>()
                            .Select(x => new Tournament { Id = x.Id, Name = x.Name })
                            .ToList();
        }
    }
}
