namespace Common.Persistence
{
    public interface IRepository<TEntity, TId> where TEntity : class
    {
        TEntity Create(TEntity entity);

        TEntity Get(TId id);

        TEntity Update(TEntity entity);

        void Delete(TId id);
    }
}
