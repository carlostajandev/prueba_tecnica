using Microsoft.EntityFrameworkCore;
using PruebaBackend.Infrastructure.Persistence;
using PruebaTecnica_Back_end.Domain.Entities;
using PruebaTecnica_Back_end.Domain.Ports;

namespace PruebaTecnica_Back_end.Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskManagementDB _context;

        public TaskRepository(TaskManagementDB context)
        {
            _context = context;
        }

        public async Task AddTaskAsync(TaskItem task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTaskAsync(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<TaskItem>> GetAllTasksAsync()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<TaskItem> GetTaskByIdAsync(int idTask)
        {
            return await _context.Tasks.FirstOrDefaultAsync(u => u.TaskId == idTask);
        }

        public async Task<List<TaskItem>> GetTasksByUserIdAsync(int id)
        {
            return await _context.Tasks
        .Where(t => t.TaskId == id)
        .ToListAsync();
        }

        public async Task UpdateTaskAsync(TaskItem task)
        {
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
        }
    }

}
