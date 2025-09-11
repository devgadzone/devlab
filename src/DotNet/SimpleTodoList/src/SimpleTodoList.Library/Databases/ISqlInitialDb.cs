namespace SimpleTodoList.Library.Databases;

public interface ISqlInitialDb<TKey>
{
    Task InitializeAsync();
}
