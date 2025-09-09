/*
 * SZKIC PROGRAMU
 * TODO: REFACTOWANIE
 */

using ConsoleSimpleTodoList.Services;

var builder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true)
    .AddUserSecrets<Program>();

IConfiguration configuration = builder.Build();

using IHost host = CreateHostBuilder(args).Build();
using var scope = host.Services.CreateScope();
var serviceProvider = scope.ServiceProvider;

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

        var todoService = serviceProvider.GetService<ITodoService<Todo, int>>();

        if (todoService is not null)
        {
            var result = await todoService.AddAsync(todo);
            WriteLine($"\nAdded items: {result}");
            Write("\nPress any key to continue...");
            ReadKey();
        }
    }
}

async Task Read()
{
    Clear();
    WriteLine("Read all todos\n");

    var todoService = serviceProvider.GetService<ITodoService<Todo, int>>();

    if (todoService == null)
    {
        WriteLine("No valid Service.\n");
    }
    else
    {
        var todos = (await todoService.GetAllAsync()).ToList();

        foreach (var todo in todos)
        {
            WriteLine($"""
                       Id: {todo.Id} - {todo.Description}
                            Created at: {todo.CreatedAt.ToShortDateString()}
                            Is done: {todo.IsDone}
                            Updated at: {(todo.UpdatedAt == null ? "Not updated yet." : todo.UpdatedAt?.ToShortDateString())}
                       -----------------------------------------------------
                       """);
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
                Todo todo = new Todo()
                {
                    Id = id, Description = userInput,
                    UpdatedAt = DateTime.Now
                };

                var todoService = serviceProvider.GetService<ITodoService<Todo, int>>();

                if (todoService is not null)
                {
                    var restul = await todoService.UpdateAsync(todo);
                    WriteLine($"Updated items: {restul}");
                    Write("\nPress any key to continue...");
                    ReadKey();
                }
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
            var todoService = serviceProvider.GetService<ITodoService<Todo, int>>();

            if (todoService is not null)
            {
                var output = await todoService.DeleteAsync(id);
                WriteLine($"\nDelete items: {output}");
                Write("\nPress any key to continue...");
                ReadKey();
            }
        }
    } while (isIdValid == false);
}

async Task InitialDB()
{
    var sql = """
              CREATE TABLE IF NOT EXISTS main.Todos (
                  Id INTEGER NOT NULL,
                  Description TEXT NOT NULL,    
                  IsDone INTEGER NOT NULL DEFAULT 0,
                  CreatedAt TEXT NOT NULL DEFAULT (datetime('now')),
                  UpdatedAt TEXT,
                  
                  PRIMARY KEY (Id AUTOINCREMENT)
              );
              """;

    using (var cnx = new SqliteConnection(configuration.GetConnectionString("SQLite")))
    {
        await cnx.ExecuteAsync(sql);
    }
}

IHostBuilder CreateHostBuilder(string[] args)
{
    return Host.CreateDefaultBuilder(args)
        .ConfigureLogging((context, logging) =>
        {
            logging.ClearProviders();
            logging.AddConsole();
            logging.AddDebug();
            logging.AddConfiguration(context.Configuration.GetSection("Logging"));
        })
        .ConfigureServices((_, services) =>
        {
            services.AddSingleton<IConfiguration>(configuration);
            services.AddSingleton<ISqlDataAccess<int>, SqlDataAccess<int>>();
            services.AddSingleton<ITodoRepository<Todo, int>, TodoRepository<Todo, int>>();
            services.AddSingleton<ITodoService<Todo, int>, TodoService<Todo, int>>();
        });
}
