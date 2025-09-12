namespace SimpleTodoList.Library.Persistance;

public interface ISqlDataAccess<TKey>
{
    Task<IEnumerable<T>> LoadDataAsync<T, U>(string command, U parameters, CommandType commandType);
    Task<TKey> SaveDataAsync<T>(string command, T parameters, CommandType commandType);
}
