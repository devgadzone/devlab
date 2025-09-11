namespace SimpleTodoList.Library.Services;

public interface ITodoService<T, TKey>
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(TKey id);
    Task<TKey> AddAsync(T model);
    Task<TKey> UpdateAsync(T model);
    Task<TKey> DeleteAsync(TKey id);
}
