using TaskTracker.Models;

namespace TaskTracker.Services;

public interface ITaskService
{
    public List<DailyTask> GetAllTasks();

    public void Add(DailyTask task);
    public DailyTask? Find(int id);
    public void Update(DailyTask task);
    public void Delete(int id);
}