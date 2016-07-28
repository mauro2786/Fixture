namespace Fixture.Domain
{
    public class Match : IEntity
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public Tournament Tournament { get; set; }

        public MatchType Type { get; set; }
        
        public Team HomeTeam { get; set; }

        public Team AwayTeam { get; set; }

        public int? HomeTeamGoals { get; set; }

        public int? AwayTeamGoals { get; set; }
    }
}