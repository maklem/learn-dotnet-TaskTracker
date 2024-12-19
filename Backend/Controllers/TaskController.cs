
using Microsoft.AspNetCore.Mvc;

using TaskTracker.Services;
using TaskTracker.Models;

namespace TaskTracker.Controllers;

[ApiController]
[Route("[controller]")]
public class TaskController : Controller
{
    private readonly ITaskService taskService;
    public TaskController(ITaskService taskService)
    {
        this.taskService = taskService;
    }

    [HttpGet]
    public ActionResult<List<DailyTask>> GetAllTasks()
    {
        return taskService.GetAllTasks();
    }

    [HttpGet("{id}")]
    public ActionResult<DailyTask> GetTask(int id)
    {
        var task = taskService.Find(id);

        if (task == null)
        {
            return NotFound();
        }
        return task;
    }
}