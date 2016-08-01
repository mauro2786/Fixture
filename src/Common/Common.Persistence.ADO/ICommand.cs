using Fixture.Domain;
using System;
using System.Collections.Generic;
using System.Data;

namespace Common.Persistence.Ado
{
    public interface ICommand
    {
        /// <summary>
        /// Adds a query parameter to parameter list.
        /// </summary>
        /// <typeparam name="T">Object type.</typeparam>
        /// <param name="name">Name of the parameter(without the "@" suffix).</param>
        /// <param name="value">Parameter value.</param>
        void AddParam<T>(string name, T value);

        /// <summary>
        /// Executes a statement, returns affected database rows.
        /// </summary>
        /// <param name="queryString">Statement to be executed.</param>
        /// <returns>Affected database rows.</returns>
        int ExecuteNonQuery(string queryString);

        /// <summary>
        /// Executes statement, returns result as DataTable.
        /// </summary>
        /// <param name="queryString">Statement to be executed.</param>
        /// <returns>Statement result as DataTable.</returns>
        DataTable ExecuteQuery(string queryString);

        /// <summary>
        /// Executes statement and returns result as entity collection.
        /// </summary>
        /// <typeparam name="TEntity">Entity type.</typeparam>
        /// <param name="queryString">Statement to be executed.</param>
        /// <param name="mapper">Function that maps entity.</param>
        /// <returns>Mapped entity collection.</returns>
        IEnumerable<TEntity> GetEntityCollection<TEntity>(string queryString, Func<IDataReader, TEntity> mapper) where TEntity : IEntity;

        /// <summary>
        /// Executes statement and returns first result mapped to an entity.
        /// </summary>
        /// <typeparam name="TEntity">Entity type.</typeparam>
        /// <param name="queryString">Statement to be executed.</param>
        /// <param name="mapper">Function that maps result to entity.</param>
        /// <returns>Mapped entity.</returns>
        TEntity GetEntity<TEntity>(string queryString, Func<IDataReader, TEntity> mapper) where TEntity : IEntity;

        /// <summary>
        /// Inserts a new entity row on specified table.
        /// </summary>
        /// <typeparam name="TId">Entity Id type</typeparam>
        /// <param name="queryString">Statement to be executed.</param>
        /// <returns>Created row id.</returns>
        TId CreateEntity<TId>(string queryString);
    }
}
