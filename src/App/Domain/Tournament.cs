using System.Collections.Generic;

namespace Fixture.Domain
{
    public class Tournament : IIdentifiable
    {
        public virtual int? Id { get; set; }
        public virtual string Name { get; set; }
        public virtual IList<Match> Matches { get; set; }
    }
}