namespace ConsoleSimpleTodoList.Repositories;

public class TodoRepository<T, TKey> : ITodoRepository<T, TKey>
{
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
