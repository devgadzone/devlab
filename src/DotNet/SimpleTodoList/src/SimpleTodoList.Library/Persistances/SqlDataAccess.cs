namespace SimpleTodoList.Library.Persistances;

public class SqlDataAccess<TKey> : ISqlDataAccess<TKey>
{
    private readonly IConfiguration _configuration;
    private ILogger _logger;

    public SqlDataAccess(IConfiguration configuration, ILogger<SqlDataAccess<TKey>> logger)
    {
        _logger = logger;
        _configuration = configuration;
    }

    public async Task<IEnumerable<T>> LoadDataAsync<T, U>(string command, U parameters, CommandType commandType)
    {
        using (var cnx = GetConnection())
        {
            return await cnx.QueryAsync<T>(command, parameters, commandType: commandType);
        }
    }

    public async Task<TKey> SaveDataAsync<T>(string command, T parameters, CommandType commandType)
    {
        using (var cnx = GetConnection())
        {
            //TODO: Exectute in Transaction
            TKey key = (TKey)Convert.ChangeType(
                await cnx.ExecuteAsync(command, parameters, commandType: commandType),
                typeof(TKey));

            return key;
        }
    }

    private IDbConnection GetConnection()
    {
        //TODO: Validation
        var dbEngineName = _configuration.GetValue<string>("DbEngineName");

        if (dbEngineName is null)
            throw new Exception("DbEngineName is empty.");

        //TODO return connection based on dbEngineName
        if (Enum.TryParse<DataBaseEngine>(dbEngineName, ignoreCase: false, out var dbEngine))
        {
            if (dbEngine == DataBaseEngine.SQLite)
                return new SqliteConnection(_configuration.GetConnectionString(dbEngineName));

            if (dbEngine == DataBaseEngine.PostgreSQL)
                throw new NotImplementedException("PostgreSQL not implemented yet.");

            if (dbEngine == DataBaseEngine.SQLServer)
                throw new NotImplementedException("SQLServer not implemented yet.");

            if (dbEngine == DataBaseEngine.MongoDB)
                throw new NotImplementedException("MongoDB not implemented yet.");

            if (dbEngine == DataBaseEngine.RavenDB)
                throw new NotImplementedException("RavenDB not implemented yet.");
        }

        throw new Exception("DbEngineName is not supported.");
    }
}
