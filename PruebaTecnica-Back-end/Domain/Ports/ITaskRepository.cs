using PruebaTecnica_Back_end.Domain.Entities;

namespace PruebaTecnica_Back_end.Domain.Ports
{
    public interface ITaskRepository
    {
        Task<List<TaskItem>> GetAllTasksAsync();
        Task<TaskItem> GetTaskByIdAsync(int idTask);
        Task<List<TaskItem>> GetTasksByUserIdAsync(int idTask);
        Task AddTaskAsync(TaskItem task);
        Task UpdateTaskAsync(TaskItem task);
        Task DeleteTaskAsync(int idTask);

    }
}
