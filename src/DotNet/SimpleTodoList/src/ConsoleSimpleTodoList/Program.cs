using static System.Console;

WriteLine("Hello!\n");

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
    WriteLine("Enter the TODO unique description:");
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
