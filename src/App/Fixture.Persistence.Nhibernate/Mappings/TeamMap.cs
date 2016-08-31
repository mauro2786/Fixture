using Fixture.Domain;
using FluentNHibernate.Mapping;

namespace Fixture.Persistence.NHibernate.Mappings
{
    public class TeamMap : ClassMap<Team>
    {
        public TeamMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
        }
    }
}
