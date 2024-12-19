using TaskTracker.Models;

namespace TaskTracker.Services;

public class MemoryTaskService : ITaskService
{

    List<DailyTask> tasks = new List<DailyTask>();
    int highest_task_id = 0;

    public MemoryTaskService()
    {
        var demotask = new DailyTask
        {
            name = "Hello World",
            to_be_done_at = DateTime.Now.TimeOfDay
        };

        this.Add(demotask);
    }
    public List<DailyTask> GetAllTasks()
    {
        return tasks;
    }

    public void Add(DailyTask task)
    {
        task.id = highest_task_id++;
        tasks.Add(task);
    }

    public DailyTask? Find(int id)
    {
        return tasks.FirstOrDefault(t => t.id == id);
    }
}