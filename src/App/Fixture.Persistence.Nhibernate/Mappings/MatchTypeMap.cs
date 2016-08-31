using Fixture.Domain;
using FluentNHibernate.Mapping;

namespace Fixture.Persistence.NHibernate.Mappings
{
    public class MatchTypeMap : ClassMap<MatchType>
    {
        public MatchTypeMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
        }
    }
}
