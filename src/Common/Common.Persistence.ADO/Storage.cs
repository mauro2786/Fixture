namespace Common.Persistence.Ado
{
    public sealed class Storage
    {
        private string connectionString;

        public Storage(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public ICommand CreateCommand(string queryString)
        {
            return new Command(connectionString, queryString);
        }
    }
}
