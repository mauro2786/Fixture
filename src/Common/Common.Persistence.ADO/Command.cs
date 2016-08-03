﻿using Fixture.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;

namespace Common.Persistence.Ado
{
    /// <summary>
    /// Handles database connection and execution of SQL queries.
    /// </summary>
    public class Command : ICommand
    {
        private const string LastInsertedIdStatement = "SELECT SCOPE_IDENTITY()";

        /// <summary>
        /// Database connectionString
        /// </summary>
        private string connectionString;

        /// <summary>
        /// Statement to be executed.
        /// </summary>
        private string queryString;

        private IList<Parameter> Parameters { get; set; } = new List<Parameter>();

        //private delegate T Executer<T>(SqlCommand command);

        //public delegate TEntity EntityMapper<TEntity>(IDataReader reader);

        public Command(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Adds a query parameter to parameter list.
        /// </summary>
        /// <typeparam name="T">Object type</typeparam>
        /// <param name="name">Name of the parameter(without the "@" suffix).</param>
        /// <param name="value">Parameter value.</param>
        public void AddParam<T>(string name, T value)
        {
            Parameters.Add(new Parameter { Name = name, Value = value });
        }

        /// <summary>
        /// Adds command parameters to SqlCommand.
        /// </summary>
        /// <param name="command">SqlCommand that needs parameters to be added.</param>
        private void AddParams(SqlCommand command)
        {
            const string ParamSufix = "@";

            foreach (var param in Parameters)
            {
                command.Parameters.AddWithValue(ParamSufix + param.Name, param.Value);
            }
        }

        /// <summary>
        /// Generic execution of SqlCommand.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryString">Statement to be executed.</param>
        /// <param name="execute">Actual execution.</param>
        /// <returns>Execution result.</returns>
        private T Execute<T>(string queryString, Func<SqlCommand, T> execute)
        {
            this.queryString = queryString;

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(this.queryString, connection))
                {
                    AddParams(command);

                    try
                    {
                        connection.Open();

                        return execute(command);
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine(ex.Message);
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Generic execution of SqlCommand with Entity mapper.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryString">Statement to be executed.</param>
        /// <param name="execute">Actual execution.</param>
        /// <param name="mapper">Entity mapper.</param>
        /// <returns>Execution result.</returns>
        private T ExecuteEntity<T, TEntity>(string queryString, Func<SqlCommand, Func<IDataReader, TEntity>, T> execute, Func<IDataReader, TEntity> mapper)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(queryString, connection))
                {
                    AddParams(command);

                    try
                    {
                        connection.Open();

                        return execute(command, mapper);
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine(ex.Message);
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Executes a statement, returns affected database rows.
        /// </summary>
        /// <param name="queryString">Statement to be executed.</param>
        /// <returns>Affected database rows.</returns>
        public int ExecuteNonQuery(string queryString)
        {
            return Execute(queryString, command => command.ExecuteNonQuery());
        }

        /// <summary>
        /// Executes statement, returns result as DataTable.
        /// </summary>
        /// <param name="queryString">Statement to be executed.</param>
        /// <returns>Statement result as DataTable.</returns>
        public DataTable ExecuteQuery(string queryString)
        {
            return Execute(queryString, ExecuteToDataTable);
        }

        protected DataTable ExecuteToDataTable(SqlCommand command)
        {
            var dataTable = new DataTable();

            using (var reader = command.ExecuteReader())
            {
                dataTable.Load(reader);
            }

            return dataTable;
        }

        /// <summary>
        /// Executes statement and returns result as entity collection.
        /// </summary>
        /// <typeparam name="TEntity">Entity type.</typeparam>
        /// <param name="queryString">Statement to be executed.</param>
        /// <param name="mapper">Function that maps entity.</param>
        /// <returns>Mapped entity collection.</returns>
        public IEnumerable<TEntity> GetEntityCollection<TEntity>(string queryString, Func<IDataReader, TEntity> mapper) where TEntity : IEntity
        {
            return ExecuteEntity(queryString, ExecuteGetEntityCollection, mapper);
        }

        private IEnumerable<TEntity> ExecuteGetEntityCollection<TEntity>(SqlCommand command, Func<IDataReader, TEntity> mapper)
        {
            var listType = typeof(List<>).MakeGenericType(typeof(TEntity));

            var list = (IList<TEntity>)Activator.CreateInstance(listType);

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    list.Add(mapper(reader));
                }
            }

            return list;
        }

        /// <summary>
        /// Executes statement and returns first result mapped to an entity.
        /// </summary>
        /// <typeparam name="TEntity">Entity type.</typeparam>
        /// <param name="queryString">Statement to be executed.</param>
        /// <param name="mapper">Function that maps result to entity.</param>
        /// <returns>Mapped entity.</returns>
        public TEntity GetEntity<TEntity>(string queryString, Func<IDataReader, TEntity> mapper) where TEntity : IEntity
        {
            return ExecuteEntity(queryString,ExecuteGetEntity, mapper);
        }

        private TEntity ExecuteGetEntity<TEntity>(SqlCommand command, Func<IDataReader, TEntity> mapper)
        {
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    return mapper(reader);
                }
            }

            return default(TEntity);
        }

        /// <summary>
        /// Inserts a new entity row on specified table.
        /// </summary>
        /// <typeparam name="TId">Entity Id type.</typeparam>
        /// <param name="queryString">Statement to be executed.</param>
        /// <returns>Created row id.</returns>
        public TId CreateEntity<TId>(string queryString)
        {
            return Execute(queryString, ExecuteCreateEntity<TId>);
        }

        protected TId ExecuteCreateEntity<TId>(SqlCommand command)
        {
            command.CommandText = $"{queryString};{LastInsertedIdStatement}";

            var lastInsertedId = command.ExecuteScalar();

            return Convert<TId>(lastInsertedId.ToString());
        }

        private static T Convert<T>(string input)
        {
            var converter = TypeDescriptor.GetConverter(typeof(T));

            if (converter != null)
                return (T)converter.ConvertFromString(input);

            return default(T);
        }
    }
}
