using PruebaTecnica_Back_end.Domain.Entities;
using PruebaTecnica_Back_end.Domain.Ports;

namespace PruebaTecnica_Back_end.Application.Services
{
    public class TaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<List<TaskItem>> GetTasksAsync()
        {
            return await _taskRepository.GetAllTasksAsync();
        }

        public async Task<TaskItem> GetTaskByIdAsync(int idTask)
        {
            return await _taskRepository.GetTaskByIdAsync(idTask);
        }

        public async Task<List<TaskItem>> GetTasksByUserIdAsync(int id)
        {
            return await _taskRepository.GetTasksByUserIdAsync(id);
        }

        public async Task AddTaskAsync(TaskItem task)
        {
            await _taskRepository.AddTaskAsync(task);
        }

        public async Task UpdateTaskAsync(int idTask, TaskItem task)
        {
            await _taskRepository.UpdateTaskAsync(task);
        }

        public async Task DeleteTaskAsync(int idTask)
        {
            await _taskRepository.DeleteTaskAsync(idTask);
        }

        public async Task AssignTaskToUser(int idTask, int id)
        {
            var task = await _taskRepository.GetTaskByIdAsync(idTask);
            if (task != null)
            {
                task.AssignedTo = id;
                await _taskRepository.UpdateTaskAsync(task);
            }
        }

        public async Task ChangeTaskStatus(int idTask, string newStatus)
        {
            var task = await _taskRepository.GetTaskByIdAsync(idTask);
            if (task != null)
            {
                task.Status = newStatus;
                await _taskRepository.UpdateTaskAsync(task);
            }
        }

        public async Task UpdateTaskStatusAsync(int taskId, string status)
        {
            var task = await _taskRepository.GetTaskByIdAsync(taskId);
            if (task == null)
            {
                throw new Exception("Task not found");
            }

            task.Status = status;
            await _taskRepository.UpdateTaskAsync(task);
        }

    }
}
