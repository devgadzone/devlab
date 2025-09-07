namespace ConsoleSimpleTodoList.Persistances;

public class SqlDataAccess : ISqlDataAccess
{
    public Task<IEnumerable<T>> LoadData<T, U>(string command, U parameters, CommandType commandType)
    {
        throw new NotImplementedException();
    }

    public Task SaveData<T>(string command, T parameters, CommandType commandType)
    {
        throw new NotImplementedException();
    }
}
