using System.Data.Entity.ModelConfiguration;
using Fixture.Domain;

namespace Fixture.Persistence.Entity.Configurations
{
    public class MatchTypeConfiguration : EntityTypeConfiguration<MatchType>
    {
        public MatchTypeConfiguration()
        {
            //HasKey(x => x.Id);
            //Property(x => x.Name);
        }
    }
}
