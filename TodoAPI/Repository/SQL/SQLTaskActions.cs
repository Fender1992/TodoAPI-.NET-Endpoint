using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using TodoAPI.Data;
using TodoAPI.Model;
using TodoAPI.Repository.Interface;

namespace TodoAPI.Repository.SQL
{
    public class SQLTaskActions : ITaskRepository
    {
        private readonly TaskDbContext _taskDbContext;

        public SQLTaskActions(TaskDbContext taskDbContext)
        {
            _taskDbContext = taskDbContext;
        }
        public async Task<UserTask> CreateTaskAsync(UserTask task)
        {
            var newTask = _taskDbContext.Tasks.Add(task).Entity;
            await _taskDbContext.SaveChangesAsync();
            return newTask;
        }

        public async Task<UserTask?> DeleteTaskAsync(Guid id)
        {
            var taskToDelete = await _taskDbContext.Tasks.FirstOrDefaultAsync(x => x.Id == id);

            if(taskToDelete == null)
            {
                return null;
            }
            _taskDbContext.Tasks.Remove(taskToDelete);
            await _taskDbContext.SaveChangesAsync();
            return taskToDelete;

        }

        public async Task<List<UserTask>> GetAllTasksAsync()
        {
            return await _taskDbContext.Tasks.ToListAsync();
        }
    }
}
