using Fixture.Domain;
using FluentNHibernate.Mapping;

namespace Fixture.Persistence.Nhibernate.Mappings
{
    public class TournamentMap : ClassMap<Tournament>
    {
        public TournamentMap()
        {
            Id(x => x.Id).GeneratedBy.Native();
            Map(x => x.Name);
        }
    }
}
