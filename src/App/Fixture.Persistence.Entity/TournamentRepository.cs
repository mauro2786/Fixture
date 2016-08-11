using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fixture.Domain;
using System.Data.Entity;
using Common.Persistence.Entity;

namespace Fixture.Persistence.Entity
{
    public class TournamentRepository : ITournamentRepository
    {
        private DbContext context;
        private DbSet<Tournament> set;

        public TournamentRepository(DbContext dbContext)            
        {
            context = dbContext;
        }

        public IEnumerable<Tournament> Get() => set.ToList();

        public Tournament Update(Tournament entity)
        {
            var entityFromDb = set.Find(entity.Id);

            entityFromDb.Name = entity.Name;

            context.SaveChanges();

            return entityFromDb;
        }

        public Tournament Create(Tournament entity)
        {
            var result = set.Add(entity);

            context.SaveChanges();

            return result;
        }

        public void Delete(int id)
        {
            set.Remove(set.Find(id));

            context.SaveChanges();
        }

        public Tournament Get(int id)
        {
            return set.Find(id);
        }
    }
}
