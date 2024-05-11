using TodoAPI.Model;

namespace TodoAPI.Repository.Interface
{
    public interface ITaskRepository
    {
        Task<UserTask> CreateTaskAsync(UserTask task);
        Task<List<UserTask>> GetAllTasksAsync();
        Task<UserTask?> DeleteTaskAsync(Guid id);
    }
}
