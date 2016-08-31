using NHibernate;

namespace Common.Persistence.NHibernate
{
    public class RepositoryBase<TEntity, TId> : IRepository<TEntity, TId> where TEntity : class
    {
        protected readonly ISession session;

        public RepositoryBase(ISession session)
        {
            this.session = session;
        }

        public TEntity Create(TEntity entity)
        {
            session.Save(entity);

            session.Flush();

            return entity;
        }

        public void Delete(TId id)
        {
            var entity = session.Load<TEntity>(id);

            session.Delete(entity);

            session.Flush();
        }

        public TEntity Get(TId id)
        {
            return session.Get<TEntity>(id);
        }

        public TEntity Update(TEntity entity)
        {
            session.SaveOrUpdate(entity);

            session.Flush();

            return entity;
        }
    }
}
