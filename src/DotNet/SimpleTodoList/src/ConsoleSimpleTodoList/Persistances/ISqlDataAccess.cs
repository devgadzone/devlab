namespace ConsoleSimpleTodoList.Persistances;

public interface ISqlDataAccess
{
    Task<IEnumerable<T>> LoadDataAsync<T, U>(string command, U parameters, CommandType commandType);
    Task SaveDataAsync<T>(string command, T parameters, CommandType commandType);
}
