using Fixture.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Common.Persistence.ADO
{
    public class Command
    {
        private string connectionString;

        private IList<Parameter> Parameters { get; set; } = new List<Parameter>();

        private delegate T Executer<T>(SqlCommand command);

        public Command(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void AddParameter<T>(string name, T value)
        {
            Parameters.Add(new Parameter { Name = name, Value = value });
        }

        private void AddParameters(SqlCommand command)
        {
            foreach (var param in Parameters)
            {
                command.Parameters.AddWithValue(param.Name, param.Value);
            }
        }

        public int ExecuteNonQuery(string queryString)
        {
            return Execute(queryString, command => command.ExecuteNonQuery());
        }

        public DataTable ExecuteQuery(string queryString)
        {
            return Execute(queryString,
                            command =>
                            {
                                var dataTable = new DataTable();

                                var reader = command.ExecuteReader();

                                dataTable.Load(reader);

                                return dataTable;
                            });
        }

        private T Execute<T>(string queryString, Executer<T> execute)
        {
            var connection = new SqlConnection(connectionString);

            using (connection)
            {
                var command = new SqlCommand(queryString, connection);

                AddParameters(command);

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

        //public IEnumerable<T> ExecuteQueryAndMap<T>(string queryString, Mapper<T> mapper)
        //{
        //    return Execute(queryString,
        //                    ReaderToEntity<T>
        //                    );
        //}

        /*private IEnumerable<T> ReaderToEntity<T>(SqlCommand command, Mapper<T> mapper)
        {
            var reader = command.ExecuteReader();

            using (reader)
            {
                while (reader.Read())
                {
                    yield return mapper(reader);
                }
            }
        }*/
    }
}
