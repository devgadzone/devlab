namespace ConsoleSimpleTodoList.Persistances;

public interface ISqlDataAccess
{
    Task<IEnumerable<T>> LoadData<T, U>(string command, U parameters, CommandType commandType, string connectionSTring);
    Task SaveData<T>(string command, T parameters, CommandType commandType, string connectionSTring);
}
