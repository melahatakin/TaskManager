using TaskManager.API.Application.DTOs;
using TaskManager.API.Application.Interfaces;
using TaskManager.API.Domain.Entities;
using TaskManager.API.Domain.Enums;
using TaskManager.API.Infrastructure.Data;

namespace TaskManager.API.Application.Services;

public class TaskService : ITaskService
{
    private readonly AppDbContext _context;

    public TaskService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<TaskItemDto>> GetAllAsync()
    {
        return _context.Tasks
            .Where(x => !x.IsDeleted)
            .Select(x => new TaskItemDto
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                Status = x.Status,
                CreatedAt = x.CreatedAt
            })
            .ToList();
    }

    public async Task CreateAsync(CreateTaskDto dto)
    {
        var task = new TaskItem
        {
            Title = dto.Title,
            Description = dto.Description,
            Status = TaskItemStatus.Todo,
            CreatedAt = DateTime.UtcNow
        };

        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateStatusAsync(int id, TaskItemStatus status)
    {
        var task = _context.Tasks.FirstOrDefault(x => x.Id == id && !x.IsDeleted);
        if (task == null) return;

        task.Status = status;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var task = _context.Tasks.FirstOrDefault(x => x.Id == id);
        if (task == null) return;

        task.IsDeleted = true;
        await _context.SaveChangesAsync();
    }

    public async Task<List<TaskItemDto>> GetPagedAsync(int page, int pageSize)
    {
        return _context.Tasks
            .Where(x => !x.IsDeleted)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(x => new TaskItemDto
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                Status = x.Status,
                CreatedAt = x.CreatedAt
            })
            .ToList();
    }
}
