namespace ConsoleSimpleTodoList.Services;

public class TodoService<T, TKey> : ITodoService<T, TKey>
{
    private readonly ITodoRepository<T, TKey> _repository;
    private readonly ILogger<TodoService<T, TKey>> _logger;

    public TodoService(ITodoRepository<T, TKey> repository, ILogger<TodoService<T, TKey>> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public Task<IEnumerable<T>> GetAllAsync()
    {
        throw new NotImplementedException();
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
