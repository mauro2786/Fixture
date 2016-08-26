using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fixture.Persistence.NHibernate.Configuration
{
    public class NHibernateConfigurator
    {
        private const string FixtureSchema = "fixture";

        public static ISessionFactory CreateSessionFactory(string connectionString)
        {
            return Fluently.Configure()
              .Database(MsSqlConfiguration.MsSql2012
                        .DefaultSchema(FixtureSchema)
                        .ConnectionString(connectionString))
              .Mappings(m => m.FluentMappings.AddFromAssemblyOf<NHibernateConfigurator>())
              .BuildSessionFactory();
        }
    }
}
