using Common.Persistence;
using Fixture.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Persistence.ADO
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : IEntity
    {
        private readonly string connectionString;        

        public RepositoryBase(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public T Create(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public T Get(string id)
        {
            throw new NotImplementedException();
        }

        public T Update(T entity)
        {
            throw new NotImplementedException();
        }

        public abstract T Map(IDataReader reader);
    }
}
