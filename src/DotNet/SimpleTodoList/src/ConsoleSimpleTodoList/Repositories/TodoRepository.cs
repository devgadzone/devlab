namespace ConsoleSimpleTodoList.Repositories;

public class TodoRepository<T, TKey> : ITodoRepository<T, TKey>
{
    private readonly ISqlDataAccess _sqlDb;

    public TodoRepository(ISqlDataAccess sqlDb)
    {
        _sqlDb = sqlDb;
    }

    public Task<IEnumerable<T>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<T?> GetByIdAsync(TKey id)
    {
        throw new NotImplementedException();
    }

    public Task<int> AddAsync(T model)
    {
        throw new NotImplementedException();
    }

    public Task<int> UpdateAsync(T model)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}
