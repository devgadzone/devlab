namespace ConsoleSimpleTodoList.Repositories;

public interface ITodoRepository<T, TKey>
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(TKey id);
    Task<int> AddAsync(T model);
    Task<int> UpdateAsync(T model);
    Task<int> DeleteAsync(int id);
}
