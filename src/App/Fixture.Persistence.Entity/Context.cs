﻿using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using Fixture.Persistence.Entity.Conventions;

namespace Fixture.Persistence.Entity
{
    public class Context : DbContext
    {
        private const string FixtureSchema = "fixture";
        private const string MappingClassPostfix = "Configuration";

        public Context(string connectionString)
            : base(connectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(FixtureSchema);

            //Removes the plural table names convention so that it works with singular named tables
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Add(new ForeignKeyNamingConvention());

            AddMappingConfigurations(modelBuilder);
        }

        /// <summary>
        /// Adds the entity to table mappings 
        /// </summary>
        /// <param name="modelBuilder"></param>
        private void AddMappingConfigurations(DbModelBuilder modelBuilder)
        {
            var assembly = Assembly.GetExecutingAssembly();

            var types = assembly.GetTypes().Where(x => x.FullName.EndsWith(MappingClassPostfix));

            foreach (var type in types)
            {
                dynamic entityConfiguration = Activator.CreateInstance(type);

                modelBuilder.Configurations.Add(entityConfiguration);
            }
        }
    }
}
