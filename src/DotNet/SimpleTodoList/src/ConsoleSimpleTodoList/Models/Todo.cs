namespace ConsoleSimpleTodoList.Models;

public class Todo
{
    public int Id { get; set; }
    public required string Description { get; set; }
    public bool IsDone { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
