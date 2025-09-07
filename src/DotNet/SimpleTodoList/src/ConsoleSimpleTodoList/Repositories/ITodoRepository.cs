namespace ConsoleSimpleTodoList.Repositories;

public interface ITodoRepository<T, TKey>
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(TKey id);
    Task<TKey> AddAsync(T model);
    Task<TKey> UpdateAsync(T model);
    Task<TKey> DeleteAsync(TKey id);
}
