using Fixture.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fixture.Persistence.Entity.Configurations
{
    internal class TournamentConfiguration : EntityTypeConfiguration<Tournament>
    {
        public TournamentConfiguration()
        {            
            HasKey(x => x.Id);
            Property(x => x.Name);
        }
    }
}
