using ConsoleSimpleTodoList;
using Dapper;
using Microsoft.Data.Sqlite;
using static System.Console;

string connectionString = "Data Source=Todos.db;";

WriteLine("Hello!\n");

await InitialDB();
Initial();

void Initial()
{
    bool isUserExit = false;
    do
    {
        MainMenu();

        Write("\n> ");
        string? userInput = ReadLine()?.ToUpper();

        if (string.IsNullOrWhiteSpace(userInput))
            continue;

        UserChoice(userInput, out isUserExit);
    } while (isUserExit == false);
}

void MainMenu()
{
    string textMenu = """
                      What do you want to do?

                      [S]see all todos
                      [A]dd a todo
                      [U]pdate todo
                      [R]emove a todo
                      [E]xit
                      """;

    WriteLine(textMenu);
    Write("\nYour choice: ");
}

void UserChoice(string userInput, out bool isUserExit)
{
    isUserExit = false;

    switch (userInput)
    {
        case "S":
            Read();
            break;
        case "A":
            Create();
            break;
        case "U":
            Update();
            break;
        case "R":
            Delete();
            break;
        case "E":
            WriteLine("\nGoodbye!");
            isUserExit = true;
            break;
        default:
            WriteLine("\nInvalid choice.");
            break;
    }
}

void Create()
{
    WriteLine("\nEnter the TODO unique description:");
    Write("\n> ");
    string? userInput = ReadLine();

    if (!string.IsNullOrWhiteSpace(userInput))
    {
        Todo todo = new()
        {
            Description = userInput,
            CreatedAt = DateTime.Now
        };

        SaveData(todo, SqlActions.Create);
    }
}

void Read()
{
    WriteLine("Read");
}

void Update()
{
    WriteLine("Update");
}

void Delete()
{
    WriteLine("Delete");
}


async Task InitialDB()
{
    var sql = """
              CREATE TABLE IF NOT EXISTS main.Todos (
                  Id INTEGER NOT NULL,
                  Description TEXT NOT NULL,    
                  CreatedAt TEXT NOT NULL,
                  PRIMARY KEY (Id AUTOINCREMENT)
              );
              """;

    using (var cnx = new SqliteConnection(connectionString))
    {
        await cnx.ExecuteAsync(sql);
    }
}

void SaveData(Todo model, SqlActions action)
{
    using (var cnx = new SqliteConnection(connectionString))
    {
    }
}
