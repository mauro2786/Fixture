using Fixture.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fixture.Persistence.Entity.Mappings
{
    internal class TournamentMapping : EntityTypeConfiguration<Tournament>
    {
        public TournamentMapping()
        {            
            HasKey(x => x.Id);
            Property(x => x.Name);
        }
    }
}
