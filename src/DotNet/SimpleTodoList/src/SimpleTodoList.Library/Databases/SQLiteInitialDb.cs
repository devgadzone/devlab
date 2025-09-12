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
        await CreateIndexesAsync();
    }

    private async Task CreateTablesAsync()
    {
        var sqlCreateTableTodos = """
                                  CREATE TABLE IF NOT EXISTS main.Todos (
                                      Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                      Description TEXT NOT NULL,    
                                      IsDone INTEGER NOT NULL DEFAULT 0,
                                      CreatedAt TEXT NOT NULL DEFAULT (datetime('now')),
                                      UpdatedAt TEX
                                  );
                                  """;

        await _sqlDb.SaveDataAsync(sqlCreateTableTodos, new { }, CommandType.Text);
    }

    private async Task CreateIndexesAsync()
    {
        var sqlCreateIndexTodoDescription = """
                                            CREATE INDEX IF NOT EXISTS idxTodoDescription
                                            ON Todos (Description);
                                            """;

        var sqlCreateIndexTodoUpdatedAt = """
                                          CREATE INDEX IF NOT EXISTS idxTodoUpdatedAt
                                          ON Todos (UpdatedAt);
                                          """;

        var sqlCreateIndexTodoIsDone = """
                                       CREATE INDEX IF NOT EXISTS idxTodoIsDone
                                       ON Todos (IsDone);
                                       """;

        await _sqlDb.SaveDataAsync(sqlCreateIndexTodoDescription, new { }, CommandType.Text);
        await _sqlDb.SaveDataAsync(sqlCreateIndexTodoUpdatedAt, new { }, CommandType.Text);
        await _sqlDb.SaveDataAsync(sqlCreateIndexTodoIsDone, new { }, CommandType.Text);
    }
}
