using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Persistence
{
    public interface IRepository<T, TId>
    {
        T Create(T entity);

        T Get(TId id);

        T Update(T entity);

        void Delete(TId id);
    }
}
