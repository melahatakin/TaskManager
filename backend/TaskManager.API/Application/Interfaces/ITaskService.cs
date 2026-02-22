using TaskManager.API.Application.DTOs;
using TaskManager.API.Domain.Enums;

namespace TaskManager.API.Application.Interfaces;

public interface ITaskService
{
    Task<List<TaskItemDto>> GetAllAsync();
    Task CreateAsync(CreateTaskDto dto);
    Task UpdateStatusAsync(int id, TaskItemStatus status);
    Task DeleteAsync(int id);
    Task<List<TaskItemDto>> GetPagedAsync(int page, int pageSize);
}
