using System.Data;
using ConsoleSimpleTodoList;
using Dapper;
using Microsoft.Data.Sqlite;
using static System.Console;

string connectionString = "Data Source=Todos.db;";

WriteLine("Hello!\n");

await InitialDB();
await Initial();

async Task Initial()
{
    bool isUserExit = false;
    do
    {
        MainMenu();

        Write("\n> ");
        string? userInput = ReadLine()?.ToUpper();

        if (string.IsNullOrWhiteSpace(userInput))
            continue;

        isUserExit = await UserChoice(userInput);
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

async Task<bool> UserChoice(string userInput)
{
    switch (userInput)
    {
        case "S":
            await Read();
            break;
        case "A":
            await Create();
            break;
        case "U":
            await Update();
            break;
        case "R":
            await Delete();
            break;
        case "E":
            WriteLine("\nGoodbye!");
            return true;
        default:
            WriteLine("\nInvalid choice.");
            break;
    }

    return false;
}

async Task Create()
{
    //TODO: VALIDATION
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

        await SaveData(todo, SqlActions.Create);
    }
}

async Task Read()
{
    Clear();
    WriteLine("Read all todos\n");
    var todos = await LoadData(0);

    if (todos.Count == 0)
    {
        WriteLine("No todos found.\n");
    }
    else
    {
        foreach (var todo in todos)
        {
            WriteLine($"{todo.Id} - {todo.Description} - {todo.CreatedAt.ToShortDateString()}");
        }
    }

    Write("\nPress any key to continue...");
    ReadKey();
}

async Task Update()
{
    await Read();
    bool isIdValid = false;

    do
    {
        WriteLine("\nEnter ID to delete:");
        Write("> ");

        string? userInput = ReadLine();
        isIdValid = int.TryParse(userInput, out int id);

        if (isIdValid == false)
        {
            WriteLine("\nInvalid ID as number.");
        }
        else
        {
            WriteLine("\nEnter the new description:");
            Write("> ");
            userInput = ReadLine();

            if (!string.IsNullOrWhiteSpace(userInput))
            {
                Todo todo = new Todo() { Id = id, Description = userInput, CreatedAt = DateTime.Now };
                await SaveData(todo, SqlActions.Update);
            }
        }
    } while (isIdValid == false);
}

async Task Delete()
{
    await Read();
    bool isIdValid = false;

    do
    {
        WriteLine("\nEnter ID to delete:");
        Write("> ");

        string? userInput = ReadLine();
        isIdValid = int.TryParse(userInput, out int id);

        if (isIdValid == false)
        {
            WriteLine("\nInvalid ID as number.");
        }
        else
        {
            await SaveData(null, SqlActions.Delete, id);
        }
    } while (isIdValid == false);
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

async Task SaveData(Todo? model, SqlActions action, int id = 0)
{
    var sql = string.Empty;

    switch (action)
    {
        case SqlActions.Create:
            sql = """
                  INSERT INTO main.Todos (Description, CreatedAt) 
                  VALUES (@Description, @CreatedAt);
                  """;
            break;
        case SqlActions.Update:
            sql = """
                  UPDATE main.Todos 
                  SET Description = @Description, CreatedAt = @CreatedAt 
                  WHERE Id = @Id
                  """;
            break;
        case SqlActions.Delete:
            sql = "DELETE FROM main.Todos WHERE Id = @Id;";
            break;
        default:
            return;
    }

    if (!string.IsNullOrWhiteSpace(sql))
    {
        using (var cnx = new SqliteConnection(connectionString))
        {
            if (id == 0)
            {
                await cnx.ExecuteAsync(sql, model, commandType: CommandType.Text);
            }
            else
            {
                await cnx.ExecuteAsync(sql, new { Id = id }, commandType: CommandType.Text);
            }
        }
    }
}

async Task<List<Todo>> LoadData(int id)
{
    var sql = string.Empty;

    if (id > 0)
    {
        sql = """
              SELECT Id, Description, CreatedAt FROM main.Todos
              WHERE Id = @Id
              ORDER BY CreatedAt DESC;
              """;
    }
    else
    {
        sql = "SELECT Id, Description, CreatedAt FROM main.Todos ORDER BY CreatedAt DESC;";
    }

    using (var cnx = new SqliteConnection(connectionString))
    {
        var output = await cnx.QueryAsync<Todo>(
            sql,
            new { Id = id },
            commandType: CommandType.Text);

        return output.ToList<Todo>();
    }
}
