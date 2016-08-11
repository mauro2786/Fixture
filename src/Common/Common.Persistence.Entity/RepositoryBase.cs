using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Persistence.Entity
{
    //: IRepository<T, TId> ver si agregarselo
    public abstract class RepositoryBase<T, TId>  where T : class
    {
        protected DbSet<T> set;
        protected DbContext context;

        public RepositoryBase(DbContext dbContext)
        {
            context = dbContext;
            set = dbContext.Set<T>();
        }

        public T Create(T entity)
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

        public T Get(TId id)
        {
            return set.Find(id);
        }
    }
}
