using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Persistence.Entity
{
    public class EntityUnitOfWork : IUnitOfWork
    {
        private DbContext context;

        public EntityUnitOfWork(DbContext context)
        {
            this.context = context;
        }

        public void Commit()
        {
            context.SaveChanges();
        }
    }
}
