using TMS.Api.Models;
using TMS.Api.Repositories;

namespace TMS.Api.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repository;

        public TaskService(ITaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TaskItem>> GetAllTasksAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<TaskItem?> GetTaskByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<TaskItem> CreateTaskAsync(TaskItem task)
        {
            task.CreatedAt = DateTime.UtcNow;
            return await _repository.AddAsync(task);
        }

        public async Task<TaskItem?> UpdateTaskAsync(int id, TaskItem task)
        {
            var existingTask = await _repository.GetByIdAsync(id);
            if (existingTask == null) return null;

            existingTask.Title = task.Title;
            existingTask.Description = task.Description;
            existingTask.IsCompleted = task.IsCompleted;

            await _repository.UpdateAsync(existingTask);
            return existingTask;
        }

        public async Task<bool> DeleteTaskAsync(int id)
        {
            var existingTask = await _repository.GetByIdAsync(id);
            if (existingTask == null) return false;

            await _repository.DeleteAsync(id);
            return true;
        }
    }
}
