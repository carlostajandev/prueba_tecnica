using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica_Back_end.Application.Services;
using PruebaTecnica_Back_end.Domain.Entities;

namespace PruebaBackend.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/task")]
    public class TasksController : ControllerBase
    {
        private readonly TaskService _taskService;

        public TasksController(TaskService taskService)
        {
            _taskService = taskService;
        }
   
        [HttpGet("list")]
        [Authorize(Roles = Roles.Admin + "," + Roles.Supervisor)]
        public async Task<IActionResult> GetAllTasks()
        {
            var tasks = await _taskService.GetTasksAsync();
            return Ok(tasks);
        }

        [HttpPost("create")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> CreateTask([FromBody] TaskItem task)
        {
            await _taskService.AddTaskAsync(task);
            return Ok(task);
        }

        [HttpDelete("delete/{id}")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> DeleteTask(int id)
        {
            await _taskService.DeleteTaskAsync(id);
            return NoContent();
        }

        [HttpPut("edit/{id}")]
        [Authorize(Roles = Roles.Admin + "," + Roles.Supervisor)]
        public async Task<IActionResult> UpdateTask(int id, [FromBody] TaskItem task)
        {
            var existingTask = await _taskService.GetTaskByIdAsync(id);
            if (existingTask == null)
            {
                return NotFound();
            }

            existingTask.Title = task.Title;
            existingTask.Description = task.Description;
            existingTask.Status = task.Status;

            await _taskService.UpdateTaskAsync(id, existingTask);
            return Ok(existingTask);

        }

        [HttpPut("status/{id}")]
        [Authorize(Roles = Roles.Employee + "," + Roles.Supervisor)]
        public async Task<IActionResult> UpdateTaskStatus(int taskId, [FromBody] string status)
        {
            try
            {

                await _taskService.UpdateTaskStatusAsync(taskId, status);
                return Ok(new { message = "Task status updated successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("task/{id}")]
        [Authorize(Roles = Roles.Employee + "," + Roles.Supervisor)]
        public async Task<IActionResult> GetTasksById(int id)
        {
            var tasks = await _taskService.GetTaskByIdAsync(id);
            if (tasks == null)
            {
                return NotFound(new { message = "No tasks found for this employee." });
            }
            return Ok(tasks);

        }
    }
}
