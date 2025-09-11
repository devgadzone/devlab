namespace SimpleTodoList.Library.Services;

public class TodoService<T, TKey> : ITodoService<T, TKey>
{
    private readonly ITodoRepository<T, TKey> _repository;
    private readonly ILogger<TodoService<T, TKey>> _logger;

    public TodoService(ITodoRepository<T, TKey> repository, ILogger<TodoService<T, TKey>> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<T?> GetByIdAsync(TKey id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<TKey> AddAsync(T model)
    {
        return await _repository.AddAsync(model);
    }

    public async Task<TKey> UpdateAsync(T model)
    {
        return await _repository.UpdateAsync(model);
    }

    public async Task<TKey> DeleteAsync(TKey id)
    {
        return await _repository.DeleteAsync(id);
    }
}
