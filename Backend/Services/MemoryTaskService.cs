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
            Name = "Hello World",
            To_be_done_at = DateTime.Now.TimeOfDay
        };

        this.Add(demotask);
    }
    public List<DailyTask> GetAllTasks()
    {
        return tasks;
    }

    public void Add(DailyTask task)
    {
        task.Id = highest_task_id++;
        tasks.Add(task);
    }

    public DailyTask? Find(int id)
    {
        return tasks.FirstOrDefault(t => t.Id == id);
    }

    public void Update(DailyTask task)
    {
        var index = tasks.FindIndex(t => t.Id == task.Id);
        if(index == -1)
            return;

        tasks[index] = task;
    }

    public void Delete(int id)
    {
        var task = tasks.FirstOrDefault(t => t.Id == id);
        if(task is null)
            return;

        tasks.Remove(task);
    }
}