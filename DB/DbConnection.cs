using Oracle.ManagedDataAccess.Client;

namespace ACCMS_AGH.DB
{
    public class DbConnection
    {
        private readonly string _connectionString;

        public DbConnection(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("OracleDb")
                ?? throw new ArgumentNullException(nameof(configuration), "Oracle connection string 'OracleDb' not found in configuration.");
        }

        public OracleConnection GetConnection()
        {
            var connection = new OracleConnection(_connectionString);
            connection.Open();
            return connection;
        }
    }
}
