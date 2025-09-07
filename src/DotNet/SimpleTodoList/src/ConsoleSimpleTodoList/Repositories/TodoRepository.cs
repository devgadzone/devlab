namespace ConsoleSimpleTodoList.Repositories;

//TODO: QUERY FOR SQLITE AND POSTGRESQL
public class TodoRepository<T, TKey> : ITodoRepository<T, TKey>
{
    private readonly ISqlDataAccess _sqlDb;
    private readonly ILogger _logger;

    public TodoRepository(ISqlDataAccess sqlDb, ILogger<TodoRepository<T, TKey>> logger)
    {
        _logger = logger;
        _sqlDb = sqlDb;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        var sql = "SELECT Id, Description, IsDone, CreatedAt, UpdatedAt FROM main.Todos;";

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
        throw new NotImplementedException();
    }

    public Task<TKey> DeleteAsync(TKey id)
    {
        throw new NotImplementedException();
    }
}
