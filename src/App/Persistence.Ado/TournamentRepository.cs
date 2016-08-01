using Common.Persistence.Ado;
using Fixture.Domain;
using System.Collections.Generic;
using System.Data;

namespace Fixture.Persistence.Ado
{
    public class TournamentRepository : ITournamentRepository
    {
        private const string NameColumn = "Name";
        private const string IdColumn = "Id";

        private Storage storage;

        public TournamentRepository(Storage storage)
        {
            this.storage = storage;
        }        

        public IEnumerable<Tournament> Get()
        {
            const string queryString = "SELECT Id, Name FROM fixture.Tournament";

            var command = storage.CreateCommand();

            return command.GetEntityCollection(queryString, MapEntity);
        }

        public Tournament Get(int id)
        {
            const string queryString = "SELECT Id, Name FROM fixture.Tournament WHERE Id = @Id";

            var command = storage.CreateCommand();

            command.AddParam(IdColumn, id);

            return command.GetEntity(queryString, MapEntity);
        }

        public Tournament Create(Tournament entity)
        {
            const string queryString = "INSERT INTO fixture.Tournament (Name) VALUES(@Name)";

            var command = storage.CreateCommand();

            command.AddParam(NameColumn, entity.Name);

            var entityId = command.CreateEntity<int>(queryString);

            entity.Id = entityId;

            return entity;
        }

        public Tournament Update(Tournament entity)
        {
            const string queryString = "UPDATE fixture.Tournament SET Name = @Name WHERE Id = @Id";

            var command = storage.CreateCommand();

            command.AddParam(NameColumn, entity.Name);
            command.AddParam(IdColumn, entity.Id);

            command.ExecuteNonQuery(queryString);

            return entity;
        }

        public void Delete(int id)
        {
            const string queryString = "DELETE FROM fixture.Tournament WHERE Id = @Id";

            var command = storage.CreateCommand();

            command.AddParam(IdColumn, id);

            command.ExecuteNonQuery(queryString);
        }

        public Tournament MapEntity(IDataReader reader)
        {
            return new Tournament
            {
                Id = (int)reader[IdColumn],
                Name = reader[NameColumn].ToString()
            };
        }        
    }
}
