using Microsoft.AspNetCore.Mvc;
using TaskManager.API.Application.DTOs;
using TaskManager.API.Application.Interfaces;
using TaskManager.API.Domain.Enums;

namespace TaskManager.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly ITaskService _taskService;

    public TasksController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _taskService.GetAllAsync());

    [HttpPost]
    public async Task<IActionResult> Create(CreateTaskDto dto)
    {
        await _taskService.CreateAsync(dto);
        return Ok();
    }

    [HttpPut("{id}/status")]
    public async Task<IActionResult> UpdateStatus(int id, [FromQuery] TaskItemStatus status)
    {
        await _taskService.UpdateStatusAsync(id, status);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _taskService.DeleteAsync(id);
        return Ok();
    }

    [HttpGet("paged")]
    public async Task<IActionResult> GetPaged(int page = 1, int pageSize = 10)
        => Ok(await _taskService.GetPagedAsync(page, pageSize));
}
