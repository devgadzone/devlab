namespace ConsoleSimpleTodoList.Repositories;

//TODO: QUERY FOR SQLITE AND POSTGRESQL
public class TodoRepository<T, TKey> : ITodoRepository<T, TKey>
{
    private readonly ISqlDataAccess<TKey> _sqlDb;
    private readonly ILogger _logger;

    public TodoRepository(ISqlDataAccess<TKey> sqlDb, ILogger<TodoRepository<T, TKey>> logger)
    {
        _logger = logger;
        _sqlDb = sqlDb;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        var sql = "SELECT Id, Description, IsDone, CreatedAt, UpdatedAt FROM main.Todos ORDER BY CreatedAt DESC;";

        return await _sqlDb.LoadDataAsync<T, dynamic>(sql, new { }, CommandType.Text);
    }

    public Task<T?> GetByIdAsync(TKey id)
    {
        throw new NotImplementedException();
    }

    public Task<TKey> AddAsync(T model)
    {
        throw new NotImplementedException();
    }

    public Task<TKey> UpdateAsync(T model)
    {
        var sql = """
                  UPDATE main.Todos 
                  SET Description = @Description, UpdatedAt = @UpdatedAt
                  WHERE Id = @Id
                  """;

        return _sqlDb.SaveDataAsync(sql, model, CommandType.Text);
    }

    public async Task<TKey> DeleteAsync(TKey id)
    {
        var sql = "DELETE FROM main.Todos WHERE Id = @Id;";

        return await _sqlDb.SaveDataAsync(sql, new { Id = id }, CommandType.Text);
    }
}
