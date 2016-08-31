namespace Fixture.Domain
{
    public class Match : IIdentifiable
    {
        public virtual int? Id { get; set; }
        public virtual Tournament Tournament { get; set; }
        public virtual MatchType Type { get; set; }
        public virtual Team HomeTeam { get; set; }
        public virtual Team AwayTeam { get; set; }
        public virtual int? HomeTeamGoals { get; set; }
        public virtual int? AwayTeamGoals { get; set; }
    }
}