
namespace ConsoleSimpleTodoList.Persistances;

public class SqlDataAccess : ISqlDataAccess
{
    private readonly IConfiguration _configuration;

    public SqlDataAccess(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public Task<IEnumerable<T>> LoadData<T, U>(string command, U parameters, CommandType commandType)
    {
        throw new NotImplementedException();
    }

    public Task SaveData<T>(string command, T parameters, CommandType commandType)
    {
        throw new NotImplementedException();
    }
}
