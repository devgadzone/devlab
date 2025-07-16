using Spectre.Console;

#region Initial demo

/*
AnsiConsole.MarkupLine("[red bold]Hello World from Spectre[/]");
AnsiConsole.MarkupLine("Hello World from Spectre");
AnsiConsole.MarkupLine("[slowblink]Hello World from Spectre[/]");
*/

#endregion


#region Colors and Styles

/*
AnsiConsole.MarkupLine("[red]This is the inline markup.[/]");
AnsiConsole.MarkupLine("[red on white]This is the inline markup.[/]");
AnsiConsole.MarkupLine("[red on white bold]This is the inline markup.[/]");

Style danger = new(
    foreground: Color.White,
    background: Color.DarkOrange,
    decoration: Decoration.Bold | Decoration.Italic
);
AnsiConsole.Write("demo text ");
AnsiConsole.Write(new Markup("Danger Text from style", danger));
AnsiConsole.WriteLine(" and more..");
*/

#endregion


#region Requesting Data from the user

int age = AnsiConsole.Ask<int>("Waht is your age?");
bool isHappy = AnsiConsole.Ask<bool>("Are you happy?");
string happyText = AnsiConsole.Prompt(
    new TextPrompt<string>("Are you happy?")
        .AddChoice("yes")
        .AddChoice("no")
        .DefaultValue("yes")
);

int age2 = AnsiConsole.Prompt(
    new TextPrompt<int>("What is your age?")
        .Validate((x) => x switch
        {
            < 0 => ValidationResult.Error("You are not born yet :)"),
            > 150 => ValidationResult.Error("You are too old :)"),
            _ => ValidationResult.Success()
        })
);


AnsiConsole.MarkupLine($"Happy: {isHappy}\nAge: {age}\nHappy: {happyText}\nAge2: {age2}");

#endregion

Console.ReadLine();
AnsiConsole.Clear();
