namespace Fixture.Domain
{
    public class Tournament : IEntity
    {
        public virtual int? Id { get; set; }

        public virtual string Name { get; set; }
    }
}