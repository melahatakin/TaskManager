using TaskManager.API.Domain.Enums;

namespace TaskManager.API.Domain.Entities;

public class TaskItem
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public TaskItemStatus Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public bool IsDeleted { get; set; } = false;
}
