﻿using System.Data.Entity.ModelConfiguration;
using Fixture.Domain;

namespace Fixture.Persistence.Entity.Configurations
{
    internal class TournamentConfiguration : EntityTypeConfiguration<Tournament>
    {
        public TournamentConfiguration()
        {
            //HasKey(x => x.Id);
            //Property(x => x.Name);
            //HasMany(x => x.Matches);
        }
    }
}
