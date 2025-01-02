
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

    [HttpPost]
    public IActionResult Create(DailyTask task)
    {            
        taskService.Add(task);
        return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, DailyTask task)
    {
        if (id != task.Id)
            return BadRequest();
            
        var existingPizza = taskService.Find(id);
        if(existingPizza is null)
            return NotFound();
    
        taskService.Update(task);           
    
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var pizza = taskService.Find(id);
    
        if (pizza is null)
            return NotFound();
        
        taskService.Delete(id);
    
        return NoContent();
    }
}