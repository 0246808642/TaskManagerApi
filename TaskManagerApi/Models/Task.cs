

using TaskManagerApi.Models.Enums;


namespace TaskManagerApi.Models;

public class Task 
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string? Descripption { get; set; }
    public DateTime DeadLine { get; set; }
    public  TaskStatusOn Status { get; set; }
    public Priority Priority { get; set; }
    public int? CategoryId { get; set; }
    public virtual Category? Category { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime CompletedAt { get; set; }
}
