using System.Data.Entity.ModelConfiguration;
using Fixture.Domain;

namespace Fixture.Persistence.Entity.Configurations
{
    public class MatchConfiguration : EntityTypeConfiguration<Match>
    {
        public MatchConfiguration()
        {
            //HasKey(x => x.Id);
            //Property(x => x.HomeTeamGoals);
            //Property(x => x.AwayTeamGoals);
            //HasRequired(x => x.Tournament)
            //    .WithRequiredDependent()
            //    .Map(x => x.MapKey("TournamentId"));
            //HasRequired(x => x.HomeTeam)
            //    .WithRequiredDependent()
            //    .Map(x => x.MapKey("HomeTeamId"));
            //HasRequired(x => x.AwayTeam)
            //    .WithRequiredDependent()
            //    .Map(x => x.MapKey("AwayTeamId"));
            //HasRequired(x => x.Type)
            //    .WithRequiredDependent()
            //    .Map(x => x.MapKey("TypeId"));
        }
    }
}
