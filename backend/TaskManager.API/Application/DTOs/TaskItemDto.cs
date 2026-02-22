using TaskManager.API.Domain.Enums;

namespace TaskManager.API.Application.DTOs;

public class TaskItemDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public TaskItemStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
}
