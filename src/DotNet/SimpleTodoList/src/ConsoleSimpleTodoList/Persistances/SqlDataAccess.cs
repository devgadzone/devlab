namespace ConsoleSimpleTodoList.Persistances;

public class SqlDataAccess : ISqlDataAccess
{
    private readonly IConfiguration _configuration;
    private ILogger _logger;

    public SqlDataAccess(IConfiguration configuration, ILogger logger)
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

    public async Task SaveDataAsync<T>(string command, T parameters, CommandType commandType)
    {
        using (var cnx = GetConnection())
        {
            //TODO: Exectute in Transaction
            await cnx.ExecuteAsync(command, parameters, commandType: commandType);
        }
    }

    private IDbConnection GetConnection()
    {
        //TODO: Get Database Engine from Configuration
        return new SqliteConnection("SQLite");
    }
}
