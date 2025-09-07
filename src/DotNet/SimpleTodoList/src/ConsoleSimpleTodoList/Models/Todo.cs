namespace ConsoleSimpleTodoList.Models;

public class Todo
{
    public int Id { get; set; }
    public required string Description { get; set; }
    public required DateTime CreatedAt { get; set; }
}
