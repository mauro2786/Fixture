using Fixture.Domain;
using FluentNHibernate.Mapping;

namespace Fixture.Persistence.NHibernate.Mappings
{
    public class MatchMap : ClassMap<Match>
    {
        public MatchMap()
        {
            Id(x => x.Id);
            Map(x => x.HomeTeamGoals);
            Map(x => x.AwayTeamGoals);
            References(x => x.Tournament).Column("TournamentId").ReadOnly().Not.LazyLoad();
            References(x => x.Type).Column("TypeId").ReadOnly().Not.LazyLoad();
            References(x => x.HomeTeam).Column("HomeTeamId").ReadOnly().Not.LazyLoad();
            References(x => x.AwayTeam).Column("AwayTeamId").ReadOnly().Not.LazyLoad();
        }
    }
}
