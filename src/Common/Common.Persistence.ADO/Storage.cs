using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Common.Persistence.ADO
{
    public class Storage
    {
        private string connectionString;

        public Storage(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Command CreateCommand()
        {
            return new Command(connectionString);
        }

        //public DataTable ExecuteQuery(string queryString, KeyValuePair<string, object>[] parameters)
        //{
        //    var dataTable = new DataTable();

        //    var connection = new SqlConnection(connectionString);

        //    using (connection)
        //    {
        //        var command = new SqlCommand(queryString, connection);

        //        try
        //        {
        //            connection.Open();

        //            var reader = command.ExecuteReader();

        //            dataTable.Load(reader);
        //        }
        //        catch (SqlException ex)
        //        {
        //            Console.WriteLine(ex.Message);
        //            throw;
        //        }
        //    }

        //    return dataTable;
        //}

        //public int ExecuteNonQuery(string queryString)
        //{
        //    var connection = new SqlConnection(connectionString);

        //    using (connection)
        //    {
        //        var command = new SqlCommand(queryString, connection);

        //        try
        //        {
        //            connection.Open();

        //            return command.ExecuteNonQuery();
        //        }
        //        catch (SqlException ex)
        //        {
        //            Console.WriteLine(ex.Message);
        //            throw;
        //        }
        //    }
        //}
    }
}
