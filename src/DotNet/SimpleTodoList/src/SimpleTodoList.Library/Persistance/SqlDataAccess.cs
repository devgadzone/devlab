namespace SimpleTodoList.Library.Persistance;

public class SqlDataAccess<TKey> : ISqlDataAccess<TKey>
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<SqlDataAccess<TKey>> _logger;

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
            cnx.Open();

            using (var tran = cnx.BeginTransaction())
            {
                try
                {
                    TKey key = (TKey)Convert.ChangeType(
                        await cnx.ExecuteAsync(
                            command,
                            parameters,
                            transaction: tran,
                            commandType: commandType),
                        typeof(TKey));

                    tran.Commit();

                    return key;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, ex.Message);
                    tran.Rollback();
                    throw;
                }
                finally
                {
                    cnx.Close();
                }
            }
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
            return dbEngine switch
            {
                DataBaseEngine.SQLite => new SqliteConnection(_configuration.GetConnectionString(dbEngineName)),
                DataBaseEngine.PostgreSQL => throw new NotImplementedException("PostgreSQL not implemented yet."),
                DataBaseEngine.SQLServer => throw new NotImplementedException("SQLServer not implemented yet."),
                _ => throw new Exception("DbEngine not supported yet.")
            };
        }

        
        throw new Exception("Invalid DbEngineName.");
    }
}
