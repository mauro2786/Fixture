namespace Common.Persistence.ADO
{
    public sealed class Storage
    {
        private string connectionString;

        public Storage(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public ICommand CreateCommand()
        {
            return new Command(connectionString);
        }
    }
}
