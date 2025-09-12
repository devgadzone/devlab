namespace SimpleTodoList.Library.Databases;

public class SQLiteInitialDb<TKey> : ISqlInitialDb<TKey>
{
    private readonly ISqlDataAccess<TKey> _sqlDb;
    private readonly ILogger<SQLiteInitialDb<TKey>> _logger;

    public SQLiteInitialDb(ISqlDataAccess<TKey> sqlDb, ILogger<SQLiteInitialDb<TKey>> logger)
    {
        _sqlDb = sqlDb;
        _logger = logger;
    }

    public async Task InitializeAsync()
    {
        await CreateTablesAsync();
    }

    private async Task<TKey> CreateTablesAsync()
    {
        var sqlCreateTableTodos = """
                             CREATE TABLE IF NOT EXISTS main.Todos (
                                 Id INTEGER NOT NULL,
                                 Description TEXT NOT NULL,    
                                 IsDone INTEGER NOT NULL DEFAULT 0,
                                 CreatedAt TEXT NOT NULL DEFAULT (datetime('now')),
                                 UpdatedAt TEXT,
                                 
                                 PRIMARY KEY (Id AUTOINCREMENT)
                             );
                             """;

        return await _sqlDb.SaveDataAsync(sqlCreateTableTodos, new { }, CommandType.Text);
    }
}
