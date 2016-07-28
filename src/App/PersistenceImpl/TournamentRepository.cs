using Common.Persistence.ADO;
using Fixture.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Fixture.Persistence.ADO
{
    public class TournamentRepository : ITournamentRepository
    {
        private Storage storage;

        public TournamentRepository(Storage storage)
        {
            this.storage = storage;
        }

        public IEnumerable<Tournament> Get()
        {
            const string queryString = "SELECT Id, Name FROM [fixture].[Tournament]";

            var result = new List<Tournament>();

            var command = storage.CreateCommand();

            var dataTable = command.ExecuteQuery(queryString);

            return result;
        }

        //public Tournament Update(Tournament tournament)
        //{
        //    const string queryString = "UPDATE Tournament SET Id = @Id, Name = @Name WHERE ";

        //    var connection = new SqlConnection(connectionString);

        //    using (connection)
        //    {
        //        var command = new SqlCommand(queryString, connection);

        //        command.Connection = connection;

        //        command.Parameters.AddWithValue("@Id", tournament.Id);
        //        command.Parameters.AddWithValue("@Name", tournament.Name);
        //        command.Parameters.

        //        connection.Open();
        //        command.ExecuteNonQuery();
        //    }

        //    return new Tournament();
        //}

        protected Tournament MapTournament(IDataReader reader)
        {
            return new Tournament
            {
                Id = (int)reader["Id"],
                Name = reader["Name"].ToString()
            };
        }
    }
}
