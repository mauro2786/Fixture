namespace Fixture.Domain
{
    public class Team : IIdentifiable
    {
        public virtual int? Id { get; set; }
        public virtual string Name { get; set; }
    }
}