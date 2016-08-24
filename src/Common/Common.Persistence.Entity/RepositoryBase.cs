using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Persistence.Entity
{
    //: IRepository<T, TId> ver si agregarselo
    public abstract class RepositoryBase<TEntity, TId> : IRepository<TEntity, TId> where TEntity : class
    {
        protected DbSet<TEntity> set;
        private DbContext context;

        public RepositoryBase(DbContext dbContext)
        {
            context = dbContext;
            set = dbContext.Set<TEntity>();
        }

        public TEntity Create(TEntity entity)
        {
            var result = set.Add(entity);

            context.SaveChanges();

            return result;
        }

        public void Delete(TId id)
        {
            set.Remove(set.Find(id));

            context.SaveChanges();
        }

        public TEntity Get(TId id)
        {
            return set.Find(id);
        }

        public TEntity Update(TEntity entity)
        {
            var result = set.Attach(entity);

            context.Entry(entity).State = EntityState.Modified;

            return result;
        }
    }
}
