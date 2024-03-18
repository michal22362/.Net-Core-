using Microsoft.AspNetCore.Mvc;
using lesson1.Models;
using lesson1.Interfaces;
// using System.Collections.Generic;
// using System.Linq;

namespace lesson1.Controllers;

[ApiController]
[Route("[controller]")]

public class TasksController : ControllerBase
{

    private ITaskService taskService;

    public TasksController(ITaskService taskService)
    {
        this.taskService = taskService;
    }
    

    [HttpGet]
    public ActionResult<IEnumerable<Tasks>> Get()
    {
        return taskService.GetAll();
    }

    [HttpGet("{id}")]
    public ActionResult<Tasks> Get(int id)
    {
        var task = taskService.Get(id);
        if (task == null)
            return NotFound();
        return Ok(task);
    }

    [HttpPost]
    public IActionResult Post(Tasks newTask)
    {
        var newId = taskService.Post(newTask);
        return CreatedAtAction(nameof(Post), new { id = newId }, newTask);
    }

    [HttpPut("{id}")]
    public ActionResult Put(int id, Tasks newTask)
    {
        taskService.Put(id, newTask);
        return Ok();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        taskService.Delete(id);
        return Ok();
    }
}