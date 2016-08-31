using System.Data.Entity.ModelConfiguration;
using Fixture.Domain;

namespace Fixture.Persistence.Entity.Configurations
{
    public class TeamConfiguration : EntityTypeConfiguration<Team>
    {
        public TeamConfiguration()
        {
            //HasKey(x => x.Id);
            //Property(x => x.Name);
        }
    }
}
