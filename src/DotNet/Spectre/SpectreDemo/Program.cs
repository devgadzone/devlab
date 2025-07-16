using Spectre.Console;

#region Initial demo

/*
AnsiConsole.MarkupLine("[red bold]Hello World from Spectre[/]");
AnsiConsole.MarkupLine("Hello World from Spectre");
AnsiConsole.MarkupLine("[slowblink]Hello World from Spectre[/]");
*/

#endregion


#region Colors and Styles

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

#endregion

Console.ReadLine();
AnsiConsole.Clear();
