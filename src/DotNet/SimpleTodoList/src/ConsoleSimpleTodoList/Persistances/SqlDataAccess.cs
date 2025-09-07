namespace ConsoleSimpleTodoList.Persistances;

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
            TKey key = (TKey) Convert.ChangeType(
                await cnx.ExecuteAsync(command, parameters, commandType: commandType),
                typeof(TKey));
            
            return key;
        }
    }

    private IDbConnection GetConnection()
    {
        //TODO: Get Database Engine from Configuration
        return new SqliteConnection(_configuration.GetConnectionString("SQLite"));
    }
}
